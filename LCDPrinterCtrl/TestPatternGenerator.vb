Imports System.ComponentModel
Imports System.Runtime.InteropServices

Public Class TestPatternGenerator
    Public ToolPath As ToolPath
    Public Display As Display
    Public Event ProgressReport(ByVal i As Integer)
    Public Event Finished()
    Public Event Aborted()
    Public Event MessageReport(ByVal s As String)
    Public Pattern() As Bitmap
    Public Pc() As Imaging.BitmapData
    Public Pb()() As Byte
    Public LayerCount As Integer
    Public LTPoint As Point, LTZero As Point
    Public NewFunction As Boolean = False

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MessageBox.Show("Will lose anything unsaved. Continue?", "Warning", MessageBoxButtons.OKCancel) = DialogResult.OK Then
            Dim xnum As Integer = (NumericUpDownW.Value - NumericUpDownEdgeDistanceW.Value * 2) \ (NumericUpDownPatternWidth.Value + NumericUpDownPatternDistance.Value)
            Dim ynum As Integer = (NumericUpDownH.Value - NumericUpDownEdgeDistanceH.Value * 2) \ (NumericUpDownPatternHeight.Value + NumericUpDownPatternDistance.Value)
            Dim RW As Double = NumericUpDownDisplayW.Value / NumericUpDownW.Value
            Dim RH As Double = NumericUpDownDisplayH.Value / NumericUpDownH.Value
            Dim ImageOut(xnum * ynum - 1) As Bitmap
            Text = NumericUpDownMinTime.Value & "ms to " & NumericUpDownMinTime.Value + (ImageOut.Length - 1) * NumericUpDownTimeIntv.Value & "ms step " & NumericUpDownTimeIntv.Value & "ms"
            RaiseEvent MessageReport(Text)
            Dim Img0 As New Bitmap(NumericUpDownDisplayW.Value， NumericUpDownDisplayH.Value, Imaging.PixelFormat.Format24bppRgb)
            Dim gc As Imaging.BitmapData = Img0.LockBits(New Rectangle(New Point, Img0.Size), Imaging.ImageLockMode.ReadWrite, Imaging.PixelFormat.Format24bppRgb)
            Dim stride As Integer = gc.Stride
            Dim b(stride * Img0.Height - 1) As Byte
            For x As Integer = Math.Round(NumericUpDownEdgeDistanceW.Value * RW) To Math.Round((NumericUpDownPatternWidth.Value + NumericUpDownEdgeDistanceW.Value) * RW) - 1
                For y As Integer = Math.Round(NumericUpDownEdgeDistanceH.Value * RH) To Math.Round((NumericUpDownPatternHeight.Value + NumericUpDownEdgeDistanceH.Value) * RH) - 1
                    b(y * stride + x * 3) = 255
                    b(y * stride + x * 3 + 1) = 255
                    b(y * stride + x * 3 + 2) = 255
                Next
            Next
            Marshal.Copy(b, 0, gc.Scan0, b.Length)
            Img0.UnlockBits(gc)
            ImageOut(0) = Img0



            For i As Integer = 1 To ImageOut.Length - 1
                ImageOut(i) = ImageOut(i - 1).Clone
                gc = ImageOut(i).LockBits(New Rectangle(New Point, ImageOut(i).Size), Imaging.ImageLockMode.ReadWrite, Imaging.PixelFormat.Format24bppRgb)
                stride = gc.Stride
                ReDim b(stride * ImageOut(i).Height - 1)
                Marshal.Copy(gc.Scan0, b, 0, b.Length)
                Dim lx As Integer = i Mod xnum
                lx = lx * (NumericUpDownPatternWidth.Value + NumericUpDownPatternDistance.Value) + NumericUpDownEdgeDistanceW.Value
                Dim ly As Integer = i \ xnum
                ly = ly * (NumericUpDownPatternHeight.Value + NumericUpDownPatternDistance.Value) + NumericUpDownEdgeDistanceH.Value
                For x As Integer = Math.Round(lx * RW) To Math.Round((lx + NumericUpDownPatternWidth.Value) * RW) - 1
                    For y As Integer = Math.Round(ly * RH) To Math.Round((ly + NumericUpDownPatternHeight.Value) * RH) - 1
                        b(y * stride + x * 3) = 255
                        b(y * stride + x * 3 + 1) = 255
                        b(y * stride + x * 3 + 2) = 255
                    Next
                Next
                Marshal.Copy(b, 0, gc.Scan0, b.Length)
                ImageOut(i).UnlockBits(gc)
                RaiseEvent ProgressReport(i / (ImageOut.Length - 1) * 10000)
            Next

            ToolPath.FrameCount = 0
            ToolPath.ImageCount = 0
            For i As Integer = 0 To ImageOut.Length - 1
                ToolPath.AddImage(ImageOut(i).Clone(New Rectangle(New Point(), ImageOut(i).Size), Imaging.PixelFormat.Format1bppIndexed))
            Next
            Dim l As Integer
            For l = 0 To NumericUpDownTotalThickness.Value / NumericUpDownLayerThickness.Value - 1
                For i As Integer = 0 To ImageOut.Length - 1
                    ToolPath.AddFrame("", ImageOut.Length - 1 - i, NumericUpDownTimeIntv.Value, "")
                Next
                ToolPath.ExposureTime(l * ImageOut.Length) = NumericUpDownMinTime.Value

                ToolPath.CodeBefore(l * ImageOut.Length) = "G91" & My.Settings.Lining &
                    "G1 Z" & NumericUpDownLiftDistance.Value & " F" & NumericUpDownFeedRateUp.Value & My.Settings.Lining &
                    "G1 Z-" & NumericUpDownLiftDistance.Value - NumericUpDownLayerThickness.Value & " F" & NumericUpDownFeedRateDown.Value & My.Settings.Lining &
                    "M3 S1000" & My.Settings.Lining & "%Sleep " & Math.Round(1000 +
NumericUpDownLiftDistance.Value / NumericUpDownFeedRateUp.Value * 60000 +
(NumericUpDownLiftDistance.Value - NumericUpDownLayerThickness.Value) / NumericUpDownFeedRateDown.Value * 60000)
                ToolPath.CodeAfter((l + 1) * ImageOut.Length - 1) = "M5"
            Next
            ToolPath.CodeAfter(l * ImageOut.Length - 1) = "G91" & My.Settings.Lining &
                "M5" & My.Settings.Lining & "G1 Z50 F" & NumericUpDownFeedRateUp.Value
            RaiseEvent Finished()
        End If
    End Sub

    Private Sub TestPatternGenerator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NumericUpDownDisplayW.Value = My.Settings.TP_DisplayWidth
        NumericUpDownDisplayH.Value = My.Settings.TP_DisplayHeight
        NumericUpDownW.Value = My.Settings.TP_Width
        NumericUpDownH.Value = My.Settings.TP_Height
        NumericUpDownPatternWidth.Value = My.Settings.TP_PatternW
        NumericUpDownPatternHeight.Value = My.Settings.TP_PatternH
        NumericUpDownPatternDistance.Value = My.Settings.TP_PatternDistance
        NumericUpDownEdgeDistanceW.Value = My.Settings.TP_EdgeDistanceW
        NumericUpDownEdgeDistanceH.Value = My.Settings.TP_EdgeDistanceH
        NumericUpDownLayerThickness.Value = My.Settings.TP_LayerThickness
        NumericUpDownTotalThickness.Value = My.Settings.TP_TotalThickness
        NumericUpDownMinTime.Value = My.Settings.TP_TimeMin
        NumericUpDownTimeIntv.Value = My.Settings.TP_TimeIntv
        NumericUpDownFeedRateUp.Value = My.Settings.TP_FeedRateUp
        NumericUpDownFeedRateDown.Value = My.Settings.TP_FeedRateDown
        NumericUpDownLiftDistance.Value = My.Settings.TP_LiftDistance
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MessageBox.Show("Will lose anything unsaved. Continue?", "Warning", MessageBoxButtons.OKCancel) = DialogResult.OK Then
            Dim th As New Threading.Thread(
                Sub()
                    Dim xnum As Integer = (NumericUpDownW.Value - NumericUpDownEdgeDistanceW.Value * 2) \ (NumericUpDownPatternWidth.Value + NumericUpDownPatternDistance.Value)
                    Dim ynum As Integer = (NumericUpDownH.Value - NumericUpDownEdgeDistanceH.Value * 2) \ (NumericUpDownPatternHeight.Value + NumericUpDownPatternDistance.Value)
                    Dim RW As Double = NumericUpDownDisplayW.Value / NumericUpDownW.Value
                    Dim RH As Double = NumericUpDownDisplayH.Value / NumericUpDownH.Value

                    LayerCount = ToolPath.ImageCount

                    ReDim Pattern(LayerCount - 1)
                    For i As Integer = 0 To LayerCount - 1
                        Pattern(i) = ToolPath.ImageLib(i).Clone(New Rectangle(New Point, ToolPath.ImageLib(i).Size), Imaging.PixelFormat.Format24bppRgb)
                    Next

                    'Dim f As New Form() With {.Height = 130, .Width = 200}
                    'Dim pb1 As New PictureBox With {.Parent = f, .SizeMode = PictureBoxSizeMode.Zoom, .Location = New Point, .Size = New Size(100, 100), .Image = Pattern(0)}
                    'Dim pb2 As New PictureBox With {.Parent = f, .SizeMode = PictureBoxSizeMode.Zoom, .Location = New Point(101, 0), .Size = New Size(100, 100), .Image = Pattern(LayerCount - 1)}
                    'f.ShowDialog()

                    LTPoint = New Point((Pattern(0).Width - NumericUpDownPatternWidth.Value * RW) / 2 + 1, (Pattern(0).Height - NumericUpDownPatternHeight.Value * RH) / 2 + 1)
                    Dim ImageOut()() As Bitmap
                    ReDim ImageOut(LayerCount)
                    ReDim Pb(LayerCount)
                    ReDim Pc(LayerCount)
                    For i As Integer = 0 To LayerCount - 1
                        ReDim ImageOut(i)(xnum * ynum - 1)
                        Pc(i) = Pattern(i).LockBits(New Rectangle(New Point, Pattern(i).Size), Imaging.ImageLockMode.ReadWrite, Imaging.PixelFormat.Format24bppRgb)
                        ReDim Pb(i)(Pattern(i).Height * Pc(i).Stride - 1)
                        Marshal.Copy(Pc(i).Scan0, Pb(i), 0, Pb(i).Length)
                    Next

                    ToolPath.FrameCount = 0
                    ToolPath.ImageCount = 0
                    Dim psrc As Point

                    Me.Invoke(Sub() Text = NumericUpDownMinTime.Value & "ms to " & NumericUpDownMinTime.Value + (ImageOut(0).Length - 1) * NumericUpDownTimeIntv.Value & "ms step " & NumericUpDownTimeIntv.Value & "ms")


                    For layer As Integer = 0 To LayerCount - 1
                        RaiseEvent MessageReport(Text)

                        Dim Img0 As New Bitmap(NumericUpDownDisplayW.Value， NumericUpDownDisplayH.Value, Imaging.PixelFormat.Format24bppRgb)
                        Dim gc As Imaging.BitmapData = Img0.LockBits(New Rectangle(New Point, Img0.Size), Imaging.ImageLockMode.ReadWrite, Imaging.PixelFormat.Format24bppRgb)
                        Dim stride As Integer = gc.Stride
                        Dim b(stride * Img0.Height - 1) As Byte
                        LTZero = New Point(Math.Round(NumericUpDownEdgeDistanceW.Value * RW)， Math.Round(NumericUpDownEdgeDistanceH.Value * RH))
                        For x As Integer = Math.Round(NumericUpDownEdgeDistanceW.Value * RW) To Math.Round((NumericUpDownPatternWidth.Value + NumericUpDownEdgeDistanceW.Value) * RW) - 1
                            For y As Integer = Math.Round(NumericUpDownEdgeDistanceH.Value * RH) To Math.Round((NumericUpDownPatternHeight.Value + NumericUpDownEdgeDistanceH.Value) * RH) - 1
                                psrc = New Point(x, y) - LTZero + LTPoint
                                b(y * stride + x * 3) = Pb(layer)(psrc.Y * Pc(layer).Stride + psrc.X * 3)
                                b(y * stride + x * 3 + 1) = Pb(layer)(psrc.Y * Pc(layer).Stride + psrc.X * 3 + 1)
                                b(y * stride + x * 3 + 2) = Pb(layer)(psrc.Y * Pc(layer).Stride + psrc.X * 3 + 2)
                            Next
                        Next
                        Marshal.Copy(b, 0, gc.Scan0, b.Length)
                        Img0.UnlockBits(gc)
                        ImageOut(layer)(0) = Img0


                        For i As Integer = 1 To ImageOut(layer).Length - 1
                            ImageOut(layer)(i) = ImageOut(layer)(i - 1).Clone
                            gc = ImageOut(layer)(i).LockBits(New Rectangle(New Point, ImageOut(layer)(i).Size), Imaging.ImageLockMode.ReadWrite, Imaging.PixelFormat.Format24bppRgb)
                            stride = gc.Stride
                            ReDim b(stride * ImageOut(layer)(i).Height - 1)
                            Marshal.Copy(gc.Scan0, b, 0, b.Length)
                            Dim lx As Integer = i Mod xnum
                            lx = lx * (NumericUpDownPatternWidth.Value + NumericUpDownPatternDistance.Value) + NumericUpDownEdgeDistanceW.Value
                            Dim ly As Integer = i \ xnum
                            ly = ly * (NumericUpDownPatternHeight.Value + NumericUpDownPatternDistance.Value) + NumericUpDownEdgeDistanceH.Value

                            LTZero = New Point(Math.Round(lx * RW), Math.Round(ly * RH))
                            For x As Integer = Math.Round(lx * RW) To Math.Round((lx + NumericUpDownPatternWidth.Value) * RW) - 1
                                For y As Integer = Math.Round(ly * RH) To Math.Round((ly + NumericUpDownPatternHeight.Value) * RH) - 1
                                    psrc = New Point(x, y) - LTZero + LTPoint
                                    b(y * stride + x * 3) = Pb(layer)(psrc.Y * Pc(layer).Stride + psrc.X * 3)
                                    b(y * stride + x * 3 + 1) = Pb(layer)(psrc.Y * Pc(layer).Stride + psrc.X * 3 + 1)
                                    b(y * stride + x * 3 + 2) = Pb(layer)(psrc.Y * Pc(layer).Stride + psrc.X * 3 + 2)
                                Next
                            Next

                            Marshal.Copy(b, 0, gc.Scan0, b.Length)
                            ImageOut(layer)(i).UnlockBits(gc)
                            RaiseEvent ProgressReport((i + 1 + (ImageOut(layer).Length * layer)) / (ImageOut(layer).Length * LayerCount) * 10000)
                        Next

                        For i As Integer = 0 To ImageOut(layer).Length - 1
                            ToolPath.AddImage(ImageOut(layer)(i).Clone(New Rectangle(New Point(), ImageOut(layer)(i).Size), Imaging.PixelFormat.Format1bppIndexed))
                            ToolPath.AddFrame("", ImageOut(layer).Length * layer + ImageOut(layer).Length - 1 - i, NumericUpDownTimeIntv.Value, "")
                        Next
                        ToolPath.ExposureTime(layer * ImageOut(layer).Length) = NumericUpDownMinTime.Value
                        ToolPath.CodeBefore(layer * ImageOut(layer).Length) = "G91" & My.Settings.Lining &
                        "G1 Z" & NumericUpDownLiftDistance.Value & " F" & NumericUpDownFeedRateUp.Value & My.Settings.Lining &
                        "G1 Z-" & NumericUpDownLiftDistance.Value - NumericUpDownLayerThickness.Value & " F" & NumericUpDownFeedRateDown.Value & My.Settings.Lining &
                        "M3 S1000" & My.Settings.Lining & "%Sleep " & Math.Round(1000 +
                                        NumericUpDownLiftDistance.Value / NumericUpDownFeedRateUp.Value * 60000 +
                                        (NumericUpDownLiftDistance.Value - NumericUpDownLayerThickness.Value) / NumericUpDownFeedRateDown.Value * 60000)

                        ToolPath.CodeAfter((layer + 1) * ImageOut(layer).Length - 1) = "G91" & My.Settings.Lining &
                        "M5" & My.Settings.Lining & "G1 Z50 F" & NumericUpDownFeedRateUp.Value
                    Next


                    For i As Integer = 0 To LayerCount - 1
                        Pattern(i).UnlockBits(Pc(i))
                    Next

                    RaiseEvent Finished()
                    Invoke(Sub()
                               Button1.Enabled = True
                               Button2.Enabled = True
                           End Sub)

                End Sub)
            Button1.Enabled = False
            Button2.Enabled = False
            th.Start()

        End If
    End Sub

    Private Sub TestPatternGenerator_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.TP_DisplayHeight = NumericUpDownDisplayH.Value
        My.Settings.TP_DisplayWidth = NumericUpDownDisplayW.Value
        My.Settings.TP_Width = NumericUpDownW.Value
        My.Settings.TP_Height = NumericUpDownH.Value
        My.Settings.TP_PatternW = NumericUpDownPatternWidth.Value
        My.Settings.TP_PatternH = NumericUpDownPatternHeight.Value
        My.Settings.TP_PatternDistance = NumericUpDownPatternDistance.Value
        My.Settings.TP_EdgeDistanceW = NumericUpDownEdgeDistanceW.Value
        My.Settings.TP_EdgeDistanceH = NumericUpDownEdgeDistanceH.Value
        My.Settings.TP_LayerThickness = NumericUpDownLayerThickness.Value
        My.Settings.TP_TotalThickness = NumericUpDownTotalThickness.Value
        My.Settings.TP_TimeMin = NumericUpDownMinTime.Value
        My.Settings.TP_TimeIntv = NumericUpDownTimeIntv.Value
        My.Settings.TP_FeedRateUp = NumericUpDownFeedRateUp.Value
        My.Settings.TP_FeedRateDown = NumericUpDownFeedRateDown.Value
        My.Settings.TP_LiftDistance = NumericUpDownLiftDistance.Value
        RaiseEvent Aborted()
    End Sub
End Class