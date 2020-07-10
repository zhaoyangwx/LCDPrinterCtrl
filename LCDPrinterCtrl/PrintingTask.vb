Public Class PrintingTask
    Public ToolPath As ToolPath
    Public Display As Display
    Public Machine As Machine
    Public IsPrinting As Boolean
    Private PrintingThread As Threading.Thread
    Private TerminateSignal As Boolean = False
    Public Paused As Boolean = False
    Public Event PringtingStarted()
    Public Event PrintingFinished()
    Public Event PrintingAborted()
    Public Event PrintingPaused()
    Public Event ProgressReport(ByVal Progress As Integer) '0-10000
    Public Event MessageReport(ByVal s As String)
    Public Function ETETime() As Long
        Dim ms As Integer = 0
        For i As Integer = ToolPath.LineNumber To ToolPath.FrameCount - 1
            ms += ToolPath.ExposureTime(i)
            Dim CB() As String = ToolPath.CodeBefore(i).Split({vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
            For j As Integer = 0 To CB.Length - 1
                If CB(j).StartsWith("%") Then
                    If CB(j).Replace(" ", "").StartsWith("%Sleep") Then
                        ms += Val(CB(j).Replace(" ", "").Replace("%Sleep", ""))
                    End If
                End If
            Next
            Dim CA() As String = ToolPath.CodeAfter(i).Split({vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
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
    Public Sub StopPrinting()
        If IsPrinting Then
            TerminateSignal = True
            If PrintingThread.ThreadState = Threading.ThreadState.WaitSleepJoin Then
                PrintingThread.Interrupt()
                Display.ImageOff()
                Machine.SendData("M5" & vbCrLf)
                RaiseEvent MessageReport("打印已取消")
                RaiseEvent PrintingAborted()
                TerminateSignal = False
                IsPrinting = False
            End If
        End If
    End Sub
    Public Sub Start()
        PrintingThread = New Threading.Thread(
            Sub()
                Try
                    IsPrinting = True
                    RaiseEvent PringtingStarted()
                    RaiseEvent MessageReport("打印开始")
                    RaiseEvent ProgressReport(0)
                    Display.ImageOff()
                    Machine.SendData(vbLf)
                    Dim TotalFrameCount As Integer = ToolPath.FrameCount - ToolPath.LineNumber
                    Dim Prog As Integer = 0
                    Dim TS As Date
                    Dim TP As Integer
                    For i As Integer = ToolPath.LineNumber To ToolPath.FrameCount - 1
                        If Paused Then RaiseEvent PrintingPaused()
                        While Paused
                            Display.ImageOff()
                            While Paused
                                Threading.Thread.Sleep(100)
                            End While
                        End While
                        If ToolPath.GetExposureTime <> 0 Then
                            RaiseEvent MessageReport("层:" & i & " 曝光前指令 ...")
                            Dim CB() As String = ToolPath.GetCodeBefore.Split({vbLf, vbCr}, StringSplitOptions.RemoveEmptyEntries)
                            For j As Integer = 0 To CB.Length - 1
                                RaiseEvent MessageReport("层:" & i & " 曝光前指令:" & j)
                                If TerminateSignal Then
                                    Display.ImageOff()
                                    RaiseEvent MessageReport("打印已取消")
                                    RaiseEvent PrintingAborted()
                                    TerminateSignal = False
                                    IsPrinting = False
                                    Exit Sub
                                End If
                                If CB(j).StartsWith("%") Then
                                    If CB(j).Replace(" ", "").StartsWith("%Sleep") Then
                                        Display.ImageOff()
                                        Threading.Thread.Sleep(Val(CB(j).Replace(" ", "").Replace("%Sleep", "")))
                                        TS = Now
                                    End If
                                Else
                                    Machine.SendData(CB(j) & My.Settings.Lining)
                                End If
                            Next
                            If TerminateSignal Then
                                Display.ImageOff()
                                RaiseEvent MessageReport("打印已取消")
                                RaiseEvent PrintingAborted()
                                TerminateSignal = False
                                IsPrinting = False
                                Exit Sub
                            End If
                            'If Paused Then RaiseEvent PrintingPaused()
                            'While Paused
                            '    Display.ImageOff()
                            '    While Paused
                            '        Threading.Thread.Sleep(100)
                            '    End While
                            'End While
                            RaiseEvent MessageReport("层:" & i & " 正在曝光 ...")
                            Dim CA() As String = ToolPath.GetCodeAfter.Split({vbLf, vbCr}, StringSplitOptions.RemoveEmptyEntries)

                            TP = ToolPath.GetExposureTime
                            TS = Now
                            Display.ShowImage(ToolPath.GetImage)
                            While (Now - TS).TotalMilliseconds < TP
                                Threading.Thread.Sleep(1)
                            End While
                            'If Paused Then RaiseEvent PrintingPaused()
                            'While Paused
                            '    Display.ImageOff()
                            '    While Paused
                            '        Threading.Thread.Sleep(100)
                            '    End While
                            'End While
                            'Threading.Thread.Sleep(ToolPath.GetExposureTime)
                            RaiseEvent MessageReport("层:" & i & " 曝光后指令 ...")
                            For j As Integer = 0 To CA.Length - 1
                                RaiseEvent MessageReport("层:" & i & " 曝光后指令:" & j)
                                If TerminateSignal Then
                                    Display.ImageOff()
                                    RaiseEvent MessageReport("打印已取消")
                                    RaiseEvent PrintingAborted()
                                    TerminateSignal = False
                                    IsPrinting = False
                                    Exit Sub
                                End If
                                If CA(j).StartsWith("%") Then
                                    If CA(j).Replace(" ", "").StartsWith("%Sleep") Then
                                        Display.ImageOff()
                                        Threading.Thread.Sleep(Val(CA(j).Replace(" ", "").Replace("%Sleep", "")))
                                    End If
                                Else
                                    Machine.SendData(CA(j) & My.Settings.Lining)
                                End If
                            Next
                        End If

                        ToolPath.NextLine()
                        Prog += 1
                        RaiseEvent ProgressReport(Prog / TotalFrameCount * 10000)
                    Next
                    Display.ImageOff()
                    IsPrinting = False
                    RaiseEvent MessageReport("打印已完成")
                    RaiseEvent PrintingFinished()
                Catch ex As Exception
                    RaiseEvent MessageReport("打印出错：" & ex.ToString)
                    RaiseEvent PrintingAborted()
                    TerminateSignal = False
                    IsPrinting = False
                    Exit Sub
                End Try
            End Sub)
        PrintingThread.Start()
    End Sub
End Class
