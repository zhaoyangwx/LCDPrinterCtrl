Imports System.ComponentModel

Public Class OnionSlicer

    Public ToolPath As ToolPath
    Public Property Depth As Integer
    Public Event ImgAdded()
    Public FileCount As Integer
    Private a1, b1, a2, b2 As String
    Private FinalGCode As String
    Private StartGCode As String
    Public Event ProgressReport(ByVal i As Integer)
    Public Event ProcCompleted()
    Public Function Generate(ByVal depth As Integer, ByRef imgs As Bitmap) As Bitmap()
        Dim ImgSrc As Bitmap = imgs
        Dim ImgOut() As Bitmap
        If ImgSrc IsNot Nothing Then
            Dim w As Integer = ImgSrc.Width
            Dim h As Integer = ImgSrc.Height
            Dim b(w - 1, h - 1) As Integer
            ImgSrc = ImgSrc.Clone(New Rectangle(0, 0, w, h), Imaging.PixelFormat.Format24bppRgb)
            Dim g As Imaging.BitmapData = ImgSrc.LockBits(New Rectangle(New Point, ImgSrc.Size), Imaging.ImageLockMode.ReadWrite, Imaging.PixelFormat.Format24bppRgb)
            Dim Stride As Integer = g.Stride
            Dim bsrc(Stride * h - 1) As Byte
            Runtime.InteropServices.Marshal.Copy(g.Scan0, bsrc, 0, bsrc.Length)
            ImgSrc.UnlockBits(g)
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
            ReDim ImgOut((layer + 1) \ depth)
            Parallel.For(0, ImgOut.Length,
                Sub(i As Integer)
                    ImgOut(i) = New Bitmap(w, h, Imaging.PixelFormat.Format24bppRgb)
                    Dim gc As Imaging.BitmapData = ImgOut(i).LockBits(New Rectangle(New Point(), ImgOut(i).Size), Imaging.ImageLockMode.ReadWrite, Imaging.PixelFormat.Format24bppRgb)
                    Dim bout(gc.Stride * ImgOut(i).Height - 1) As Byte

                    For x As Integer = 0 To w - 1
                        For y As Integer = 0 To h - 1
                            If b(x, y) = 0 Then Continue For
                            If (Math.Abs(b(x, y)) + 1) \ depth = ImgOut.Length - 1 - i Then
                                bout((x * 3 + y * Stride)) = 255
                                bout((x * 3 + y * Stride) + 1) = 255
                                bout((x * 3 + y * Stride) + 2) = 255
                            End If
                        Next
                    Next
                    Runtime.InteropServices.Marshal.Copy(bout, 0, gc.Scan0, bout.Length)
                    ImgOut(i).UnlockBits(gc)
                    ImgOut(i) = ImgOut(i).Clone(New Rectangle(New Point, ImgOut(i).Size), Imaging.PixelFormat.Format1bppIndexed)
                End Sub)
            Return ImgOut
        End If
    End Function

    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        a1 = My.Settings.TPG_CodeBefore1
        a2 = My.Settings.TPG_CodeBefore2
        b1 = My.Settings.TPG_CodeAfter1
        b2 = My.Settings.TPG_CodeAfter2
        NumericUpDown1.Value = My.Settings.TPG_l1
        NumericUpDown4.Value = My.Settings.TPG_l2
        NumericUpDown2.Value = My.Settings.TPG_t1
        NumericUpDown3.Value = My.Settings.TPG_t2
        NumericUpDown5.Value = My.Settings.TPG_t3
        NumericUpDown6.Value = My.Settings.TPG_OSlicWidth
        TextBox1.Text = My.Settings.TPG_loc
        FinalGCode = My.Settings.TPG_FinalGCode
        StartGCode = My.Settings.TPG_StartGCode
        If My.Computer.FileSystem.DirectoryExists(TextBox1.Text) Then
            FolderBrowserDialog1.SelectedPath = TextBox1.Text
        End If
    End Sub

    Private Sub ToolPathGenerator_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.TPG_CodeBefore1 = a1
        My.Settings.TPG_CodeBefore2 = a2
        My.Settings.TPG_CodeAfter1 = b1
        My.Settings.TPG_CodeAfter2 = b2
        My.Settings.TPG_l1 = NumericUpDown1.Value
        My.Settings.TPG_l2 = NumericUpDown4.Value
        My.Settings.TPG_t1 = NumericUpDown2.Value
        My.Settings.TPG_t2 = NumericUpDown3.Value
        My.Settings.TPG_t3 = NumericUpDown5.Value
        My.Settings.TPG_OSlicWidth = NumericUpDown6.Value
        My.Settings.TPG_loc = TextBox1.Text
        My.Settings.TPG_FinalGCode = FinalGCode
        My.Settings.TPG_StartGCode = StartGCode
        My.Settings.Save()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            TextBox1.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim TF As New TextInputForm
        TF.TextBox1.Text = b1
        If TF.ShowDialog() = DialogResult.OK Then
            b1 = TF.TextBox1.Text
        End If
        TF.Dispose()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim TF As New TextInputForm
        TF.TextBox1.Text = a2
        If TF.ShowDialog() = DialogResult.OK Then
            a2 = TF.TextBox1.Text
        End If
        TF.Dispose()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim TF As New TextInputForm
        TF.TextBox1.Text = b2
        If TF.ShowDialog() = DialogResult.OK Then
            b2 = TF.TextBox1.Text
        End If
        TF.Dispose()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MessageBox.Show("Will lose anything unsaved. Continue?", "Warning", MessageBoxButtons.OKCancel) = DialogResult.OK Then
            Dim canexit As Boolean = False
            Panel1.Enabled = False
            Button6.Enabled = False
            Button7.Enabled = False
            Button8.Enabled = False
            Dim th As Threading.Thread = New Threading.Thread(
                Sub()
                    Dim TotalFrameCount As Integer
                    Dim StartIndex(FileCount - 1) As Integer
                    Dim ImgList()() As Bitmap
                    ReDim ImgList(FileCount - 1)
                    Dim SubframeCount(FileCount - 1) As Integer
                    Dim prog As Integer = 0
                    Dim prs As String = ""
                    AddHandler Me.ProgressReport,
                    Sub(i As Integer)
                        prs = prog & " - " & i / 100 & "%"
                    End Sub
                    Dim thprg As New Threading.Thread(
                    Sub()
                        While Not canexit
                            Threading.Thread.Sleep(100)
                            Invoke(Sub() Text = prs)
                        End While

                        Invoke(
                        Sub()
                            Close()
                            Dispose()
                        End Sub)
                    End Sub)
                    thprg.Start()
                    Parallel.For(0, FileCount,
                        Sub(i As Integer)
                            ImgList(i) = Generate(Depth， Image.FromFile(TextBox1.Text & "\" & i & ".png"))
                            SubframeCount(i) = ImgList(i).Length
                            Threading.Interlocked.Add(TotalFrameCount, SubframeCount(i))
                            Threading.Interlocked.Add(prog, 1)
                            RaiseEvent ProgressReport(prog / FileCount * 10000)
                        End Sub)
                    For i As Integer = 1 To FileCount - 1
                        StartIndex(i) = StartIndex(i - 1) + SubframeCount(i - 1)
                    Next

                    Dim Multip As Integer = NumericUpDown4.Value + 1
                    ToolPath.FrameCount = TotalFrameCount * Multip
                    ToolPath.ImageCount = TotalFrameCount
                    ReDim ToolPath.CodeBefore(ToolPath.FrameCount - 1)
                    ReDim ToolPath.CodeAfter(ToolPath.FrameCount - 1)
                    ReDim ToolPath.ExposureTime(ToolPath.FrameCount - 1)
                    ReDim ToolPath.ImageID(ToolPath.FrameCount - 1)
                    ReDim ToolPath.ImageLib(ToolPath.ImageCount - 1)
                    prog = 0
                    Parallel.For(0, FileCount,
                        Sub(i As Integer)
                            Dim CBi, CAi As String
                            CBi = "%Sleep " & Math.Max(NumericUpDown5.Value - 200, 100) & "
M3 S1000
%Sleep 200"
                            CAi = "M5"
                            For sf As Integer = 0 To SubframeCount(i) - 1
                                ToolPath.SetImage(StartIndex(i) + sf, ImgList(i)(sf))
                                If i < NumericUpDown1.Value Then
                                    If NumericUpDown4.Value = 0 Then
                                        ToolPath.SetFrame(StartIndex(i) + sf, CBi, StartIndex(i) + sf, NumericUpDown2.Value, CAi)
                                    Else
                                        ToolPath.SetFrame(StartIndex(i) * Multip + sf * Multip, CBi, StartIndex(i) + sf, NumericUpDown2.Value, CAi)
                                        For j As Integer = 1 To Multip - 2
                                            ToolPath.SetFrame(StartIndex(i) * Multip + sf * Multip + j, CBi, StartIndex(i) + sf, NumericUpDown2.Value, CAi)
                                        Next
                                        ToolPath.SetFrame(StartIndex(i) * Multip + sf * Multip + Multip - 1, CBi, StartIndex(i) + sf, NumericUpDown2.Value, CAi)
                                    End If
                                Else
                                    If NumericUpDown4.Value = 0 Then
                                        ToolPath.SetFrame(StartIndex(i) + sf, CBi, StartIndex(i) + sf, NumericUpDown3.Value, CAi)
                                    Else
                                        ToolPath.SetFrame(StartIndex(i) * Multip + sf * Multip, CBi, StartIndex(i) + sf, NumericUpDown3.Value, CAi)
                                        For j As Integer = 1 To Multip - 2
                                            ToolPath.SetFrame(StartIndex(i) * Multip + sf * Multip + j, CBi, StartIndex(i) + sf, NumericUpDown3.Value, CAi)
                                        Next
                                        ToolPath.SetFrame(StartIndex(i) * Multip + sf * Multip + Multip - 1, CBi, StartIndex(i) + sf, NumericUpDown3.Value, CAi)
                                    End If
                                End If
                                RaiseEvent ProgressReport(Threading.Interlocked.Add(prog, 1) / TotalFrameCount * 10000)
                            Next
                            If i < NumericUpDown1.Value Then
                                ToolPath.SetFrame(StartIndex(i) * Multip, a1, StartIndex(i), NumericUpDown2.Value, CAi)
                                ToolPath.SetFrame((StartIndex(i) + SubframeCount(i)) * Multip - 1, CBi, StartIndex(i) + SubframeCount(i) - 1, NumericUpDown2.Value, b1)
                            Else
                                ToolPath.SetFrame(StartIndex(i) * Multip, a2, StartIndex(i), NumericUpDown3.Value, CAi)
                                ToolPath.SetFrame((StartIndex(i) + SubframeCount(i)) * Multip - 1, CBi, StartIndex(i) + SubframeCount(i) - 1, NumericUpDown3.Value, b2)
                            End If
                        End Sub)
                    ToolPath.CodeBefore(0) = StartGCode & My.Settings.Lining & ToolPath.CodeBefore(0)
                    ToolPath.CodeAfter(ToolPath.FrameCount - 1) &= My.Settings.Lining & FinalGCode
                    GC.Collect()
                    RaiseEvent ProcCompleted()
                    Threading.Interlocked.MemoryBarrier()
                    Threading.Interlocked.Exchange(canexit, True)
                End Sub)
            th.Start()
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim Path As String = TextBox1.Text & "\"
        Parallel.For(0, FileCount,
            Sub(i As Integer)
                Dim FileName As String = Path & i & ".png"
                Dim b1 As Bitmap = New ImageConverter().ConvertFrom(IO.File.ReadAllBytes(FileName))
                Dim b2 As Image = b1.Clone(New Rectangle(New Point, b1.Size), Imaging.PixelFormat.Format1bppIndexed)
                My.Computer.FileSystem.DeleteFile(FileName)
                b2.Save(FileName, Imaging.ImageFormat.Png)
            End Sub)
    End Sub

    Private Sub NumericUpDown6_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown6.ValueChanged
        Depth = NumericUpDown6.Value
    End Sub

    Private Sub ImgSplitter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If a1 = "" And a2 = "" And b1 = "" And b2 = "" And FinalGCode = "" Then
            a1 = "G91
G1 Z1 F100
G1 Z2 F300
G1 Z-1.5 F300
G1 Z-1 F75
G1 Z-0.45 F50
%Sleep 4000"
            b1 = "%Sleep 1000"
            a2 = a1
            b2 = b1
            FinalGCode = "G1 Z1 F100
G1 Z29 F300"
        End If
    End Sub

    Private Sub ButtonFinalGCode_Click(sender As Object, e As EventArgs) Handles ButtonFinalGCode.Click
        Dim TF As New TextInputForm
        TF.TextBox1.Text = FinalGCode
        If TF.ShowDialog() = DialogResult.OK Then
            FinalGCode = TF.TextBox1.Text
        End If
        TF.Dispose()
    End Sub

    Private Sub ButtonStartGCode_Click(sender As Object, e As EventArgs) Handles ButtonStartGCode.Click
        Dim TF As New TextInputForm
        TF.TextBox1.Text = StartGCode
        If TF.ShowDialog() = DialogResult.OK Then
            StartGCode = TF.TextBox1.Text
        End If
        TF.Dispose()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim flist As IO.FileInfo() = My.Computer.FileSystem.GetDirectoryInfo(TextBox1.Text).GetFiles
        Dim i As Integer
        For i = 0 To flist.Length
            If Not My.Computer.FileSystem.FileExists(TextBox1.Text & "\" & i & ".png") Then
                Exit For
            End If
        Next
        i -= 1
        If i < 0 Then Exit Sub
        FileCount = i + 1
        NumericUpDown1.Maximum = i
        Panel1.Enabled = True
        Button8.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim TF As New TextInputForm
        TF.TextBox1.Text = a1
        If TF.ShowDialog() = DialogResult.OK Then
            a1 = TF.TextBox1.Text
        End If
        TF.Dispose()
    End Sub

    Private Sub ImgSplitter_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = Not Button6.Enabled
    End Sub
End Class