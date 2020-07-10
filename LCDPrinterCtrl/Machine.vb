Public Class Machine
    Public Property PortName As String
    Public Property BaudRate As Integer
    Public Property Name As String
    Public Property IsBusy As Boolean
    Public Property DebugMode As Boolean = False

    Public Event ConnectionChanged(ByVal b As Boolean)
    Public Event ErrorMsgThrow(ByVal s As String)
    Public Event DataReceived(ByVal s As String)
    Public Event DataSent(ByVal Info As Integer)
    Public Event StatusChanged(ByVal s As String)
    Public Event LightOn()
    Public Event LightOff()

    Public Structure StatusDef
        Property G0 As Boolean
        Property G1 As Boolean
        Property G90 As Boolean
        Property G91 As Boolean
        Property G92 As Boolean
        Property F As Double
        Property X As Double
        Property Y As Double
        Property Z As Double
        Property E As Double
        Property M As Double
    End Structure
    Public Status As StatusDef
    Public StatusString As String
    Public Sub SetStatus(ByVal cmd As String, ByVal value As Double)
        Select Case cmd.ToUpper
            Case "G"
                Select Case CInt(value)
                    Case 0
                        Status.G0 = True
                        Status.G1 = False
                        Status.G92 = False
                    Case 1
                        Status.G0 = False
                        Status.G1 = True
                        Status.G92 = False
                    Case 90
                        Status.G90 = True
                        Status.G91 = False
                        Status.G92 = False
                    Case 91
                        Status.G90 = False
                        Status.G91 = True
                        Status.G92 = False
                    Case 92
                        Status.G92 = True
                End Select

            Case "F"
                Status.F = value
                Status.G92 = False
            Case "X"
                If Status.G92 Then
                    Status.X = value
                Else
                    If Status.G90 Then Status.X = value Else Status.X += value
                End If
            Case "Y"
                If Status.G92 Then
                    Status.Y = value
                Else
                    If Status.G90 Then Status.Y = value Else Status.Y += value
                End If
            Case "Z"
                If Status.G92 Then
                    Status.Z = value
                Else
                    If Status.G90 Then Status.Z = value Else Status.Z += value
                End If
            Case "M"
                Status.G92 = False
            Case "S"
                Status.G92 = False
            Case "$H"
                Status.X = 0
                Status.Y = 0
                Status.Z = 0
                Status.G92 = False
        End Select
    End Sub
    Public Function GetStatus() As String
        GetStatus = ""
        If Status.G90 Then GetStatus &= "G90 "
        If Status.G91 Then GetStatus &= "G91 "
        If Status.G0 Then GetStatus &= "G0 "
        If Status.G1 Then GetStatus &= "G1 "
        If GetStatus <> "" Then GetStatus &= My.Settings.Lining
        GetStatus &= "F" & Math.Round(Status.F) & " "
        GetStatus &= "X" & Math.Round(Status.X, 2) & " "
        GetStatus &= "Y" & Math.Round(Status.Y, 2) & " "
        GetStatus &= "Z" & Math.Round(Status.Z, 2) & " "
        StatusString = GetStatus
    End Function

    Public SPort1 As IO.Ports.SerialPort
    Public Sub New()
        SPort1 = New IO.Ports.SerialPort
        AddHandler SPort1.DataReceived,
            Sub(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs)
                RaiseEvent DataReceived(SPort1.ReadExisting)
            End Sub
        AddHandler SPort1.ErrorReceived,
            Sub(sender As Object, ex As IO.Ports.SerialErrorReceivedEventArgs)
                Try
                    DisConnect()
                Catch e As Exception
                End Try
                RaiseEvent ConnectionChanged(False)
                RaiseEvent ErrorMsgThrow(ex.ToString)
            End Sub

    End Sub
    Public Sub Connect()
        If DebugMode Then
            RaiseEvent ConnectionChanged(True)
            Exit Sub
        End If
        Try
            DisConnect()
        Catch ex As Exception
        End Try
        Try
            SPort1.PortName = PortName
            SPort1.BaudRate = BaudRate
            SPort1.Open()
            RaiseEvent ConnectionChanged(True)
        Catch ex As Exception
            RaiseEvent ErrorMsgThrow(ex.ToString)
            RaiseEvent ConnectionChanged(False)
        End Try

    End Sub
    Public Sub DisConnect()
        If DebugMode Then
            RaiseEvent ConnectionChanged(False)
            Exit Sub
        End If
        SPort1.Close()
        RaiseEvent ConnectionChanged(False)
    End Sub
    Public Sub SendData(ByVal s As String)
        If DebugMode Then
            RaiseEvent StatusChanged(s)
        Else
            While Threading.Interlocked.CompareExchange(IsBusy, True, False)
            End While
            For i As Integer = 0 To s.Length - 1
                SPort1.Write(s(i))
            Next
            RaiseEvent DataSent(s.Length)
            RaiseEvent StatusChanged(s)
            IsBusy = False
        End If
        If s.Contains("M3") Or s.Contains("M03") Then RaiseEvent LightOn()
        If s.Contains("M5") Or s.Contains("M05") Then RaiseEvent LightOff()
    End Sub
    Public Sub Dispose()
        Try
            DisConnect()
            SPort1.Dispose()
        Catch ex As Exception

        End Try
    End Sub
End Class
