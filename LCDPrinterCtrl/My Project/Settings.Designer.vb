﻿'------------------------------------------------------------------------------
' <auto-generated>
'     此代码由工具生成。
'     运行时版本:4.0.30319.42000
'
'     对此文件的更改可能会导致不正确的行为，并且如果
'     重新生成代码，这些更改将会丢失。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.2.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings 自动保存功能"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("G91"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"G1 Z1 F100"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"G1 Z4 F300"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"G1 Z-3.5 F300"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"G1 Z-1 F75"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"G1 Z-0.45 F50"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"%Sleep 370"& _ 
            "0"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"M3 S1000"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"%Sleep 300")>  _
        Public Property TPG_CodeBefore1() As String
            Get
                Return CType(Me("TPG_CodeBefore1"),String)
            End Get
            Set
                Me("TPG_CodeBefore1") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("G91"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"G1 Z1 F100"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"G1 Z4 F300"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"G1 Z-3.5 F300"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"G1 Z-1 F75"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"G1 Z-0.45 F50"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"%Sleep 370"& _ 
            "0"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"M3 S1000"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"%Sleep 300")>  _
        Public Property TPG_CodeBefore2() As String
            Get
                Return CType(Me("TPG_CodeBefore2"),String)
            End Get
            Set
                Me("TPG_CodeBefore2") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("M5"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"%Sleep 1000")>  _
        Public Property TPG_CodeAfter1() As String
            Get
                Return CType(Me("TPG_CodeAfter1"),String)
            End Get
            Set
                Me("TPG_CodeAfter1") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("M5"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"%Sleep 1000")>  _
        Public Property TPG_CodeAfter2() As String
            Get
                Return CType(Me("TPG_CodeAfter2"),String)
            End Get
            Set
                Me("TPG_CodeAfter2") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property TPG_loc() As String
            Get
                Return CType(Me("TPG_loc"),String)
            End Get
            Set
                Me("TPG_loc") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("6500")>  _
        Public Property TPG_t1() As Integer
            Get
                Return CType(Me("TPG_t1"),Integer)
            End Get
            Set
                Me("TPG_t1") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("500")>  _
        Public Property TPG_t2() As Integer
            Get
                Return CType(Me("TPG_t2"),Integer)
            End Get
            Set
                Me("TPG_t2") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("500")>  _
        Public Property TPG_t3() As Integer
            Get
                Return CType(Me("TPG_t3"),Integer)
            End Get
            Set
                Me("TPG_t3") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("3")>  _
        Public Property TPG_l1() As Integer
            Get
                Return CType(Me("TPG_l1"),Integer)
            End Get
            Set
                Me("TPG_l1") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property TPG_l2() As Integer
            Get
                Return CType(Me("TPG_l2"),Integer)
            End Get
            Set
                Me("TPG_l2") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("115200")>  _
        Public Property Machine_Baudrate() As Integer
            Get
                Return CType(Me("Machine_Baudrate"),Integer)
            End Get
            Set
                Me("Machine_Baudrate") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Last_Open_File() As String
            Get
                Return CType(Me("Last_Open_File"),String)
            End Get
            Set
                Me("Last_Open_File") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Last_Save_File() As String
            Get
                Return CType(Me("Last_Save_File"),String)
            End Get
            Set
                Me("Last_Save_File") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Last_Import_File() As String
            Get
                Return CType(Me("Last_Import_File"),String)
            End Get
            Set
                Me("Last_Import_File") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property TerminalInput() As String
            Get
                Return CType(Me("TerminalInput"),String)
            End Get
            Set
                Me("TerminalInput") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("3")>  _
        Public Property TP_PatternW() As Double
            Get
                Return CType(Me("TP_PatternW"),Double)
            End Get
            Set
                Me("TP_PatternW") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("6")>  _
        Public Property TP_PatternDistance() As Double
            Get
                Return CType(Me("TP_PatternDistance"),Double)
            End Get
            Set
                Me("TP_PatternDistance") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("12")>  _
        Public Property TP_EdgeDistanceW() As Double
            Get
                Return CType(Me("TP_EdgeDistanceW"),Double)
            End Get
            Set
                Me("TP_EdgeDistanceW") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("120.96")>  _
        Public Property TP_Width() As Double
            Get
                Return CType(Me("TP_Width"),Double)
            End Get
            Set
                Me("TP_Width") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("68.04")>  _
        Public Property TP_Height() As Double
            Get
                Return CType(Me("TP_Height"),Double)
            End Get
            Set
                Me("TP_Height") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0.05")>  _
        Public Property TP_LayerThickness() As Double
            Get
                Return CType(Me("TP_LayerThickness"),Double)
            End Get
            Set
                Me("TP_LayerThickness") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1")>  _
        Public Property TP_TotalThickness() As Double
            Get
                Return CType(Me("TP_TotalThickness"),Double)
            End Get
            Set
                Me("TP_TotalThickness") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("100")>  _
        Public Property TP_TimeMin() As Integer
            Get
                Return CType(Me("TP_TimeMin"),Integer)
            End Get
            Set
                Me("TP_TimeMin") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("100")>  _
        Public Property TP_TimeIntv() As Integer
            Get
                Return CType(Me("TP_TimeIntv"),Integer)
            End Get
            Set
                Me("TP_TimeIntv") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("100")>  _
        Public Property TP_FeedRateUp() As Integer
            Get
                Return CType(Me("TP_FeedRateUp"),Integer)
            End Get
            Set
                Me("TP_FeedRateUp") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("300")>  _
        Public Property TP_FeedRateDown() As Integer
            Get
                Return CType(Me("TP_FeedRateDown"),Integer)
            End Get
            Set
                Me("TP_FeedRateDown") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("2.5")>  _
        Public Property TP_LiftDistance() As Double
            Get
                Return CType(Me("TP_LiftDistance"),Double)
            End Get
            Set
                Me("TP_LiftDistance") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("M5"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"G1 Z1 F100"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"G1 Z39 F300")>  _
        Public Property TPG_FinalGCode() As String
            Get
                Return CType(Me("TPG_FinalGCode"),String)
            End Get
            Set
                Me("TPG_FinalGCode") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("$X"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"G91")>  _
        Public Property TPG_StartGCode() As String
            Get
                Return CType(Me("TPG_StartGCode"),String)
            End Get
            Set
                Me("TPG_StartGCode") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Lining() As String
            Get
                Return CType(Me("Lining"),String)
            End Get
            Set
                Me("Lining") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1920")>  _
        Public Property TP_DisplayWidth() As String
            Get
                Return CType(Me("TP_DisplayWidth"),String)
            End Get
            Set
                Me("TP_DisplayWidth") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1080")>  _
        Public Property TP_DisplayHeight() As String
            Get
                Return CType(Me("TP_DisplayHeight"),String)
            End Get
            Set
                Me("TP_DisplayHeight") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("45000,30000,20000,10000,7000,6500")>  _
        Public Property TP_FastLayerTime() As String
            Get
                Return CType(Me("TP_FastLayerTime"),String)
            End Get
            Set
                Me("TP_FastLayerTime") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("30")>  _
        Public Property TPG_OSlicWidth() As String
            Get
                Return CType(Me("TPG_OSlicWidth"),String)
            End Get
            Set
                Me("TPG_OSlicWidth") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("6")>  _
        Public Property TP_EdgeDistanceH() As Double
            Get
                Return CType(Me("TP_EdgeDistanceH"),Double)
            End Get
            Set
                Me("TP_EdgeDistanceH") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("3")>  _
        Public Property TP_PatternH() As String
            Get
                Return CType(Me("TP_PatternH"),String)
            End Get
            Set
                Me("TP_PatternH") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.LCDPrinterCtrl.My.MySettings
            Get
                Return Global.LCDPrinterCtrl.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
