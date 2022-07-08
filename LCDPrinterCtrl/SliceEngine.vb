
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.Threading.Tasks

Public Class STL
    Public Faces() As Triangle = {}
    Private _Minx, _Maxx, _Miny, _Maxy, _Minz, _Maxz As Double
    Private _Minxf, _Maxxf, _Minyf, _Maxyf, _Minzf, _Maxzf As Boolean
    Public IsBusy As Boolean = False
    Public Event ProgressReport(prog As Integer)
    Public Event LoadStarted()
    Public Event LoadFinished()
    Public Event ErrorOccured(ex As Exception)

    Public Sub New()
        ResetCache()
        Faces = {}
    End Sub

    Public Function Open(FileName As String) As Boolean
        If IO.File.Exists(FileName) Then
            Try
                RaiseEvent LoadStarted()
                Faces = {}
                ResetCache()
                Dim fs As New IO.FileStream(FileName, IO.FileMode.Open)
                Dim h(0) As Byte
                Dim ASCII As Boolean = True
                For i As Integer = 0 To fs.Length - 1
                    fs.Read(h, 0, 1)
                    If h(0) < 32 Or h(0) >= 127 Then
                        ASCII = False
                        Exit For
                    End If
                Next
                If ASCII Then
#Region "                ASCII"
                    fs.Close()
                    fs.Dispose()
                    Dim s() As String = My.Computer.FileSystem.ReadAllText(FileName).Split({" ", vbTab, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
                    Dim j As Integer = -1
                    Dim ProgMax As Integer = s.Length
                    For i As Integer = 0 To s.Length - 1
                        If s(i).ToLower = "normal" Then
                            j += 1
                            ReDim Preserve Faces(j)
                            Faces(j) = New Triangle With
                            {
                                .n = New Vector3DF With
                                {
                                    .x = Val(s(i + 1)),
                                    .y = Val(s(i + 2)),
                                    .z = Val(s(i + 3))
                                },
                                .p =
                                {
                                    New Point3DF With
                                    {
                                        .x = Val(s(i + 7)),
                                        .y = Val(s(i + 8)),
                                        .z = Val(s(i + 9))
                                    },
                                    New Point3DF With
                                    {
                                        .x = Val(s(i + 11)),
                                        .y = Val(s(i + 12)),
                                        .z = Val(s(i + 13))
                                    },
                                    New Point3DF With
                                    {
                                        .x = Val(s(i + 15)),
                                        .y = Val(s(i + 16)),
                                        .z = Val(s(i + 17))
                                    }
                                }
                            }
                            i += 18
                        End If
                        If i Mod (ProgMax \ 100) = 0 Then RaiseEvent ProgressReport(((i + 1) / ProgMax) * 10000)
                    Next
                    RaiseEvent ProgressReport(10000)
#End Region
                Else
#Region "                Binary"
                    fs.Position = 0
                    fs.Position = 80
                    Dim d(3) As Byte
                    fs.Read(d, 0, 4)
                    ReDim Faces(BitConverter.ToInt32(d, 0) - 1)
                    ReDim d(47)
                    Dim ProgMax As Integer = Faces.Length
                    For i As Integer = 0 To Faces.Length - 1
                        fs.Read(d, 0, 48)
                        Faces(i) = New Triangle With
                        {
                            .n = New Vector3DF With
                            {
                                .x = BitConverter.ToSingle(d, 0),
                                .y = BitConverter.ToSingle(d, 4),
                                .z = BitConverter.ToSingle(d, 8)
                            },
                            .p =
                            {
                                New Point3DF With
                                {
                                    .x = BitConverter.ToSingle(d, 12),
                                    .y = BitConverter.ToSingle(d, 16),
                                    .z = BitConverter.ToSingle(d, 20)
                                },
                                New Point3DF With
                                {
                                    .x = BitConverter.ToSingle(d, 24),
                                    .y = BitConverter.ToSingle(d, 28),
                                    .z = BitConverter.ToSingle(d, 32)
                                },
                                New Point3DF With
                                {
                                    .x = BitConverter.ToSingle(d, 36),
                                    .y = BitConverter.ToSingle(d, 40),
                                    .z = BitConverter.ToSingle(d, 44)
                                }
                            }
                        }
                        fs.Read(d, 0, 2)
                        If (ProgMax \ 100) > 0 Then
                            If i Mod (ProgMax \ 100) = 0 Then RaiseEvent ProgressReport((i + 1) / ProgMax * 10000)
                        End If
                    Next
                    RaiseEvent ProgressReport(10000)
#End Region
                End If
                ResetCache()
                RaiseEvent LoadFinished()
                Return True
            Catch ex As Exception
                RaiseEvent ErrorOccured(ex)
            End Try
        Else
            Return False
        End If
        Return Nothing
    End Function

    Public Sub FixNormal()
        For i As Integer = 0 To FaceCount - 1
            Faces(i).FixNormal()
        Next
    End Sub    'Rebulid Normal Vector

    Private Sub ResetCache()
        _Minxf = False
        _Maxxf = False
        _Minyf = False
        _Maxyf = False
        _Minzf = False
        _Maxzf = False
    End Sub

#Region "    Public ReadOnly Property MinMax"
    Public ReadOnly Property MinZ
        Get
            If _Minzf Then Return _Minz
            If Faces.Length = 0 Then Return 0
            Dim m As Double = Faces(0).p(0).z
            For i As Integer = 0 To Faces.Length - 1
                If m > Faces(i).p(0).z Then m = Faces(i).p(0).z
                If m > Faces(i).p(1).z Then m = Faces(i).p(1).z
                If m > Faces(i).p(2).z Then m = Faces(i).p(2).z
            Next
            _Minzf = True
            _Minz = m
            Return m
        End Get
    End Property

    Public ReadOnly Property MaxZ
        Get
            If _Maxzf Then Return _Maxz
            If Faces.Length = 0 Then Return 0
            Dim m As Double = Faces(0).p(0).z
            For i As Integer = 0 To Faces.Length - 1
                If m < Faces(i).p(0).z Then m = Faces(i).p(0).z
                If m < Faces(i).p(1).z Then m = Faces(i).p(1).z
                If m < Faces(i).p(2).z Then m = Faces(i).p(2).z
            Next
            _Maxzf = True
            _Maxz = m
            Return m
        End Get
    End Property

    Public ReadOnly Property MinX
        Get
            If _Minxf Then Return _Minx
            If Faces.Length = 0 Then Return 0
            Dim m As Double = Faces(0).p(0).x
            For i As Integer = 0 To Faces.Length - 1
                If m > Faces(i).p(0).x Then m = Faces(i).p(0).x
                If m > Faces(i).p(1).x Then m = Faces(i).p(1).x
                If m > Faces(i).p(2).x Then m = Faces(i).p(2).x
            Next
            _Minxf = True
            _Minx = m
            Return m
        End Get
    End Property

    Public ReadOnly Property MaxX
        Get
            If _Maxxf Then Return _Maxx
            If Faces.Length = 0 Then Return 0
            Dim m As Double = Faces(0).p(0).x
            For i As Integer = 0 To Faces.Length - 1
                If m < Faces(i).p(0).x Then m = Faces(i).p(0).x
                If m < Faces(i).p(1).x Then m = Faces(i).p(1).x
                If m < Faces(i).p(2).x Then m = Faces(i).p(2).x
            Next
            _Maxxf = True
            _Maxx = m
            Return m
        End Get
    End Property

    Public ReadOnly Property MinY
        Get
            If _Minyf Then Return _Miny
            If Faces.Length = 0 Then Return 0
            Dim m As Double = Faces(0).p(0).y
            For i As Integer = 0 To Faces.Length - 1
                If m > Faces(i).p(0).y Then m = Faces(i).p(0).y
                If m > Faces(i).p(1).y Then m = Faces(i).p(1).y
                If m > Faces(i).p(2).y Then m = Faces(i).p(2).y
            Next
            _Minyf = True
            _Miny = m
            Return m
        End Get
    End Property

    Public ReadOnly Property MaxY
        Get
            If _Maxyf Then Return _Maxy
            If Faces.Length = 0 Then Return 0
            Dim m As Double = Faces(0).p(0).y
            For i As Integer = 0 To Faces.Length - 1
                If m < Faces(i).p(0).y Then m = Faces(i).p(0).y
                If m < Faces(i).p(1).y Then m = Faces(i).p(1).y
                If m < Faces(i).p(2).y Then m = Faces(i).p(2).y
            Next
            _Maxyf = True
            _Maxy = m
            Return m
        End Get
    End Property
#End Region

    Public ReadOnly Property FaceCount As Integer
        Get
            Return Faces.Length
        End Get
    End Property

    Public Function Slice(z As Double) As Polygon3DF
        If z > MaxZ Or z < MinZ Then Return New Polygon3DF()
        Dim pf As New Polygon3DF
        Parallel.For(0, FaceCount,
                    Sub(i As Integer)
                        Dim l() As Line3DF = Faces(i).Intersect(z)
                        For j As Integer = 0 To l.Length - 1
                            If l(j) Is Nothing Then
                                Continue For
                            End If
                            If l(j).p(0) Is Nothing Or l(j).p(1) Is Nothing Then
                                Continue For
                            End If
                            If l(j).Length > Geometry.Epsilon Then
                                SyncLock pf
                                    pf.Add(l(j))
                                End SyncLock
                            End If
                        Next
                    End Sub)
        Return pf
    End Function
    Public Sub BeginSlice(z As Double, ByVal pf As Polygon3DF, ByVal ev As EventHandler)
        Dim th As New Threading.Thread(
            Sub()

                If z > MaxZ Or z < MinZ Then
                Else
                    Parallel.For(0, FaceCount,
                        Sub(i As Integer)
                            Dim l() As Line3DF = Faces(i).Intersect(z)
                            For j As Integer = 0 To l.Length - 1
                                If l(j) Is Nothing Then
                                    Continue For
                                End If
                                If l(j).p(0) Is Nothing Or l(j).p(1) Is Nothing Then
                                    Continue For
                                End If
                                If l(j).Length > Geometry.Epsilon Then
                                    SyncLock pf
                                        pf.Add(l(j))
                                    End SyncLock
                                End If
                            Next
                        End Sub)
                End If
                ev(Nothing, Nothing)
            End Sub)
        th.Start()
    End Sub

    Public Sub Move(v As Vector3DF)
        Parallel.For(0, FaceCount,
            Sub(i As Integer)
                Faces(i).p(0) += v
                Faces(i).p(1) += v
                Faces(i).p(2) += v
            End Sub)
        ResetCache()
    End Sub

    Public Sub CenterXY()
        Move(New Vector3DF(-(MaxX + MinX） / 2, -(MaxY + MinY） / 2, 0))
    End Sub

    Public Sub SitOnPlatform()
        Move(New Vector3DF(0, 0, -MinZ))
    End Sub

    Public Sub Transform(m As Matrix3)
        Dim prog As Integer = 0
        Dim thprog As New Threading.Thread(
            Sub()
                While prog < FaceCount
                    Threading.Thread.Sleep(100)
                    RaiseEvent ProgressReport(prog / FaceCount * 10000)
                End While
                RaiseEvent ProgressReport(10000)
            End Sub)
        thprog.Start()
        Parallel.For(0, FaceCount,
            Sub(i As Integer)
                Faces(i).p(0) *= m
                Faces(i).p(1) *= m
                Faces(i).p(2) *= m
                Faces(i).n = m * Faces(i).n
                Threading.Interlocked.Add(prog, 1)
            End Sub)
        ResetCache()
    End Sub
End Class

Public Class Geometry
    Public Const Epsilon As Double = 0.00000000000001
    Public Shared Function Pixel2Len(Src As Point, SrcSize As Size, TargetSize As SizeF) As PointF
        Return New PointF((Src.X - SrcSize.Width / 2) / SrcSize.Width * TargetSize.Width, (Src.Y - SrcSize.Height / 2) / SrcSize.Height * TargetSize.Height)
    End Function
    Public Shared Function Len2Pixel(Src As PointF, SrcSize As SizeF, TargetSize As Size) As Point
        Return New Point(Src.X / SrcSize.Width * TargetSize.Width + TargetSize.Width / 2, Src.Y / SrcSize.Height * TargetSize.Height + TargetSize.Height / 2)
    End Function
    Public Shared Function Pixel2Len(Src As Integer, SrcSize As Integer, TargetSize As Double) As Double
        Return (Src - SrcSize / 2) / SrcSize * TargetSize
    End Function
    Public Shared Function Len2Pixel(Src As Double, SrcSize As Double, TargetSize As Integer) As Integer
        Return Src / SrcSize * TargetSize + TargetSize / 2
    End Function
    Public Shared Sub DrawLine(ByRef b() As Byte, ByVal p1 As Point, ByVal p2 As Point, ByVal TargetCol As Byte, ByRef Stride As Integer, ByVal BytePerPixel As Integer, ByRef ImgSize As Rectangle)
        Dim x, y As Integer
        Dim sx, sy As Integer
        If p2.X < p1.X Then sx = -1 Else sx = 1
        If p2.Y < p1.Y Then sy = -1 Else sy = 1
        For x = Math.Min(ImgSize.Width - 1, Math.Max(0, p1.X)) To Math.Min(Math.Max(0, p2.X), ImgSize.Width - 1) Step sx
            If p2.X <> p1.X And x <> p1.X Then
                y = (p2.Y - p1.Y) / (p2.X - p1.X) * (x - p1.X) + p1.Y
            Else
                y = p1.Y
            End If
            If y < 0 Or y >= ImgSize.Height Then Continue For
            For k As Integer = 0 To BytePerPixel - 1
                b(y * Stride + x * BytePerPixel + k) = TargetCol
            Next
        Next
        For y = Math.Min(ImgSize.Height - 1, Math.Max(0, p1.Y)) To Math.Min(Math.Max(0, p2.Y), ImgSize.Height - 1) Step sy
            If p2.Y <> p1.Y And y <> p1.Y Then
                x = (p2.X - p1.X) / (p2.Y - p1.Y) * (y - p1.Y) + p1.X
            Else
                x = p1.X
            End If
            If x < 0 Or x >= ImgSize.Width Then Continue For
            For k As Integer = 0 To BytePerPixel - 1
                b(y * Stride + x * BytePerPixel + k) = TargetCol
            Next
        Next
    End Sub
End Class
Public Class Triangle
    Inherits Geometry
    Public p(2) As Point3DF
    Public n As Vector3DF
    Public Sub New()
        p(0) = New Point3DF
        p(1) = New Point3DF
        p(2) = New Point3DF
        n = New Vector3DF
    End Sub
    Public Function Intersect(Z As Double) As Line3DF()
        If Z < p(0).z And Z < p(1).z And Z < p(2).z Then Return {New Line3DF}
        If Z > p(0).z And Z > p(1).z And Z > p(2).z Then Return {New Line3DF}
        If Math.Abs(p(0).z - Z) < Epsilon And Math.Abs(p(1).z - Z) < Epsilon And Math.Abs(p(2).z - Z) < Epsilon Then
            Dim m As New Matrix3({{0, 1, 0}, {-1, 0, 0}, {0, 0, 0}})
            Dim n0, n1, n2 As Vector3DF
            n0 = m * (p(2) - p(1))
            If (p(1) - p(0)) ^ n0 < 0 Then n0 *= -1
            n1 = m * (p(2) - p(0))
            If (p(2) - p(1)) ^ n1 < 0 Then n1 *= -1
            n2 = m * (p(0) - p(1))
            If (p(1) - p(2)) ^ n2 < 0 Then n2 *= -1
            Return {New Line3DF(p(0), p(1), n2), New Line3DF(p(1), p(2), n0), New Line3DF(p(2), p(0), n1)}
        ElseIf Math.Abs(p(0).z - Z) < Epsilon Then
            Return {New Line3DF(p(0), New Line3DF(p(1), p(2)).IntersectZ(Z), n)}
        ElseIf Math.Abs(p(1).z - Z) < Epsilon Then
            Return {New Line3DF(p(1), New Line3DF(p(0), p(2)).IntersectZ(Z), n)}
        ElseIf Math.Abs(p(2).z - Z) < Epsilon Then
            Return {New Line3DF(p(2), New Line3DF(p(0), p(1)).IntersectZ(Z), n)}
        Else
            Return {New Line3DF(
                {
                    New Line3DF(p(0), p(1)).IntersectZ(Z),
                    New Line3DF(p(0), p(2)).IntersectZ(Z),
                    New Line3DF(p(2), p(1)).IntersectZ(Z)
                }, n)}
        End If
    End Function
    Public Sub FixNormal()
        n = (p(1) - p(0)) * (p(2) - p(0))
    End Sub
End Class
Public Class Polygon3DF
    Inherits Geometry
    Public Line() As Line3DF
    Public GroupIndex() As Integer
    Public ReadOnly Property GroupCount
        Get
            Dim m As Integer = GroupIndex(0)
            For i As Integer = 0 To GroupIndex.Length - 1
                If GroupIndex(i) > m Then m = GroupIndex(i)
            Next
            Return m
        End Get
    End Property
    Public Sub New()
        Line = {}
    End Sub
    Public Sub Add(l As Line3DF)
        SyncLock Line
            ReDim Preserve Line(Line.Length)
            Line(Line.Length - 1) = l.Clone
        End SyncLock
    End Sub
    Public Sub Add(l() As Line3DF)
        SyncLock Line
            ReDim Preserve Line(Line.Length - 1 + l.Length)
            For i As Integer = Line.Length - l.Length To Line.Length - 1
                Line(i) = l(i).Clone
            Next
        End SyncLock
    End Sub
    Public Sub Remove(i As UInteger)
        SyncLock Line
            If i < 0 Or i >= Line.Length Then Exit Sub
            Dim ll(Line.Length - 1) As Line3DF
            For j As Integer = 0 To i - 1
                ll(j) = Line(j)
            Next
            For j As Integer = i + 1 To Line.Length - 1
                ll(j - 1) = Line(j)
            Next
            Line = ll
        End SyncLock
    End Sub
    Public Sub Remove(i As UInteger, k As UInteger)
        SyncLock Line
            If i < 0 Or i >= Line.Length Then Exit Sub
            Dim ll(Line.Length - 1) As Line3DF
            For j As Integer = 0 To i - 1
                ll(j) = Line(j)
            Next
            For j As Integer = k + 1 To Line.Length - 1
                ll(j - 1) = Line(j)
            Next
            Line = ll
        End SyncLock
    End Sub
    Public Sub RemoveDuplicate()
        SyncLock Line
            Dim Flag(Line.Length - 1) As Boolean
            Dim FCount As Integer = 0
            Parallel.For(0, Line.Length - 1,
            Sub(i As Integer)
                For j As Integer = i + 1 To Line.Length - 1
                    If Flag(i) Then Continue For
                    If Line(i) = Line(j) Then
                        Flag(j) = True
                        Threading.Interlocked.Add(FCount, 1)
                    End If
                Next
            End Sub)
            If FCount = 0 Then Exit Sub
            Dim ll(Line.Length - 1 - FCount) As Line3DF
            Dim k As Integer = 0
            For i As Integer = 0 To Line.Length - 1
                If Not Flag(i) Then
                    ll(k) = Line(i)
                    k += 1
                End If
            Next
            Line = ll
        End SyncLock
    End Sub
    Public Sub Classify()
        RemoveDuplicate()
        SyncLock Line
            ReDim GroupIndex(Line.Length - 1)
            For i As Integer = 0 To Line.Length - 1
                GroupIndex(i) = i
            Next
            For i As Integer = 0 To Line.Length - 2
                For j As Integer = i + 1 To Line.Length - 1
                    If Line(i).p(0) = Line(j).p(1) Or Line(i).p(1) = Line(j).p(0) Or Line(i).p(0) = Line(j).p(0) Or Line(i).p(1) = Line(j).p(1) Then
                        Dim GIJTMP As Integer = GroupIndex(j)
                        For k As Integer = 0 To Line.Length - 1
                            If GroupIndex(k) = GIJTMP Then GroupIndex(k) = GroupIndex(i)
                        Next
                    End If
                Next
            Next
            Dim GExist(Line.Length - 1) As Boolean
            For i As Integer = 0 To Line.Length - 1
                GExist(GroupIndex(i)) = True
            Next
            Dim GCount As Integer = 0
            Dim GG(Line.Length - 1) As Integer
            For i As Integer = 0 To Line.Length - 1
                If GExist(i) Then
                    GG(i) = GCount
                    GCount += 1
                End If
            Next
            For i As Integer = 0 To Line.Length - 1
                GroupIndex(i) = GG(GroupIndex(i))
            Next
        End SyncLock
    End Sub
    Public Sub RenderZCrossEdge(b() As Byte, pColor As Byte, ByVal imgSize As Size, ByVal ScrSize As SizeF, ByVal Stride As Integer, ByVal BytePerPixel As Integer)
        SyncLock Line
            Parallel.For(0, Line.Count,
                Sub(i As Integer)
                    Dim pf1 As New PointF(Line(i).p(0).x, Line(i).p(0).y)
                    Dim pf2 As New PointF(Line(i).p(1).x, Line(i).p(1).y)
                    Dim p1 As Point = Len2Pixel(pf1, ScrSize, imgSize)
                    Dim p2 As Point = Len2Pixel(pf2, ScrSize, imgSize)
                    DrawLine(b, p1, p2, pColor, Stride, BytePerPixel, New Rectangle(New Point, imgSize))
                End Sub)
        End SyncLock
    End Sub
    Public Sub RenderZCrossSection(b() As Byte, pColor As Byte, ByVal imgSize As Size, ByVal ScrSize As SizeF, ByVal Stride As Integer, ByVal BytePerPixel As Integer)
        Dim pCount(imgSize.Width - 1, imgSize.Height - 1) As Integer
        Dim pMin(imgSize.Width - 1, imgSize.Height - 1) As Double
        Dim pMax(imgSize.Width - 1, imgSize.Height - 1) As Double
        Dim pMinFlag(imgSize.Width - 1, imgSize.Height - 1) As Byte
        Dim pMaxFlag(imgSize.Width - 1, imgSize.Height - 1) As Byte


        SyncLock Line
            Parallel.For(0, Line.Count,
                Sub(l As Integer)
                    If Math.Abs(Line(l).p(0).x - 12.0973) < 0.01 Then
                        l = l
                    End If
                    If Line(l).Length < Epsilon Then Exit Sub
                    If Math.Abs(Line(l).p(0).y - Line(l).p(1).y) < Epsilon Then Exit Sub

                    Dim p0, p1 As Point
                    p0 = Len2Pixel(Line(l).p(0), ScrSize, imgSize)
                    p1 = Len2Pixel(Line(l).p(1), ScrSize, imgSize)

                    Dim IntersectPoint As Point2DF
                    For j As Integer = Math.Min(p0.Y, p1.Y) To Math.Max(p0.Y, p1.Y)
                        If j < 0 Or j > imgSize.Height - 1 Then Continue For
                        IntersectPoint = Line(l).ProjectionIntersectY(Pixel2Len(j, imgSize.Height, ScrSize.Height))
                        If IntersectPoint IsNot Nothing Then
                            Dim aa As Integer = 1
                            If (IntersectPoint - Line(l).p(0).Projection()).Length < Epsilon Then aa = 0
                            If (IntersectPoint - Line(l).p(1).Projection()).Length < Epsilon Then aa = 0
                            Dim xx As Integer = Len2Pixel(IntersectPoint.x, ScrSize.Width, imgSize.Width)
                            If xx < 0 Or xx > imgSize.Width - 1 Then Continue For
                            If (xx = 1333 Or xx = 1308) And j = 365 Then
                                l = l
                            End If

                            If True Then
                                '算法一 根据法向量判断区域（要求法向量准确）
                                If Line(l).n.x < 0 Then
                                    pCount(xx, j) += aa
                                    If IntersectPoint.x < pMin(xx, j) Or pMinFlag(xx, j) = 0 Then
                                        pMin(xx, j) = IntersectPoint.x
                                        pMinFlag(xx, j) = 1
                                    End If
                                    If IntersectPoint.x > pMax(xx, j) Or pMaxFlag(xx, j) = 0 Then
                                        pMax(xx, j) = IntersectPoint.x
                                        pMaxFlag(xx, j) = 1
                                    End If
                                ElseIf Line(l).n.x > 0 Then
                                    pCount(xx, j) -= aa
                                    If IntersectPoint.x < pMin(xx, j) Or pMinFlag(xx, j) = 0 Then
                                        pMin(xx, j) = IntersectPoint.x
                                        pMinFlag(xx, j) = 255
                                    End If
                                    If IntersectPoint.x > pMax(xx, j) Or pMaxFlag(xx, j) = 0 Then
                                        pMax(xx, j) = IntersectPoint.x
                                        pMaxFlag(xx, j) = 255
                                    End If
                                End If
                            Else
                                '算法二 根据边界计算区域（要求单连通，且不超出范围）
                                For bi As Integer = xx To imgSize.Width - 1
                                    SyncLock pCount
                                        If pCount(bi, j) = 0 Then
                                            pCount(bi, j) = 1
                                        Else
                                            pCount(bi, j) *= -1
                                        End If
                                    End SyncLock
                                Next
                            End If

                        End If
                    Next
                End Sub)


            Parallel.For(0, imgSize.Height,
                Sub(j As Integer)
                    Dim flag As Boolean = False
                    For i As Integer = 0 To imgSize.Width - 1
                        If pMinFlag(i, j) = 1 And pMaxFlag(i, j) = 255 Then
                            pCount(i, j) = 0
                        ElseIf pMinFlag(i, j) = 255 And pMaxFlag(i, j) = 1 Then
                            pCount(i, j) = 0
                        ElseIf pMinFlag(i, j) = 1 Or pMaxFlag(i, j) = 1 Then
                            pCount(i, j) = 1
                        ElseIf pMinFlag(i, j) = 255 Or pMaxFlag(i, j) = 255 Then
                            pCount(i, j) = -1
                        End If
                        flag = pCount(i, j) > 0 Or (pCount(i, j) = 0 And flag)
                        If flag Then
                            For k As Integer = 0 To BytePerPixel - 1
                                b(j * Stride + i * BytePerPixel + k) = pColor
                            Next
                        End If
                    Next
                    flag = False
                    'For i As Integer = imgSize.Width - 1 To 0 Step -1
                    '    flag = pCount(i, j) < 0 Or (pCount(i, j) = 0 And flag)
                    '    If Not flag Then
                    '        For k As Integer = 0 To BytePerPixel - 1
                    '            b(j * Stride + i * BytePerPixel + k) = 0
                    '        Next
                    '    End If
                    'Next
                End Sub)
        End SyncLock


        'DebugLog-Line
        'My.Computer.FileSystem.WriteAllText("D:\Desktop\Debug.csv", "", False)
        'Dim o As String = ""
        'For i As Integer = 0 To Line.Length - 1
        '    o &= Line(i).p(0).x & vbTab & Line(i).p(0).y & vbTab & Line(i).p(0).z & vbTab & Line(i).p(1).x & vbTab & Line(i).p(1).y & vbTab & Line(i).p(1).z & vbTab & Line(i).n.x & vbTab & Line(i).n.y & vbTab & Line(i).n.z & vbCrLf
        '    If o.Length > 10000 Then
        '        My.Computer.FileSystem.WriteAllText("D:\Desktop\Debug.csv", o, True)
        '        o = ""
        '    End If
        'Next
        'My.Computer.FileSystem.WriteAllText("D:\Desktop\Debug.csv", o, True)


        'DebugLog-Flag
        'Dim o As String = ""
        'My.Computer.FileSystem.WriteAllText("D:\Desktop\Debug.csv", o, False)
        'For j As Integer = 0 To imgSize.Height - 1
        '    For i As Integer = 0 To imgSize.Width - 1
        '        o &= pCount(i, j) & vbTab
        '    Next
        '    o &= vbCrLf
        '    If o.Length > 10000 Then
        '        My.Computer.FileSystem.WriteAllText("D:\Desktop\Debug.csv", o, True)
        '        o = ""
        '    End If
        'Next
        'My.Computer.FileSystem.WriteAllText("D:\Desktop\Debug.csv", o, True)
    End Sub

#Region "Code from CreationWorkshop"
    'From CW Code
    Public Mirror As Boolean = False
    Public Sub RenderSlice(ByRef bmp As Bitmap, pColor As Color, ByVal imgSize As Size, ByVal ScrSize As SizeF, Optional ByVal OutlineOnly As Boolean = False, Optional ByVal Offset As Double = 0, Optional ByVal pColorOutLine As Color = Nothing)
        If Line Is Nothing Then Exit Sub
        Dim timestart As Date = Now

        If pColorOutLine.ToArgb = 0 Then pColorOutLine = pColor

        'Dim gd As BitmapData = bmp.LockBits(New Rectangle(New Point, bmp.Size), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed)
        'Dim imgStride As Integer = gd.Stride
        'Dim imgData(gd.Stride * gd.Height - 1) As Byte
        'bmp.UnlockBits(gd)

        Dim g As Graphics = Graphics.FromImage(bmp)


        Dim pen1 As New Pen(pColor, 1.0F)
        If ScrSize.Width * ScrSize.Height < 0 Then
            Mirror = True
        End If
        ScrSize = ImageTools.AbsSize(ScrSize)
        Dim lines As New List(Of Line2D)
        For Each l As Line3DF In Line
            lines.Add(New Line2D(Len2Pixel(New PointF(l.p(0).x, l.p(0).y), ScrSize, imgSize), Len2Pixel(New PointF(l.p(1).x, l.p(1).y), ScrSize, imgSize), l))
        Next
        If lines.Count <> 0 Then
            If OutlineOnly Then
                RenderOutlines(g, lines, pColorOutLine, imgSize, ScrSize, bmp)
                Exit Sub
            Else
                Render2dlines(g, lines, pColor, imgSize, ScrSize)
            End If
        Else
            Exit Sub
        End If
        Dim xmin, xmax, ymin, ymax As Integer
        xmin = lines(0).p1.X
        ymin = lines(0).p1.Y
        xmax = xmin
        ymax = ymin
        For Each l As Line2D In lines
            If l.p1.X < xmin Then xmin = l.p1.X
            If l.p2.X < xmin Then xmin = l.p2.X
            If l.p1.X > xmax Then xmax = l.p1.X
            If l.p2.X > xmax Then xmax = l.p2.X
            If l.p1.Y < ymin Then ymin = l.p1.Y
            If l.p2.Y < ymin Then ymin = l.p2.Y
            If l.p1.Y > ymax Then ymax = l.p1.Y
            If l.p2.Y > ymax Then ymax = l.p2.Y
        Next

        Dim timepoly As Date = Now

        Parallel.For(ymin, ymax,
            Sub(i As Integer)
                Dim point1 As New Point
                Dim point2 As New Point
                Dim list2 As New List(Of Line2D)
                For Each lined As Line2D In lines
                    If ((lined.p1.Y > i And lined.p2.Y <= i) Or (lined.p2.Y > i And lined.p1.Y <= i) Or (lined.p2.Y = i And lined.p1.Y = i)) Then
                        list2.Add(lined)
                    End If
                Next
                Dim intersectingPoints As New List(Of Point2D)
                For Each lined As Line2D In list2
                    Dim miny As Integer = Math.Min(lined.p1.Y, lined.p2.Y)
                    If lined.p1.Y = i And lined.p2.Y = i Then
                        If lined.p1.X < lined.p2.X Then
                            lined.p1.backfacing = True
                        Else
                            lined.p1.backfacing = False
                        End If
                        lined.p2.backfacing = Not lined.p1.backfacing
                        intersectingPoints.Add(lined.p1)
                        intersectingPoints.Add(lined.p2)

                    ElseIf lined.p1.Y = i Then
                        'If lined.p2.Y < i Then Continue For
                        'If lined.p1.Y = miny Then
                        lined.p1.backfacing = lined.parent.n.x < 0F
                        intersectingPoints.Add(lined.p1)
                        'End If
                    ElseIf lined.p2.Y = i Then
                        'If lined.p1.Y < i Then Continue For
                        'If lined.p2.Y = miny Then
                        lined.p2.backfacing = lined.parent.n.x < 0F
                        intersectingPoints.Add(lined.p2)
                        'End If
                    Else
                        Dim item As New Point2D
                        item.Y = i
                        If (lined.p2.Y - lined.p1.Y) <> 0 Then
                            item.X = (item.Y - lined.p1.Y) / (lined.p2.Y - lined.p1.Y) * (lined.p2.X - lined.p1.X) + lined.p1.X
                        Else
                            item.X = item.Y - lined.p1.Y + lined.p1.X
                        End If
                        item.parent = lined.parent
                        item.backfacing = lined.parent.n.x < 0F
                        'intersectingPoints.Add(item)
                        intersectingPoints.Add(item)
                    End If
                Next
                intersectingPoints.Sort()
                'SortBackfaces(intersectingPoints)
                'Dim DebugL2 As String = ""
                'For Each l As Line2D In list2
                '    DebugL2 &= l.p1.X & vbTab & l.p1.Y & vbTab & l.p2.X & vbTab & l.p2.Y & vbTab & vbCrLf
                'Next
                'Dim debugmsg As String = ""
                'For Each p As Point2D In intersectingPoints
                '    debugmsg &= p.X & vbTab & p.Y & vbTab & p.backfacing & vbCrLf
                'Next
                'If i = 840 Then
                '    i = 840
                'End If
                If False Then
                    'EvenOdd Algorithm
                    If intersectingPoints.Count Mod 2 = 0 Then
                        For j As Integer = 0 To intersectingPoints.Count - 1 Step 2
                            Dim pointd As Point2D = intersectingPoints(j)
                            Dim pointd2 As Point2D = intersectingPoints(j + 1)
                            point1.X = pointd.X
                            point1.Y = pointd.Y
                            point2.X = pointd2.X
                            point2.Y = pointd2.Y
                            SyncLock g
                                g.DrawLine(pen1, ImageTools.InvertPoint(point1.X, imgSize.Width, Mirror), point1.Y, ImageTools.InvertPoint(point2.X, imgSize.Width, Mirror), point2.Y)
                            End SyncLock
                        Next
                    Else
                        'MessageBox.Show("Row y=" & i & "odd points = " & intersectingPoints.Count & "! Model may contain holes.")
                    End If
                Else
                    'NormalCount Algorithm
                    Dim pointA, pointB As Point2D
                    pointA = Nothing
                    pointB = Nothing
                    Dim num5 As Integer = 0
                    If intersectingPoints.Count <> 0 Then
                        Dim drawmx As Integer = -1
                        For k As Integer = 0 To intersectingPoints.Count - 1
                            If intersectingPoints(k).backfacing Then
                                If num5 = 0 Then
                                    pointA = intersectingPoints(k)
                                End If
                                num5 += 1
                            Else
                                num5 -= 1
                                If num5 = 0 And pointA IsNot Nothing Then
                                    'If Not pointA.backfacing Then Continue For
                                    pointB = intersectingPoints(k)
                                    'point1.X = pointA.X
                                    'point1.Y = pointA.Y
                                    'point2.X = pointB.X
                                    'point2.Y = pointB.Y

                                    Dim x1 As Integer = ImageTools.InvertPoint(pointA.X, imgSize.Width, Mirror)
                                    Dim x2 As Integer = ImageTools.InvertPoint(pointB.X, imgSize.Width, Mirror)
                                    'If x1 > x2 Then ImageTools.Swap(x1, x2)
                                    If x1 < x2 Then
                                        SyncLock g
                                            g.DrawLine(pen1, x1, i, x2, i)
                                            drawmx = x2
                                        End SyncLock
                                    ElseIf x1 > x2 Then
                                        SyncLock g
                                            g.DrawLine(pen1, x2, i, x1, i)
                                            drawmx = x1
                                        End SyncLock
                                    Else
                                        If x1 <> drawmx Then
                                            SyncLock g
                                                g.DrawLine(pen1, x1, i, x2, i)
                                                drawmx = x2
                                            End SyncLock
                                        End If
                                    End If
                                    'For pp As Integer = x1 To x2
                                    '    imgData(pp + imgStride * point1.Y) = 255
                                    'Next

                                    pointA = pointB
                                    pointB = Nothing
                                    'num5 = 0
                                End If
                            End If
                        Next
                        If num5 <> 0 Then
                            If pointA IsNot Nothing Then
                                pointB = intersectingPoints(intersectingPoints.Count - 1)
                                'point1.X = pointA.X
                                'point1.Y = pointA.Y
                                'point2.X = pointB.X
                                'point2.Y = pointB.Y

                                Dim x1 As Integer = ImageTools.InvertPoint(pointA.X, imgSize.Width, Mirror)
                                Dim x2 As Integer = ImageTools.InvertPoint(pointB.X, imgSize.Width, Mirror)
                                'If x1 > x2 Then ImageTools.Swap(x1, x2)
                                If x1 <= x2 Then
                                    SyncLock g
                                        g.DrawLine(pen1, x1, i, x2, i)
                                    End SyncLock
                                Else
                                    SyncLock g
                                        g.DrawLine(pen1, x2, i, x1, i)
                                    End SyncLock
                                End If
                                'For pp As Integer = x1 To x2
                                '    imgData(pp + imgStride * point1.Y) = 255
                                'Next
                                pointA = pointB
                                pointB = Nothing
                            End If
                            'MessageBox.Show("Row y=" & i & "odd points = " & intersectingPoints.Count & "! Model may contain holes.")
                        End If
                    End If
                End If
            End Sub)
        Dim timefill As Date = Now
        'gd = bmp.LockBits(New Rectangle(New Point, bmp.Size), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed)
        'Marshal.Copy(imgData, 0, gd.Scan0, imgData.Length)
        'bmp.UnlockBits(gd)

        If Offset <> 0 Then
            Dim pen2 As Pen

            For Each ln As Line2D In lines

                Dim dy As Double = -(ln.p2.X - ln.p1.X)
                Dim dx As Double = ln.p2.Y - ln.p1.Y
                Dim l As Double = (dx ^ 2 + dy ^ 2) ^ 0.5
                If l = 0 Then l = 1
                dx /= l
                dy /= l
                dx *= Offset
                dy *= Offset
                dx *= imgSize.Width / Math.Abs(ScrSize.Width)
                dy *= imgSize.Height / Math.Abs(ScrSize.Height)
                Dim ofs As Integer = (dx ^ 2 + dy ^ 2) ^ 0.5
                If ofs = 0 Then ofs = Offset * imgSize.Width / Math.Abs(ScrSize.Width)
                If Offset < 0 Then
                    pen2 = New Pen(Color.Black, ofs)
                Else
                    pen2 = New Pen(pColor, ofs)
                End If

                Dim x1 As Integer = ImageTools.InvertPoint(ln.p1.X, imgSize.Width, Mirror)
                Dim x2 As Integer = ImageTools.InvertPoint(ln.p2.X, imgSize.Width, Mirror)
                g.DrawLine(pen2, x1, ln.p1.Y, x2, ln.p2.Y)
            Next
        End If
        Dim timeofs As Date = Now
        If pColor.ToArgb <> pColorOutLine.ToArgb Then RenderOutlines(g, lines, pColorOutLine, imgSize, ScrSize, bmp)
        Dim timeend As Date = Now
        'MessageBox.Show("Polygon:" & (timepoly - timestart).TotalMilliseconds & vbCrLf &
        '                "Fill:" & (timefill - timepoly).TotalMilliseconds & vbCrLf &
        '                "Offset:" & (timeofs - timefill).TotalMilliseconds & vbCrLf &
        '                "Outline:" & (timeend - timeofs).TotalMilliseconds)
    End Sub

    Public Sub RenderSliceSMAA(ByRef bmp As Bitmap, pColor As Color, ByVal imgSize As Size, ByVal ScrSize As SizeF, Optional ByVal Offset As Double = 0)
        If Line Is Nothing Then Exit Sub

    End Sub
    Public Sub SortBackfaces(points As List(Of Point2D))
        Dim num2 As Integer
        Dim backfacing As Boolean = False
        Dim i As Integer = 0
        While i < points.Count
            num2 = i + 1
            While (num2 < points.Count)
                If Not points(num2).X = points(i).X Then Exit While
                num2 += 1
            End While
            num2 -= 1
            If num2 > i Then
                For j As Integer = i To num2 - 1
                    If points(j).backfacing = backfacing Then
                        For k As Integer = j + 1 To num2
                            If points(k).backfacing <> backfacing Then
                                Dim pointd As Point2D = points(k)
                                points(k) = points(j)
                                points(j) = pointd
                            End If
                        Next
                    End If
                    backfacing = points(j).backfacing
                Next
            End If
            backfacing = points(num2).backfacing
            i = num2 + 1
        End While
    End Sub
    Public Sub Render2dlines(g As Graphics, lines As List(Of Line2D), pColor As Color, ByVal imgSize As Size, ByVal ScrSize As SizeF)
        Try
            Dim point1 As New Point
            Dim point2 As New Point
            Dim pen1 As New Pen(pColor, 1.0F)
            For Each lined As Line2D In lines
                Dim pointd1 As Point2D = lined.p1
                Dim pointd2 As Point2D = lined.p2
                point1.X = pointd1.X
                point1.Y = pointd1.Y
                point2.X = pointd2.X
                point2.Y = pointd2.Y
                g.DrawLine(pen1, ImageTools.InvertPoint(point1, imgSize.Width, Mirror), ImageTools.InvertPoint(point2, imgSize.Width, Mirror))
            Next
            pen1.Dispose()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub RenderOutlines(g As Graphics, ByRef lines As List(Of Line2D), pColor As Color, ByVal imgSize As Size, ByVal ScrSize As SizeF, ByVal SrcImg As Bitmap)
        Try
            Dim Orig As Bitmap = SrcImg.Clone
            Dim point1 As New Point
            Dim point2 As New Point
            Dim pen1 As New Pen(pColor, 1.0F)
            For Each lined As Line2D In lines
                Dim pointd1 As Point2D = lined.p1
                Dim pointd2 As Point2D = lined.p2
                point1.X = pointd1.X
                point1.Y = pointd1.Y
                point2.X = pointd2.X
                point2.Y = pointd2.Y
                g.DrawLine(pen1, ImageTools.InvertPoint(point1, imgSize.Width, Mirror), ImageTools.InvertPoint(point2, imgSize.Width, Mirror))
            Next
            pen1.Dispose()
            If True Then
                Dim gc1 As BitmapData = SrcImg.LockBits(New Rectangle(New Point, SrcImg.Size), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb)
                Dim gc2 As BitmapData = Orig.LockBits(New Rectangle(New Point, Orig.Size), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb)
                Dim b1(gc1.Stride * SrcImg.Height - 1) As Byte
                Dim b2(gc2.Stride * Orig.Height - 1) As Byte
                Marshal.Copy(gc1.Scan0, b1, 0, b1.Length - 1)
                Marshal.Copy(gc2.Scan0, b2, 0, b2.Length - 1)
                Dim w As Integer = SrcImg.Width
                Dim h As Integer = SrcImg.Height
                Dim Stride As Integer = gc1.Stride
                Parallel.For(0, h,
                    Sub(y As Integer)
                        For x As Integer = 0 To w - 1
                            Dim Boundary As Boolean = False
                            'If x > 0 And y > 0 Then
                            '    If b2((x - 1) * 3 + (y - 1) * Stride) = 0 Then
                            '        Boundary = True
                            '    End If
                            'End If
                            If y > 0 Then
                                If b2((x) * 3 + (y - 1) * Stride) = 0 Then
                                    Continue For
                                    Boundary = True
                                End If
                            End If
                            'If x < w - 1 And y > 0 Then
                            '    If b2((x + 1) * 3 + (y - 1) * Stride) = 0 Then
                            '        Boundary = True
                            '    End If
                            'End If
                            If x > 0 Then
                                If b2((x - 1) * 3 + (y) * Stride) = 0 Then
                                    Continue For
                                    Boundary = True
                                End If
                            End If
                            If x < w - 1 Then
                                If b2((x + 1) * 3 + (y) * Stride) = 0 Then
                                    Continue For
                                    Boundary = True
                                End If
                            End If
                            'If x > 0 And y < h - 1 Then
                            '    If b2((x - 1) * 3 + (y + 1) * Stride) = 0 Then
                            '        Boundary = True
                            '    End If
                            'End If
                            If y < h - 1 Then
                                If b2((x) * 3 + (y + 1) * Stride) = 0 Then
                                    Continue For
                                    Boundary = True
                                End If
                            End If
                            'If x < w - 1 And y < h - 1 Then
                            '    If b2((x + 1) * 3 + (y + 1) * Stride) = 0 Then
                            '        Boundary = True
                            '    End If
                            'End If
                            If Not Boundary Then
                                b1(x * 3 + y * Stride) = b2(x * 3 + y * Stride)
                                b1(x * 3 + y * Stride + 1) = b2(x * 3 + y * Stride + 1)
                                b1(x * 3 + y * Stride + 2) = b2(x * 3 + y * Stride + 2)
                            End If
                        Next
                    End Sub)
                Marshal.Copy(b1, 0, gc1.Scan0, b1.Length)
                SrcImg.UnlockBits(gc1)
                Orig.UnlockBits(gc2)
                SrcImg = SrcImg.Clone(New Rectangle(New Point, SrcImg.Size), PixelFormat.Format1bppIndexed)
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region
End Class
Public Class Polygon2DF
    Inherits Geometry
    Public Line() As Line2DF
    Public Sub New()
        Line = {}
    End Sub
    Public Sub New(pg3d As Polygon3DF)
        ReDim Line(pg3d.Line.Length - 1)
        For i As Integer = 0 To pg3d.Line.Length - 1
            Line(i) = New Line2DF(New Point2DF(pg3d.Line(i).p(0).x, pg3d.Line(i).p(0).y), New Point2DF(pg3d.Line(i).p(1).x, pg3d.Line(i).p(1).y), pg3d.Line(i).n)
        Next
    End Sub
    Public Sub RenderEdge(b() As Byte, pColor As Byte, ByVal imgSize As Size, ByVal ScrSize As SizeF, ByVal Stride As Integer, ByVal BytePerPixel As Integer)
        Parallel.For(0, Line.Count,
            Sub(i As Integer)
                Dim pf1 As New PointF(Line(i).p(0).x, Line(i).p(0).y)
                Dim pf2 As New PointF(Line(i).p(1).x, Line(i).p(1).y)
                Dim p1 As Point = Len2Pixel(pf1, ScrSize, imgSize)
                Dim p2 As Point = Len2Pixel(pf2, ScrSize, imgSize)
                DrawLine(b, p1, p2, pColor, Stride, BytePerPixel, New Rectangle(New Point, imgSize))
            End Sub)
    End Sub
    Public Sub RenderCrossSection(b() As Byte, pColor As Byte, ByVal imgSize As Size, ByVal ScrSize As SizeF, ByVal Stride As Integer, ByVal BytePerPixel As Integer)
        Dim pCount(imgSize.Width - 1, imgSize.Height - 1) As Integer
        Parallel.For(0, Line.Count,
            Sub(l As Integer)
                If Line(l).Length < Epsilon Then Exit Sub
                If Math.Abs(Line(l).p(0).y - Line(l).p(1).y) < Epsilon Then Exit Sub
                Dim p0, p1 As Point
                p0 = Len2Pixel(Line(l).p(0), ScrSize, imgSize)
                p1 = Len2Pixel(Line(l).p(1), ScrSize, imgSize)
                Dim IntersectPoint As Point2DF
                For j As Integer = Math.Min(p0.Y, p1.Y) To Math.Max(p0.Y, p1.Y)
                    If j < 0 Or j > imgSize.Height - 1 Then Continue For
                    IntersectPoint = Line(l).IntersectY(Pixel2Len(j, imgSize.Height, ScrSize.Height))
                    If IntersectPoint IsNot Nothing Then
                        Dim xx As Integer = Len2Pixel(IntersectPoint.x, ScrSize.Width, imgSize.Width)
                        If xx < 0 Or xx > imgSize.Width - 1 Then Continue For
                        If Line(l).n ^ New Vector2DF(1, 0) < 0 Then
                            pCount(xx, j) += 1
                        Else
                            pCount(xx, j) -= 1
                        End If
                    End If
                Next
            End Sub)
        Parallel.For(0, imgSize.Height,
            Sub(j As Integer)
                Dim flag As Boolean = False
                For i As Integer = 0 To imgSize.Width - 1
                    flag = pCount(i, j) > 0 Or (pCount(i, j) = 0 And flag)
                    If flag Then
                        For k As Integer = 0 To BytePerPixel - 1
                            b(j * Stride + i * BytePerPixel + k) = pColor
                        Next
                    End If
                Next
                flag = False
                For i As Integer = imgSize.Width - 1 To 0 Step -1
                    flag = pCount(i, j) < 0 Or (pCount(i, j) = 0 And flag)
                    If Not flag Then
                        For k As Integer = 0 To BytePerPixel - 1
                            b(j * Stride + i * BytePerPixel + k) = 0
                        Next
                    End If
                Next
            End Sub)
    End Sub
End Class
Public Class Point3DF
    Inherits Geometry
    Public x, y, z As Double
    Public Sub New()
        x = 0
        y = 0
        z = 0
    End Sub
    Public Sub New(xx As Double, yy As Double, zz As Double)
        x = xx
        y = yy
        z = zz
    End Sub
    Public Shared Operator +(a As Point3DF, b As Vector3DF) As Point3DF
        Return New Point3DF(a.x + b.x, a.y + b.y, a.z + b.z)
    End Operator
    Public Shared Operator -(a As Point3DF, b As Vector3DF) As Point3DF
        Return New Point3DF(a.x - b.x, a.y - b.y, a.z - b.z)
    End Operator
    Public Shared Operator -(a As Point3DF, b As Point3DF) As Vector3DF
        Return New Vector3DF(a.x - b.x, a.y - b.y, a.z - b.z)
    End Operator
    Public Shared Operator -(a As Point3DF) As Point3DF
        Return New Point3DF(-a.x, -a.y, -a.z)
    End Operator
    Public Shared Operator /(a As Point3DF, b As Double) As Point3DF
        Return New Point3DF(a.x / b, a.y / b, a.z / b)
    End Operator
    Public Shared Operator *(a As Point3DF, b As Double) As Point3DF
        Return New Point3DF(a.x * b, a.y * b, a.z * b)
    End Operator
    Public Shared Operator *(m As Matrix3, b As Point3DF) As Point3DF
        Return New Point3DF(b.x * m.Data(0, 0) + b.y * m.Data(1, 0) + b.z * m.Data(2, 0), b.x * m.Data(0, 1) + b.y * m.Data(1, 1) + b.z * m.Data(2, 1), b.x * m.Data(0, 2) + b.y * m.Data(1, 2) + b.z * m.Data(2, 2))
    End Operator
    Public Shared Operator *(b As Point3DF, m As Matrix3) As Point3DF
        Return m * b
    End Operator
    Public Shared Operator =(a As Point3DF, b As Point3DF) As Boolean
        Return (a - b).Length <= Epsilon
    End Operator
    Public Shared Operator <>(a As Point3DF, b As Point3DF) As Boolean
        Return Not a = b
    End Operator
    Public Function Projection() As Point2DF
        Return New Point2DF(x, y)
    End Function
    Public Function Clone() As Point3DF
        Return New Point3DF(x, y, z)
    End Function

    Public Shared Widening Operator CType(v As Point3DF) As PointF
        Return New PointF(v.x, v.y)
    End Operator
    Public Shared Widening Operator CType(v As PointF) As Point3DF
        Return New Point3DF(v.X, v.Y, 0)
    End Operator
    Public Shared Widening Operator CType(v As Point2DF) As Point3DF
        Return New Point3DF(v.x, v.y, 0)
    End Operator
End Class
Public Class Point3DInt
    Inherits Point3DF
    Public Shadows x, y, z As Integer
End Class
Public Class Point2DF
    Inherits Geometry
    Public x, y As Double
    Public Sub New()
        x = 0
        y = 0
    End Sub
    Public Sub New(xx As Double, yy As Double)
        x = xx
        y = yy
    End Sub
    Public Function Clone() As Point2DF
        Return New Point2DF(x, y)
    End Function
    Public Shared Operator +(a As Point2DF, b As Vector2DF) As Point2DF
        Return New Point2DF(a.x + b.x, a.y + b.y)
    End Operator
    Public Shared Operator -(a As Point2DF, b As Vector2DF) As Point2DF
        Return New Point2DF(a.x - b.x, a.y - b.y)
    End Operator
    Public Shared Operator -(a As Point2DF, b As Point2DF) As Vector2DF
        Return New Vector2DF(a.x - b.x, a.y - b.y)
    End Operator
    Public Shared Operator -(a As Point2DF) As Point2DF
        Return New Point2DF(-a.x, -a.y)
    End Operator
    Public Shared Operator /(a As Point2DF, b As Double) As Point2DF
        Return New Point2DF(a.x / b, a.y / b)
    End Operator
    Public Shared Operator *(a As Point2DF, b As Double) As Point2DF
        Return New Point2DF(a.x * b, a.y * b)
    End Operator
    Public Overloads Shared Operator *(m As Matrix2, b As Point2DF) As Point2DF
        Return New Point2DF(b.x * m.Data(0, 0) + b.y * m.Data(1, 0), b.x * m.Data(0, 1) + b.y * m.Data(1, 1))
    End Operator
    Public Overloads Shared Operator *(b As Point2DF, m As Matrix2) As Point2DF
        Return m * b
    End Operator
    Public Shared Operator =(a As Point2DF, b As Point2DF) As Boolean
        Return (a - b).Length <= Epsilon
    End Operator
    Public Shared Operator <>(a As Point2DF, b As Point2DF) As Boolean
        Return Not a = b
    End Operator
    Public Shared Widening Operator CType(v As Point2DF) As PointF
        Return New PointF(v.x, v.y)
    End Operator
    Public Shared Widening Operator CType(v As PointF) As Point2DF
        Return New Point2DF(v.X, v.Y)
    End Operator
    Public Shared Widening Operator CType(v As Point3DF) As Point2DF
        Return New Point2DF(v.x, v.y)
    End Operator
End Class
Public Class Vector3DF
    Inherits Point3DF
    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(xx As Double, yy As Double, zz As Double)
        MyBase.New(xx, yy, zz)
    End Sub
    Public Overloads Shared Operator +(a As Vector3DF, b As Vector3DF) As Vector3DF
        Return New Vector3DF(a.x + b.x, a.y + b.y, a.z + b.z)
    End Operator
    Public Overloads Shared Operator -(a As Vector3DF, b As Vector3DF) As Vector3DF
        Return New Vector3DF(a.x - b.x, a.y - b.y, a.z - b.z)
    End Operator
    Public Overloads Shared Operator -(a As Vector3DF) As Vector3DF
        Return New Vector3DF(-a.x, -a.y, -a.z)
    End Operator
    Public Overloads Shared Operator /(a As Vector3DF, b As Double) As Vector3DF
        Return New Vector3DF(a.x / b, a.y / b, a.z / b)
    End Operator
    Public Overloads Shared Operator *(a As Vector3DF, b As Double) As Vector3DF
        Return New Vector3DF(a.x * b, a.y * b, a.z * b)
    End Operator
    Public Overloads Shared Operator *(a As Vector3DF, b As Vector3DF) As Vector3DF
        Return New Vector3DF(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x)
    End Operator
    Public Overloads Shared Operator *(m As Matrix3, b As Vector3DF) As Vector3DF
        Return New Vector3DF(b.x * m.Data(0, 0) + b.y * m.Data(1, 0) + b.z * m.Data(2, 0), b.x * m.Data(0, 1) + b.y * m.Data(1, 1) + b.z * m.Data(2, 1), b.x * m.Data(0, 2) + b.y * m.Data(1, 2) + b.z * m.Data(2, 2))
    End Operator
    Public Overloads Shared Operator *(b As Vector3DF, m As Matrix3) As Vector3DF
        Return m * b
    End Operator
    Public Shared Operator ^(a As Vector3DF, b As Vector3DF) As Double
        Return a.x * b.x + a.y * b.y + a.z * b.z
    End Operator
    Public Overloads Shared Widening Operator CType(v As Vector2DF) As Vector3DF
        Return New Vector3DF(v.x, v.y, 0)
    End Operator
    Public Overloads Function Projection() As Vector2DF
        Return New Vector2DF(x, y)
    End Function
    Public Overloads Function Clone() As Vector3DF
        Return New Vector3DF(x, y, z)
    End Function
    Public Function Length() As Double
        Return (x ^ 2 + y ^ 2 + z ^ 2) ^ 0.5
    End Function
End Class
Public Class Vector3DInt
    Inherits Vector3DF
    Public Shadows x, y, z As Integer
End Class
Public Class Vector2DF
    Inherits Point2DF
    Public Sub New()
        x = 0
        y = 0
    End Sub
    Public Sub New(xx As Double, yy As Double)
        x = xx
        y = yy
    End Sub
    Public Overloads Shared Operator +(a As Vector2DF, b As Vector2DF) As Vector2DF
        Return New Vector2DF(a.x + b.x, a.y + b.y)
    End Operator
    Public Overloads Shared Operator -(a As Vector2DF, b As Vector2DF) As Vector2DF
        Return New Vector2DF(a.x - b.x, a.y - b.y)
    End Operator
    Public Overloads Shared Operator -(a As Vector2DF) As Vector2DF
        Return New Vector2DF(-a.x, -a.y)
    End Operator
    Public Overloads Shared Operator /(a As Vector2DF, b As Double) As Vector2DF
        Return New Vector2DF(a.x / b, a.y / b)
    End Operator
    Public Overloads Shared Operator *(a As Vector2DF, b As Double) As Vector2DF
        Return New Vector2DF(a.x * b, a.y * b)
    End Operator
    Public Shared Operator ^(a As Vector2DF, b As Vector2DF) As Double
        Return a.x * b.x + a.y * b.y
    End Operator
    Public Overloads Shared Operator *(m As Matrix2, b As Vector2DF) As Vector2DF
        Return New Vector2DF(b.x * m.Data(0, 0) + b.y * m.Data(1, 0), b.x * m.Data(0, 1) + b.y * m.Data(1, 1))
    End Operator
    Public Overloads Shared Operator *(b As Vector2DF, m As Matrix2) As Vector2DF
        Return m * b
    End Operator
    Public Overloads Function Clone() As Vector2DF
        Return New Vector2DF(x, y)
    End Function
    Public Overloads Shared Widening Operator CType(v As Vector3DF) As Vector2DF
        Return New Vector2DF(v.x, v.y)
    End Operator
    Public Overloads Shared Widening Operator CType(v As Vector2DF) As PointF
        Return New PointF(v.x, v.y)
    End Operator
    Public Function Length() As Double
        Return (x ^ 2 + y ^ 2) ^ 0.5
    End Function
End Class
Public Class Line3DF
    Inherits Geometry
    Public p(1) As Point3DF
    Public n As Vector3DF
    Public ReadOnly Property IsEmpty
        Get
            If p(0) = p(1) Then Return True Else Return False
        End Get
    End Property
    Public Sub New()
        p(0) = New Point3DF
        p(1) = New Point3DF
        n = New Vector3DF
    End Sub
    Public Sub New(p0 As Point3DF, p1 As Point3DF)
        If p0 IsNot Nothing Then
            p(0) = p0.Clone
        Else
            p(0) = New Point3DF
        End If
        If p1 IsNot Nothing Then
            p(1) = p1.Clone
        Else
            p(1) = p(0).Clone
        End If
    End Sub
    Public Sub New(p0 As Point3DF, p1 As Point3DF, nn As Vector3DF)
        Me.New(p0, p1)
        Dim v1 As Vector3DF = p(1) - p(0)
        v1 *= New Matrix3({{0, 1, 0}, {-1, 0, 0}, {0, 0, 0}})
        If v1 ^ nn < 0 Then v1 *= -1
        n = v1
    End Sub
    Public Sub New(pp() As Point3DF)
        If pp Is Nothing Then
            p(0) = New Point3DF
            p(1) = New Point3DF
        Else
            Dim j As Integer = 0
            For i As Integer = 0 To pp.Length - 1
                If pp(i) IsNot Nothing Then
                    p(j) = pp(i).Clone
                    j += 1
                End If
                If j >= 2 Then Exit For
            Next
            While j < 2
                p(j) = New Point3DF
                j += 1
            End While
        End If
    End Sub
    Public Sub New(pp() As Point3DF, nn As Vector3DF)
        Me.New(pp)
        Dim v1 As Vector3DF = p(1) - p(0)
        v1 *= New Matrix3({{0, 1, 0}, {-1, 0, 0}, {0, 0, 0}})
        If v1 ^ nn < 0 Then v1 *= -1
        n = v1
    End Sub
    Public Function Clone() As Line3DF
        Return New Line3DF(p(0), p(1), n)
    End Function
    Public Function IntersectZ(ByVal z As Double) As Point3DF
        If z < p(0).z And z < p(1).z Then Return Nothing
        If z > p(0).z And z > p(1).z Then Return Nothing
        'If z = p(0).z And z > p(1).z Then Return Nothing
        'If z = p(1).z And z > p(0).z Then Return Nothing
        If p(0).z = p(1).z Then
            Return Nothing
            'Return p(0)
        ElseIf (math.Abs(p(1).z - z) < Epsilon And p(0).z < z) Or (math.Abs(p(0).z - z) < Epsilon And p(1).z < z) Then
            Return Nothing
        Else
            Return p(0) + (p(1) - p(0)) / (p(1).z - p(0).z) * (z - p(0).z)
        End If
    End Function
    Public Function ProjectionIntersectY(ByVal y As Double) As Point2DF
        Dim x1, y1, x2, y2 As Double
        If p(0).y < p(1).y Then
            x1 = p(0).x
            y1 = p(0).y
            x2 = p(1).x
            y2 = p(1).y
        Else
            x1 = p(1).x
            y1 = p(1).y
            x2 = p(0).x
            y2 = p(0).y
        End If
        If y < y1 - Epsilon Or y > y2 + Epsilon Then Return Nothing
        If y1 = y2 Then Return Nothing
        Return New Point2DF((y - y1) / (y2 - y1) * (x2 - x1) + x1, y)
    End Function
    Public Function Length() As Double
        Return (p(0) - p(1)).Length
    End Function
    Public Shared Operator =(a As Line3DF, b As Line3DF) As Boolean
        Return (a.p(0) = b.p(0) And a.p(1) = b.p(1)) Or (a.p(0) = b.p(1) And a.p(1) = b.p(0))
    End Operator
    Public Shared Operator <>(a As Line3DF, b As Line3DF) As Boolean
        Return Not a = b
    End Operator

End Class
Public Class Line2DF
    Inherits Geometry
    Public p(1) As Point2DF
    Public n As Vector2DF
    Public Sub New()
        p = {New Point2DF, New Point2DF}
    End Sub
    Public Sub New(p1 As Point2DF, p2 As Point2DF)
        p = {p1.Clone, p2.Clone}
    End Sub
    Public Sub New(pp() As Point2DF)
        If pp Is Nothing Then
            p = {New Point2DF, New Point2DF}
        ElseIf pp.Length >= 2 Then
            p = {pp(0).Clone, pp(1).Clone}
        ElseIf pp.Length = 0 Then
            p = {New Point2DF, New Point2DF}
        ElseIf pp.Length = 1 Then
            p = {pp(0).Clone, New Point2DF}
        Else
            p = {New Point2DF, New Point2DF}
        End If
    End Sub
    Public Sub New(p1 As Point2DF, p2 As Point2DF, nn As Vector2DF)
        Me.New(p1, p2)
        n = nn.Clone()
    End Sub
    Public Function Length()
        Return (p(0) - p(1)).Length
    End Function
    Public Function IntersectY(ByVal y As Double) As Point2DF
        Dim x1, y1, x2, y2 As Double
        If p(0).y < p(1).y Then
            x1 = p(0).x
            y1 = p(0).y
            x2 = p(1).x
            y2 = p(1).y
        Else
            x1 = p(1).x
            y1 = p(1).y
            x2 = p(0).x
            y2 = p(0).y
        End If
        If y < y1 Or y > y2 Then Return Nothing
        If y1 = y2 Then Return Nothing
        Return New Point2DF((y - y1) / (y2 - y1) * (x2 - x1) + x1, y)
    End Function
End Class
Public Class Line2D
    Inherits Geometry
    Public p1 As New Point2D
    Public p2 As New Point2D
    Public parent As Line3DF
    Public Sub New(a As Point2D, b As Point2D)
        p1 = a
        p2 = b
    End Sub
    Public Sub New(a As Point2D, b As Point2D, pr As Line3DF)
        p1 = a
        p2 = b
        parent = pr
    End Sub
End Class
Public Class Point2D
    Inherits Geometry
    Implements IComparable
    Public X, Y As Integer
    Public backfacing As Boolean
    Public parent As Line3DF
    Public Sub New()
        X = 0
        Y = 0
    End Sub
    Public Sub New(a As Integer, b As Integer)
        X = a
        Y = b
    End Sub
    Public Sub New(p As Point)
        X = p.X
        Y = p.Y
    End Sub
    Public Shared Widening Operator CType(ByVal p As Point) As Point2D
        Return New Point2D(p)
    End Operator

    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        Dim pointd As Point2D = CType(obj, Point2D)
        If pointd.X > X Then
            Return -1
        ElseIf pointd.X < X Then
            Return 1
        Else
            Return 0
        End If
    End Function
End Class
Public Class Plane3DF
    Inherits Geometry
    Private _p As Point3DF, _v As Vector3DF
    Public Sub New()
        _p = New Point3DF
        _v = New Vector3DF
    End Sub
    Public Property p As Point3DF
        Set(value As Point3DF)
            _p = p
        End Set
        Get
            Return _p
        End Get
    End Property
    Public Property v As Vector3DF
        Set(value As Vector3DF)
            _v = v
        End Set
        Get
            Return _v
        End Get
    End Property
End Class
Public Class Matrix3
    Inherits Geometry
    Public Data(2, 2) As Double
    Public Sub New()
        Data = {{0, 0, 0}, {0, 0, 0}, {0, 0, 0}}
    End Sub
    Public Sub New(p(,) As Double)
        Data = p
    End Sub
End Class
Public Class Matrix2
    Inherits Geometry
    Public Data(1, 1) As Double
    Public Sub New()
        Data = {{0, 0}, {0, 0}}
    End Sub
    Public Sub New(p(,) As Double)
        Data = p
    End Sub
End Class
Public Class ImageTools
    Public Shared Function GreyCompressToRGB(ByVal imgsrc As Bitmap) As Bitmap
        If imgsrc Is Nothing Then Return Nothing
        Dim ParallelOption As New ParallelOptions
        If My.Settings.EnableParallelProcessing Then
            ParallelOption.MaxDegreeOfParallelism = Environment.ProcessorCount
        Else
            ParallelOption.MaxDegreeOfParallelism = My.Settings.MaximumThreads
        End If
        imgsrc = imgsrc.Clone(New Rectangle(New Point(), imgsrc.Size), Imaging.PixelFormat.Format24bppRgb)
        Dim sz As Size = imgsrc.Size
        Dim g1 As BitmapData = imgsrc.LockBits(New Rectangle(New Point(), sz), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb)
        Dim b1(g1.Stride * sz.Height - 1) As Byte
        Marshal.Copy(g1.Scan0, b1, 0, b1.Length)
        Dim imgconv As New Bitmap(sz.Width, (sz.Height + 2) \ 3, Imaging.PixelFormat.Format24bppRgb)
        Dim g2 As BitmapData = imgconv.LockBits(New Rectangle(New Point(), imgconv.Size), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb)
        Dim b2(g2.Stride * imgconv.Height - 1) As Byte
        Parallel.For(0, (sz.Height + 2) \ 3,
            Sub(y As Integer)
                For x As Integer = 0 To sz.Width - 1
                    b2(y * g2.Stride + x * 3 + 2) = b1((y * 3 + 0) * g1.Stride + x * 3)
                    If y * 3 + 1 < sz.Height Then b2(y * g2.Stride + x * 3 + 1) = b1((y * 3 + 1) * g1.Stride + x * 3)
                    If y * 3 + 2 < sz.Height Then b2(y * g2.Stride + x * 3 + 0) = b1((y * 3 + 2) * g1.Stride + x * 3)
                Next
            End Sub)
        'For y As Integer = 0 To (sz.Height + 2) \ 3 - 1
        'Next
        Marshal.Copy(b2, 0, g2.Scan0, b2.Length)
        imgsrc.UnlockBits(g1)
        imgconv.UnlockBits(g2)
        Return imgconv
    End Function
    Public Shared Function RGBExpandToGrey(ByVal imgsrc As Bitmap, Optional ByVal Height As Integer = 0)
        If imgsrc Is Nothing Then Return Nothing
        If Height = 0 Then Height = imgsrc.Height * 3
        Dim sz As Size = imgsrc.Size
        Dim g1 As BitmapData = imgsrc.LockBits(New Rectangle(New Point(), sz), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb)
        Dim b1(g1.Stride * sz.Height - 1) As Byte
        Marshal.Copy(g1.Scan0, b1, 0, b1.Length)
        Dim imgconv As New Bitmap(sz.Width, Height, Imaging.PixelFormat.Format24bppRgb)
        Dim g2 As BitmapData = imgconv.LockBits(New Rectangle(New Point(), imgconv.Size), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb)
        Dim b2(g2.Stride * imgconv.Height - 1) As Byte
        Parallel.For(0, sz.Height,
            Sub(y As Integer)
                For x As Integer = 0 To sz.Width - 1
                    If y * 3 + 0 < Height Then
                        b2((y * 3 + 0) * g2.Stride + x * 3 + 0) = b1(y * g1.Stride + x * 3 + 2)
                        b2((y * 3 + 0) * g2.Stride + x * 3 + 1) = b1(y * g1.Stride + x * 3 + 2)
                        b2((y * 3 + 0) * g2.Stride + x * 3 + 2) = b1(y * g1.Stride + x * 3 + 2)
                    End If
                    If y * 3 + 1 < Height Then
                        b2((y * 3 + 1) * g2.Stride + x * 3 + 0) = b1(y * g1.Stride + x * 3 + 1)
                        b2((y * 3 + 1) * g2.Stride + x * 3 + 1) = b1(y * g1.Stride + x * 3 + 1)
                        b2((y * 3 + 1) * g2.Stride + x * 3 + 2) = b1(y * g1.Stride + x * 3 + 1)
                    End If
                    If y * 3 + 2 < Height Then
                        b2((y * 3 + 2) * g2.Stride + x * 3 + 0) = b1(y * g1.Stride + x * 3 + 0)
                        b2((y * 3 + 2) * g2.Stride + x * 3 + 1) = b1(y * g1.Stride + x * 3 + 0)
                        b2((y * 3 + 2) * g2.Stride + x * 3 + 2) = b1(y * g1.Stride + x * 3 + 0)
                    End If
                Next
            End Sub)
        'For y As Integer = 0 To (sz.Height + 2) \ 3 - 1
        'Next
        Marshal.Copy(b2, 0, g2.Scan0, b2.Length)
        imgsrc.UnlockBits(g1)
        imgconv.UnlockBits(g2)
        Return imgconv
    End Function
    Public Shared Function GetUncompressedImage(img As Bitmap, Optional ByVal Height As Integer = 0) As Bitmap
        If My.Settings.GreyThroughRGB Then
            Return ImageTools.RGBExpandToGrey(img, Height)
        Else
            Return img
        End If
    End Function
    Public Shared Function GetImageToBeStored(img As Bitmap) As Bitmap
        If My.Settings.GreyThroughRGB Then
            Return ImageTools.GreyCompressToRGB(img)
        Else
            Return img
        End If
    End Function
    Public Shared Sub Swap(ByRef a As Long, ByRef b As Long)
        Dim t As Long = a
        a = b
        b = t
    End Sub
    Public Shared Sub Swap(ByRef a As Integer, ByRef b As Integer)
        Dim t As Integer = a
        a = b
        b = t
    End Sub
    Public Shared Function IsValidPoint(p As Point, sz As Size) As Boolean
        If p.X < 0 Or p.Y < 0 Then Return False
        If p.X > sz.Width - 1 Or p.Y > sz.Height - 1 Then Return False
        Return True
    End Function
    Public Shared Function WSortMap(source As Byte(,), EdgeA As Long, EdgeB As Long, TargetA As Long, TargetB As Long) As Integer(,)
        If EdgeA > EdgeB Then Swap(EdgeA, EdgeB)
        If TargetA > TargetB Then Swap(TargetA, TargetB)
        Dim dir() As Point = {New Point(-1, -1), New Point(-1, 0), New Point(-1, 1), New Point(0, -1), New Point(0, 1), New Point(1, -1), New Point(1, 0), New Point(1, 1)}
        'Dim dir() As Point = {New Point(-1, 0), New Point(0, -1), New Point(0, 1), New Point(1, 0)}

        Dim sz As Size = New Size(source.GetLength(0), source.GetLength(1))
        Dim Result(sz.Width - 1, sz.Height - 1) As Integer
        Dim q(sz.Width * sz.Height - 1) As Point
        Dim qs As Integer = 0, qe As Integer = -1
        Dim l As Integer = 1
        Parallel.For(0, sz.Height,
            Sub(y As Integer)
                For x As Integer = 0 To sz.Width - 1
                    If source(x, y) >= EdgeA And source(x, y) <= EdgeB Then
                        Dim qe2 As Integer = Threading.Interlocked.Increment(qe)
                        SyncLock q
                            If q.Length - 1 < qe2 Then ReDim Preserve q(qe2)
                        End SyncLock
                        q(qe2) = New Point(x, y)
                        Result(x, y) = l
                    End If
                Next
            End Sub)

        While qs <= qe
            l += 1
            Dim qe0 As Integer = qe
            Parallel.For(qs, qe + 1,
                Sub(k As Integer)
                    For Each ofs As Point In dir
                        Dim p2 As Point = q(k) + ofs
                        If IsValidPoint(p2, sz) Then
                            If Threading.Interlocked.CompareExchange(Result(p2.X, p2.Y), l, 0) = 0 Then
                                Dim qe2 As Integer = Threading.Interlocked.Increment(qe)
                                SyncLock q
                                    If q.Length - 1 < qe2 Then ReDim Preserve q(qe2)
                                End SyncLock
                                q(qe2) = p2
                                Result(p2.X, p2.Y) = l
                            End If
                        End If
                    Next
                End Sub)
            qs = qe0 + 1
        End While
        Parallel.For(0, sz.Height,
            Sub(y As Integer)
                For x As Integer = 0 To sz.Width - 1
                    If Result(x, y) > 0 Then Result(x, y) -= 1
                Next
            End Sub)
        Return Result
    End Function
    Public Shared Function WSortMap(source As Bitmap, EdgeA As Long, EdgeB As Long, TargetA As Long, TargetB As Long) As Integer(,)
        Return WSortMap(ImageToByte(source), EdgeA, EdgeB, TargetA, TargetB)
    End Function

    Public Shared Function WSDepthMap(source As Byte(,), EdgeA As Long, EdgeB As Long, TargetA As Long, TargetB As Long) As Integer(,)
        Dim Result(,) As Integer = WSortMap(source, EdgeA, EdgeB, TargetA, TargetB)
        Dim ChgFlag As Boolean = False
        Dim sz As Size = New Size(source.GetLength(0), source.GetLength(1))
        Dim dir() As Point = {New Point(-1, -1), New Point(-1, 0), New Point(-1, 1), New Point(0, -1), New Point(0, 1), New Point(1, -1), New Point(1, 0), New Point(1, 1)}
        'Dim dir() As Point = {New Point(-1, 0), New Point(0, -1), New Point(0, 1), New Point(1, 0)}
        Do
            ChgFlag = False
            For y As Integer = 0 To sz.Height - 1 Step 2
                For x As Integer = 0 To sz.Width - 1
                    For Each vec As Point In dir
                        Dim p2 As Point = New Point(x, y) + vec
                        If IsValidPoint(p2, sz) Then
                            If Result(p2.X, p2.Y) <> 0 And Result(x, y) <> 0 Then
                                If Result(p2.X, p2.Y) <> Result(x, y) Then
                                    ChgFlag = True
                                    Result(p2.X, p2.Y) = Math.Max(Result(x, y), Result(p2.X, p2.Y))
                                    Result(x, y) = Math.Max(Result(x, y), Result(p2.X, p2.Y))
                                End If
                            End If
                        End If
                    Next
                Next
            Next
            If Not ChgFlag Then Exit Do
            ChgFlag = False
            For y As Integer = 0 To sz.Height - 1 Step 2
                For x As Integer = sz.Width - 1 To 0 Step -1
                    For Each vec As Point In dir
                        Dim p2 As Point = New Point(x, y) + vec
                        If IsValidPoint(p2, sz) Then
                            If Result(p2.X, p2.Y) <> 0 And Result(x, y) <> 0 Then
                                If Result(p2.X, p2.Y) <> Result(x, y) Then
                                    ChgFlag = True
                                    Result(p2.X, p2.Y) = Math.Max(Result(x, y), Result(p2.X, p2.Y))
                                    Result(x, y) = Math.Max(Result(x, y), Result(p2.X, p2.Y))
                                End If
                            End If
                        End If
                    Next
                Next
            Next
            If Not ChgFlag Then Exit Do
            ChgFlag = False
            For y As Integer = sz.Height - 1 To 0 Step -2
                For x As Integer = 0 To sz.Width - 1 
                    For Each vec As Point In dir
                        Dim p2 As Point = New Point(x, y) + vec
                        If IsValidPoint(p2, sz) Then
                            If Result(p2.X, p2.Y) <> 0 And Result(x, y) <> 0 Then
                                If Result(p2.X, p2.Y) <> Result(x, y) Then
                                    ChgFlag = True
                                    Result(p2.X, p2.Y) = Math.Max(Result(x, y), Result(p2.X, p2.Y))
                                    Result(x, y) = Math.Max(Result(x, y), Result(p2.X, p2.Y))
                                End If
                            End If
                        End If
                    Next
                Next
            Next
            If Not ChgFlag Then Exit Do
            ChgFlag = False
            For y As Integer = sz.Height - 1 To 0 Step -2
                For x As Integer = sz.Width - 1 To 0 Step -1
                    For Each vec As Point In dir
                        Dim p2 As Point = New Point(x, y) + vec
                        If IsValidPoint(p2, sz) Then
                            If Result(p2.X, p2.Y) <> 0 And Result(x, y) <> 0 Then
                                If Result(p2.X, p2.Y) <> Result(x, y) Then
                                    ChgFlag = True
                                    Result(p2.X, p2.Y) = Math.Max(Result(x, y), Result(p2.X, p2.Y))
                                    Result(x, y) = Math.Max(Result(x, y), Result(p2.X, p2.Y))
                                End If
                            End If
                        End If
                    Next
                Next
            Next
            ChgFlag = False
        Loop Until Not ChgFlag
        Return Result
    End Function
    Public Shared Function WSDepthMap(source As Bitmap, EdgeA As Long, EdgeB As Long, TargetA As Long, TargetB As Long) As Integer(,)
        Return WSDepthMap(ImageToByte(source), EdgeA, EdgeB, TargetA, TargetB)
    End Function

    Public Shared Function ImageToByte(img As Bitmap) As Byte(,)
        Dim sz As Size = img.Size
        Dim Result(sz.Width - 1, sz.Height - 1) As Byte
        Dim bc As BitmapData = img.LockBits(New Rectangle(New Point, sz), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb)
        Dim b(bc.Stride * sz.Height - 1) As Byte
        Marshal.Copy(bc.Scan0, b, 0, b.Length)
        img.UnlockBits(bc)
        Parallel.For(0, sz.Height,
            Sub(y As Integer)
                For x As Integer = 0 To sz.Width - 1
                    Result(x, y) = b(y * bc.Stride + 3 * x)
                Next
            End Sub)
        Return Result
    End Function
    Public Shared Function AbsSize(ByVal sz As SizeF) As SizeF
        Return New SizeF(Math.Abs(sz.Width), Math.Abs(sz.Height))
    End Function
    Public Shared Function InvertPoint(orig As Integer, Width As Integer, Optional Invert As Boolean = False) As Integer
        If Invert Then
            Return Width - 1 - orig
        Else
            Return orig
        End If
    End Function
    Public Shared Function InvertPoint(orig As Point, Width As Integer, Optional Invert As Boolean = False) As Point
        If Invert Then
            Return New Point(Width - 1 - orig.X, orig.Y)
        Else
            Return orig
        End If
    End Function
End Class