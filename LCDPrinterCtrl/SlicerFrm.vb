Imports System.ComponentModel
Imports System.Drawing.Imaging

Public Class SlicerFrm

    Public ToolPath As ToolPath
    Public Event ProgressReport(ByVal i As Integer)
    Public Event ProcCompleted()
    Public Event MessageReport(s As String)

    Public Event DialogReturn()
    Public STLFile As STL
    Public LayerThickness As Double = My.Settings.TP_LayerThickness
    Public ImgSize As Size = New Size(My.Settings.TP_DisplayWidth, My.Settings.TP_DisplayHeight)
    Public DisplaySize As SizeF = New SizeF(My.Settings.TP_Width, My.Settings.TP_Height)

    Public Sub RefreshDisplay()
        If STLFile IsNot Nothing Then
            Dim img As New Bitmap(ImgSize.Width, ImgSize.Height, PixelFormat.Format24bppRgb)
            If True Then
                STLFile.Slice(NumericUpDown1.Value * LayerThickness + LayerThickness / 2).RenderSlice(img, Color.White, ImgSize, DisplaySize, CheckBox2.Checked, Val(TextBox10.Text))
            Else
                Dim gc As BitmapData = img.LockBits(New Rectangle(New Point, img.Size), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb)
                Dim b(img.Height * gc.Stride - 1) As Byte
                STLFile.Slice(NumericUpDown1.Value * LayerThickness + LayerThickness / 2).RenderZCrossSection(b, 255, ImgSize, DisplaySize, gc.Stride, 3)
                Runtime.InteropServices.Marshal.Copy(b, 0, gc.Scan0, b.Length)
                img.UnlockBits(gc)
            End If
            PictureBox1.Image = img
        End If
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            TextBox1.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If My.Computer.FileSystem.FileExists(TextBox1.Text) Then
            STLFile = New STL
            STLFile.Open(TextBox1.Text)
            STLFile.FixNormal()
            STLFile.CenterXY()
            STLFile.SitOnPlatform()
            GroupBox1.Enabled = True
            Button4_Click(sender, e)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim s() As String = TextBox2.Text.Split({",", " ", vbTab}, StringSplitOptions.RemoveEmptyEntries)
        If s.Length <> 3 Then Exit Sub
        STLFile.Move(New Vector3DF(Val(s(0)), Val(s(1)), Val(s(2))))
        Button4_Click(sender, e)
        RefreshDisplay()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim s() As String = TextBox3.Text.Split({",", " ", vbTab, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
        If s.Length <> 9 Then Exit Sub
        STLFile.Transform(New Matrix3({{Val(s(0)), Val(s(1)), Val(s(2))}, {Val(s(3)), Val(s(4)), Val(s(5))}, {Val(s(6)), Val(s(7)), Val(s(8))}}))
        STLFile.CenterXY()
        STLFile.SitOnPlatform()
        Button4_Click(sender, e)
        RefreshDisplay()
    End Sub

    Public Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Val(TextBox4.Text) > 0 Then LayerThickness = Val(TextBox4.Text)
        NumericUpDown1.Maximum = Math.Truncate((STLFile.MaxZ - STLFile.MinZ) / LayerThickness) - 1
        TrackBar1.Maximum = NumericUpDown1.Maximum
        RefreshDisplay()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        TrackBar1.Value = NumericUpDown1.Value
        RefreshDisplay()
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        NumericUpDown1.Value = TrackBar1.Value
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If Convert.ToInt32(Val(TextBox5.Text)) > 0 And Convert.ToInt32(Val(TextBox6.Text)) > 0 Then
            ImgSize.Width = Val(TextBox5.Text)
            ImgSize.Height = Val(TextBox6.Text)
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If Val(TextBox5.Text) > 0 And Val(TextBox6.Text) > 0 Then
            DisplaySize.Width = Val(TextBox7.Text)
            DisplaySize.Height = Val(TextBox8.Text)
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        STLFile.CenterXY()
        STLFile.SitOnPlatform()
        RefreshDisplay()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If My.Computer.FileSystem.DirectoryExists(TextBox9.Text) Then
            If MessageBox.Show("Will rewrite existing file. Continue?", "Warning", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                Dim prog As Integer = 0
                Dim th As New Threading.Thread(
                    Sub()
                        Parallel.For(0, NumericUpDown1.Maximum + 1,
                            Sub(i As Integer)
                                Dim img As New Bitmap(ImgSize.Width, ImgSize.Height, PixelFormat.Format24bppRgb)
                                'Dim gc As BitmapData = img.LockBits(New Rectangle(New Point, img.Size), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb)
                                'Dim b(img.Height * gc.Stride - 1) As Byte
                                'SyncLock (STLFile)
                                'STLFile.Slice(i * LayerThickness + LayerThickness / 2).RenderZCrossSection(b, 255, ImgSize, DisplaySize, gc.Stride, 3)
                                STLFile.Slice(i * LayerThickness + LayerThickness / 2).RenderSlice(img, Color.White, ImgSize, DisplaySize, CheckBox2.Checked, Val(TextBox10.Text))
                                'End SyncLock
                                'Runtime.InteropServices.Marshal.Copy(b, 0, gc.Scan0, b.Length)
                                'img.UnlockBits(gc)
                                img.Clone(New Rectangle(New Point, img.Size), PixelFormat.Format1bppIndexed).Save(TextBox9.Text & "\" & i & ".png")
                                Threading.Interlocked.Add(prog, 1)
                            End Sub)
                        RaiseEvent ProcCompleted()
                    End Sub)
                Dim thprg As New Threading.Thread(
                    Sub()
                        While prog < NumericUpDown1.Maximum + 1
                            Invoke(Sub()
                                       Text = prog & " / " & NumericUpDown1.Maximum + 1
                                       RaiseEvent ProgressReport(prog / (NumericUpDown1.Maximum + 1) * 10000)
                                   End Sub)
                            Threading.Thread.Sleep(100)
                        End While
                        Invoke(
                            Sub()
                                Text = prog & " / " & NumericUpDown1.Maximum + 1
                                GroupBox1.Enabled = True
                                RaiseEvent ProgressReport(prog / (NumericUpDown1.Maximum + 1) * 10000)
                            End Sub)
                    End Sub)
                GroupBox1.Enabled = False
                thprg.Start()
                th.Start()
            End If
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            TextBox9.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If MessageBox.Show("将清空现有图像，是否继续", "警告", MessageBoxButtons.OKCancel) = DialogResult.OK Then
            Dim prog As Integer = 0
            ToolPath.ImageCount = NumericUpDown1.Maximum + 1
            ReDim ToolPath.ImageLib(ToolPath.ImageCount - 1)
            Dim th As New Threading.Thread(
                Sub()
                    Parallel.For(0, NumericUpDown1.Maximum + 1,
                        Sub(i As Integer)
                            Dim img As New Bitmap(ImgSize.Width, ImgSize.Height, PixelFormat.Format24bppRgb)
                            STLFile.Slice(i * LayerThickness + LayerThickness / 2).RenderSlice(img, Color.White, ImgSize, DisplaySize, CheckBox2.Checked, Val(TextBox10.Text))
                            ToolPath.ImageLib(i) = img.Clone(New Rectangle(New Point, img.Size), PixelFormat.Format1bppIndexed)
                            Threading.Interlocked.Add(prog, 1)
                        End Sub)
                    RaiseEvent ProcCompleted()
                    DialogResult = DialogResult.OK
                    RaiseEvent DialogReturn()
                End Sub)
            Dim thprg As New Threading.Thread(
                Sub()
                    While prog < NumericUpDown1.Maximum + 1
                        Invoke(Sub()
                                   Text = prog & " / " & NumericUpDown1.Maximum + 1
                                   RaiseEvent ProgressReport(prog / (NumericUpDown1.Maximum + 1) * 10000)
                               End Sub)
                        Threading.Thread.Sleep(100)
                    End While
                    Invoke(
                        Sub()
                            Text = prog & " / " & NumericUpDown1.Maximum + 1
                            GroupBox1.Enabled = True
                            RaiseEvent ProgressReport(prog / (NumericUpDown1.Maximum + 1) * 10000)
                        End Sub)
                End Sub)
            GroupBox1.Enabled = False
            thprg.Start()
            th.Start()

        End If
    End Sub

    Private Sub SlicerFrm_Load(sender As Object, e As EventArgs) Handles Me.Load
        TextBox4.Text = My.Settings.TP_LayerThickness
        TextBox5.Text = My.Settings.TP_DisplayWidth
        TextBox6.Text = My.Settings.TP_DisplayHeight
        TextBox7.Text = My.Settings.TP_Width
        TextBox8.Text = My.Settings.TP_Height
    End Sub

    Private Sub SlicerFrm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.TP_LayerThickness = TextBox4.Text
        My.Settings.TP_DisplayWidth = TextBox5.Text
        My.Settings.TP_DisplayHeight = TextBox6.Text
        My.Settings.TP_Width = TextBox7.Text
        My.Settings.TP_Height = TextBox8.Text
        My.Settings.Save()
    End Sub

End Class