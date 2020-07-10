Imports System.ComponentModel

Public Class ToolPathGenerator
    Public ToolPath As ToolPath
    Public FileCount As Integer
    Private CodeBefore1, CodeAfter1, CodeBefore2, CodeAfter2 As String
    Private FinalGCode As String
    Private StartGCode As String
    Public Event ProgressReport(ByVal i As Integer)
    Public Event ProcCompleted()
    Public LoadFromFile As Boolean = False
    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        CodeBefore1 = My.Settings.TPG_CodeBefore1
        CodeBefore2 = My.Settings.TPG_CodeBefore2
        CodeAfter1 = My.Settings.TPG_CodeAfter1
        CodeAfter2 = My.Settings.TPG_CodeAfter2
        FinalGCode = My.Settings.TPG_FinalGCode
        NumericUpDown1.Value = My.Settings.TPG_l1
        NumericUpDown4.Value = My.Settings.TPG_l2
        NumericUpDown2.Value = My.Settings.TPG_t1
        NumericUpDown3.Value = My.Settings.TPG_t2
        NumericUpDown5.Value = My.Settings.TPG_t3
        TextBox1.Text = My.Settings.TPG_loc
        StartGCode = My.Settings.TPG_StartGCode
        If My.Computer.FileSystem.DirectoryExists(TextBox1.Text) Then
            FolderBrowserDialog1.SelectedPath = TextBox1.Text
        End If
    End Sub

    Private Sub ToolPathGenerator_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.TPG_CodeBefore1 = CodeBefore1
        My.Settings.TPG_CodeBefore2 = CodeBefore2
        My.Settings.TPG_CodeAfter1 = CodeAfter1
        My.Settings.TPG_CodeAfter2 = CodeAfter2
        My.Settings.TPG_l1 = NumericUpDown1.Value
        My.Settings.TPG_l2 = NumericUpDown4.Value
        My.Settings.TPG_t1 = NumericUpDown2.Value
        My.Settings.TPG_t2 = NumericUpDown3.Value
        My.Settings.TPG_t3 = NumericUpDown5.Value
        My.Settings.TPG_loc = TextBox1.Text
        My.Settings.TPG_StartGCode = StartGCode
        My.Settings.TPG_FinalGCode = FinalGCode
        My.Settings.Save()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            TextBox1.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim TF As New TextInputForm
        TF.TextBox1.Text = CodeAfter1
        If TF.ShowDialog() = DialogResult.OK Then
            CodeAfter1 = TF.TextBox1.Text
        End If
        TF.Dispose()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim TF As New TextInputForm
        TF.TextBox1.Text = CodeBefore2
        If TF.ShowDialog() = DialogResult.OK Then
            CodeBefore2 = TF.TextBox1.Text
        End If
        TF.Dispose()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim TF As New TextInputForm
        TF.TextBox1.Text = CodeAfter2
        If TF.ShowDialog() = DialogResult.OK Then
            CodeAfter2 = TF.TextBox1.Text
        End If
        TF.Dispose()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MessageBox.Show("Will lose anything unsaved. Continue?", "Warning", MessageBoxButtons.OKCancel) = DialogResult.OK Then
            Dim th As Threading.Thread = New Threading.Thread(
                Sub()
                    Dim Multip As Integer = NumericUpDown4.Value + 1
                    ToolPath.FrameCount = FileCount * Multip
                    ToolPath.ImageCount = FileCount
                    ReDim ToolPath.CodeBefore(ToolPath.FrameCount - 1)
                    ReDim ToolPath.CodeAfter(ToolPath.FrameCount - 1)
                    ReDim ToolPath.ExposureTime(ToolPath.FrameCount - 1)
                    ReDim ToolPath.ImageID(ToolPath.FrameCount - 1)
                    Dim ImgTempLib() As Bitmap
                    If Not LoadFromFile Then
                        ImgTempLib = ToolPath.ImageLib.Clone
                    End If
                    ReDim ToolPath.ImageLib(ToolPath.ImageCount - 1)
                    Dim prog As Integer = 0
                    Parallel.For(0, FileCount,
                        Sub(i As Integer)
                            If LoadFromFile Then
                                ToolPath.SetImage(i, Image.FromFile(TextBox1.Text & "\" & i & ".png"))
                            Else
                                ToolPath.SetImage(i, ImgTempLib(i))
                            End If
                            If i < NumericUpDown1.Value Then
                                If NumericUpDown4.Value = 0 Then
                                    ToolPath.SetFrame(i, CodeBefore1, i, NumericUpDown2.Value, CodeAfter1)
                                Else
                                    ToolPath.SetFrame(i * Multip, CodeBefore1, i, NumericUpDown2.Value, "")
                                    For j As Integer = 1 To NumericUpDown4.Value - 1
                                        ToolPath.SetFrame(i * Multip + j, "%Sleep " & NumericUpDown5.Value, i, NumericUpDown2.Value, "")
                                    Next
                                    ToolPath.SetFrame(i * Multip + Multip - 1, "%Sleep " & NumericUpDown5.Value, i, NumericUpDown2.Value, CodeAfter1)
                                End If
                            Else
                                If NumericUpDown4.Value = 0 Then
                                    ToolPath.SetFrame(i, CodeBefore2, i, NumericUpDown3.Value, CodeAfter2)
                                Else
                                    ToolPath.SetFrame(i * Multip, CodeBefore2, i, NumericUpDown3.Value, "")
                                    For j As Integer = 1 To NumericUpDown4.Value - 1
                                        ToolPath.SetFrame(i * Multip + j, "%Sleep " & NumericUpDown5.Value, i, NumericUpDown3.Value, "")
                                    Next
                                    ToolPath.SetFrame(i * Multip + Multip - 1, "%Sleep " & NumericUpDown5.Value, i, NumericUpDown3.Value, CodeAfter2)
                                End If
                            End If
                            RaiseEvent ProgressReport(Threading.Interlocked.Add(prog, 1) / FileCount * 10000)
                        End Sub)
                    ToolPath.CodeBefore(0) = StartGCode & My.Settings.Lining & ToolPath.CodeBefore(0)
                    ToolPath.CodeAfter(ToolPath.FrameCount - 1) &= My.Settings.Lining & FinalGCode
                    GC.Collect()
                    RaiseEvent ProcCompleted()
                    Invoke(
                    Sub()
                        Close()
                        Dispose()
                    End Sub)
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



    Private Sub ToolPathGenerator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CodeBefore1 = "" And CodeBefore2 = "" And CodeAfter1 = "" And CodeAfter2 = "" And StartGCode = "" And FinalGCode = "" Then
            CodeBefore1 = "G91
G1 Z1 F100
G1 Z4 F300
G1 Z-3.5 F300
G1 Z-1 F75
G1 Z-0.45 F50
%Sleep 3700
M3 S1000
%Sleep 300"
            CodeAfter1 = "M5
M3 S1000
M5
%Sleep 1000"
            CodeBefore2 = CodeBefore1
            CodeAfter2 = CodeAfter1
            StartGCode = "$X
G91"
            FinalGCode = "M5
G1 Z1 F100
G1 Z39 F300
"
        End If
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
        LoadFromFile = True
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If ToolPath.ImageCount > 0 Then
            FileCount = ToolPath.ImageCount
            NumericUpDown1.Maximum = FileCount - 1
            Panel1.Enabled = True
            Button8.Enabled = True
            LoadFromFile = False
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim TF As New TextInputForm
        TF.TextBox1.Text = CodeBefore1
        If TF.ShowDialog() = DialogResult.OK Then
            CodeBefore1 = TF.TextBox1.Text
        End If
        TF.Dispose()
    End Sub


End Class