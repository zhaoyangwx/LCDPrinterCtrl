Imports System.Threading.Tasks

Public Class ToolPath
    Public Property FrameCount As Integer
    Public Property ImageCount As Integer
    Public ImageLib() As Bitmap
    Public CodeBefore() As String
    Public ExposureTime() As Integer
    Public CodeAfter() As String
    Public ImageID() As Integer
    Public Property LineNumber As Integer
    Public Event EndOfToolPath()
    Public Event FrameCountChanged()
    Public Event ImageCountChanged()
    Public Event ProgressReport(ByVal i As Integer, ByVal s As String)
    Public Event ProgressFinished()
    Public Event LoadingStarted()
    Public Event LoadingFinished()
    Public Event TimingAbsent()
    Public Event ExceptionOccured(ex As Exception)
    Private Loading As Boolean = False
    Public LastFileName As String = ""

    Public Sub New()
        LineNumber = 0
        FrameCount = 0
        ImageCount = 0
    End Sub
    Public Sub NextLine()
        LineNumber += 1
        If LineNumber >= CodeBefore.Length Then
            RaiseEvent EndOfToolPath()
        End If
    End Sub
    Public Function GetCodeBefore() As String
        Return CodeBefore(LineNumber)
    End Function
    Public Function GetImage() As Bitmap
        If ImageLib(ImageID(LineNumber)) IsNot Nothing Then
            Return ImageLib(ImageID(LineNumber))
        ElseIf My.Computer.FileSystem.FileExists(TmpDir & "/Image\" & ImageID(LineNumber) & ".png") Then
            Return New ImageConverter().ConvertFrom(IO.File.ReadAllBytes(TmpDir & "/Image\" & ImageID(LineNumber) & ".png"))
        Else
            Return Nothing
        End If
    End Function
    Public Function GetExposureTime() As Integer
        Return ExposureTime(LineNumber)
    End Function
    Public Function GetCodeAfter() As String
        Return CodeAfter(LineNumber)
    End Function
    Public Sub AddImage(ByRef image As Bitmap)
        ImageCount += 1
        ReDim Preserve ImageLib(ImageCount - 1)
        ImageLib(ImageCount - 1) = image.Clone
        RaiseEvent ImageCountChanged()
    End Sub
    Public Sub AddImage(ByVal FileName As String)
        Try
            AddImage(New ImageConverter().ConvertFrom(IO.File.ReadAllBytes(FileName)))
        Catch ex As Exception
            RaiseEvent ExceptionOccured(ex)
        End Try
    End Sub
    Public Sub InsertImage(ByVal IID As Integer, ByVal image As Bitmap)
        Try
            If IID > ImageCount - 1 Then
                AddImage(image)
            Else
                If IID < 0 Then IID = 0
                ReDim Preserve ImageLib(ImageCount)
                ImageCount += 1
                For i As Integer = ImageCount - 1 To IID + 1 Step -1
                    ImageLib(i) = ImageLib(i - 1)
                Next
                ImageLib(IID) = image
                RaiseEvent ImageCountChanged()
            End If
        Catch ex As Exception
            RaiseEvent ExceptionOccured(ex)
        End Try
    End Sub
    Public Sub InsertImage(ByVal IID As Integer, ByVal FileName As String)
        Try
            InsertImage(IID, New ImageConverter().ConvertFrom(IO.File.ReadAllBytes(FileName)))
        Catch ex As Exception
            RaiseEvent ExceptionOccured(ex)
        End Try
    End Sub
    Public Sub RemoveImage(ByVal IID As Integer)
        If ImageCount > 1 Then
            Dim IL(ImageCount - 2) As Bitmap
            For i As Integer = 0 To IID - 1
                IL(i) = ImageLib(i)
            Next
            For i As Integer = IID + 1 To ImageCount - 1
                IL(i - 1) = ImageLib(i)
            Next
            ImageLib = IL
            For i As Integer = 0 To FrameCount - 1
                If ImageID(i) >= IID Then ImageID(i) -= 1
            Next
            ImageCount -= 1
            RaiseEvent ImageCountChanged()
        ElseIf ImageCount = 1 Then
            ImageCount -= 1
            RaiseEvent ImageCountChanged()
        End If

    End Sub
    Public Sub InsertFrame(ByVal FID As Integer, ByVal CodeBf As String, ByVal ImgID As Integer, ByVal ExpTime As Integer, ByVal CodeAft As String)
        If FID > FrameCount - 1 Then
            AddFrame(CodeBf, ImgID, ExpTime, CodeAft)
        Else
            If FID < 0 Then FID = 0
            FrameCount += 1
            ReDim Preserve CodeBefore(FrameCount - 1)
            ReDim Preserve CodeAfter(FrameCount - 1)
            ReDim Preserve ImageID(FrameCount - 1)
            ReDim Preserve ExposureTime(FrameCount - 1)
            For i As Integer = FrameCount - 1 To FID + 1 Step -1
                CodeBefore(i) = CodeBefore(i - 1)
                CodeAfter(i) = CodeAfter(i - 1)
                ImageID(i) = ImageID(i - 1)
                ExposureTime(i) = ExposureTime(i - 1)
            Next
            CodeBefore(FID) = CodeBf
            CodeAfter(FID) = CodeAft
            ImageID(FID) = ImgID
            ExposureTime(FID) = ExpTime
            RaiseEvent FrameCountChanged()
        End If
    End Sub
    Public Sub SetFrame(ByVal FID As Integer, ByVal CodeBf As String, ByVal ImgID As Integer, ByVal ExpTime As Integer, ByVal CodeAft As String)
        If FID < 0 Or FID >= FrameCount Then Exit Sub
        CodeBefore(FID) = CodeBf
        CodeAfter(FID) = CodeAft
        ImageID(FID) = ImgID
        ExposureTime(FID) = ExpTime
    End Sub
    Public Sub SetImage(ByVal IID As Integer, ByRef img As Bitmap)
        Try
            If IID < 0 Or IID >= ImageCount Then Exit Sub
            ImageLib(IID) = img
        Catch ex As Exception
            RaiseEvent ExceptionOccured(ex)
        End Try
    End Sub
    Public Sub AddFrame(ByVal CodeBf As String, ByVal ImgID As Integer, ByVal ExpTime As Integer, ByVal CodeAft As String)
        FrameCount += 1
        ReDim Preserve CodeBefore(FrameCount - 1)
        CodeBefore(FrameCount - 1) = CodeBf
        ReDim Preserve CodeAfter(FrameCount - 1)
        CodeAfter(FrameCount - 1) = CodeAft
        ReDim Preserve ImageID(FrameCount - 1)
        ImageID(FrameCount - 1) = ImgID
        ReDim Preserve ExposureTime(FrameCount - 1)
        ExposureTime(FrameCount - 1) = ExpTime
        RaiseEvent FrameCountChanged()
    End Sub
    Public Sub AddFrame()
        FrameCount += 1
        ReDim Preserve CodeBefore(FrameCount - 1)
        ReDim Preserve CodeAfter(FrameCount - 1)
        ReDim Preserve ImageID(FrameCount - 1)
        ReDim Preserve ExposureTime(FrameCount - 1)
        RaiseEvent FrameCountChanged()
    End Sub

    Public Sub RemoveFrame(ByVal FID As Integer)
        If FID >= 0 And FID < FrameCount Then
            Dim CB(FrameCount - 2) As String
            Dim CA(FrameCount - 2) As String
            Dim II(FrameCount - 2) As Integer
            Dim ET(FrameCount - 2) As Integer
            For i As Integer = 0 To FID - 1
                CB(i) = CodeBefore(i)
                CA(i) = CodeAfter(i)
                II(i) = ImageID(i)
                ET(i) = ExposureTime(i)
            Next
            For i As Integer = FID + 1 To FrameCount - 1
                CB(i - 1) = CodeBefore(i)
                CA(i - 1) = CodeAfter(i)
                II(i - 1) = ImageID(i)
                ET(i - 1) = ExposureTime(i)
            Next
            CodeBefore = CB
            CodeAfter = CA
            ImageID = II
            ExposureTime = ET
            FrameCount -= 1
            RaiseEvent FrameCountChanged()
        End If
    End Sub
    Public Enum TimeUnit
        s = 1000
        second = 1000
        ms = 1
        millisecond = 1
    End Enum
    Public Function GetLayerTimeString(Optional ByVal TimeUnit As TimeUnit = TimeUnit.second) As String
        If FrameCount = 0 Then Return ""
        Dim tm As String = ""
        Dim LastExpTime As Integer = ExposureTime(FrameCount - 1)
        Dim FrameLastInitExpTime As Integer
        For FrameLastInitExpTime = FrameCount - 1 To -1 Step -1
            If FrameLastInitExpTime = -1 Then Exit For
            If ExposureTime(FrameLastInitExpTime) <> LastExpTime Then
                Exit For
            End If
        Next
        If FrameLastInitExpTime >= 0 Then
            For i As Integer = 0 To FrameLastInitExpTime
                tm &= Double.Parse(ExposureTime(i)) / TimeUnit & ","
            Next
        End If
        tm &= LastExpTime / TimeUnit
        Return tm
    End Function
    Public Sub SetLayerTime(ByVal TimeString As String, Optional ByVal TimeUnit As TimeUnit = TimeUnit.second)
        If FrameCount = 0 Then Exit Sub
        Dim s() As String = TimeString.Split({",", vbTab, " "}, StringSplitOptions.RemoveEmptyEntries)
        If s Is Nothing Then Exit Sub
        If s.Length = 0 Then Exit Sub
        If Val(s(0)) = 0 Then Exit Sub
        For i As Integer = 0 To s.Length - 2
            If FrameCount > i Then
                ExposureTime(i) = Val(s(i)) * TimeUnit
            Else
                Exit For
            End If
        Next
        If FrameCount >= s.Length Then
            Dim vl As Integer = CInt(Val(s(s.Length - 1)) * TimeUnit)
            For i As Integer = s.Length - 1 To FrameCount - 1
                ExposureTime(i) = vl
            Next
        End If
    End Sub
    Public Sub SaveToFile(ByVal FileName As String)
        Dim th As New Threading.Thread(
            Sub()
                Try
                    RaiseEvent LoadingStarted()
                    Dim TmpDir As String = My.Computer.FileSystem.GetTempFileName
                    Dim prog As Integer = 0
                    RaiseEvent ProgressReport(1000, "创建临时目录...")
                    My.Computer.FileSystem.DeleteFile(TmpDir)
                    My.Computer.FileSystem.CreateDirectory(TmpDir)
                    My.Computer.FileSystem.CreateDirectory(TmpDir & "/Image")
                    My.Computer.FileSystem.CreateDirectory(TmpDir & "/CB")
                    My.Computer.FileSystem.CreateDirectory(TmpDir & "/CA")
                    My.Computer.FileSystem.CreateDirectory(TmpDir & "/II")
                    My.Computer.FileSystem.CreateDirectory(TmpDir & "/ET")
                    RaiseEvent ProgressReport(2000, "导出文件...")
                    Dim PRTh As Threading.Thread = New Threading.Thread(
                        Sub()
                            While True
                                RaiseEvent ProgressReport(prog / (ImageCount + FrameCount) * 10000, "Preparing " & prog & "/" & (ImageCount + FrameCount))
                                If prog >= ImageCount + FrameCount Then Exit While
                                Threading.Thread.Sleep(100)
                            End While
                        End Sub)
                    PRTh.Start()
                    Parallel.For(0, ImageCount,
                        Sub(i As Integer)
                            ImageLib(i).Save(TmpDir & "/Image\" & i & ".png", Imaging.ImageFormat.Png)
                            Threading.Interlocked.Add(prog, 1)
                        End Sub)
                    Parallel.For(0, FrameCount,
                        Sub(i As Integer)
                            My.Computer.FileSystem.WriteAllText(TmpDir & "/CB\" & i & ".txt", CodeBefore(i), False)
                            My.Computer.FileSystem.WriteAllText(TmpDir & "/CA\" & i & ".txt", CodeAfter(i), False)
                            My.Computer.FileSystem.WriteAllText(TmpDir & "/II\" & i & ".txt", ImageID(i), False)
                            My.Computer.FileSystem.WriteAllText(TmpDir & "/ET\" & i & ".txt", ExposureTime(i), False)
                            Threading.Interlocked.Add(prog, 1)
                        End Sub)
                    RaiseEvent ProgressReport(9000, "正在保存...")
                    Dim Info As String = ImageCount & "," & FrameCount & "," & LineNumber
                    My.Computer.FileSystem.WriteAllText(TmpDir & "/Info.txt", Info, False)
                    If My.Computer.FileSystem.FileExists(FileName) Then My.Computer.FileSystem.DeleteFile(FileName)
                    IO.Compression.ZipFile.CreateFromDirectory(TmpDir, FileName)
                    LastFileName = FileName
                    My.Computer.FileSystem.DeleteDirectory(TmpDir, FileIO.DeleteDirectoryOption.DeleteAllContents)
                    Threading.Thread.MemoryBarrier()
                    RaiseEvent ProgressFinished()
                Catch ex As Exception
                    RaiseEvent ExceptionOccured(ex)
                End Try
            End Sub)
        th.Start()
    End Sub
    Public Function LoadFromFile(ByVal FileName As String, Optional ByVal FinishedAction As Action = Nothing) As Boolean
        Dim DebugMSG As Boolean = True
        Try
            If Threading.Interlocked.Equals(Loading, True) Then Return False
            Dim th As New Threading.Thread(
                Sub()
                    Try
                        RaiseEvent LoadingStarted()
                        My.Computer.FileSystem.DeleteFile(TmpDir)
                        My.Computer.FileSystem.CreateDirectory(TmpDir)
                        RaiseEvent ProgressReport(2000, "正在解包...")
                        IO.Compression.ZipFile.ExtractToDirectory(FileName, TmpDir)
                        RaiseEvent ProgressReport(5000, "正在加载...")
                        Dim TimingAbs As Boolean = False
                        If My.Computer.FileSystem.FileExists(TmpDir & "/Info.txt") Then
                            Dim Info() As String = My.Computer.FileSystem.ReadAllText(TmpDir & "/Info.txt").Split({","}, StringSplitOptions.RemoveEmptyEntries)
                            ImageCount = Val(Info(0))
                            FrameCount = Val(Info(1))
                            LineNumber = Val(Info(2))
                            ReDim ImageLib(ImageCount - 1)
                            ReDim CodeBefore(FrameCount - 1)
                            ReDim CodeAfter(FrameCount - 1)
                            ReDim ImageID(FrameCount - 1)
                            ReDim ExposureTime(FrameCount - 1)
                            Dim prog As Integer = 0
                            Dim PRTh As Threading.Thread = New Threading.Thread(
                                Sub()
                                    While True
                                        RaiseEvent ProgressReport(prog / (ImageCount + FrameCount) * 10000, "加载 " & prog & "/" & (ImageCount + FrameCount))
                                        If prog >= ImageCount + FrameCount Then Exit While
                                        Threading.Thread.Sleep(100)
                                    End While
                                End Sub)
                            PRTh.Start()
                            Threading.Thread.Sleep(5000)
                            Parallel.For(0, ImageCount,
                                Sub(i As Integer)
                                    ImageLib(i) = New ImageConverter().ConvertFrom(IO.File.ReadAllBytes(TmpDir & "/Image\" & i & ".png"))
                                    ImageLib(i) = ImageLib(i).Clone(New Rectangle(New Point, ImageLib(i).Size), Imaging.PixelFormat.Format8bppIndexed)
                                    Threading.Interlocked.Add(prog, 1)
                                    GC.Collect()
                                End Sub)

                            Parallel.For(0, FrameCount,
                                Sub(i As Integer)
                                    CodeBefore(i) = My.Computer.FileSystem.ReadAllText(TmpDir & "/CB\" & i & ".txt")
                                    CodeAfter(i) = My.Computer.FileSystem.ReadAllText(TmpDir & "/CA\" & i & ".txt")
                                    ImageID(i) = My.Computer.FileSystem.ReadAllText(TmpDir & "/II\" & i & ".txt")
                                    ExposureTime(i) = My.Computer.FileSystem.ReadAllText(TmpDir & "/ET\" & i & ".txt")
                                    Threading.Interlocked.Add(prog, 1)
                                End Sub)
                        Else
                            TimingAbs = True
                            FrameCount = 0
                            Dim StartIndex As Integer = 1
                            If My.Computer.FileSystem.FileExists(TmpDir & "/" & 0 & ".png") Then StartIndex = 0
                            While True
                                If Not My.Computer.FileSystem.FileExists(TmpDir & "/" & FrameCount - 1 + StartIndex + 1 & ".png") Then
                                    Exit While
                                End If
                                FrameCount += 1
                            End While
                            Dim FileNameList() As String = {}

                            If FrameCount = 0 Then
                                For Each f As IO.FileInfo In My.Computer.FileSystem.GetDirectoryInfo(TmpDir).GetFiles
                                    If f.Extension.ToLower = ".png" Then
                                        ReDim Preserve FileNameList(FileNameList.Length)
                                        FileNameList(FileNameList.Length - 1) = f.Name
                                        FrameCount += 1
                                    End If
                                Next
                            Else
                                ReDim FileNameList(FrameCount - 1)
                                For i As Integer = 0 To FileNameList.Length - 1
                                    FileNameList(i) = i + StartIndex & ".png"
                                Next
                            End If
                            ImageCount = FrameCount
                            LineNumber = 0
                            ReDim ImageLib(ImageCount - 1)
                            ReDim CodeBefore(FrameCount - 1)
                            ReDim CodeAfter(FrameCount - 1)
                            ReDim ImageID(FrameCount - 1)
                            ReDim ExposureTime(FrameCount - 1)
                            Dim prog As Integer = 0
                            Dim PRTh As Threading.Thread = New Threading.Thread(
                                                           Sub()
                                                               While True
                                                                   RaiseEvent ProgressReport(prog / (FrameCount) * 10000, "加载 " & prog & "/" & (FrameCount))
                                                                   If prog >= FrameCount Then Exit While
                                                                   Threading.Thread.Sleep(100)
                                                               End While
                                                           End Sub)
                            PRTh.Start()
                            Parallel.For(0, ImageCount,
                                                           Sub(i As Integer)
                                                               ImageLib(i) = New ImageConverter().ConvertFrom(IO.File.ReadAllBytes(TmpDir & "/" & FileNameList(i)))
                                                               ImageLib(i) = ImageLib(i).Clone(New Rectangle(New Point, ImageLib(i).Size), Imaging.PixelFormat.Format8bppIndexed)
                                                               ImageID(i) = i
                                                               Threading.Interlocked.Add(prog, 1)
                                                               GC.Collect()
                                                           End Sub)
                        End If
                        Threading.Thread.MemoryBarrier()

                        LastFileName = FileName
                        My.Computer.FileSystem.DeleteDirectory(TmpDir, FileIO.DeleteDirectoryOption.DeleteAllContents)
                        If TimingAbs Then
                            RaiseEvent TimingAbsent()
                            Threading.Interlocked.Exchange(Loading, False)
                        Else
                            RaiseEvent ImageCountChanged()
                            RaiseEvent FrameCountChanged()
                            RaiseEvent ProgressFinished()
                            Threading.Interlocked.Exchange(Loading, False)
                            RaiseEvent LoadingFinished()
                        End If
                    Catch ex As Exception
                        RaiseEvent ExceptionOccured(ex)
                    End Try
                    If FinishedAction IsNot Nothing Then FinishedAction()
                End Sub)
            Threading.Interlocked.Exchange(Loading, True)
            th.Start()
            Return True
        Catch ex As Exception
            RaiseEvent ExceptionOccured(ex)
            Return False
        End Try
    End Function
    Public TmpDir As String = My.Computer.FileSystem.GetTempFileName()
    Public Function PartialLoad(ByVal FileName As String, Optional ByVal FinishedAction As Action = Nothing) As Boolean
        Dim DebugMSG As Boolean = True
        Try
            If Threading.Interlocked.Equals(Loading, True) Then Return False
            Dim th As New Threading.Thread(
                Sub()
                    Try
                        RaiseEvent LoadingStarted()
                        My.Computer.FileSystem.DeleteFile(TmpDir)
                        My.Computer.FileSystem.CreateDirectory(TmpDir)
                        If My.Computer.FileSystem.DirectoryExists(TmpDir) Then
                            My.Computer.FileSystem.DeleteDirectory(TmpDir, FileIO.DeleteDirectoryOption.DeleteAllContents)
                        End If
                        My.Computer.FileSystem.CreateDirectory(TmpDir)
                        RaiseEvent ProgressReport(2000, "正在解包...")
                        IO.Compression.ZipFile.ExtractToDirectory(FileName, TmpDir)
                        RaiseEvent ProgressReport(5000, "正在加载...")
                        Dim TimingAbs As Boolean = False
                        If My.Computer.FileSystem.FileExists(TmpDir & "/Info.txt") Then
                            Dim Info() As String = My.Computer.FileSystem.ReadAllText(TmpDir & "/Info.txt").Split({","}, StringSplitOptions.RemoveEmptyEntries)
                            ImageCount = Val(Info(0))
                            FrameCount = Val(Info(1))
                            LineNumber = Val(Info(2))
                            ReDim ImageLib(ImageCount - 1)
                            ReDim CodeBefore(FrameCount - 1)
                            ReDim CodeAfter(FrameCount - 1)
                            ReDim ImageID(FrameCount - 1)
                            ReDim ExposureTime(FrameCount - 1)
                            Dim prog As Integer = 0
                            Dim PRTh As Threading.Thread = New Threading.Thread(
                                Sub()
                                    While True
                                        RaiseEvent ProgressReport(prog / (ImageCount + FrameCount) * 10000, "加载 " & prog & "/" & (ImageCount + FrameCount))
                                        If prog >= ImageCount + FrameCount Then Exit While
                                        Threading.Thread.Sleep(100)
                                    End While
                                End Sub)
                            PRTh.Start()
                            Threading.Thread.Sleep(5000)
                            'Parallel.For(0, ImageCount,
                            '    Sub(i As Integer)
                            '        ImageLib(i) = New ImageConverter().ConvertFrom(IO.File.ReadAllBytes(TmpDir & "/Image\" & i & ".png"))
                            '        ImageLib(i) = ImageLib(i).Clone(New Rectangle(New Point, ImageLib(i).Size), Imaging.PixelFormat.Format8bppIndexed)
                            '        Threading.Interlocked.Add(prog, 1)
                            '        GC.Collect()
                            '    End Sub)
                            prog += ImageCount
                            Parallel.For(0, FrameCount,
                                Sub(i As Integer)
                                    CodeBefore(i) = My.Computer.FileSystem.ReadAllText(TmpDir & "/CB\" & i & ".txt")
                                    CodeAfter(i) = My.Computer.FileSystem.ReadAllText(TmpDir & "/CA\" & i & ".txt")
                                    ImageID(i) = My.Computer.FileSystem.ReadAllText(TmpDir & "/II\" & i & ".txt")
                                    ExposureTime(i) = My.Computer.FileSystem.ReadAllText(TmpDir & "/ET\" & i & ".txt")
                                    Threading.Interlocked.Add(prog, 1)
                                End Sub)
                        Else
                            TimingAbs = True
                            FrameCount = 0
                            While True
                                If Not My.Computer.FileSystem.FileExists(TmpDir & "/" & FrameCount + 1 & ".png") Then
                                    Exit While
                                End If
                                FrameCount += 1
                            End While
                            ImageCount = FrameCount
                            LineNumber = 0
                            ReDim ImageLib(ImageCount - 1)
                            ReDim CodeBefore(FrameCount - 1)
                            ReDim CodeAfter(FrameCount - 1)
                            ReDim ImageID(FrameCount - 1)
                            ReDim ExposureTime(FrameCount - 1)
                            Dim prog As Integer = 0
                            Dim PRTh As Threading.Thread = New Threading.Thread(
                                                           Sub()
                                                               While True
                                                                   RaiseEvent ProgressReport(prog / (FrameCount) * 10000, "加载 " & prog & "/" & (FrameCount))
                                                                   If prog >= FrameCount Then Exit While
                                                                   Threading.Thread.Sleep(100)
                                                               End While
                                                           End Sub)
                            PRTh.Start()
                            Parallel.For(0, ImageCount,
                                                           Sub(i As Integer)
                                                               ImageLib(i) = New ImageConverter().ConvertFrom(IO.File.ReadAllBytes(TmpDir & "/" & i + 1 & ".png"))
                                                               ImageLib(i) = ImageLib(i).Clone(New Rectangle(New Point, ImageLib(i).Size), Imaging.PixelFormat.Format8bppIndexed)
                                                               ImageID(i) = i
                                                               Threading.Interlocked.Add(prog, 1)
                                                               GC.Collect()
                                                           End Sub)
                        End If

                        LastFileName = FileName
                        If TimingAbs Then
                            RaiseEvent TimingAbsent()
                            Threading.Interlocked.Exchange(Loading, False)
                        Else
                            RaiseEvent ImageCountChanged()
                            RaiseEvent FrameCountChanged()
                            RaiseEvent ProgressFinished()
                            Threading.Interlocked.Exchange(Loading, False)
                            RaiseEvent LoadingFinished()
                        End If
                    Catch ex As Exception
                        RaiseEvent ExceptionOccured(ex)
                    End Try
                    If FinishedAction IsNot Nothing Then FinishedAction()
                End Sub)
            Threading.Interlocked.Exchange(Loading, True)
            th.Start()
            Return True
        Catch ex As Exception
            RaiseEvent ExceptionOccured(ex)
            Return False
        End Try
    End Function

    Public Function ETETime() As Long
        Dim ms As Integer = 0
        For i As Integer = LineNumber To FrameCount - 1
            ms += ExposureTime(i)
            Dim CB() As String = CodeBefore(i).Split({vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
            For j As Integer = 0 To CB.Length - 1
                If CB(j).StartsWith("%") Then
                    If CB(j).Replace(" ", "").StartsWith("%Sleep") Then
                        ms += Val(CB(j).Replace(" ", "").Replace("%Sleep", ""))
                    End If
                End If
            Next
            Dim CA() As String = CodeAfter(i).Split({vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
            For j As Integer = 0 To CA.Length - 1
                If CA(j).StartsWith("%") Then
                    If CA(j).Replace(" ", "").StartsWith("%Sleep") Then
                        ms += Val(CA(j).Replace(" ", "").Replace("%Sleep", ""))
                    End If
                End If
            Next
            ms += 10
        Next
        Return ms
    End Function
End Class
