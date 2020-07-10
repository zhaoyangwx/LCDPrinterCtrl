Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

Public Class FormGUI
    Public Display As Display
    Public Machine As Machine
    Public ToolPath As ToolPath
    Private PrintingTask As PrintingTask
    Public PMsg As Boolean = False
    Public PMsgBuffer As String
    Public ScreenList() As Screen
    Private FrameID As Integer = -1
    Private LoadComplete As Boolean = False
    Private ProgVal As Integer = 0
    Private ETETime As Date
    Private GScr As Graphics
    Private TPG As ToolPathGenerator
    Private BCF As BatchCopy
    Private ISFrm As OnionSlicer
    Private TP As TestPatternGenerator
    Private SliFrm As SlicerFrm
    Friend Shared Platform As Object
    Friend Shared RunningPlatform As Object
    Public Event PictureBoxFramePreviewImageChanged(ByRef Img As Bitmap)
    Public Sub New()
        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        AddHandler My.Application.Shutdown,
                    Sub()
                        My.Settings.Save()
                    End Sub

        If Screen.PrimaryScreen.Bounds.Width < Me.Width Then
            Me.Width = Screen.PrimaryScreen.Bounds.Width - 10
            Me.Left = 0
        End If
        Display = New Display
        AddHandler Display.FormStatusChanged,
            Sub(b As Boolean)
                Invoke(
                Sub()
                    ToolStripStatusLabelDisplay.Text = "屏幕 "
                    If b Then
                        ToolStripStatusLabelDisplay.Text &= "开"
                        ButtonDisplayShow.Text = "关闭"
                        ToolStripStatusLabelDisplay.ForeColor = Color.Green
                    Else
                        ToolStripStatusLabelDisplay.Text &= "关"
                        ButtonDisplayShow.Text = "打开"
                        ToolStripStatusLabelDisplay.ForeColor = Color.Red
                    End If
                    CheckCanPrint()
                End Sub)
            End Sub
        Display.LastRefreshTime = Now
        AddHandler Display.ContentChanged,
            Sub(img As Bitmap, b As Boolean)
                Invoke(
                    Sub()
                        If (Now - Display.LastRefreshTime).TotalMilliseconds < 500 Then Exit Sub
                        If False Then
                            Dim bmp As Bitmap = New Bitmap(Display.DisplayRegion.Width, Display.DisplayRegion.Height, Imaging.PixelFormat.Format24bppRgb)
                            Dim g As Graphics = Graphics.FromImage(bmp)
                            g.CopyFromScreen(Display.DisplayRegion.Location, New Point(), Display.DisplayRegion.Size)
                            PictureBoxPreviewPrinting.Image = bmp
                        Else
                            PictureBoxPreviewPrinting.Image = img
                        End If
                        If Not b Then Display.LastRefreshTime = Now
                    End Sub)
            End Sub

        Machine = New Machine
        AddHandler Machine.ConnectionChanged,
            Sub(b As Boolean)
                Invoke(
                Sub()
                    If b Then
                        ButtonSPConnect.Text = "断开"
                        ToolStripStatusLabelPortStatus.Text = "已连接 - " & Machine.SPort1.BaudRate & "@" & Machine.SPort1.PortName
                        ToolStripStatusLabelPortStatus.ForeColor = Color.Green
                        ButtonSPSend.Enabled = True
                        GroupBoxMechanicControl.Enabled = True
                    Else
                        ToolStripStatusLabelPortStatus.Text = "未连接"
                        ToolStripStatusLabelPortStatus.ForeColor = Color.Red
                        ButtonSPSend.Enabled = GroupBoxMechanicControl.Enabled = True
                        GroupBoxMechanicControl.Enabled = False

                        ButtonSPConnect.Text = "连接"
                    End If
                    CheckCanPrint()
                End Sub)
            End Sub
        AddHandler Machine.ErrorMsgThrow,
            Sub(s As String)
                PrintMsg(My.Settings.Lining & s)
            End Sub
        AddHandler Machine.DataReceived,
            Sub(ByVal s As String)
                PrintMsg(s)
            End Sub
        AddHandler Machine.StatusChanged,
            Sub(s As String)
                Dim th As New Threading.Thread(
                Sub()
                    Dim t() As String = s.Split({My.Settings.Lining}, StringSplitOptions.RemoveEmptyEntries)
                    For i As Integer = 0 To t.Length - 1
                        t(i) = t(i).Replace(" ", "")
                        If t(i)(0) = "%" Then Continue For
                        For j As Integer = 0 To t(i).Length - 1
                            If Not IsAlphabet(t(i)(0)) Then
                                If t(i).Length >= 2 Then
                                    If t(i)(0) = "$" Then
                                        Try
                                            Machine.SetStatus(t(i).Take(2), 0)
                                        Catch ex As Exception
                                        End Try
                                    End If
                                End If
                                Continue For
                            End If
                            Dim k As Integer
                            For k = j + 1 To t(i).Length - 1
                                If Not IsNumChar(t(i)(k)) Then
                                    k -= 1
                                    Exit For
                                End If
                            Next
                            If k > t(i).Length - 1 Then k = t(i).Length - 1
                            Dim vals As String = Mid(t(i), j + 2, k - j)
                            If vals = "" Then Continue For
                            Dim value As Double = Val(vals)
                            Machine.SetStatus(t(i)(j).ToString.ToUpper, value)
                        Next
                    Next
                End Sub)
                th.Start()
            End Sub
        NewToolPath()
        LoadSettings()
        LoadComplete = True
        ButtonSPScan_Click(Nothing, Nothing)
        ButtonDisplayScan_Click(Nothing, Nothing)
    End Sub
    'Public Overloads Sub Finalize()

    'End Sub
    Private Sub FormGUI_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
    Public Sub LoadSettings()
        My.Settings.Lining = My.Settings.Lining.Replace(" ", "")
        My.Settings.Lining = My.Settings.Lining.Replace(vbTab, "")
        If My.Settings.Lining = "" Then My.Settings.Lining = vbCrLf
        My.Settings.Save()
        ComboBoxSPBaudrate.Text = My.Settings.Machine_Baudrate
        TextBoxTerminalInput.Text = My.Settings.TerminalInput
        CheckBoxLf.Checked = (My.Settings.Lining = vbLf)
        TextBoxFastLayerThickness.Text = My.Settings.TP_LayerThickness
        TextBoxFastLayerTime.Text = My.Settings.TP_FastLayerTime
        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CurrentDirectory & "\logo.png") Then
            PictureBoxLogo.Image = Image.FromFile(My.Computer.FileSystem.CurrentDirectory & "\logo.png")
            PictureBoxLogo.Refresh()
        End If
    End Sub
    Public Sub PrintMsg(ByRef s As String)
        s = s.Replace(vbCrLf, My.Settings.Lining)
        PrintMsgEx(Threading.Interlocked.Exchange(s, ""))
    End Sub
    Private Sub PrintMsgEx(ByRef s1 As String)
        Dim s As String = s1
        Me.Invoke(Sub()
                      SyncLock TextBoxOutput.Text
                          TextBoxOutput.Text &= s
                          TextBoxOutput.Select(TextBoxOutput.TextLength, 0)
                          TextBoxOutput.ScrollToCaret()
                      End SyncLock
                  End Sub)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim img As New Bitmap(1920, 1080, Imaging.PixelFormat.Format24bppRgb)
        Dim g As Imaging.BitmapData = img.LockBits(New Rectangle(New Point, img.Size), Imaging.ImageLockMode.ReadWrite, Imaging.PixelFormat.Format24bppRgb)
        Dim b(g.Stride * img.Height - 1) As Byte
        For i As Integer = 0 To b.Length - 1
            b(i) = 127
        Next
        Marshal.Copy(b, 0, g.Scan0, b.Length)
        img.UnlockBits(g)
        Dim t As New Threading.Thread(
            Sub()
                Dim d As New Display
                d.ChangeRegion(New Rectangle(0, 0, 1920, 1080))
                d.CreateForm()
                Threading.Thread.Sleep(500)
                d.ShowImage(img)
                Threading.Thread.Sleep(500)
                d.ImageOff()
                Threading.Thread.Sleep(500)
                d.Close()
            End Sub)
        t.Start()
    End Sub

    Private Sub ButtonSPScan_Click(sender As Object, e As EventArgs) Handles ButtonSPScan.Click
        Dim s() As String = {}
        s = IO.Ports.SerialPort.GetPortNames
        ComboBoxSPort.Items.Clear()
        If s Is Nothing Then Exit Sub
        If s.Length = 0 Then Exit Sub
        For Each t As String In s
            ComboBoxSPort.Items.Add(t)
        Next
        If ComboBoxSPort.Text = "" Then ComboBoxSPort.SelectedItem = ComboBoxSPort.Items.Item(ComboBoxSPort.Items.Count - 1)
    End Sub

    Public Function IsNumChar(ByVal c As Char) As Boolean
        If Asc(c) >= Asc("0") And Asc(c) <= Asc("9") Then
            Return True
        ElseIf c = "." Or c = "-" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function IsAlphabet(ByVal c As Char) As Boolean
        c = c.ToString.ToLower.ToCharArray()(0)
        If Asc(c) >= Asc("a") And Asc(c) <= Asc("z") Then Return True Else Return False

    End Function
    Public Sub NewToolPath()
        ToolPath = New ToolPath
        AddHandler ToolPath.FrameCountChanged,
            Sub()
                If LoadComplete Then
                    Invoke(Sub()
                               If ToolPath.FrameCount > 0 Then
                                   ButtonRemoveFrame.Enabled = True

                               Else
                                   ButtonRemoveFrame.Enabled = False
                                   ButtonStartPrinting.Enabled = False
                               End If
                               NumericUpDownPrintingProgress.Maximum = Math.Max(0, ToolPath.FrameCount - 1)
                           End Sub)
                End If
            End Sub
        AddHandler ToolPath.ImageCountChanged,
            Sub()
                If LoadComplete Then
                    Invoke(Sub()
                               NumericUpDownIID.Maximum = ToolPath.ImageCount - 1
                               If ToolPath.ImageCount > 0 Then ButtonDeleteImage.Enabled = True Else ButtonDeleteImage.Enabled = False
                           End Sub)
                End If
            End Sub
    End Sub

    Public Sub CheckCanPrint(Optional ByVal Force As Boolean = False)
        If Force Then
            ButtonStartPrinting.Enabled = True
            Exit Sub
        End If
        Dim cpr As Boolean = True
        If ToolPath.FrameCount <= 0 Then cpr = False
        If ToolStripStatusLabelPortStatus.Text = "未连接" Then cpr = False
        If ToolStripStatusLabelDisplay.Text = "屏幕关" Then cpr = False
        ButtonStartPrinting.Enabled = cpr
    End Sub
    Private Sub ButtonSPConnect_Click(sender As Object, e As EventArgs) Handles ButtonSPConnect.Click
        If ButtonSPConnect.Text = "连接" Then
            Machine.PortName = ComboBoxSPort.Text
            Machine.BaudRate = Math.Max(9600, Val(ComboBoxSPBaudrate.Text))
            ComboBoxSPBaudrate.Text = Machine.BaudRate
            Machine.Connect()
        Else
            Machine.DisConnect()
        End If
    End Sub

    Private Sub ButtonSPSend_Click(sender As Object, e As EventArgs) Handles ButtonSPSend.Click
        Machine.SendData(TextBoxTerminalInput.Text)
        If CheckBoxClearInput.Checked Then TextBoxTerminalInput.Text = ""
    End Sub

    Private Sub FormGUI_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If PrintingTask IsNot Nothing Then
            If PrintingTask.IsPrinting Then
                'Dim flag As Boolean = True
                'AddHandler PrintingTask.PrintingAborted, Sub() flag = False
                'AddHandler PrintingTask.PrintingFinished, Sub() flag = False
                PrintingTask.StopPrinting()
                Dim thE As New Threading.Thread(
                    Sub()
                        While PrintingTask.IsPrinting
                        End While
                        e.Cancel = False
                        End
                    End Sub)
                thE.Start()
                e.Cancel = True
                Exit Sub
            End If
        End If
        Machine.Dispose()
        Display.Close()
        My.Settings.TerminalInput = TextBoxTerminalInput.Text
        My.Settings.Machine_Baudrate = Val(ComboBoxSPBaudrate.Text)
        My.Settings.Save()
    End Sub



    Private Sub ButtonDisplaySettingSave_Click(sender As Object, e As EventArgs) Handles ButtonDisplaySettingSave.Click
        Display.ChangeRegion(New Rectangle(NumericUpDownL.Value, NumericUpDownT.Value, NumericUpDownW.Value, NumericUpDownH.Value))
    End Sub

    Private Sub ButtonDisplayShow_Click(sender As Object, e As EventArgs) Handles ButtonDisplayShow.Click
        If Display.IsOpened Then
            Display.Close()
        Else
            ButtonDisplaySettingSave_Click(sender, e)
            Display.CreateForm()
        End If
    End Sub

    Private Sub TimerSPRefresh_Tick(sender As Object, e As EventArgs) Handles TimerSPRefresh.Tick

        If Machine IsNot Nothing Then
            Machine.GetStatus()
            LabelMachineStatus.Text = "状态:" & My.Settings.Lining & Machine.StatusString
        End If
        ProgressBar1.Value = Math.Min(10000, Math.Max(0, ProgVal))
        ToolStripProgressBarP.Value = Math.Min(10000, Math.Max(0, ProgVal))
        ToolStripStatusLabelProgress.Text = ProgVal / 100 & "%"

        If PrintingTask IsNot Nothing Then
            If PrintingTask.Paused Then
                If PrintingTask.IsPrinting Then ToolStripStatusLabelPrintingTask.Text = "已暂停"
            Else
                If PrintingTask.IsPrinting Then ToolStripStatusLabelPrintingTask.Text = "正在打印 " & ProgVal / 100 & "%"
            End If
        End If

        ButtonFastStartStop.Text = ButtonStartPrinting.Text
        ButtonFastPause.Text = ButtonPause.Text
    End Sub

    Private Sub ButtonDisplayScan_Click(sender As Object, e As EventArgs) Handles ButtonDisplayScan.Click
        ScreenList = Screen.AllScreens
        ComboBoxDisplayList.Items.Clear()
        For i As Integer = 0 To ScreenList.Length - 1
            ComboBoxDisplayList.Items.Add(ScreenList(i).DeviceName)
        Next
        ComboBoxDisplayList.SelectedItem = ComboBoxDisplayList.Items.Item(ComboBoxDisplayList.Items.Count - 1)
    End Sub

    Private Sub ComboBoxDisplayList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxDisplayList.SelectedIndexChanged
        If Not LoadComplete Then Exit Sub
        Dim r As Rectangle = ScreenList(ComboBoxDisplayList.SelectedIndex).Bounds
        NumericUpDownL.Value = r.Left
        NumericUpDownT.Value = r.Top
        NumericUpDownW.Value = r.Width
        NumericUpDownH.Value = r.Height
    End Sub
    Public Sub LoadCurrentFrame(ByVal FID As Integer)
        If Not LoadComplete Then Exit Sub
        If FID < 0 Or FID >= ToolPath.FrameCount Then Exit Sub
        TextBoxCodeBefore.Text = ToolPath.CodeBefore(FID)
        TextBoxCodeAfter.Text = ToolPath.CodeAfter(FID)
        NumericUpDownLayerTime.Value = ToolPath.ExposureTime(FID)
        NumericUpDownIID.Value = ToolPath.ImageID(FID)
        If ToolPath.FrameCount = 0 Then Exit Sub
        LoadCurrentImage(NumericUpDownIID.Value)
        Static c As Integer
        c += 1
        If c >= 20 Then
            GC.Collect()
            c = 0
        End If
    End Sub
    Public Sub LoadCurrentImage(ByVal IID As Integer)
        If IID < 0 Or IID >= ToolPath.ImageCount Then Exit Sub
        NumericUpDownIID.Value = IID
        ListBoxImgLib.SelectedIndex = IID
        If ToolPath.ImageCount = 0 Then Exit Sub
        PictureBoxFramePreview.Image = ToolPath.ImageLib(ListBoxImgLib.SelectedIndex).Clone(New Rectangle(New Point, ToolPath.ImageLib(ListBoxImgLib.SelectedIndex).Size), PixelFormat.Format24bppRgb)
        RaiseEvent PictureBoxFramePreviewImageChanged(ToolPath.ImageLib(ListBoxImgLib.SelectedIndex))
    End Sub
    Private Sub ButtonAddFrame_Click(sender As Object, e As EventArgs) Handles ButtonAddFrame.Click
        ToolPath.AddFrame()
        ListBoxFrame.Items.Add(ToolPath.FrameCount - 1)
        LoadCurrentFrame(ListBoxFrame.SelectedIndex)
    End Sub

    Private Sub ButtonInsertImage_Click(sender As Object, e As EventArgs) Handles ButtonInsertImage.Click
        Dim b As Bitmap = Clipboard.GetImage
        If b IsNot Nothing Then
            Dim index As Integer = ListBoxImgLib.SelectedIndex
            If index = -1 Then index = 0
            ToolPath.InsertImage(index, b)
            ListBoxImgLib.Items.Add(ToolPath.ImageCount - 1)
            LoadCurrentImage(index)
        End If
    End Sub

    Private Sub ImportImagePToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportImagePToolStripMenuItem.Click
        Dim ofd As New OpenFileDialog With {.Filter = "PNG文件|*.png|ALL|*.*"}
        ofd.FileName = My.Settings.Last_Import_File
        If ofd.ShowDialog = DialogResult.OK Then
            My.Settings.Last_Import_File = ofd.FileName
            My.Settings.Save()
            ToolPath.InsertImage(ListBoxImgLib.SelectedIndex, ofd.FileName)
            ListBoxImgLib.Items.Add(ToolPath.ImageCount - 1)
            LoadCurrentImage(ListBoxImgLib.SelectedIndex)
        End If
    End Sub

    Private Sub ButtonDeleteImage_Click(sender As Object, e As EventArgs) Handles ButtonDeleteImage.Click
        Dim index As Integer = ListBoxImgLib.SelectedIndex
        If index = -1 Then index = ToolPath.ImageCount - 1
        If index < 0 Then Exit Sub
        ToolPath.RemoveImage(index)
        ListBoxImgLib.Items.RemoveAt(ListBoxImgLib.Items.Count - 1)
        LoadCurrentImage(index)
    End Sub

    Private Sub ListBoxImgLib_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxImgLib.SelectedIndexChanged
        If Not LoadComplete Then Exit Sub
        If ListBoxImgLib.SelectedIndex < ToolPath.ImageCount Then
            LoadCurrentImage(ListBoxImgLib.SelectedIndex)
        End If
    End Sub

    Private Sub NumericUpDownIID_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownIID.ValueChanged
        If Not LoadComplete Then Exit Sub
        ListBoxImgLib.SelectedIndex = NumericUpDownIID.Value
        LoadCurrentImage(NumericUpDownIID.Value)
    End Sub

    Private Sub ButtonApplyFrameChange_Click(sender As Object, e As EventArgs) Handles ButtonApplyFrameChange.Click
        Dim index As Integer = FrameID
        If index = -1 Then index = 0
        If index >= ToolPath.FrameCount Then Exit Sub
        ToolPath.CodeBefore(index) = TextBoxCodeBefore.Text
        ToolPath.CodeAfter(index) = TextBoxCodeAfter.Text
        ToolPath.ExposureTime(index) = NumericUpDownLayerTime.Value
        ToolPath.ImageID(index) = NumericUpDownIID.Value

    End Sub

    Private Sub ListBoxFrame_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxFrame.SelectedIndexChanged
        If Not LoadComplete Then Exit Sub
        If CheckBoxAutoApply.Checked Then ButtonApplyFrameChange_Click(sender, e)
        FrameID = ListBoxFrame.SelectedIndex
        LoadCurrentFrame(FrameID)
    End Sub

    Private Sub ButtonAppendImage_Click(sender As Object, e As EventArgs) Handles ButtonAppendImage.Click
        Dim b As Bitmap = Clipboard.GetImage
        If b IsNot Nothing Then
            Dim index As Integer = ListBoxImgLib.SelectedIndex
            If index = -1 Then index = ToolPath.ImageCount - 1
            ToolPath.InsertImage(index + 1, b)
            ListBoxImgLib.Items.Add(ToolPath.ImageCount - 1)
            LoadCurrentImage(index + 1)
        End If
    End Sub

    Private Sub ButtonRemoveFrame_Click(sender As Object, e As EventArgs) Handles ButtonRemoveFrame.Click
        Dim Index As Integer = FrameID
        If Index = -1 Then Index = ToolPath.FrameCount - 1
        If Index < 0 Then Exit Sub
        ToolPath.RemoveFrame(Index)
        ListBoxFrame.Items.RemoveAt(ListBoxFrame.Items.Count - 1)
        LoadCurrentFrame(Index)
    End Sub

    Private Sub SaveTaskFileSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveTaskFileSToolStripMenuItem.Click
        Dim sfd1 As New SaveFileDialog With {.Filter = "Zip文件|*.zip|所有文件|*.*"}
        sfd1.FileName = My.Settings.Last_Save_File
        If sfd1.ShowDialog = DialogResult.OK Then
            My.Settings.Last_Save_File = sfd1.FileName
            My.Settings.Save()
            Dim th As Threading.Thread = New Threading.Thread(
                Sub()
                    Invoke(Sub()
                               SaveTaskFileSToolStripMenuItem.Enabled = False
                               ToolStripStatusLabelMessage.Text = "正在保存 " & sfd1.FileName
                           End Sub)
                    Dim PGR As ToolPath.ProgressReportEventHandler =
                    Sub(i As Integer, s As String)
                        Invoke(Sub()
                                   ProgVal = i
                                   ToolStripStatusLabelMessage.Text = s
                               End Sub)
                    End Sub
                    Dim PGF As ToolPath.ProgressFinishedEventHandler =
                    Sub()
                        Invoke(Sub()
                                   SaveTaskFileSToolStripMenuItem.Enabled = True
                                   RemoveHandler ToolPath.ProgressFinished, PGF
                                   RemoveHandler ToolPath.ProgressReport, PGR
                                   ToolStripStatusLabelMessage.Text = "文件已保存"
                               End Sub)
                    End Sub
                    AddHandler ToolPath.ProgressReport, PGR
                    AddHandler ToolPath.ProgressFinished, PGF
                    ToolPath.SaveToFile(sfd1.FileName)
                End Sub)
            th.Start()
        End If
    End Sub

    Private Sub OpenTaskFileOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenTaskFileOToolStripMenuItem.Click
        Dim ofd1 As New OpenFileDialog With {.Filter = "Zip文件|*.zip|所有文件|*.*"}
        ofd1.FileName = My.Settings.Last_Open_File
        If ofd1.ShowDialog = DialogResult.OK Then
            My.Settings.Last_Open_File = ofd1.FileName
            My.Settings.Save()
            Dim th As Threading.Thread = New Threading.Thread(
                Sub()
                    Invoke(Sub()
                               OpenTaskFileOToolStripMenuItem.Enabled = False
                               ToolStripStatusLabelMessage.Text = "正在加载 " & ofd1.FileName
                           End Sub)
                    Dim PGR As ToolPath.ProgressReportEventHandler =
                    Sub(i As Integer, s As String)
                        Invoke(Sub()
                                   ProgVal = i
                                   ToolStripStatusLabelMessage.Text = s
                               End Sub)
                    End Sub
                    Dim PGF As ToolPath.ProgressFinishedEventHandler =
                    Sub()
                        Invoke(Sub()
                                   OpenTaskFileOToolStripMenuItem.Enabled = True
                                   RemoveHandler ToolPath.ProgressFinished, PGF
                                   RemoveHandler ToolPath.ProgressReport, PGR
                                   ReLoad()
                                   ToolStripStatusLabelMessage.Text = "文件已加载"
                               End Sub)
                    End Sub
                    AddHandler ToolPath.ProgressReport, PGR
                    AddHandler ToolPath.ProgressFinished, PGF
                    ToolPath.LoadFromFile(ofd1.FileName)
                End Sub)
            th.Start()
        End If
    End Sub
    Public Sub ReLoad()
        LoadComplete = False
        NumericUpDownIID.Maximum = ToolPath.ImageCount - 1
        ListBoxFrame.Items.Clear()
        ListBoxImgLib.Items.Clear()
        For i As Integer = 0 To ToolPath.FrameCount - 1
            ListBoxFrame.Items.Add(i)
        Next
        For i As Integer = 0 To ToolPath.ImageCount - 1
            ListBoxImgLib.Items.Add(i)
        Next
        NumericUpDownPrintingProgress.Maximum = ToolPath.FrameCount - 1
        FrameID = ToolPath.FrameCount - 1
        LoadComplete = True
        LoadCurrentFrame(FrameID)
        CheckCanPrint()
    End Sub
    Private Sub CloseAllCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseAllCToolStripMenuItem.Click
        NewToolPath()
        ListBoxFrame.Items.Clear()
        ListBoxImgLib.Items.Clear()
        TextBoxCodeBefore.Text = ""
        TextBoxCodeAfter.Text = ""
        PictureBoxFramePreview.Image = New Bitmap(100, 100, Imaging.PixelFormat.Format24bppRgb)
        RaiseEvent PictureBoxFramePreviewImageChanged(PictureBoxFramePreview.Image)

        NumericUpDownLayerTime.Value = 0
    End Sub

    Private Sub GenerateGToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateGToolStripMenuItem.Click
        TPG = New ToolPathGenerator
        TPG.ToolPath = ToolPath
        AddHandler TPG.ProgressReport,
            Sub(i As Integer)
                ProgVal = i
            End Sub
        AddHandler TPG.ProcCompleted,
            Sub()
                Invoke(
                Sub()
                    ReLoad()
                End Sub
                )
            End Sub
        TPG.Show()
    End Sub

    Private Sub BatchCopyCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BatchCopyCToolStripMenuItem.Click
        If ToolPath.FrameCount = 0 Then
            ToolStripStatusLabelMessage.Text = "无内容可复制"
            Exit Sub
        End If
        BCF = New BatchCopy
        With BCF
            .StartPosition = FormStartPosition.Manual
            .Location = Me.Location + New Point(65, -30)
            If .Left < 0 Then .Left = 0
            If .Top < 0 Then .Top = 0
            .NumericUpDownSa.Maximum = ToolPath.FrameCount - 1
            .NumericUpDownSb.Maximum = ToolPath.FrameCount - 1
            .NumericUpDownTa.Maximum = ToolPath.FrameCount - 1
            .NumericUpDownTb.Maximum = ToolPath.FrameCount - 1
            .NumericUpDownSa.Value = Math.Min(.NumericUpDownSa.Maximum, Math.Max(0, FrameID))
            .NumericUpDownSb.Value = .NumericUpDownSa.Value
            .NumericUpDownTa.Value = Math.Min(.NumericUpDownSa.Value + 1, .NumericUpDownTa.Maximum)
            .NumericUpDownTb.Value = .NumericUpDownTb.Maximum
        End With
        AddHandler BCF.FormClosing,
            Sub()
                If BCF.DialogResult = DialogResult.OK Then
                    Dim sa As Integer = BCF.NumericUpDownSa.Value
                    Dim sb As Integer = BCF.NumericUpDownSb.Value
                    Dim ta As Integer = BCF.NumericUpDownTa.Value
                    Dim tb As Integer = BCF.NumericUpDownTb.Value
                    Dim th As Threading.Thread = New Threading.Thread(
                          Sub()
                              If sa > sb Or ta > tb Then Exit Sub
                              Dim l As Integer = 0
                              For i As Integer = ta To tb
                                  If i >= sa And i <= sb Then Continue For
                                  If BCF.CheckBox1.Checked Then ToolPath.CodeBefore(i) = ToolPath.CodeBefore(sa + l)
                                  If BCF.CheckBox3.Checked Then ToolPath.ExposureTime(i) = ToolPath.ExposureTime(sa + l)
                                  If BCF.CheckBox2.Checked Then ToolPath.CodeAfter(i) = ToolPath.CodeAfter(sa + l)
                                  If BCF.CheckBox4.Checked Then ToolPath.ImageID(i) = ToolPath.ImageID(sa + l)
                                  l += 1
                                  l = l Mod (sb - sa + 1)
                                  ProgVal = (i - ta) / (tb - ta) * 10000
                              Next
                              Invoke(Sub()
                                         ToolStripStatusLabelMessage.Text = "复制" & sa & "-" & sb & " 到 " & ta & "-" & tb
                                     End Sub)
                          End Sub)
                    th.Start()
                End If
            End Sub
        BCF.Show()
    End Sub

    Private Sub ButtonStartPrinting_Click(sender As Object, e As EventArgs) Handles ButtonStartPrinting.Click
        If CheckBoxDebugImage.Checked = False Then
            If ToolStripStatusLabelPortStatus.Text = "未连接" Then Exit Sub
            If ToolStripStatusLabelDisplay.Text = "屏幕关" Then Exit Sub
        End If
        If PrintingTask IsNot Nothing Then
            If PrintingTask.IsPrinting Then
                PrintingTask.StopPrinting()
                Exit Sub
            End If
        End If
        PrintingTask = New PrintingTask
        PrintingTask.ToolPath = ToolPath
        PrintingTask.Display = Display
        PrintingTask.Machine = Machine
        PrintingTask.ToolPath.LineNumber = NumericUpDownPrintingProgress.Value
        AddHandler PrintingTask.PringtingStarted,
            Sub()
                Me.BeginInvoke(
                Sub()
                    ButtonCalcETE.Enabled = False
                    ButtonStartPrinting.Text = "取消"
                    ToolStripStatusLabelPrintingTask.Text = "打印中"
                    ToolStripStatusLabelPrintingTask.ForeColor = Color.OrangeRed
                    PrintMsg(My.Settings.Lining & "开始时间：" & Now.ToString)
                End Sub)
            End Sub
        AddHandler PrintingTask.ProgressReport,
            Sub(i As Integer)
                Me.BeginInvoke(Sub() ProgVal = i)
            End Sub
        AddHandler PrintingTask.PrintingAborted,
            Sub()
                Me.BeginInvoke(
                Sub()
                    ButtonCalcETE.Enabled = True
                    ButtonStartPrinting.Text = "开始"
                    ButtonPause.Text = "暂停"
                    Display.ImageOff()
                    ToolStripStatusLabelPrintingTask.Text = "无任务"
                    ToolStripStatusLabelPrintingTask.ForeColor = Color.Blue
                    PrintMsg(My.Settings.Lining & "取消时间：" & Now.ToString)
                End Sub)
            End Sub
        AddHandler PrintingTask.PrintingFinished,
            Sub()
                Me.BeginInvoke(
                Sub()
                    ButtonCalcETE.Enabled = True
                    ButtonStartPrinting.Text = "开始"
                    ButtonPause.Text = "暂停"
                    Display.ImageOff()
                    ToolStripStatusLabelPrintingTask.Text = "无任务"
                    ToolStripStatusLabelPrintingTask.ForeColor = Color.Blue
                    PrintMsg(My.Settings.Lining & "结束时间：" & Now.ToString)
                End Sub)
            End Sub
        AddHandler PrintingTask.MessageReport,
            Sub(ByVal s As String)
                Me.BeginInvoke(
                Sub()
                    ToolStripStatusLabelMessage.Text = s
                End Sub)
            End Sub
        Dim ms As Integer = PrintingTask.ETETime
        ETETime = New Date(1, 1, 1, 0, 0, 0, 0).AddMilliseconds(ms)
        ToolStripStatusLabelETEFinishingTime.Text = "预计结束时间：" & Now.AddMilliseconds(ms)
        Dim t As Integer = PrintingTask.ETETime
        Label15.Text = "预计打印时间：" & t \ 3600000 & "h "
        t = t Mod 3600000
        Label15.Text &= t \ 60000 & "m "
        t = t Mod 60000
        Label15.Text &= t / 1000 & "s"
        PrintingTask.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ButtonDisplayShow_Click(sender, e)
        ButtonStartPrinting_Click(sender, e)
    End Sub

    Private Sub ButtonCalcETE_Click(sender As Object, e As EventArgs) Handles ButtonCalcETE.Click
        PrintingTask = New PrintingTask
        PrintingTask.ToolPath = ToolPath
        PrintingTask.Display = Display
        PrintingTask.Machine = Machine
        PrintingTask.ToolPath.LineNumber = NumericUpDownPrintingProgress.Value
        ETETime = New Date(1, 1, 1, 0, 0, 0, 0).AddMilliseconds(PrintingTask.ETETime)
        Dim t As Integer = PrintingTask.ETETime
        'MessageBox.Show(t)
        Label15.Text = "预计打印时间：" & t \ 3600000 & "h "
        t = t Mod 3600000
        Label15.Text &= t \ 60000 & "m "
        t = t Mod 60000
        Label15.Text &= t / 1000 & "s"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        NumericUpDownH.Value = 480
        NumericUpDownW.Value = 640
        NumericUpDownL.Value = 0
        NumericUpDownT.Value = 0
        ButtonDisplaySettingSave_Click(sender, e)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim i As Integer = Val(InputBox("插入数量", "输入", "0"))
        If i > 0 Then
            For j As Integer = 0 To i - 1
                ButtonAddFrame_Click(sender, e)
            Next
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        ToolPath.InsertFrame(FrameID, TextBoxCodeBefore.Text, NumericUpDownIID.Value, NumericUpDownLayerTime.Value, TextBoxCodeAfter.Text)
        ListBoxFrame.Items.Add(ToolPath.FrameCount - 1)
        LoadCurrentFrame(FrameID)
    End Sub

    Private Sub ImageSplitterIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImageSplitterIToolStripMenuItem.Click
        If LoadComplete Then
            ISFrm = New OnionSlicer
            AddHandler ISFrm.ProgressReport,
                Sub(i As Integer)
                    ProgVal = i
                End Sub
            AddHandler ISFrm.ProcCompleted,
                Sub()
                    Invoke(
                    Sub()
                        ReLoad()
                    End Sub
                    )
                End Sub
            ISFrm.ToolPath = ToolPath
            ISFrm.Show()
        End If
    End Sub

    Private Sub CheckBoxDebugImage_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxDebugImage.CheckedChanged
        Machine.DebugMode = CheckBoxDebugImage.Checked
        CheckCanPrint(CheckBoxDebugImage.Checked)
        ButtonSPSend.Enabled = CheckBoxDebugImage.Checked Or (ToolStripStatusLabelPortStatus.Text <> "未连接")
        GroupBoxMechanicControl.Enabled = CheckBoxDebugImage.Checked Or (ToolStripStatusLabelPortStatus.Text <> "未连接")
    End Sub


    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If Not LoadComplete Then Exit Sub
        ToolStripStatusLabelPointer.Visible = (TabControl1.SelectedIndex = 0)
        'If TabControl1.SelectedIndex = 1 Then
        '    Panel1.Parent = GroupBoxSPTerminal
        'ElseIf TabControl1.SelectedIndex = 2 Then
        '    Panel1.Parent = GroupBoxMCT
        'Else
        '    Exit Sub
        'End If
        'Panel1.Width = Panel1.Parent.Width
        'Panel1.Height = Panel1.Parent.Height - 11
    End Sub

    Private Sub TestPatternGeneratorTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestPatternGeneratorTToolStripMenuItem.Click
        TP = New TestPatternGenerator
        AddHandler TP.ProgressReport,
            Sub(i As Integer)
                ProgVal = i
            End Sub
        AddHandler TP.Finished,
            Sub()
                Invoke(Sub() ReLoad())
                TP.Invoke(Sub() MessageBox.Show("测试图案已生成！"))
            End Sub
        AddHandler TP.MessageReport,
            Sub(s As String)
                Invoke(Sub() ToolStripStatusLabelMessage.Text = s)
            End Sub
        AddHandler TP.Aborted,
            Sub()
                LoadComplete = True
            End Sub
        TP.ToolPath = ToolPath
        TP.Display = Display
        TP.NumericUpDownDisplayW.Value = Display.DisplayRegion.Width
        TP.NumericUpDownDisplayH.Value = Display.DisplayRegion.Height
        TP.Show()
        LoadComplete = False
    End Sub

    Private Sub ButtonZ10_Click(sender As Object, e As EventArgs) Handles ButtonZ10.Click
        Machine.SendData("G91" & My.Settings.Lining & "G1 Z10 F300" & My.Settings.Lining)
    End Sub
    Private Sub ButtonZ1_Click(sender As Object, e As EventArgs) Handles ButtonZ1.Click
        Machine.SendData("G91" & My.Settings.Lining & "G1 Z1 F300" & My.Settings.Lining)
    End Sub
    Private Sub ButtonZ01_Click(sender As Object, e As EventArgs) Handles ButtonZ01.Click
        Machine.SendData("G91" & My.Settings.Lining & "G1 Z0.1 F300" & My.Settings.Lining)
    End Sub
    Private Sub ButtonZ_01_Click(sender As Object, e As EventArgs) Handles ButtonZ_01.Click
        Machine.SendData("G91" & My.Settings.Lining & "G1 Z-0.1 F300" & My.Settings.Lining)
    End Sub
    Private Sub ButtonZ_1_Click(sender As Object, e As EventArgs) Handles ButtonZ_1.Click
        Machine.SendData("G91" & My.Settings.Lining & "G1 Z-1 F300" & My.Settings.Lining)
    End Sub
    Private Sub ButtonZ_10_Click(sender As Object, e As EventArgs) Handles ButtonZ_10.Click
        Machine.SendData("G91" & My.Settings.Lining & "G1 Z-10 F300" & My.Settings.Lining)
    End Sub
    Private Sub ButtonX10_Click(sender As Object, e As EventArgs) Handles ButtonX10.Click
        Machine.SendData("G91" & My.Settings.Lining & "G1 X10 F300" & My.Settings.Lining)
    End Sub
    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Machine.SendData("G91" & My.Settings.Lining & "G1 X1 F300" & My.Settings.Lining)
    End Sub
    Private Sub ButtonX01_Click(sender As Object, e As EventArgs) Handles ButtonX01.Click
        Machine.SendData("G91" & My.Settings.Lining & "G1 X0.1 F300" & My.Settings.Lining)
    End Sub
    Private Sub ButtonX_01_Click(sender As Object, e As EventArgs) Handles ButtonX_01.Click
        Machine.SendData("G91" & My.Settings.Lining & "G1 X-0.1 F300" & My.Settings.Lining)
    End Sub
    Private Sub ButtonX_1_Click(sender As Object, e As EventArgs) Handles ButtonX_1.Click
        Machine.SendData("G91" & My.Settings.Lining & "G1 X-1 F300" & My.Settings.Lining)
    End Sub
    Private Sub ButtonX_10_Click(sender As Object, e As EventArgs) Handles ButtonX_10.Click
        Machine.SendData("G91" & My.Settings.Lining & "G1 X-10 F300" & My.Settings.Lining)
    End Sub
    Private Sub ButtonY10_Click(sender As Object, e As EventArgs) Handles ButtonY10.Click
        Machine.SendData("G91" & My.Settings.Lining & "G1 Y10 F300" & My.Settings.Lining)
    End Sub
    Private Sub ButtonY1_Click(sender As Object, e As EventArgs) Handles ButtonY1.Click
        Machine.SendData("G91" & My.Settings.Lining & "G1 Y1 F300" & My.Settings.Lining)
    End Sub
    Private Sub ButtonY01_Click(sender As Object, e As EventArgs) Handles ButtonY01.Click
        Machine.SendData("G91" & My.Settings.Lining & "G1 Y0.1 F300" & My.Settings.Lining)
    End Sub
    Private Sub ButtonY_01_Click(sender As Object, e As EventArgs) Handles ButtonY_01.Click
        Machine.SendData("G91" & My.Settings.Lining & "G1 Y-0.1 F300" & My.Settings.Lining)
    End Sub
    Private Sub ButtonY_1_Click(sender As Object, e As EventArgs) Handles ButtonY_1.Click
        Machine.SendData("G91" & My.Settings.Lining & "G1 Y-1 F300" & My.Settings.Lining)
    End Sub
    Private Sub ButtonY_10_Click(sender As Object, e As EventArgs) Handles ButtonY_10.Click
        Machine.SendData("G91" & My.Settings.Lining & "G1 Y-10 F300" & My.Settings.Lining)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Dim loc As String = InputBox("", "", "")
        'Dim f() As IO.FileInfo = My.Computer.FileSystem.GetDirectoryInfo(loc).GetFiles
        'For i As Integer = 0 To f.Length - 1
        '    If f(i).FullName.EndsWith(".resources.resx.resx") Then
        '        My.Computer.FileSystem.RenameFile(f(i).FullName, f(i).Name.Replace(".resources.resx", ""))
        '    End If
        'Next

        'Dim s() As String = My.Computer.FileSystem.ReadAllText("B:\IP.txt").Split({My.Settings.Lining}, StringSplitOptions.RemoveEmptyEntries)
        'Dim o As String
        'Dim ipfront As New List(Of Integer)
        'Dim maskfront As New List(Of Integer)
        'For i As Integer = 0 To s.Length - 1
        '    Dim t() As String = s(i).Split({"/"}, StringSplitOptions.RemoveEmptyEntries)
        '    Dim t2() As String = t(0).Split({"."}, StringSplitOptions.RemoveEmptyEntries)
        '    Dim b() As Byte = {Val(t2(3)), Val(t2(2)), Val(t2(1)), Val(t2(0))}
        '    ipfront.Add(BitConverter.ToInt32(b, 0))
        '    Dim n As Integer = 32 - Val(t(1))
        '    Dim mask As Integer = 1 << n
        '    If n > 0 Then mask = mask - 1
        '    mask = Not mask
        '    maskfront.Add(mask)
        'Next
        'For i As Integer = 0 To ipfront.Count - 2
        '    For j As Integer = i + 1 To ipfront.Count - 1
        '        If ipfront(i) And maskfront(j) = ipfront(j) Then
        '            ipfront(i) = ipfront(j)
        '            maskfront(i) = maskfront(j)
        '        ElseIf ipfront(j) And maskfront(i) = ipfront(i) Then
        '            ipfront(j) = ipfront(i)
        '            maskfront(j) = maskfront(i)
        '        End If
        '    Next
        'Next

        'For i As Integer = 0 To s.Length - 1
        '    Dim ipb() As Byte = BitConverter.GetBytes(ipfront(i))
        '    Dim b() As Byte = BitConverter.GetBytes(maskfront(i))
        '    o &= "route add " & ipb(3) & "." & ipb(2) & "." & ipb(1) & "." & ipb(0) &
        '        " mask " & b(3) & "." & b(2) & "." & b(1) & "." & b(0) & " 192.168.74.254" & My.Settings.Lining
        'Next
        'Clipboard.SetText(o)

        'Parallel.For(0, 40,
        '             Sub(f As Integer)
        '                 Dim img As Bitmap = Image.FromFile("D:\Desktop\Image\" & f & ".png")
        '                 img = img.Clone(New Rectangle(New Point, New Size(1920, 1080)), PixelFormat.Format24bppRgb)
        '                 Dim imgb As New Bitmap(1920, 1080, PixelFormat.Format24bppRgb)
        '                 For j As Integer = 0 To 1079 - 100
        '                     For i As Integer = 0 To 1919 - 100
        '                         imgb.SetPixel(i + 100, j + 100, img.GetPixel(i, j))
        '                     Next
        '                 Next
        '                 imgb.Clone(New Rectangle(New Point, New Size(1920, 1080)), PixelFormat.Format1bppIndexed).Save("D:\Desktop\Image\opt\" & f & ".png")
        '             End Sub)
        Dim th As New Threading.Thread(
            Sub()
                Invoke(Sub() Button4.Enabled = False)
                Dim b(255) As Boolean
                Dim o As String = ""
                Dim ic As Integer = 0
                Parallel.For(0, 255,
                    Sub(i As Integer)
                        If (New Net.NetworkInformation.Ping).Send(New Net.IPAddress({192, 168, 0, i})).Status = Net.NetworkInformation.IPStatus.Success Then
                            b(i) = True

                        End If
                        Threading.Interlocked.Add(ic, 1)
                        Threading.Interlocked.Exchange(ProgVal, ic / 256 * 10000)
                        Invoke(Sub() ToolStripStatusLabelMessage.Text = "Ping " & ic & "/256 Addresses")
                    End Sub)
                For i As Integer = 0 To 255
                    If b(i) Then o &= "192.168.0." & i & vbCrLf
                Next
                Invoke(Sub()
                           ProgVal = 10000
                           ToolStripStatusLabelMessage.Text = "Ping Finished!"
                           MessageBox.Show(o)
                           Button4.Enabled = True
                       End Sub)
            End Sub)
        th.Start()
    End Sub

    Private Sub DObjectSlicerSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DObjectSlicerSToolStripMenuItem.Click
        SliFrm = New SlicerFrm
        SliFrm.ToolPath = ToolPath
        AddHandler SliFrm.ProgressReport,
            Sub(i As Integer)
                ProgVal = i
            End Sub
        AddHandler SliFrm.ProcCompleted,
            Sub()
                SliFrm.Invoke(Sub() MessageBox.Show("制作完成"))
                Invoke(Sub() ReLoad())
            End Sub
        AddHandler SliFrm.MessageReport,
            Sub(s As String)
                Invoke(Sub() ToolStripStatusLabelMessage.Text = s)
            End Sub
        SliFrm.Show()
    End Sub

    Private Sub ButtonPause_Click(sender As Object, e As EventArgs) Handles ButtonPause.Click
        If PrintingTask Is Nothing Then Exit Sub
        If ButtonPause.Text = "暂停" Then
            PrintingTask.Paused = True
            ButtonPause.Text = "恢复"
            ToolStripStatusLabelPrintingTask.Text = "已暂停"
            PrintMsg(My.Settings.Lining & "暂停时间：" & Now.ToString & " Z=" & Math.Round(Machine.Status.Z, 3))
        Else
            PrintingTask.Paused = False
            ButtonPause.Text = "暂停"
            If PrintingTask.IsPrinting Then
                ToolStripStatusLabelPrintingTask.Text = "正在打印"
                PrintMsg(My.Settings.Lining & "恢复时间：" & Now.ToString)
            Else
                ToolStripStatusLabelPrintingTask.Text = "无任务"
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Display.IsOpened Then
            Dim img As New Bitmap(Display.DisplayRegion.Size.Width, Display.DisplayRegion.Size.Height, Imaging.PixelFormat.Format24bppRgb)
            Dim g As Imaging.BitmapData = img.LockBits(New Rectangle(New Point, img.Size), Imaging.ImageLockMode.ReadWrite, Imaging.PixelFormat.Format24bppRgb)
            Dim b(g.Stride * img.Height - 1) As Byte
            For i As Integer = 0 To b.Length - 1
                b(i) = 255
            Next
            Marshal.Copy(b, 0, g.Scan0, b.Length)
            img.UnlockBits(g)
            Display.ShowImage(img)
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Display.IsOpened Then
            Display.ImageOff()
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim od As New OpenFileDialog With {.Filter = "PNG文件|*.png|所有文件|*.*"}
        If od.ShowDialog = DialogResult.OK Then
            TextBoxApplyMask.Text = od.FileName
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim mask As Bitmap = Image.FromFile(TextBoxApplyMask.Text)
        mask = mask.Clone(New Rectangle(New Point, mask.Size), PixelFormat.Format24bppRgb)
        Dim mc As BitmapData = mask.LockBits(New Rectangle(New Point, mask.Size), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb)
        Dim b(mc.Stride * mask.Height - 1) As Byte
        Marshal.Copy(mc.Scan0, b, 0, b.Length)
        mask.UnlockBits(mc)
        Button7.Enabled = False
        Try
            Dim th As New Threading.Thread(
                Sub()
                    Dim prog As Integer = 0
                    Parallel.For(0, ToolPath.ImageCount - 1,
                        Sub(i As Integer)
                            Dim img As Bitmap = ToolPath.ImageLib(i).Clone(New Rectangle(New Point, ToolPath.ImageLib(i).Size), PixelFormat.Format24bppRgb)
                            Dim ic As BitmapData = img.LockBits(New Rectangle(New Point, img.Size), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb)
                            Dim bi(ic.Stride * img.Height - 1) As Byte
                            Marshal.Copy(ic.Scan0, bi, 0, bi.Length)
                            For j As Integer = 0 To bi.Length - 1
                                bi(j) = bi(j) And b(j)
                            Next
                            Marshal.Copy(bi, 0, ic.Scan0, bi.Length)
                            img.UnlockBits(ic)
                            ToolPath.ImageLib(i) = img.Clone(New Rectangle(New Point, img.Size), PixelFormat.Format1bppIndexed)
                            Threading.Interlocked.Add(prog, 1)
                            ProgVal = prog / ToolPath.ImageCount * 10000
                        End Sub)
                    Invoke(Sub()
                               ReLoad()
                               Button7.Enabled = True
                           End Sub)
                End Sub)
            th.Start()
        Catch ex As Exception
            Button7.Enabled = True
        End Try
    End Sub

    Private Sub CheckBoxLf_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxLf.CheckedChanged
        If CheckBoxLf.Checked Then
            My.Settings.Lining = vbLf
        Else
            My.Settings.Lining = vbCrLf
        End If
        My.Settings.Save()
    End Sub

    Private Sub ButtonG92_Click(sender As Object, e As EventArgs) Handles ButtonG92.Click
        Machine.SendData("G92 Z0" & My.Settings.Lining)
    End Sub

    Private Sub ButtonM84_Click(sender As Object, e As EventArgs) Handles ButtonM84.Click
        Machine.SendData("M9" & My.Settings.Lining)
    End Sub

    Private Sub FormGUI_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.TP_LayerThickness = TextBoxFastLayerThickness.Text
        My.Settings.TP_FastLayerTime = TextBoxFastLayerTime.Text
        My.Settings.Save()
        End
    End Sub

    Private Sub ButtonGrblHome_Click(sender As Object, e As EventArgs) Handles ButtonGrblHome.Click
        If MessageBox.Show("请确定平台安装正确且清理干净"， "警告", MessageBoxButtons.OKCancel) = DialogResult.OK Then
            Machine.SendData("G91" & My.Settings.Lining & "$H" & My.Settings.Lining)
        End If
    End Sub

    Private Sub ButtonGrblUnlock_Click(sender As Object, e As EventArgs) Handles ButtonGrblUnlock.Click
        Machine.SendData("G91" & My.Settings.Lining & "$X" & My.Settings.Lining)
    End Sub

    Private Sub ButtonGrblSetting_Click(sender As Object, e As EventArgs) Handles ButtonGrblSetting.Click
        Machine.SendData("G91" & My.Settings.Lining & "$$" & My.Settings.Lining)
    End Sub

    Private Sub ButtonM3_Click(sender As Object, e As EventArgs) Handles ButtonM3.Click
        Machine.SendData("G91" & My.Settings.Lining & "M3 S1000" & My.Settings.Lining)
    End Sub

    Private Sub ButtonM5_Click(sender As Object, e As EventArgs) Handles ButtonM5.Click
        Machine.SendData("G91" & My.Settings.Lining & "M5" & My.Settings.Lining)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Machine.SendData("G91" & My.Settings.Lining & "M8" & My.Settings.Lining)
    End Sub

    Private Sub ButtonGHome_Click(sender As Object, e As EventArgs) Handles ButtonGHome.Click
        If MessageBox.Show("请确定平台安装正确且清理干净"， "警告", MessageBoxButtons.OKCancel) = DialogResult.OK Then
            Machine.SendData("G91" & My.Settings.Lining & "$H
G91
G0 Z-0.7 F100
G92 Z0" & My.Settings.Lining)
        End If

    End Sub

    Private Sub ButtonFastSTLFileSelect_Click(sender As Object, e As EventArgs) Handles ButtonFastSTLFileSelect.Click
        Dim od As New OpenFileDialog With {.Filter = "STL文件|*.stl|所有文件|*.*"}
        If od.ShowDialog = DialogResult.OK Then
            TextBoxFastSTLFile.Text = od.FileName
        End If
    End Sub

    Private Sub ButtonFastSTLOpen_Click(sender As Object, e As EventArgs) Handles ButtonFastSTLOpen.Click
        If My.Computer.FileSystem.FileExists(TextBoxFastSTLFile.Text) Then
            SliFrm = New SlicerFrm
            SliFrm.ToolPath = ToolPath
            SliFrm.TextBox1.Text = TextBoxFastSTLFile.Text
            SliFrm.TextBox4.Text = TextBoxFastLayerThickness.Text
            AddHandler SliFrm.ProgressReport,
                Sub(i As Integer)
                    ProgVal = i
                End Sub
            AddHandler SliFrm.ProcCompleted,
                Sub()
                    ToolPath.FrameCount = Math.Min(ToolPath.FrameCount, ToolPath.ImageCount)
                    SliFrm.Invoke(Sub() MessageBox.Show("制作完成"))
                    Invoke(Sub() ReLoad())
                End Sub
            AddHandler SliFrm.MessageReport,
                Sub(s As String)
                    Invoke(Sub() ToolStripStatusLabelMessage.Text = s)
                End Sub
            AddHandler SliFrm.DialogReturn,
                Sub()
                    SliFrm.BeginInvoke(Sub() SliFrm.Close())
                End Sub
            SliFrm.Button1_Click(sender, e)
            SliFrm.Button4_Click(sender, e)
            SliFrm.DialogResult = DialogResult.Cancel
            If SliFrm.ShowDialog() = DialogResult.OK Then
                GroupBoxFastPrintingSetting.Enabled = True
            End If
        End If

    End Sub

    Private Sub ButtonFastSlicing_Click(sender As Object, e As EventArgs) Handles ButtonFastSlicing.Click
        Dim s() As String = TextBoxFastLayerTime.Text.Split({","}, StringSplitOptions.RemoveEmptyEntries)
        If s IsNot Nothing Then
            SyncLock ToolPath
                ToolPath.FrameCount = ToolPath.ImageCount
                ReDim ToolPath.CodeBefore(ToolPath.FrameCount - 1)
                ReDim ToolPath.CodeAfter(ToolPath.FrameCount - 1)
                ReDim ToolPath.ExposureTime(ToolPath.FrameCount - 1)
                ReDim ToolPath.ImageID(ToolPath.FrameCount - 1)
                For i As Integer = 0 To Math.Min(s.Length - 1, ToolPath.FrameCount - 1)
                    ToolPath.ExposureTime(i) = Val(s(i))
                Next
                For i As Integer = s.Length To ToolPath.FrameCount - 1
                    ToolPath.ExposureTime(i) = Val(s(s.Length - 1))
                Next
                ToolPath.CodeBefore(0) = My.Settings.TPG_StartGCode & My.Settings.Lining
                For i As Integer = 0 To Math.Min(s.Length - 2, ToolPath.FrameCount - 1)
                    ToolPath.CodeBefore(i) &= My.Settings.TPG_CodeBefore1
                    ToolPath.CodeAfter(i) = My.Settings.TPG_CodeAfter1
                Next
                For i As Integer = s.Length - 1 To ToolPath.FrameCount - 1
                    ToolPath.CodeBefore(i) = My.Settings.TPG_CodeBefore2
                    ToolPath.CodeAfter(i) = My.Settings.TPG_CodeAfter2
                Next
                ToolPath.CodeAfter(ToolPath.FrameCount - 1) &= (My.Settings.Lining & My.Settings.TPG_FinalGCode)
                For i As Integer = 0 To ToolPath.FrameCount - 1
                    ToolPath.ImageID(i) = i
                    ToolPath.CodeBefore(i) = ToolPath.CodeBefore(i).Replace(My.Settings.Lining & My.Settings.Lining, My.Settings.Lining)
                    ToolPath.CodeAfter(i) = ToolPath.CodeAfter(i).Replace(My.Settings.Lining & My.Settings.Lining, My.Settings.Lining)
                Next
            End SyncLock
            ReLoad()
            GroupBoxFastCtrl.Enabled = True
        End If
    End Sub

    Private Sub ButtonFastHoming_Click(sender As Object, e As EventArgs) Handles ButtonFastHoming.Click
        If ButtonGHome.Enabled Then
            ButtonGHome_Click(sender, e)
        Else
            MessageBox.Show("设备未连接！")
        End If
    End Sub

    Private Sub ButtonFastStartStop_Click(sender As Object, e As EventArgs) Handles ButtonFastStartStop.Click
        If ButtonStartPrinting.Enabled Then
            ButtonStartPrinting_Click(sender, e)
        Else
            MessageBox.Show("设备未连接或屏幕未打开")
        End If
    End Sub

    Private Sub ButtonFastPause_Click(sender As Object, e As EventArgs) Handles ButtonFastPause.Click
        If ButtonPause.Enabled Then
            ButtonPause_Click(sender, e)
        Else

        End If

    End Sub

    Private Sub 空心化HToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 空心化HToolStripMenuItem.Click
        Dim sgf As New ShellGenFrm
        sgf.Location = Me.Location + New Point(65, -10)
        If sgf.Top < 0 Then sgf.Top = 0
        If sgf.Left < 0 Then sgf.Left = 0
        sgf.NumericUpDown2.Maximum = ToolPath.ImageCount
        sgf.NumericUpDown3.Maximum = ToolPath.ImageCount
        If sgf.ShowDialog = DialogResult.OK Then
            Dim d As Integer = sgf.NumericUpDown1.Value
            Dim StartLayer As Integer = sgf.NumericUpDown2.Value
            Dim TopLayer As Integer = sgf.NumericUpDown3.Value
            If MessageBox.Show("壁厚=" & d & " 此操作无法撤销，是否继续？", "提示", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                Dim progi As Integer = 0
                Dim th As New Threading.Thread(
                Sub()
                    Dim TopMask(ToolPath.ImageCount - 1, ToolPath.ImageLib(0).Width - 1, ToolPath.ImageLib(0).Height - 1) As Boolean
                    Dim TopDetected(ToolPath.ImageLib(0).Width - 1, ToolPath.ImageLib(0).Height - 1) As Boolean
                    For f As Integer = ToolPath.ImageCount - 1 To 0 Step -1
                        Dim imgsrc As Bitmap = ToolPath.ImageLib(f).Clone(New Rectangle(New Point, ToolPath.ImageLib(f).Size), PixelFormat.Format24bppRgb)
                        Dim w As Integer = imgsrc.Width
                        Dim h As Integer = imgsrc.Height
                        Dim g As BitmapData = imgsrc.LockBits(New Rectangle(New Point, imgsrc.Size), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb)
                        Dim Stride As Integer = g.Stride
                        Dim bsrc(Stride * h - 1) As Byte
                        Marshal.Copy(g.Scan0, bsrc, 0, bsrc.Length)
                        imgsrc.UnlockBits(g)
                        Dim curlayer As Integer = f
                        Parallel.For(0, h,
                            Sub(j As Integer)
                                For i As Integer = 0 To w - 1
                                    If Not TopDetected(i, j) Then
                                        If bsrc(j * Stride + i * 3) = 255 Then
                                            TopDetected(i, j) = True
                                            For l As Integer = curlayer To Math.Max(0, curlayer - TopLayer + 1) Step -1
                                                TopMask(l, i, j) = True
                                            Next
                                        End If
                                    End If
                                Next
                            End Sub)
                    Next
                    Parallel.For(StartLayer, ToolPath.ImageCount,
                        Sub(f As Integer)
                            SyncLock ToolPath.ImageLib(f)
                                Dim imgsrc As Bitmap = ToolPath.ImageLib(f).Clone(New Rectangle(New Point, ToolPath.ImageLib(f).Size), PixelFormat.Format24bppRgb)
                                Dim w As Integer = imgsrc.Width
                                Dim h As Integer = imgsrc.Height
                                Dim b(w - 1, h - 1) As Short
                                Dim g As BitmapData = imgsrc.LockBits(New Rectangle(New Point, imgsrc.Size), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb)
                                Dim Stride As Integer = g.Stride
                                Dim bsrc(Stride * h - 1) As Byte
                                Marshal.Copy(g.Scan0, bsrc, 0, bsrc.Length)
                                For j As Integer = 0 To h - 1
                                    For i As Integer = 0 To w - 1
                                        If bsrc(j * Stride + i * 3) <> 0 Then
                                            b(i, j) = 1
                                        End If
                                    Next
                                Next


                                Dim q(w * h - 1) As Point
                                Dim qtmp() As Point
                                Dim qptmp As Integer = -1
                                Dim qpin As Integer = -1
                                Dim layer As Integer = 0
                                For x As Integer = 0 To w - 1
                                    For y As Integer = 0 To h - 1
                                        If b(x, y) = 0 Then
                                            qpin += 1
                                            q(qpin) = New Point(x, y)
                                        End If
                                    Next
                                Next

                                'WS
                                While qpin >= 0
                                    layer += 1
                                    ReDim qtmp(Math.Min((qpin + 1) * 8, w * h - 1))
                                    qptmp = -1
                                    For i As Integer = 0 To qpin
                                        With q(i)
                                            If .X > 0 And .Y > 0 Then
                                                'LT
                                                If b(.X - 1, .Y - 1) = 1 Then
                                                    b(.X - 1, .Y - 1) = -layer
                                                    qptmp += 1
                                                    qtmp(qptmp).X = .X - 1
                                                    qtmp(qptmp).Y = .Y - 1
                                                End If
                                            End If
                                            If .X > 0 Then
                                                '.L
                                                If b(.X - 1, .Y) = 1 Then
                                                    b(.X - 1, .Y) = -layer
                                                    qptmp += 1
                                                    qtmp(qptmp).X = .X - 1
                                                    qtmp(qptmp).Y = .Y
                                                End If
                                            End If
                                            If .X > 0 And .Y < h - 1 Then
                                                'LB
                                                If b(.X - 1, .Y + 1) = 1 Then
                                                    b(.X - 1, .Y + 1) = -layer
                                                    qptmp += 1
                                                    qtmp(qptmp).X = .X - 1
                                                    qtmp(qptmp).Y = .Y + 1
                                                End If
                                            End If
                                            If .Y > 0 Then
                                                'T
                                                If b(.X, .Y - 1) = 1 Then
                                                    b(.X, .Y - 1) = -layer
                                                    qptmp += 1
                                                    qtmp(qptmp).X = .X
                                                    qtmp(qptmp).Y = .Y - 1
                                                End If
                                            End If
                                            If .Y > 0 And .X < w - 1 Then
                                                'TR
                                                If b(.X + 1, .Y - 1) = 1 Then
                                                    b(.X + 1, .Y - 1) = -layer
                                                    qptmp += 1
                                                    qtmp(qptmp).X = .X + 1
                                                    qtmp(qptmp).Y = .Y - 1
                                                End If
                                            End If
                                            If .Y < h - 1 Then
                                                'B
                                                If b(.X, .Y + 1) = 1 Then
                                                    b(.X, .Y + 1) = -layer
                                                    qptmp += 1
                                                    qtmp(qptmp).X = .X
                                                    qtmp(qptmp).Y = .Y + 1
                                                End If
                                            End If
                                            If .Y < h - 1 And .X < w - 1 Then
                                                'BR
                                                If b(.X + 1, .Y + 1) = 1 Then
                                                    b(.X + 1, .Y + 1) = -layer
                                                    qptmp += 1
                                                    qtmp(qptmp).X = .X + 1
                                                    qtmp(qptmp).Y = .Y + 1
                                                End If
                                            End If
                                            If .X < w - 1 Then
                                                'R
                                                If b(.X + 1, .Y) = 1 Then
                                                    b(.X + 1, .Y) = -layer
                                                    qptmp += 1
                                                    qtmp(qptmp).X = .X + 1
                                                    qtmp(qptmp).Y = .Y
                                                End If
                                            End If
                                        End With
                                    Next
                                    qpin = qptmp
                                    q = qtmp
                                End While

                                Dim bopt(Stride * h - 1) As Byte
                                Parallel.For(0, h,
                                    Sub(y As Integer)
                                        For x As Integer = 0 To w - 1
                                            If b(x, y) < 0 Then
                                                If -b(x, y) <= d Or TopMask(f, x, y) Then
                                                    bopt(y * Stride + 3 * x) = 255
                                                    bopt(y * Stride + 3 * x + 1) = 255
                                                    bopt(y * Stride + 3 * x + 2) = 255
                                                End If
                                            End If
                                        Next
                                    End Sub)
                                Marshal.Copy(bopt, 0, g.Scan0, bopt.Length)
                                imgsrc.UnlockBits(g)
                                ToolPath.ImageLib(f) = imgsrc.Clone(New Rectangle(New Point, imgsrc.Size), PixelFormat.Format1bppIndexed)

                                Threading.Interlocked.Add(progi, 1)
                                ProgVal = progi / （ToolPath.ImageCount - StartLayer） * 10000
                            End SyncLock
                        End Sub)
                    GC.Collect()
                    Invoke(Sub() 空心化HToolStripMenuItem.Enabled = True)
                End Sub)
                空心化HToolStripMenuItem.Enabled = False
                th.Start()

            End If

        End If
    End Sub


    Private Sub PictureBoxFramePreview_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBoxFramePreview.MouseMove
        SyncLock PictureBoxFramePreview
            If PictureBoxFramePreview.Image IsNot Nothing Then
                Dim x, y As Integer
                If PictureBoxFramePreview.Width / PictureBoxFramePreview.Height >= PictureBoxFramePreview.Image.Width / PictureBoxFramePreview.Image.Height Then
                    y = e.Y / PictureBoxFramePreview.Height * PictureBoxFramePreview.Image.Height
                    x = e.X - (PictureBoxFramePreview.Width - PictureBoxFramePreview.Height / PictureBoxFramePreview.Image.Height * PictureBoxFramePreview.Image.Width) / 2
                    x = x / PictureBoxFramePreview.Height * PictureBoxFramePreview.Image.Height
                Else
                    x = e.X / PictureBoxFramePreview.Width * PictureBoxFramePreview.Image.Width
                    y = e.Y - (PictureBoxFramePreview.Height - PictureBoxFramePreview.Width / PictureBoxFramePreview.Image.Width * PictureBoxFramePreview.Image.Height) / 2
                    y = y / PictureBoxFramePreview.Width * PictureBoxFramePreview.Image.Width
                End If
                If x < 0 Then Exit Sub
                If y < 0 Then Exit Sub
                If x >= PictureBoxFramePreview.Image.Width Then Exit Sub
                If y >= PictureBoxFramePreview.Image.Height Then Exit Sub
                PreviewCursor(x, y)
                If e.Button = MouseButtons.Left Then
                    Dim g As Graphics = Graphics.FromImage(PictureBoxFramePreview.Image)
                    Dim sz As Integer = Val(ToolStripTextBoxBrushSize.Text)
                    If sz <= 0 Then sz = 1
                    Dim brs As Brush
                    If 白色ToolStripMenuItem.Checked Then brs = Brushes.White Else brs = Brushes.Black
                    g.FillEllipse(brs, New Rectangle(x - sz \ 2, y - sz \ 2, sz, sz))
                    If 笔刷工具BToolStripMenuItem.Checked Then ToolPath.ImageLib(FrameID) = CType(PictureBoxFramePreview.Image, Bitmap).Clone(New Rectangle(New Point, PictureBoxFramePreview.Image.Size), PixelFormat.Format1bppIndexed)
                    PictureBoxFramePreview.Refresh()
                End If
            End If
        End SyncLock
    End Sub

    Public Sub PreviewCursor(ByVal x As Integer, ByVal y As Integer)
        ToolStripStatusLabelPointer.Text = "(" & x & "," & y & ")"
    End Sub

    Private Sub PictureBoxFramePreview_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBoxFramePreview.MouseDown
        PictureBoxFramePreview_MouseMove(sender, e)
    End Sub

    Private Sub 笔刷工具BToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 笔刷工具BToolStripMenuItem.Click
        笔刷工具BToolStripMenuItem.Checked = Not 笔刷工具BToolStripMenuItem.Checked
    End Sub

    Private Sub 白色ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 白色ToolStripMenuItem.Click
        白色ToolStripMenuItem.Checked = True
        黑色ToolStripMenuItem.Checked = False
    End Sub

    Private Sub 黑色ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 黑色ToolStripMenuItem.Click
        白色ToolStripMenuItem.Checked = False
        黑色ToolStripMenuItem.Checked = True
    End Sub

    Private Sub MaskSlicerMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MaskSlicerMToolStripMenuItem.Click
        Dim maskf As String
        If My.Computer.FileSystem.FileExists(TextBoxApplyMask.Text) Then
            maskf = TextBoxApplyMask.Text
        Else
            Dim mof As New OpenFileDialog
            If mof.ShowDialog = DialogResult.OK Then
                maskf = mof.FileName
            Else
                Exit Sub
            End If
        End If

        Dim mask As Bitmap = Image.FromFile(maskf)
        mask = mask.Clone(New Rectangle(New Point, mask.Size), PixelFormat.Format24bppRgb)
        Dim mc As BitmapData = mask.LockBits(New Rectangle(New Point, mask.Size), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb)
        Dim b(mc.Stride * mask.Height - 1) As Byte
        Marshal.Copy(mc.Scan0, b, 0, b.Length)
        mask.UnlockBits(mc)
        Button7.Enabled = False
        Try
            Dim th As New Threading.Thread(
                Sub()
                    Dim prog As Integer = 0
                    Parallel.For(0, ToolPath.FrameCount - 1,
                        Sub(i As Integer)
                            Dim img As Bitmap = ToolPath.ImageLib(i).Clone(New Rectangle(New Point, ToolPath.ImageLib(i).Size), PixelFormat.Format24bppRgb)
                            Dim ic As BitmapData = img.LockBits(New Rectangle(New Point, img.Size), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb)
                            Dim bi(ic.Stride * img.Height - 1) As Byte
                            Marshal.Copy(ic.Scan0, bi, 0, bi.Length)
                            For j As Integer = 0 To bi.Length - 1
                                bi(j) = bi(j) And b(j)
                            Next
                            Marshal.Copy(bi, 0, ic.Scan0, bi.Length)
                            img.UnlockBits(ic)
                            ToolPath.ImageLib(i) = img.Clone(New Rectangle(New Point, img.Size), PixelFormat.Format1bppIndexed)
                            Threading.Interlocked.Add(prog, 1)
                            ProgVal = prog / ToolPath.ImageCount * 10000
                        End Sub)
                    Invoke(Sub()
                               ReLoad()
                               Button7.Enabled = True
                           End Sub)
                End Sub)
            th.Start()
        Catch ex As Exception
            Button7.Enabled = True
        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If MessageBox.Show("是否重置设置", "警告", MessageBoxButtons.OKCancel) = DialogResult.OK Then
            My.Settings.Reset()
            My.Settings.Save()

        End If
    End Sub

    Private Sub 复制ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 复制ToolStripMenuItem.Click
        If Not LoadComplete Then Exit Sub
        If ListBoxImgLib.SelectedIndex < ToolPath.ImageCount Then
            LoadCurrentImage(ListBoxImgLib.SelectedIndex)
            Clipboard.SetImage(PictureBoxFramePreview.Image)
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles ButtonOffset.Click
        If MessageBox.Show("Offset?", "Warning", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim ofs As Point
            Dim s() As String = TextBoxOffset.Text.Split({"(", ",", ")"}, StringSplitOptions.RemoveEmptyEntries)
            ofs.X = Val(s(0))
            ofs.Y = Val(s(1))
            Dim mx As Integer = ToolPath.ImageCount
            Dim prg As Integer = 0
            Dim th As New Threading.Thread(
                Sub()
                    Parallel.For(0, ToolPath.ImageCount,
                        Sub(i As Integer)
                            Dim img As Bitmap = ToolPath.ImageLib(i).Clone(New Rectangle(New Point, ToolPath.ImageLib(i).Size), PixelFormat.Format24bppRgb)
                            Dim gc As BitmapData = img.LockBits(New Rectangle(New Point, img.Size), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb)
                            Dim Stride As Integer = gc.Stride
                            Dim w As Integer = img.Width
                            Dim h As Integer = img.Height
                            Dim b(Stride * h - 1) As Byte
                            Dim b2(Stride * h - 1) As Byte
                            For j As Integer = 0 To b2.Length - 1
                                b2(j) = 0
                            Next
                            Marshal.Copy(gc.Scan0, b, 0, b.Length)
                            Parallel.For(0, h,
                                Sub(y As Integer)
                                    For x As Integer = 0 To w - 1
                                        If x + ofs.X < w And x + ofs.X >= 0 And y + ofs.Y < h And y + ofs.Y >= 0 Then
                                            b2(3 * (x + ofs.X) + Stride * (y + ofs.Y)) = b(3 * x + Stride * y)
                                            b2(3 * (x + ofs.X) + Stride * (y + ofs.Y) + 1) = b(3 * x + Stride * y + 1)
                                            b2(3 * (x + ofs.X) + Stride * (y + ofs.Y) + 2) = b(3 * x + Stride * y + 2)
                                        End If
                                    Next
                                End Sub)
                            Marshal.Copy(b2, 0, gc.Scan0, b2.Length)
                            img.UnlockBits(gc)
                            ToolPath.ImageLib(i) = img.Clone(New Rectangle(New Point, ToolPath.ImageLib(i).Size), PixelFormat.Format1bppIndexed)
                            img.Dispose()
                            Threading.Interlocked.Add(prg, 1)
                            Threading.Interlocked.Exchange(ProgVal, prg / mx * 10000)
                        End Sub)
                    Invoke(Sub()
                               ButtonOffset.Enabled = True
                               MessageBox.Show("Finished!")
                           End Sub)
                End Sub)
            ProgVal = 0
            ButtonOffset.Enabled = False
            th.Start()

        End If
    End Sub

    Private Sub Button11_Click_1(sender As Object, e As EventArgs) Handles Button11.Click
        If MessageBox.Show("Rotate?", "Warning", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim s() As String = TextBoxOffset.Text.Split({"(", ",", ")"}, StringSplitOptions.RemoveEmptyEntries)
            Dim mx As Integer = ToolPath.ImageCount
            Dim prg As Integer = 0
            Dim th As New Threading.Thread(
                Sub()
                    Parallel.For(0, ToolPath.ImageCount,
                        Sub(i As Integer)
                            Dim img As Bitmap = ToolPath.ImageLib(i).Clone(New Rectangle(New Point, ToolPath.ImageLib(i).Size), PixelFormat.Format24bppRgb)
                            Dim gc As BitmapData = img.LockBits(New Rectangle(New Point, img.Size), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb)
                            Dim Stride As Integer = gc.Stride
                            Dim w As Integer = img.Width
                            Dim h As Integer = img.Height
                            Dim b(Stride * h - 1) As Byte
                            Dim b2(Stride * h - 1) As Byte
                            For j As Integer = 0 To b2.Length - 1
                                b2(j) = 0
                            Next
                            Marshal.Copy(gc.Scan0, b, 0, b.Length)
                            Parallel.For(0, h,
                                Sub(y As Integer)
                                    For x As Integer = 0 To w - 1
                                        b2(3 * (x) + Stride * (y)) = b(3 * (w - 1 - x) + Stride * (h - 1 - y))
                                        b2(3 * (x) + Stride * (y) + 1) = b(3 * (w - 1 - x) + Stride * (h - 1 - y) + 1)
                                        b2(3 * (x) + Stride * (y) + 2) = b(3 * (w - 1 - x) + Stride * (h - 1 - y) + 2)
                                    Next
                                End Sub)
                            Marshal.Copy(b2, 0, gc.Scan0, b2.Length)
                            img.UnlockBits(gc)
                            ToolPath.ImageLib(i) = img.Clone(New Rectangle(New Point, ToolPath.ImageLib(i).Size), PixelFormat.Format1bppIndexed)
                            img.Dispose()
                            Threading.Interlocked.Add(prg, 1)
                            Threading.Interlocked.Exchange(ProgVal, prg / mx * 10000)
                        End Sub)
                    Invoke(Sub()
                               ButtonOffset.Enabled = True
                               MessageBox.Show("Finished!")
                           End Sub)
                End Sub)
            ProgVal = 0
            ButtonOffset.Enabled = False
            th.Start()

        End If
    End Sub

    Private Sub 时间分层ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 时间分层ToolStripMenuItem.Click
        Dim diffmx As Integer = 50
        Dim w As Integer = ToolPath.ImageLib(0).Width
        Dim h As Integer = ToolPath.ImageLib(0).Height

        For l As Integer = 0 To ToolPath.ImageCount - 2
            Dim mask(w - 1, h - 1) As Integer
            Dim gc As BitmapData = ToolPath.ImageLib(l).LockBits(New Rectangle(New Point, New Size(w, h)), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb)
            Dim std As Integer = gc.Stride
            Dim b(gc.Stride * h - 1) As Byte
            Marshal.Copy(gc.Scan0, b, 0, b.Length)
            Parallel.For(0, h, Sub(j As Integer)
                                   For i As Integer = 0 To w - 1
                                       If b(i * 3 + j * std) > 0 Then mask(i, j) = 1
                                   Next
                               End Sub)

            Dim q(w * h - 1) As Point
            Dim qtmp() As Point
            Dim qptmp As Integer = -1
            Dim qpin As Integer = -1
            Dim layer As Integer = 0
            For x As Integer = 0 To w - 1
                For y As Integer = 0 To h - 1
                    If mask(x, y) = 0 Then
                        qpin += 1
                        q(qpin) = New Point(x, y)
                    End If
                Next
            Next

            'WS
            While qpin >= 0
                layer += 1
                ReDim qtmp(Math.Min((qpin + 1) * 8, w * h - 1))
                qptmp = -1
                For i As Integer = 0 To qpin
                    With q(i)
                        If .X > 0 And .Y > 0 Then
                            'LT
                            If mask(.X - 1, .Y - 1) = 1 Then
                                mask(.X - 1, .Y - 1) = -layer
                                qptmp += 1
                                qtmp(qptmp).X = .X - 1
                                qtmp(qptmp).Y = .Y - 1
                            End If
                        End If
                        If .X > 0 Then
                            'L
                            If mask(.X - 1, .Y) = 1 Then
                                mask(.X - 1, .Y) = -layer
                                qptmp += 1
                                qtmp(qptmp).X = .X - 1
                                qtmp(qptmp).Y = .Y
                            End If
                        End If
                        If .X > 0 And .Y < h - 1 Then
                            'LB
                            If mask(.X - 1, .Y + 1) = 1 Then
                                mask(.X - 1, .Y + 1) = -layer
                                qptmp += 1
                                qtmp(qptmp).X = .X - 1
                                qtmp(qptmp).Y = .Y + 1
                            End If
                        End If
                        If .Y > 0 Then
                            'T
                            If mask(.X, .Y - 1) = 1 Then
                                mask(.X, .Y - 1) = -layer
                                qptmp += 1
                                qtmp(qptmp).X = .X
                                qtmp(qptmp).Y = .Y - 1
                            End If
                        End If
                        If .Y > 0 And .X < w - 1 Then
                            'TR
                            If mask(.X + 1, .Y - 1) = 1 Then
                                mask(.X + 1, .Y - 1) = -layer
                                qptmp += 1
                                qtmp(qptmp).X = .X + 1
                                qtmp(qptmp).Y = .Y - 1
                            End If
                        End If
                        If .Y < h - 1 Then
                            'B
                            If mask(.X, .Y + 1) = 1 Then
                                mask(.X, .Y + 1) = -layer
                                qptmp += 1
                                qtmp(qptmp).X = .X
                                qtmp(qptmp).Y = .Y + 1
                            End If
                        End If
                        If .Y < h - 1 And .X < w - 1 Then
                            'BR
                            If mask(.X + 1, .Y + 1) = 1 Then
                                mask(.X + 1, .Y + 1) = -layer
                                qptmp += 1
                                qtmp(qptmp).X = .X + 1
                                qtmp(qptmp).Y = .Y + 1
                            End If
                        End If
                        If .X < w - 1 Then
                            'R
                            If mask(.X + 1, .Y) = 1 Then
                                mask(.X + 1, .Y) = -layer
                                qptmp += 1
                                qtmp(qptmp).X = .X + 1
                                qtmp(qptmp).Y = .Y
                            End If
                        End If
                    End With
                Next
                qpin = qptmp
                q = qtmp
            End While

            Dim bopt(std * h - 1) As Byte
            Parallel.For(0, h,
                Sub(y As Integer)
                    For x As Integer = 0 To w - 1
                        If mask(x, y) < 0 Then
                            If -mask(x, y) <= diffmx Then
                                bopt(y * std + 3 * x) = 255
                                bopt(y * std + 3 * x + 1) = 255
                                bopt(y * std + 3 * x + 2) = 255
                            End If
                        End If
                    Next
                End Sub)
        Next
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Parallel.For(0, 1386,
                     Sub(i As Integer)
                         Dim img As Bitmap = Image.FromFile("C:\Users\Administrator\Desktop\FreqAnl\out\V" & i.ToString("D4") & ".png")
                         'Dim img2 As Bitmap = img.Clone(New Rectangle(New Point(466, 858), New Size(100, 100)), PixelFormat.Format24bppRgb)
                         Dim gcd As Imaging.BitmapData = img.LockBits(New Rectangle(New Point, img.Size), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb)
                         Dim b(gcd.Stride * img.Height - 1) As Byte
                         Marshal.Copy(gcd.Scan0, b, 0, b.Length)
                         For y As Integer = 0 To img.Height - 1
                             For x As Integer = 0 To img.Width - 1
                                 If (CInt(b(3 * x + gcd.Stride * y + 2)) - (CInt(b(3 * x + gcd.Stride * y)) + CInt(b(3 * x + gcd.Stride * y + 1))) / 2) <= 50 Then
                                     b(3 * x + gcd.Stride * y) = 255
                                     b(3 * x + gcd.Stride * y + 1) = 255
                                     b(3 * x + gcd.Stride * y + 2) = 255
                                 End If
                             Next
                         Next
                         Marshal.Copy(b, 0, gcd.Scan0, b.Length)
                         img.UnlockBits(gcd)
                         img.Save("C:\Users\Administrator\Desktop\FreqAnl\out2\V" & i.ToString("D4") & ".png")
                         img.Dispose()
                         GC.Collect()
                         'img2.Dispose()
                     End Sub)
        MessageBox.Show("Finished!")
    End Sub


End Class
