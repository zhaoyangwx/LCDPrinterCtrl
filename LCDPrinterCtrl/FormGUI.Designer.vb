<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormGUI
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormGUI))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenTaskFileOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveTaskFileSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseAllCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportImagePToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.切片SToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DObjectSlicerSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageSplitterIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateGToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestPatternGeneratorTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BatchCopyCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.空心化HToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaskSlicerMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SliceVerifierVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.笔刷工具BToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.大小ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripTextBoxBrushSize = New System.Windows.Forms.ToolStripTextBox()
        Me.颜色ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.白色ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.黑色ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.时间分层ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.CheckBoxAutoApply = New System.Windows.Forms.CheckBox()
        Me.ButtonAppendImage = New System.Windows.Forms.Button()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.复制ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ButtonApplyFrameChange = New System.Windows.Forms.Button()
        Me.ButtonDeleteImage = New System.Windows.Forms.Button()
        Me.ButtonInsertImage = New System.Windows.Forms.Button()
        Me.NumericUpDownIID = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ListBoxImgLib = New System.Windows.Forms.ListBox()
        Me.PictureBoxFramePreview = New System.Windows.Forms.PictureBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.NumericUpDownLayerTime = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBoxCodeBefore = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBoxCodeAfter = New System.Windows.Forms.TextBox()
        Me.ButtonRemoveFrame = New System.Windows.Forms.Button()
        Me.ButtonAddFrame = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ListBoxFrame = New System.Windows.Forms.ListBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBoxMechanicControl = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ButtonGHome = New System.Windows.Forms.Button()
        Me.LabelMachineStatus = New System.Windows.Forms.Label()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.ButtonZ10 = New System.Windows.Forms.Button()
        Me.ButtonM5 = New System.Windows.Forms.Button()
        Me.ButtonZ1 = New System.Windows.Forms.Button()
        Me.ButtonM3 = New System.Windows.Forms.Button()
        Me.ButtonZ01 = New System.Windows.Forms.Button()
        Me.ButtonGrblUnlock = New System.Windows.Forms.Button()
        Me.ButtonZ_01 = New System.Windows.Forms.Button()
        Me.ButtonGrblHome = New System.Windows.Forms.Button()
        Me.ButtonZ_1 = New System.Windows.Forms.Button()
        Me.ButtonGrblSetting = New System.Windows.Forms.Button()
        Me.ButtonZ_10 = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ButtonM84 = New System.Windows.Forms.Button()
        Me.ButtonX10 = New System.Windows.Forms.Button()
        Me.ButtonG92 = New System.Windows.Forms.Button()
        Me.ButtonX1 = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ButtonX01 = New System.Windows.Forms.Button()
        Me.ButtonX_01 = New System.Windows.Forms.Button()
        Me.ButtonY_10 = New System.Windows.Forms.Button()
        Me.ButtonX_1 = New System.Windows.Forms.Button()
        Me.ButtonY_1 = New System.Windows.Forms.Button()
        Me.ButtonX_10 = New System.Windows.Forms.Button()
        Me.ButtonY_01 = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ButtonY01 = New System.Windows.Forms.Button()
        Me.ButtonY10 = New System.Windows.Forms.Button()
        Me.ButtonY1 = New System.Windows.Forms.Button()
        Me.GroupBoxSPTerminal = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.TextBoxOutput = New System.Windows.Forms.TextBox()
        Me.TextBoxTerminalInput = New System.Windows.Forms.TextBox()
        Me.CheckBoxClearInput = New System.Windows.Forms.CheckBox()
        Me.ButtonSPSend = New System.Windows.Forms.Button()
        Me.GroupBoxDisplay = New System.Windows.Forms.GroupBox()
        Me.ButtonDisplayScan = New System.Windows.Forms.Button()
        Me.ComboBoxDisplayList = New System.Windows.Forms.ComboBox()
        Me.ButtonDisplayShow = New System.Windows.Forms.Button()
        Me.NumericUpDownH = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NumericUpDownW = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.NumericUpDownT = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NumericUpDownL = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ButtonDisplaySettingSave = New System.Windows.Forms.Button()
        Me.GroupBoxSP = New System.Windows.Forms.GroupBox()
        Me.ButtonSPConnect = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBoxSPBaudrate = New System.Windows.Forms.ComboBox()
        Me.ButtonSPScan = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBoxSPort = New System.Windows.Forms.ComboBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.ButtonPause = New System.Windows.Forms.Button()
        Me.PictureBoxPreviewPrinting = New System.Windows.Forms.PictureBox()
        Me.ButtonCalcETE = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.NumericUpDownPrintingProgress = New System.Windows.Forms.NumericUpDown()
        Me.ButtonStartPrinting = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.GroupBoxFastCtrl = New System.Windows.Forms.GroupBox()
        Me.ButtonFastPause = New System.Windows.Forms.Button()
        Me.ButtonFastStartStop = New System.Windows.Forms.Button()
        Me.ButtonFastHoming = New System.Windows.Forms.Button()
        Me.GroupBoxFastPrintingSetting = New System.Windows.Forms.GroupBox()
        Me.ButtonFastSlicing = New System.Windows.Forms.Button()
        Me.TextBoxFastLayerTime = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.GroupBoxFastSTLSlice = New System.Windows.Forms.GroupBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TextBoxFastLayerThickness = New System.Windows.Forms.TextBox()
        Me.ButtonFastSTLFileSelect = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ButtonFastSTLOpen = New System.Windows.Forms.Button()
        Me.TextBoxFastSTLFile = New System.Windows.Forms.TextBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.TextBoxOffset = New System.Windows.Forms.TextBox()
        Me.ButtonOffset = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.CheckBoxLf = New System.Windows.Forms.CheckBox()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.TextBoxApplyMask = New System.Windows.Forms.TextBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.CheckBoxDebugImage = New System.Windows.Forms.CheckBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PictureBoxLogo = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabelPortStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelDisplay = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelPrintingTask = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBarP = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabelProgress = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelPointer = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelETEFinishingTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TimerSPRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        CType(Me.NumericUpDownIID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxFramePreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownLayerTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBoxMechanicControl.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBoxSPTerminal.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GroupBoxDisplay.SuspendLayout()
        CType(Me.NumericUpDownH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownW, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxSP.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.PictureBoxPreviewPrinting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownPrintingProgress, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        Me.GroupBoxFastCtrl.SuspendLayout()
        Me.GroupBoxFastPrintingSetting.SuspendLayout()
        Me.GroupBoxFastSTLSlice.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button1.Location = New System.Drawing.Point(6, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Display Test"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.AliceBlue
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.切片SToolStripMenuItem, Me.EditEToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 3)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(821, 25)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenTaskFileOToolStripMenuItem, Me.SaveTaskFileSToolStripMenuItem, Me.CloseAllCToolStripMenuItem, Me.ImportImagePToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(62, 21)
        Me.FileToolStripMenuItem.Text = "文件 (&F)"
        '
        'OpenTaskFileOToolStripMenuItem
        '
        Me.OpenTaskFileOToolStripMenuItem.Name = "OpenTaskFileOToolStripMenuItem"
        Me.OpenTaskFileOToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.OpenTaskFileOToolStripMenuItem.Text = "打开任务 (&O)"
        '
        'SaveTaskFileSToolStripMenuItem
        '
        Me.SaveTaskFileSToolStripMenuItem.Name = "SaveTaskFileSToolStripMenuItem"
        Me.SaveTaskFileSToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.SaveTaskFileSToolStripMenuItem.Text = "保存任务 (&S)"
        '
        'CloseAllCToolStripMenuItem
        '
        Me.CloseAllCToolStripMenuItem.Name = "CloseAllCToolStripMenuItem"
        Me.CloseAllCToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.CloseAllCToolStripMenuItem.Text = "关闭 (&C)"
        '
        'ImportImagePToolStripMenuItem
        '
        Me.ImportImagePToolStripMenuItem.Name = "ImportImagePToolStripMenuItem"
        Me.ImportImagePToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.ImportImagePToolStripMenuItem.Text = "导入图像 (&P)"
        '
        '切片SToolStripMenuItem
        '
        Me.切片SToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DObjectSlicerSToolStripMenuItem, Me.ImageSplitterIToolStripMenuItem, Me.GenerateGToolStripMenuItem, Me.TestPatternGeneratorTToolStripMenuItem})
        Me.切片SToolStripMenuItem.Name = "切片SToolStripMenuItem"
        Me.切片SToolStripMenuItem.Size = New System.Drawing.Size(63, 21)
        Me.切片SToolStripMenuItem.Text = "切片 (&S)"
        '
        'DObjectSlicerSToolStripMenuItem
        '
        Me.DObjectSlicerSToolStripMenuItem.Name = "DObjectSlicerSToolStripMenuItem"
        Me.DObjectSlicerSToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.DObjectSlicerSToolStripMenuItem.Text = "STL切片(&S)"
        '
        'ImageSplitterIToolStripMenuItem
        '
        Me.ImageSplitterIToolStripMenuItem.Name = "ImageSplitterIToolStripMenuItem"
        Me.ImageSplitterIToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.ImageSplitterIToolStripMenuItem.Text = "分区域切片 (&I)"
        '
        'GenerateGToolStripMenuItem
        '
        Me.GenerateGToolStripMenuItem.Name = "GenerateGToolStripMenuItem"
        Me.GenerateGToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.GenerateGToolStripMenuItem.Text = "任务文件制作 (&G)"
        '
        'TestPatternGeneratorTToolStripMenuItem
        '
        Me.TestPatternGeneratorTToolStripMenuItem.Name = "TestPatternGeneratorTToolStripMenuItem"
        Me.TestPatternGeneratorTToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.TestPatternGeneratorTToolStripMenuItem.Text = "测试方块制作 (&T)"
        '
        'EditEToolStripMenuItem
        '
        Me.EditEToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BatchCopyCToolStripMenuItem, Me.空心化HToolStripMenuItem, Me.MaskSlicerMToolStripMenuItem, Me.ToolStripSeparator2, Me.SliceVerifierVToolStripMenuItem, Me.笔刷工具BToolStripMenuItem, Me.时间分层ToolStripMenuItem})
        Me.EditEToolStripMenuItem.Name = "EditEToolStripMenuItem"
        Me.EditEToolStripMenuItem.Size = New System.Drawing.Size(63, 21)
        Me.EditEToolStripMenuItem.Text = "编辑 (&E)"
        '
        'BatchCopyCToolStripMenuItem
        '
        Me.BatchCopyCToolStripMenuItem.Name = "BatchCopyCToolStripMenuItem"
        Me.BatchCopyCToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.BatchCopyCToolStripMenuItem.Text = "批量复制 (&C)"
        '
        '空心化HToolStripMenuItem
        '
        Me.空心化HToolStripMenuItem.Name = "空心化HToolStripMenuItem"
        Me.空心化HToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.空心化HToolStripMenuItem.Text = "空心化 (&H)"
        '
        'MaskSlicerMToolStripMenuItem
        '
        Me.MaskSlicerMToolStripMenuItem.Name = "MaskSlicerMToolStripMenuItem"
        Me.MaskSlicerMToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.MaskSlicerMToolStripMenuItem.Text = "掩模化(&M)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(141, 6)
        '
        'SliceVerifierVToolStripMenuItem
        '
        Me.SliceVerifierVToolStripMenuItem.Enabled = False
        Me.SliceVerifierVToolStripMenuItem.Name = "SliceVerifierVToolStripMenuItem"
        Me.SliceVerifierVToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.SliceVerifierVToolStripMenuItem.Text = "切片检查 (&V)"
        '
        '笔刷工具BToolStripMenuItem
        '
        Me.笔刷工具BToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.大小ToolStripMenuItem, Me.颜色ToolStripMenuItem})
        Me.笔刷工具BToolStripMenuItem.Name = "笔刷工具BToolStripMenuItem"
        Me.笔刷工具BToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.笔刷工具BToolStripMenuItem.Text = "笔刷工具 (&B)"
        '
        '大小ToolStripMenuItem
        '
        Me.大小ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBoxBrushSize})
        Me.大小ToolStripMenuItem.Name = "大小ToolStripMenuItem"
        Me.大小ToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.大小ToolStripMenuItem.Text = "大小"
        '
        'ToolStripTextBoxBrushSize
        '
        Me.ToolStripTextBoxBrushSize.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!)
        Me.ToolStripTextBoxBrushSize.Name = "ToolStripTextBoxBrushSize"
        Me.ToolStripTextBoxBrushSize.Size = New System.Drawing.Size(100, 23)
        Me.ToolStripTextBoxBrushSize.Text = "48"
        '
        '颜色ToolStripMenuItem
        '
        Me.颜色ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.白色ToolStripMenuItem, Me.黑色ToolStripMenuItem})
        Me.颜色ToolStripMenuItem.Name = "颜色ToolStripMenuItem"
        Me.颜色ToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.颜色ToolStripMenuItem.Text = "颜色"
        '
        '白色ToolStripMenuItem
        '
        Me.白色ToolStripMenuItem.Checked = True
        Me.白色ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.白色ToolStripMenuItem.Name = "白色ToolStripMenuItem"
        Me.白色ToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.白色ToolStripMenuItem.Text = "白色"
        '
        '黑色ToolStripMenuItem
        '
        Me.黑色ToolStripMenuItem.Name = "黑色ToolStripMenuItem"
        Me.黑色ToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.黑色ToolStripMenuItem.Text = "黑色"
        '
        '时间分层ToolStripMenuItem
        '
        Me.时间分层ToolStripMenuItem.Name = "时间分层ToolStripMenuItem"
        Me.时间分层ToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.时间分层ToolStripMenuItem.Text = "时间分层"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TabControl1.ItemSize = New System.Drawing.Size(80, 36)
        Me.TabControl1.Location = New System.Drawing.Point(0, 1)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(835, 414)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.CheckBoxAutoApply)
        Me.TabPage1.Controls.Add(Me.ButtonAppendImage)
        Me.TabPage1.Controls.Add(Me.ButtonApplyFrameChange)
        Me.TabPage1.Controls.Add(Me.ButtonDeleteImage)
        Me.TabPage1.Controls.Add(Me.ButtonInsertImage)
        Me.TabPage1.Controls.Add(Me.NumericUpDownIID)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.ListBoxImgLib)
        Me.TabPage1.Controls.Add(Me.PictureBoxFramePreview)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.NumericUpDownLayerTime)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.SplitContainer1)
        Me.TabPage1.Controls.Add(Me.ButtonRemoveFrame)
        Me.TabPage1.Controls.Add(Me.ButtonAddFrame)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.ListBoxFrame)
        Me.TabPage1.Controls.Add(Me.MenuStrip1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 40)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(827, 370)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "切片"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'CheckBoxAutoApply
        '
        Me.CheckBoxAutoApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxAutoApply.AutoSize = True
        Me.CheckBoxAutoApply.Checked = True
        Me.CheckBoxAutoApply.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxAutoApply.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CheckBoxAutoApply.Location = New System.Drawing.Point(560, 346)
        Me.CheckBoxAutoApply.Name = "CheckBoxAutoApply"
        Me.CheckBoxAutoApply.Size = New System.Drawing.Size(15, 14)
        Me.CheckBoxAutoApply.TabIndex = 21
        Me.CheckBoxAutoApply.UseVisualStyleBackColor = True
        '
        'ButtonAppendImage
        '
        Me.ButtonAppendImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAppendImage.ContextMenuStrip = Me.ContextMenuStrip2
        Me.ButtonAppendImage.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ButtonAppendImage.Location = New System.Drawing.Point(731, 341)
        Me.ButtonAppendImage.Name = "ButtonAppendImage"
        Me.ButtonAppendImage.Size = New System.Drawing.Size(42, 23)
        Me.ButtonAppendImage.TabIndex = 20
        Me.ButtonAppendImage.Text = "粘贴"
        Me.ButtonAppendImage.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.复制ToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(101, 26)
        '
        '复制ToolStripMenuItem
        '
        Me.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem"
        Me.复制ToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.复制ToolStripMenuItem.Text = "复制"
        '
        'ButtonApplyFrameChange
        '
        Me.ButtonApplyFrameChange.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonApplyFrameChange.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ButtonApplyFrameChange.Location = New System.Drawing.Point(581, 341)
        Me.ButtonApplyFrameChange.Name = "ButtonApplyFrameChange"
        Me.ButtonApplyFrameChange.Size = New System.Drawing.Size(75, 23)
        Me.ButtonApplyFrameChange.TabIndex = 19
        Me.ButtonApplyFrameChange.Text = "应用"
        Me.ButtonApplyFrameChange.UseVisualStyleBackColor = True
        '
        'ButtonDeleteImage
        '
        Me.ButtonDeleteImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonDeleteImage.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ButtonDeleteImage.Location = New System.Drawing.Point(779, 340)
        Me.ButtonDeleteImage.Name = "ButtonDeleteImage"
        Me.ButtonDeleteImage.Size = New System.Drawing.Size(42, 23)
        Me.ButtonDeleteImage.TabIndex = 18
        Me.ButtonDeleteImage.Text = "删除"
        Me.ButtonDeleteImage.UseVisualStyleBackColor = True
        '
        'ButtonInsertImage
        '
        Me.ButtonInsertImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonInsertImage.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ButtonInsertImage.Location = New System.Drawing.Point(662, 341)
        Me.ButtonInsertImage.Name = "ButtonInsertImage"
        Me.ButtonInsertImage.Size = New System.Drawing.Size(63, 23)
        Me.ButtonInsertImage.TabIndex = 17
        Me.ButtonInsertImage.Text = "插入粘贴"
        Me.ButtonInsertImage.UseVisualStyleBackColor = True
        '
        'NumericUpDownIID
        '
        Me.NumericUpDownIID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDownIID.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NumericUpDownIID.Location = New System.Drawing.Point(367, 342)
        Me.NumericUpDownIID.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericUpDownIID.Name = "NumericUpDownIID"
        Me.NumericUpDownIID.Size = New System.Drawing.Size(93, 22)
        Me.NumericUpDownIID.TabIndex = 16
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label13.Location = New System.Drawing.Point(306, 346)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 12)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "图像序号"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label12.Location = New System.Drawing.Point(660, 33)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 12)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "图像库"
        '
        'ListBoxImgLib
        '
        Me.ListBoxImgLib.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBoxImgLib.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ListBoxImgLib.FormattingEnabled = True
        Me.ListBoxImgLib.IntegralHeight = False
        Me.ListBoxImgLib.ItemHeight = 12
        Me.ListBoxImgLib.Location = New System.Drawing.Point(662, 48)
        Me.ListBoxImgLib.Name = "ListBoxImgLib"
        Me.ListBoxImgLib.Size = New System.Drawing.Size(159, 287)
        Me.ListBoxImgLib.TabIndex = 13
        '
        'PictureBoxFramePreview
        '
        Me.PictureBoxFramePreview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBoxFramePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxFramePreview.Location = New System.Drawing.Point(308, 48)
        Me.PictureBoxFramePreview.Name = "PictureBoxFramePreview"
        Me.PictureBoxFramePreview.Size = New System.Drawing.Size(348, 287)
        Me.PictureBoxFramePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxFramePreview.TabIndex = 12
        Me.PictureBoxFramePreview.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label11.Location = New System.Drawing.Point(308, 33)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 12)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "预览"
        '
        'NumericUpDownLayerTime
        '
        Me.NumericUpDownLayerTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDownLayerTime.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NumericUpDownLayerTime.Location = New System.Drawing.Point(228, 342)
        Me.NumericUpDownLayerTime.Maximum = New Decimal(New Integer() {3600000, 0, 0, 0})
        Me.NumericUpDownLayerTime.Name = "NumericUpDownLayerTime"
        Me.NumericUpDownLayerTime.Size = New System.Drawing.Size(74, 22)
        Me.NumericUpDownLayerTime.TabIndex = 10
        Me.NumericUpDownLayerTime.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label10.Location = New System.Drawing.Point(122, 345)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(101, 12)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "曝光时间（毫秒）"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(124, 33)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxCodeBefore)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBoxCodeAfter)
        Me.SplitContainer1.Size = New System.Drawing.Size(178, 302)
        Me.SplitContainer1.SplitterDistance = 146
        Me.SplitContainer1.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 12)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "曝光前"
        '
        'TextBoxCodeBefore
        '
        Me.TextBoxCodeBefore.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxCodeBefore.Location = New System.Drawing.Point(3, 15)
        Me.TextBoxCodeBefore.Multiline = True
        Me.TextBoxCodeBefore.Name = "TextBoxCodeBefore"
        Me.TextBoxCodeBefore.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxCodeBefore.Size = New System.Drawing.Size(172, 128)
        Me.TextBoxCodeBefore.TabIndex = 7
        Me.TextBoxCodeBefore.WordWrap = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 12)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "曝光后"
        '
        'TextBoxCodeAfter
        '
        Me.TextBoxCodeAfter.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxCodeAfter.Location = New System.Drawing.Point(3, 15)
        Me.TextBoxCodeAfter.Multiline = True
        Me.TextBoxCodeAfter.Name = "TextBoxCodeAfter"
        Me.TextBoxCodeAfter.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxCodeAfter.Size = New System.Drawing.Size(172, 135)
        Me.TextBoxCodeAfter.TabIndex = 9
        Me.TextBoxCodeAfter.WordWrap = False
        '
        'ButtonRemoveFrame
        '
        Me.ButtonRemoveFrame.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonRemoveFrame.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ButtonRemoveFrame.Location = New System.Drawing.Point(65, 341)
        Me.ButtonRemoveFrame.Name = "ButtonRemoveFrame"
        Me.ButtonRemoveFrame.Size = New System.Drawing.Size(53, 23)
        Me.ButtonRemoveFrame.TabIndex = 6
        Me.ButtonRemoveFrame.Text = "删除层"
        Me.ButtonRemoveFrame.UseVisualStyleBackColor = True
        '
        'ButtonAddFrame
        '
        Me.ButtonAddFrame.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonAddFrame.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ButtonAddFrame.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ButtonAddFrame.Location = New System.Drawing.Point(6, 341)
        Me.ButtonAddFrame.Name = "ButtonAddFrame"
        Me.ButtonAddFrame.Size = New System.Drawing.Size(53, 23)
        Me.ButtonAddFrame.TabIndex = 5
        Me.ButtonAddFrame.Text = "添加层"
        Me.ButtonAddFrame.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(137, 48)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(136, 22)
        Me.ToolStripMenuItem1.Text = "添加多层"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(136, 22)
        Me.ToolStripMenuItem2.Text = "在前方插入"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "分层选择"
        '
        'ListBoxFrame
        '
        Me.ListBoxFrame.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ListBoxFrame.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ListBoxFrame.FormattingEnabled = True
        Me.ListBoxFrame.IntegralHeight = False
        Me.ListBoxFrame.ItemHeight = 12
        Me.ListBoxFrame.Location = New System.Drawing.Point(6, 48)
        Me.ListBoxFrame.Name = "ListBoxFrame"
        Me.ListBoxFrame.Size = New System.Drawing.Size(112, 287)
        Me.ListBoxFrame.TabIndex = 3
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBoxMechanicControl)
        Me.TabPage2.Controls.Add(Me.GroupBoxSPTerminal)
        Me.TabPage2.Controls.Add(Me.GroupBoxDisplay)
        Me.TabPage2.Controls.Add(Me.GroupBoxSP)
        Me.TabPage2.Location = New System.Drawing.Point(4, 40)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(827, 370)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "控制"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBoxMechanicControl
        '
        Me.GroupBoxMechanicControl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxMechanicControl.Controls.Add(Me.Panel2)
        Me.GroupBoxMechanicControl.Enabled = False
        Me.GroupBoxMechanicControl.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBoxMechanicControl.Location = New System.Drawing.Point(554, 101)
        Me.GroupBoxMechanicControl.Name = "GroupBoxMechanicControl"
        Me.GroupBoxMechanicControl.Size = New System.Drawing.Size(269, 263)
        Me.GroupBoxMechanicControl.TabIndex = 11
        Me.GroupBoxMechanicControl.TabStop = False
        Me.GroupBoxMechanicControl.Text = "运动控制"
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.Controls.Add(Me.ButtonGHome)
        Me.Panel2.Controls.Add(Me.LabelMachineStatus)
        Me.Panel2.Controls.Add(Me.Button9)
        Me.Panel2.Controls.Add(Me.ButtonZ10)
        Me.Panel2.Controls.Add(Me.ButtonM5)
        Me.Panel2.Controls.Add(Me.ButtonZ1)
        Me.Panel2.Controls.Add(Me.ButtonM3)
        Me.Panel2.Controls.Add(Me.ButtonZ01)
        Me.Panel2.Controls.Add(Me.ButtonGrblUnlock)
        Me.Panel2.Controls.Add(Me.ButtonZ_01)
        Me.Panel2.Controls.Add(Me.ButtonGrblHome)
        Me.Panel2.Controls.Add(Me.ButtonZ_1)
        Me.Panel2.Controls.Add(Me.ButtonGrblSetting)
        Me.Panel2.Controls.Add(Me.ButtonZ_10)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.ButtonM84)
        Me.Panel2.Controls.Add(Me.ButtonX10)
        Me.Panel2.Controls.Add(Me.ButtonG92)
        Me.Panel2.Controls.Add(Me.ButtonX1)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.ButtonX01)
        Me.Panel2.Controls.Add(Me.ButtonX_01)
        Me.Panel2.Controls.Add(Me.ButtonY_10)
        Me.Panel2.Controls.Add(Me.ButtonX_1)
        Me.Panel2.Controls.Add(Me.ButtonY_1)
        Me.Panel2.Controls.Add(Me.ButtonX_10)
        Me.Panel2.Controls.Add(Me.ButtonY_01)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.ButtonY01)
        Me.Panel2.Controls.Add(Me.ButtonY10)
        Me.Panel2.Controls.Add(Me.ButtonY1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 17)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(263, 243)
        Me.Panel2.TabIndex = 6
        '
        'ButtonGHome
        '
        Me.ButtonGHome.Location = New System.Drawing.Point(164, 326)
        Me.ButtonGHome.Name = "ButtonGHome"
        Me.ButtonGHome.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGHome.TabIndex = 30
        Me.ButtonGHome.Text = "自动调零"
        Me.ButtonGHome.UseVisualStyleBackColor = True
        '
        'LabelMachineStatus
        '
        Me.LabelMachineStatus.AutoSize = True
        Me.LabelMachineStatus.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelMachineStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LabelMachineStatus.Location = New System.Drawing.Point(2, 3)
        Me.LabelMachineStatus.Name = "LabelMachineStatus"
        Me.LabelMachineStatus.Size = New System.Drawing.Size(80, 48)
        Me.LabelMachineStatus.TabIndex = 10
        Me.LabelMachineStatus.Text = "机器状态:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "未知" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "X0 Y0 Z0"
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(83, 297)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 23)
        Me.Button9.TabIndex = 29
        Me.Button9.Text = "M8"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'ButtonZ10
        '
        Me.ButtonZ10.Location = New System.Drawing.Point(164, 54)
        Me.ButtonZ10.Name = "ButtonZ10"
        Me.ButtonZ10.Size = New System.Drawing.Size(75, 23)
        Me.ButtonZ10.TabIndex = 0
        Me.ButtonZ10.Text = "+10mm"
        Me.ButtonZ10.UseVisualStyleBackColor = True
        '
        'ButtonM5
        '
        Me.ButtonM5.Location = New System.Drawing.Point(2, 326)
        Me.ButtonM5.Name = "ButtonM5"
        Me.ButtonM5.Size = New System.Drawing.Size(75, 23)
        Me.ButtonM5.TabIndex = 28
        Me.ButtonM5.Text = "M5"
        Me.ButtonM5.UseVisualStyleBackColor = True
        '
        'ButtonZ1
        '
        Me.ButtonZ1.Location = New System.Drawing.Point(164, 83)
        Me.ButtonZ1.Name = "ButtonZ1"
        Me.ButtonZ1.Size = New System.Drawing.Size(75, 23)
        Me.ButtonZ1.TabIndex = 1
        Me.ButtonZ1.Text = "+1mm"
        Me.ButtonZ1.UseVisualStyleBackColor = True
        '
        'ButtonM3
        '
        Me.ButtonM3.Location = New System.Drawing.Point(2, 297)
        Me.ButtonM3.Name = "ButtonM3"
        Me.ButtonM3.Size = New System.Drawing.Size(75, 23)
        Me.ButtonM3.TabIndex = 27
        Me.ButtonM3.Text = "M3 S1000"
        Me.ButtonM3.UseVisualStyleBackColor = True
        '
        'ButtonZ01
        '
        Me.ButtonZ01.Location = New System.Drawing.Point(164, 112)
        Me.ButtonZ01.Name = "ButtonZ01"
        Me.ButtonZ01.Size = New System.Drawing.Size(75, 23)
        Me.ButtonZ01.TabIndex = 2
        Me.ButtonZ01.Text = "+0.1mm"
        Me.ButtonZ01.UseVisualStyleBackColor = True
        '
        'ButtonGrblUnlock
        '
        Me.ButtonGrblUnlock.Location = New System.Drawing.Point(83, 268)
        Me.ButtonGrblUnlock.Name = "ButtonGrblUnlock"
        Me.ButtonGrblUnlock.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGrblUnlock.TabIndex = 26
        Me.ButtonGrblUnlock.Text = "$X"
        Me.ButtonGrblUnlock.UseVisualStyleBackColor = True
        '
        'ButtonZ_01
        '
        Me.ButtonZ_01.Location = New System.Drawing.Point(164, 161)
        Me.ButtonZ_01.Name = "ButtonZ_01"
        Me.ButtonZ_01.Size = New System.Drawing.Size(75, 23)
        Me.ButtonZ_01.TabIndex = 3
        Me.ButtonZ_01.Text = "-0.1mm"
        Me.ButtonZ_01.UseVisualStyleBackColor = True
        '
        'ButtonGrblHome
        '
        Me.ButtonGrblHome.Location = New System.Drawing.Point(2, 268)
        Me.ButtonGrblHome.Name = "ButtonGrblHome"
        Me.ButtonGrblHome.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGrblHome.TabIndex = 25
        Me.ButtonGrblHome.Text = "$H"
        Me.ButtonGrblHome.UseVisualStyleBackColor = True
        '
        'ButtonZ_1
        '
        Me.ButtonZ_1.Location = New System.Drawing.Point(164, 190)
        Me.ButtonZ_1.Name = "ButtonZ_1"
        Me.ButtonZ_1.Size = New System.Drawing.Size(75, 23)
        Me.ButtonZ_1.TabIndex = 4
        Me.ButtonZ_1.Text = "-1mm"
        Me.ButtonZ_1.UseVisualStyleBackColor = True
        '
        'ButtonGrblSetting
        '
        Me.ButtonGrblSetting.Location = New System.Drawing.Point(164, 268)
        Me.ButtonGrblSetting.Name = "ButtonGrblSetting"
        Me.ButtonGrblSetting.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGrblSetting.TabIndex = 24
        Me.ButtonGrblSetting.Text = "$$"
        Me.ButtonGrblSetting.UseVisualStyleBackColor = True
        '
        'ButtonZ_10
        '
        Me.ButtonZ_10.Location = New System.Drawing.Point(164, 219)
        Me.ButtonZ_10.Name = "ButtonZ_10"
        Me.ButtonZ_10.Size = New System.Drawing.Size(75, 23)
        Me.ButtonZ_10.TabIndex = 5
        Me.ButtonZ_10.Text = "-10mm"
        Me.ButtonZ_10.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Calibri", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label20.Location = New System.Drawing.Point(97, 245)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(49, 20)
        Me.Label20.TabIndex = 23
        Me.Label20.Text = "Grbl"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Calibri", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label17.Location = New System.Drawing.Point(192, 138)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(19, 20)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Z"
        '
        'ButtonM84
        '
        Me.ButtonM84.Location = New System.Drawing.Point(83, 326)
        Me.ButtonM84.Name = "ButtonM84"
        Me.ButtonM84.Size = New System.Drawing.Size(75, 23)
        Me.ButtonM84.TabIndex = 22
        Me.ButtonM84.Text = "M9"
        Me.ButtonM84.UseVisualStyleBackColor = True
        '
        'ButtonX10
        '
        Me.ButtonX10.Location = New System.Drawing.Point(2, 54)
        Me.ButtonX10.Name = "ButtonX10"
        Me.ButtonX10.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX10.TabIndex = 7
        Me.ButtonX10.Text = "+10mm"
        Me.ButtonX10.UseVisualStyleBackColor = True
        '
        'ButtonG92
        '
        Me.ButtonG92.Location = New System.Drawing.Point(164, 297)
        Me.ButtonG92.Name = "ButtonG92"
        Me.ButtonG92.Size = New System.Drawing.Size(75, 23)
        Me.ButtonG92.TabIndex = 21
        Me.ButtonG92.Text = "G92 Z0"
        Me.ButtonG92.UseVisualStyleBackColor = True
        '
        'ButtonX1
        '
        Me.ButtonX1.Location = New System.Drawing.Point(2, 83)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX1.TabIndex = 8
        Me.ButtonX1.Text = "+1mm"
        Me.ButtonX1.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Calibri", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label19.Location = New System.Drawing.Point(111, 138)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(19, 20)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "Y"
        '
        'ButtonX01
        '
        Me.ButtonX01.Location = New System.Drawing.Point(2, 112)
        Me.ButtonX01.Name = "ButtonX01"
        Me.ButtonX01.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX01.TabIndex = 9
        Me.ButtonX01.Text = "+0.1mm"
        Me.ButtonX01.UseVisualStyleBackColor = True
        '
        'ButtonX_01
        '
        Me.ButtonX_01.Location = New System.Drawing.Point(2, 161)
        Me.ButtonX_01.Name = "ButtonX_01"
        Me.ButtonX_01.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX_01.TabIndex = 10
        Me.ButtonX_01.Text = "-0.1mm"
        Me.ButtonX_01.UseVisualStyleBackColor = True
        '
        'ButtonY_10
        '
        Me.ButtonY_10.Location = New System.Drawing.Point(83, 219)
        Me.ButtonY_10.Name = "ButtonY_10"
        Me.ButtonY_10.Size = New System.Drawing.Size(75, 23)
        Me.ButtonY_10.TabIndex = 19
        Me.ButtonY_10.Text = "-10mm"
        Me.ButtonY_10.UseVisualStyleBackColor = True
        '
        'ButtonX_1
        '
        Me.ButtonX_1.Location = New System.Drawing.Point(2, 190)
        Me.ButtonX_1.Name = "ButtonX_1"
        Me.ButtonX_1.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX_1.TabIndex = 11
        Me.ButtonX_1.Text = "-1mm"
        Me.ButtonX_1.UseVisualStyleBackColor = True
        '
        'ButtonY_1
        '
        Me.ButtonY_1.Location = New System.Drawing.Point(83, 190)
        Me.ButtonY_1.Name = "ButtonY_1"
        Me.ButtonY_1.Size = New System.Drawing.Size(75, 23)
        Me.ButtonY_1.TabIndex = 18
        Me.ButtonY_1.Text = "-1mm"
        Me.ButtonY_1.UseVisualStyleBackColor = True
        '
        'ButtonX_10
        '
        Me.ButtonX_10.Location = New System.Drawing.Point(2, 219)
        Me.ButtonX_10.Name = "ButtonX_10"
        Me.ButtonX_10.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX_10.TabIndex = 12
        Me.ButtonX_10.Text = "-10mm"
        Me.ButtonX_10.UseVisualStyleBackColor = True
        '
        'ButtonY_01
        '
        Me.ButtonY_01.Location = New System.Drawing.Point(83, 161)
        Me.ButtonY_01.Name = "ButtonY_01"
        Me.ButtonY_01.Size = New System.Drawing.Size(75, 23)
        Me.ButtonY_01.TabIndex = 17
        Me.ButtonY_01.Text = "-0.1mm"
        Me.ButtonY_01.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Calibri", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label18.Location = New System.Drawing.Point(31, 138)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(19, 20)
        Me.Label18.TabIndex = 13
        Me.Label18.Text = "X"
        '
        'ButtonY01
        '
        Me.ButtonY01.Location = New System.Drawing.Point(83, 112)
        Me.ButtonY01.Name = "ButtonY01"
        Me.ButtonY01.Size = New System.Drawing.Size(75, 23)
        Me.ButtonY01.TabIndex = 16
        Me.ButtonY01.Text = "+0.1mm"
        Me.ButtonY01.UseVisualStyleBackColor = True
        '
        'ButtonY10
        '
        Me.ButtonY10.Location = New System.Drawing.Point(83, 54)
        Me.ButtonY10.Name = "ButtonY10"
        Me.ButtonY10.Size = New System.Drawing.Size(75, 23)
        Me.ButtonY10.TabIndex = 14
        Me.ButtonY10.Text = "+10mm"
        Me.ButtonY10.UseVisualStyleBackColor = True
        '
        'ButtonY1
        '
        Me.ButtonY1.Location = New System.Drawing.Point(83, 83)
        Me.ButtonY1.Name = "ButtonY1"
        Me.ButtonY1.Size = New System.Drawing.Size(75, 23)
        Me.ButtonY1.TabIndex = 15
        Me.ButtonY1.Text = "+1mm"
        Me.ButtonY1.UseVisualStyleBackColor = True
        '
        'GroupBoxSPTerminal
        '
        Me.GroupBoxSPTerminal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxSPTerminal.Controls.Add(Me.Panel1)
        Me.GroupBoxSPTerminal.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBoxSPTerminal.Location = New System.Drawing.Point(6, 101)
        Me.GroupBoxSPTerminal.Name = "GroupBoxSPTerminal"
        Me.GroupBoxSPTerminal.Size = New System.Drawing.Size(542, 263)
        Me.GroupBoxSPTerminal.TabIndex = 9
        Me.GroupBoxSPTerminal.TabStop = False
        Me.GroupBoxSPTerminal.Text = "终端"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.SplitContainer2)
        Me.Panel1.Controls.Add(Me.CheckBoxClearInput)
        Me.Panel1.Controls.Add(Me.ButtonSPSend)
        Me.Panel1.Location = New System.Drawing.Point(0, 11)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(542, 252)
        Me.Panel1.TabIndex = 4
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.TextBoxOutput)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.TextBoxTerminalInput)
        Me.SplitContainer2.Size = New System.Drawing.Size(536, 214)
        Me.SplitContainer2.SplitterDistance = 112
        Me.SplitContainer2.TabIndex = 4
        '
        'TextBoxOutput
        '
        Me.TextBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxOutput.Location = New System.Drawing.Point(0, 0)
        Me.TextBoxOutput.Multiline = True
        Me.TextBoxOutput.Name = "TextBoxOutput"
        Me.TextBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxOutput.Size = New System.Drawing.Size(536, 112)
        Me.TextBoxOutput.TabIndex = 0
        Me.TextBoxOutput.WordWrap = False
        '
        'TextBoxTerminalInput
        '
        Me.TextBoxTerminalInput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxTerminalInput.Location = New System.Drawing.Point(0, 0)
        Me.TextBoxTerminalInput.Multiline = True
        Me.TextBoxTerminalInput.Name = "TextBoxTerminalInput"
        Me.TextBoxTerminalInput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxTerminalInput.Size = New System.Drawing.Size(536, 98)
        Me.TextBoxTerminalInput.TabIndex = 1
        Me.TextBoxTerminalInput.WordWrap = False
        '
        'CheckBoxClearInput
        '
        Me.CheckBoxClearInput.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.CheckBoxClearInput.AutoSize = True
        Me.CheckBoxClearInput.Location = New System.Drawing.Point(312, 227)
        Me.CheckBoxClearInput.Name = "CheckBoxClearInput"
        Me.CheckBoxClearInput.Size = New System.Drawing.Size(96, 16)
        Me.CheckBoxClearInput.TabIndex = 3
        Me.CheckBoxClearInput.Text = "自动清空输入"
        Me.CheckBoxClearInput.UseVisualStyleBackColor = True
        '
        'ButtonSPSend
        '
        Me.ButtonSPSend.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonSPSend.Enabled = False
        Me.ButtonSPSend.Location = New System.Drawing.Point(231, 223)
        Me.ButtonSPSend.Name = "ButtonSPSend"
        Me.ButtonSPSend.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSPSend.TabIndex = 2
        Me.ButtonSPSend.Text = "发送"
        Me.ButtonSPSend.UseVisualStyleBackColor = True
        '
        'GroupBoxDisplay
        '
        Me.GroupBoxDisplay.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxDisplay.Controls.Add(Me.ButtonDisplayScan)
        Me.GroupBoxDisplay.Controls.Add(Me.ComboBoxDisplayList)
        Me.GroupBoxDisplay.Controls.Add(Me.ButtonDisplayShow)
        Me.GroupBoxDisplay.Controls.Add(Me.NumericUpDownH)
        Me.GroupBoxDisplay.Controls.Add(Me.Label5)
        Me.GroupBoxDisplay.Controls.Add(Me.NumericUpDownW)
        Me.GroupBoxDisplay.Controls.Add(Me.Label6)
        Me.GroupBoxDisplay.Controls.Add(Me.NumericUpDownT)
        Me.GroupBoxDisplay.Controls.Add(Me.Label4)
        Me.GroupBoxDisplay.Controls.Add(Me.NumericUpDownL)
        Me.GroupBoxDisplay.Controls.Add(Me.Label3)
        Me.GroupBoxDisplay.Controls.Add(Me.ButtonDisplaySettingSave)
        Me.GroupBoxDisplay.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBoxDisplay.Location = New System.Drawing.Point(293, 6)
        Me.GroupBoxDisplay.Name = "GroupBoxDisplay"
        Me.GroupBoxDisplay.Size = New System.Drawing.Size(530, 95)
        Me.GroupBoxDisplay.TabIndex = 8
        Me.GroupBoxDisplay.TabStop = False
        Me.GroupBoxDisplay.Text = "屏幕"
        '
        'ButtonDisplayScan
        '
        Me.ButtonDisplayScan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonDisplayScan.Location = New System.Drawing.Point(479, 12)
        Me.ButtonDisplayScan.Name = "ButtonDisplayScan"
        Me.ButtonDisplayScan.Size = New System.Drawing.Size(45, 23)
        Me.ButtonDisplayScan.TabIndex = 8
        Me.ButtonDisplayScan.Text = "刷新"
        Me.ButtonDisplayScan.UseVisualStyleBackColor = True
        '
        'ComboBoxDisplayList
        '
        Me.ComboBoxDisplayList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxDisplayList.FormattingEnabled = True
        Me.ComboBoxDisplayList.Location = New System.Drawing.Point(199, 14)
        Me.ComboBoxDisplayList.Name = "ComboBoxDisplayList"
        Me.ComboBoxDisplayList.Size = New System.Drawing.Size(274, 20)
        Me.ComboBoxDisplayList.TabIndex = 8
        '
        'ButtonDisplayShow
        '
        Me.ButtonDisplayShow.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonDisplayShow.Location = New System.Drawing.Point(270, 66)
        Me.ButtonDisplayShow.Name = "ButtonDisplayShow"
        Me.ButtonDisplayShow.Size = New System.Drawing.Size(75, 23)
        Me.ButtonDisplayShow.TabIndex = 17
        Me.ButtonDisplayShow.Text = "打开"
        Me.ButtonDisplayShow.UseVisualStyleBackColor = True
        '
        'NumericUpDownH
        '
        Me.NumericUpDownH.Location = New System.Drawing.Point(145, 38)
        Me.NumericUpDownH.Maximum = New Decimal(New Integer() {3199, 0, 0, 0})
        Me.NumericUpDownH.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDownH.Name = "NumericUpDownH"
        Me.NumericUpDownH.Size = New System.Drawing.Size(48, 21)
        Me.NumericUpDownH.TabIndex = 16
        Me.NumericUpDownH.Value = New Decimal(New Integer() {240, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(104, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "高"
        '
        'NumericUpDownW
        '
        Me.NumericUpDownW.Location = New System.Drawing.Point(47, 38)
        Me.NumericUpDownW.Maximum = New Decimal(New Integer() {5119, 0, 0, 0})
        Me.NumericUpDownW.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDownW.Name = "NumericUpDownW"
        Me.NumericUpDownW.Size = New System.Drawing.Size(48, 21)
        Me.NumericUpDownW.TabIndex = 14
        Me.NumericUpDownW.Value = New Decimal(New Integer() {320, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 12)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "宽"
        '
        'NumericUpDownT
        '
        Me.NumericUpDownT.Location = New System.Drawing.Point(145, 13)
        Me.NumericUpDownT.Maximum = New Decimal(New Integer() {3199, 0, 0, 0})
        Me.NumericUpDownT.Name = "NumericUpDownT"
        Me.NumericUpDownT.Size = New System.Drawing.Size(48, 21)
        Me.NumericUpDownT.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(104, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 12)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "上"
        '
        'NumericUpDownL
        '
        Me.NumericUpDownL.Location = New System.Drawing.Point(47, 13)
        Me.NumericUpDownL.Maximum = New Decimal(New Integer() {5119, 0, 0, 0})
        Me.NumericUpDownL.Name = "NumericUpDownL"
        Me.NumericUpDownL.Size = New System.Drawing.Size(48, 21)
        Me.NumericUpDownL.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "左"
        '
        'ButtonDisplaySettingSave
        '
        Me.ButtonDisplaySettingSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonDisplaySettingSave.Location = New System.Drawing.Point(189, 66)
        Me.ButtonDisplaySettingSave.Name = "ButtonDisplaySettingSave"
        Me.ButtonDisplaySettingSave.Size = New System.Drawing.Size(75, 23)
        Me.ButtonDisplaySettingSave.TabIndex = 8
        Me.ButtonDisplaySettingSave.Text = "应用"
        Me.ButtonDisplaySettingSave.UseVisualStyleBackColor = True
        '
        'GroupBoxSP
        '
        Me.GroupBoxSP.Controls.Add(Me.ButtonSPConnect)
        Me.GroupBoxSP.Controls.Add(Me.Label1)
        Me.GroupBoxSP.Controls.Add(Me.ComboBoxSPBaudrate)
        Me.GroupBoxSP.Controls.Add(Me.ButtonSPScan)
        Me.GroupBoxSP.Controls.Add(Me.Label2)
        Me.GroupBoxSP.Controls.Add(Me.ComboBoxSPort)
        Me.GroupBoxSP.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBoxSP.Location = New System.Drawing.Point(6, 6)
        Me.GroupBoxSP.Name = "GroupBoxSP"
        Me.GroupBoxSP.Size = New System.Drawing.Size(281, 95)
        Me.GroupBoxSP.TabIndex = 7
        Me.GroupBoxSP.TabStop = False
        Me.GroupBoxSP.Text = "连接"
        '
        'ButtonSPConnect
        '
        Me.ButtonSPConnect.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonSPConnect.Location = New System.Drawing.Point(102, 66)
        Me.ButtonSPConnect.Name = "ButtonSPConnect"
        Me.ButtonSPConnect.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSPConnect.TabIndex = 7
        Me.ButtonSPConnect.Text = "连接"
        Me.ButtonSPConnect.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "端口"
        '
        'ComboBoxSPBaudrate
        '
        Me.ComboBoxSPBaudrate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxSPBaudrate.FormattingEnabled = True
        Me.ComboBoxSPBaudrate.Items.AddRange(New Object() {"9600", "38400", "57600", "115200"})
        Me.ComboBoxSPBaudrate.Location = New System.Drawing.Point(83, 39)
        Me.ComboBoxSPBaudrate.Name = "ComboBoxSPBaudrate"
        Me.ComboBoxSPBaudrate.Size = New System.Drawing.Size(139, 20)
        Me.ComboBoxSPBaudrate.TabIndex = 6
        Me.ComboBoxSPBaudrate.Text = "115200"
        '
        'ButtonSPScan
        '
        Me.ButtonSPScan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSPScan.Location = New System.Drawing.Point(228, 11)
        Me.ButtonSPScan.Name = "ButtonSPScan"
        Me.ButtonSPScan.Size = New System.Drawing.Size(45, 23)
        Me.ButtonSPScan.TabIndex = 2
        Me.ButtonSPScan.Text = "刷新"
        Me.ButtonSPScan.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "波特率"
        '
        'ComboBoxSPort
        '
        Me.ComboBoxSPort.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxSPort.FormattingEnabled = True
        Me.ComboBoxSPort.Location = New System.Drawing.Point(83, 13)
        Me.ComboBoxSPort.Name = "ComboBoxSPort"
        Me.ComboBoxSPort.Size = New System.Drawing.Size(139, 20)
        Me.ComboBoxSPort.TabIndex = 3
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.ButtonPause)
        Me.TabPage3.Controls.Add(Me.PictureBoxPreviewPrinting)
        Me.TabPage3.Controls.Add(Me.ButtonCalcETE)
        Me.TabPage3.Controls.Add(Me.Label15)
        Me.TabPage3.Controls.Add(Me.ProgressBar1)
        Me.TabPage3.Controls.Add(Me.NumericUpDownPrintingProgress)
        Me.TabPage3.Controls.Add(Me.ButtonStartPrinting)
        Me.TabPage3.Controls.Add(Me.Label14)
        Me.TabPage3.Location = New System.Drawing.Point(4, 40)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(827, 370)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "任务"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'ButtonPause
        '
        Me.ButtonPause.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ButtonPause.Location = New System.Drawing.Point(175, 83)
        Me.ButtonPause.Name = "ButtonPause"
        Me.ButtonPause.Size = New System.Drawing.Size(75, 23)
        Me.ButtonPause.TabIndex = 7
        Me.ButtonPause.Text = "暂停"
        Me.ButtonPause.UseVisualStyleBackColor = True
        '
        'PictureBoxPreviewPrinting
        '
        Me.PictureBoxPreviewPrinting.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBoxPreviewPrinting.BackColor = System.Drawing.Color.Black
        Me.PictureBoxPreviewPrinting.Location = New System.Drawing.Point(256, 6)
        Me.PictureBoxPreviewPrinting.Name = "PictureBoxPreviewPrinting"
        Me.PictureBoxPreviewPrinting.Size = New System.Drawing.Size(568, 474)
        Me.PictureBoxPreviewPrinting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxPreviewPrinting.TabIndex = 6
        Me.PictureBoxPreviewPrinting.TabStop = False
        '
        'ButtonCalcETE
        '
        Me.ButtonCalcETE.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ButtonCalcETE.Location = New System.Drawing.Point(10, 83)
        Me.ButtonCalcETE.Name = "ButtonCalcETE"
        Me.ButtonCalcETE.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCalcETE.TabIndex = 5
        Me.ButtonCalcETE.Text = "计算"
        Me.ButtonCalcETE.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 68)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(113, 12)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "预计打印时间: 未知"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(10, 34)
        Me.ProgressBar1.Maximum = 10000
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(240, 23)
        Me.ProgressBar1.TabIndex = 3
        '
        'NumericUpDownPrintingProgress
        '
        Me.NumericUpDownPrintingProgress.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NumericUpDownPrintingProgress.Location = New System.Drawing.Point(49, 6)
        Me.NumericUpDownPrintingProgress.Name = "NumericUpDownPrintingProgress"
        Me.NumericUpDownPrintingProgress.Size = New System.Drawing.Size(120, 22)
        Me.NumericUpDownPrintingProgress.TabIndex = 2
        '
        'ButtonStartPrinting
        '
        Me.ButtonStartPrinting.Enabled = False
        Me.ButtonStartPrinting.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ButtonStartPrinting.Location = New System.Drawing.Point(175, 6)
        Me.ButtonStartPrinting.Name = "ButtonStartPrinting"
        Me.ButtonStartPrinting.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStartPrinting.TabIndex = 1
        Me.ButtonStartPrinting.Text = "开始"
        Me.ButtonStartPrinting.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label14.Location = New System.Drawing.Point(8, 12)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(29, 12)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "层号"
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.GroupBoxFastCtrl)
        Me.TabPage5.Controls.Add(Me.GroupBoxFastPrintingSetting)
        Me.TabPage5.Controls.Add(Me.GroupBoxFastSTLSlice)
        Me.TabPage5.Location = New System.Drawing.Point(4, 40)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(827, 370)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "快捷工具"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'GroupBoxFastCtrl
        '
        Me.GroupBoxFastCtrl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxFastCtrl.Controls.Add(Me.ButtonFastPause)
        Me.GroupBoxFastCtrl.Controls.Add(Me.ButtonFastStartStop)
        Me.GroupBoxFastCtrl.Controls.Add(Me.ButtonFastHoming)
        Me.GroupBoxFastCtrl.Enabled = False
        Me.GroupBoxFastCtrl.Location = New System.Drawing.Point(8, 202)
        Me.GroupBoxFastCtrl.Name = "GroupBoxFastCtrl"
        Me.GroupBoxFastCtrl.Size = New System.Drawing.Size(811, 83)
        Me.GroupBoxFastCtrl.TabIndex = 14
        Me.GroupBoxFastCtrl.TabStop = False
        Me.GroupBoxFastCtrl.Text = "打印控制"
        '
        'ButtonFastPause
        '
        Me.ButtonFastPause.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ButtonFastPause.Location = New System.Drawing.Point(449, 29)
        Me.ButtonFastPause.Name = "ButtonFastPause"
        Me.ButtonFastPause.Size = New System.Drawing.Size(75, 32)
        Me.ButtonFastPause.TabIndex = 2
        Me.ButtonFastPause.Text = "暂停"
        Me.ButtonFastPause.UseVisualStyleBackColor = True
        '
        'ButtonFastStartStop
        '
        Me.ButtonFastStartStop.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ButtonFastStartStop.Location = New System.Drawing.Point(368, 29)
        Me.ButtonFastStartStop.Name = "ButtonFastStartStop"
        Me.ButtonFastStartStop.Size = New System.Drawing.Size(75, 32)
        Me.ButtonFastStartStop.TabIndex = 1
        Me.ButtonFastStartStop.Text = "开始"
        Me.ButtonFastStartStop.UseVisualStyleBackColor = True
        '
        'ButtonFastHoming
        '
        Me.ButtonFastHoming.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ButtonFastHoming.Location = New System.Drawing.Point(287, 29)
        Me.ButtonFastHoming.Name = "ButtonFastHoming"
        Me.ButtonFastHoming.Size = New System.Drawing.Size(75, 32)
        Me.ButtonFastHoming.TabIndex = 0
        Me.ButtonFastHoming.Text = "Z归零"
        Me.ButtonFastHoming.UseVisualStyleBackColor = True
        '
        'GroupBoxFastPrintingSetting
        '
        Me.GroupBoxFastPrintingSetting.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxFastPrintingSetting.Controls.Add(Me.ButtonFastSlicing)
        Me.GroupBoxFastPrintingSetting.Controls.Add(Me.TextBoxFastLayerTime)
        Me.GroupBoxFastPrintingSetting.Controls.Add(Me.Label23)
        Me.GroupBoxFastPrintingSetting.Enabled = False
        Me.GroupBoxFastPrintingSetting.Location = New System.Drawing.Point(8, 90)
        Me.GroupBoxFastPrintingSetting.Name = "GroupBoxFastPrintingSetting"
        Me.GroupBoxFastPrintingSetting.Size = New System.Drawing.Size(811, 106)
        Me.GroupBoxFastPrintingSetting.TabIndex = 13
        Me.GroupBoxFastPrintingSetting.TabStop = False
        Me.GroupBoxFastPrintingSetting.Text = "打印设置"
        '
        'ButtonFastSlicing
        '
        Me.ButtonFastSlicing.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonFastSlicing.Location = New System.Drawing.Point(715, 51)
        Me.ButtonFastSlicing.Name = "ButtonFastSlicing"
        Me.ButtonFastSlicing.Size = New System.Drawing.Size(90, 32)
        Me.ButtonFastSlicing.TabIndex = 12
        Me.ButtonFastSlicing.Text = "切片"
        Me.ButtonFastSlicing.UseVisualStyleBackColor = True
        '
        'TextBoxFastLayerTime
        '
        Me.TextBoxFastLayerTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxFastLayerTime.Location = New System.Drawing.Point(10, 51)
        Me.TextBoxFastLayerTime.Name = "TextBoxFastLayerTime"
        Me.TextBoxFastLayerTime.Size = New System.Drawing.Size(699, 30)
        Me.TextBoxFastLayerTime.TabIndex = 13
        Me.TextBoxFastLayerTime.Text = "45000,30000,20000,10000,7000,6500"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(6, 28)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(269, 20)
        Me.Label23.TabIndex = 12
        Me.Label23.Text = "曝光时间（1,2,3,...,n)(ms)"
        '
        'GroupBoxFastSTLSlice
        '
        Me.GroupBoxFastSTLSlice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxFastSTLSlice.Controls.Add(Me.Label22)
        Me.GroupBoxFastSTLSlice.Controls.Add(Me.TextBoxFastLayerThickness)
        Me.GroupBoxFastSTLSlice.Controls.Add(Me.ButtonFastSTLFileSelect)
        Me.GroupBoxFastSTLSlice.Controls.Add(Me.Label21)
        Me.GroupBoxFastSTLSlice.Controls.Add(Me.ButtonFastSTLOpen)
        Me.GroupBoxFastSTLSlice.Controls.Add(Me.TextBoxFastSTLFile)
        Me.GroupBoxFastSTLSlice.Location = New System.Drawing.Point(8, 9)
        Me.GroupBoxFastSTLSlice.Name = "GroupBoxFastSTLSlice"
        Me.GroupBoxFastSTLSlice.Size = New System.Drawing.Size(811, 75)
        Me.GroupBoxFastSTLSlice.TabIndex = 3
        Me.GroupBoxFastSTLSlice.TabStop = False
        Me.GroupBoxFastSTLSlice.Text = "STL切片设置"
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(629, 28)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(89, 20)
        Me.Label22.TabIndex = 11
        Me.Label22.Text = "层厚(mm)"
        '
        'TextBoxFastLayerThickness
        '
        Me.TextBoxFastLayerThickness.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxFastLayerThickness.Location = New System.Drawing.Point(724, 25)
        Me.TextBoxFastLayerThickness.Name = "TextBoxFastLayerThickness"
        Me.TextBoxFastLayerThickness.Size = New System.Drawing.Size(81, 30)
        Me.TextBoxFastLayerThickness.TabIndex = 10
        Me.TextBoxFastLayerThickness.Text = "0.05"
        '
        'ButtonFastSTLFileSelect
        '
        Me.ButtonFastSTLFileSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonFastSTLFileSelect.Location = New System.Drawing.Point(437, 25)
        Me.ButtonFastSTLFileSelect.Name = "ButtonFastSTLFileSelect"
        Me.ButtonFastSTLFileSelect.Size = New System.Drawing.Size(90, 32)
        Me.ButtonFastSTLFileSelect.TabIndex = 3
        Me.ButtonFastSTLFileSelect.Text = "选择"
        Me.ButtonFastSTLFileSelect.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 28)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(79, 20)
        Me.Label21.TabIndex = 2
        Me.Label21.Text = "STL文件"
        '
        'ButtonFastSTLOpen
        '
        Me.ButtonFastSTLOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonFastSTLOpen.Location = New System.Drawing.Point(533, 25)
        Me.ButtonFastSTLOpen.Name = "ButtonFastSTLOpen"
        Me.ButtonFastSTLOpen.Size = New System.Drawing.Size(90, 32)
        Me.ButtonFastSTLOpen.TabIndex = 1
        Me.ButtonFastSTLOpen.Text = "打开"
        Me.ButtonFastSTLOpen.UseVisualStyleBackColor = True
        '
        'TextBoxFastSTLFile
        '
        Me.TextBoxFastSTLFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxFastSTLFile.Location = New System.Drawing.Point(101, 25)
        Me.TextBoxFastSTLFile.Name = "TextBoxFastSTLFile"
        Me.TextBoxFastSTLFile.Size = New System.Drawing.Size(330, 30)
        Me.TextBoxFastSTLFile.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Button12)
        Me.TabPage4.Controls.Add(Me.Button11)
        Me.TabPage4.Controls.Add(Me.TextBoxOffset)
        Me.TabPage4.Controls.Add(Me.ButtonOffset)
        Me.TabPage4.Controls.Add(Me.Button10)
        Me.TabPage4.Controls.Add(Me.CheckBoxLf)
        Me.TabPage4.Controls.Add(Me.Button8)
        Me.TabPage4.Controls.Add(Me.TextBoxApplyMask)
        Me.TabPage4.Controls.Add(Me.Button7)
        Me.TabPage4.Controls.Add(Me.Button6)
        Me.TabPage4.Controls.Add(Me.Button5)
        Me.TabPage4.Controls.Add(Me.Button4)
        Me.TabPage4.Controls.Add(Me.CheckBoxDebugImage)
        Me.TabPage4.Controls.Add(Me.Button3)
        Me.TabPage4.Controls.Add(Me.Label16)
        Me.TabPage4.Controls.Add(Me.Button2)
        Me.TabPage4.Controls.Add(Me.Button1)
        Me.TabPage4.Location = New System.Drawing.Point(4, 40)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(827, 370)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "调试"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(430, 196)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(75, 23)
        Me.Button12.TabIndex = 21
        Me.Button12.Text = "?"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.Location = New System.Drawing.Point(6, 330)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(75, 23)
        Me.Button11.TabIndex = 20
        Me.Button11.Text = "Rotate"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'TextBoxOffset
        '
        Me.TextBoxOffset.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TextBoxOffset.Location = New System.Drawing.Point(6, 302)
        Me.TextBoxOffset.Name = "TextBoxOffset"
        Me.TextBoxOffset.Size = New System.Drawing.Size(251, 22)
        Me.TextBoxOffset.TabIndex = 19
        Me.TextBoxOffset.Text = "(30,30)"
        '
        'ButtonOffset
        '
        Me.ButtonOffset.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOffset.Location = New System.Drawing.Point(263, 302)
        Me.ButtonOffset.Name = "ButtonOffset"
        Me.ButtonOffset.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOffset.TabIndex = 18
        Me.ButtonOffset.Text = "Offset"
        Me.ButtonOffset.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button10.Location = New System.Drawing.Point(282, 6)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(75, 23)
        Me.Button10.TabIndex = 17
        Me.Button10.Text = "SettingRST"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'CheckBoxLf
        '
        Me.CheckBoxLf.AutoSize = True
        Me.CheckBoxLf.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CheckBoxLf.Location = New System.Drawing.Point(10, 261)
        Me.CheckBoxLf.Name = "CheckBoxLf"
        Me.CheckBoxLf.Size = New System.Drawing.Size(78, 16)
        Me.CheckBoxLf.TabIndex = 16
        Me.CheckBoxLf.Text = "Unix Line"
        Me.CheckBoxLf.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button8.Location = New System.Drawing.Point(263, 233)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(32, 23)
        Me.Button8.TabIndex = 15
        Me.Button8.Text = "..."
        Me.Button8.UseVisualStyleBackColor = True
        '
        'TextBoxApplyMask
        '
        Me.TextBoxApplyMask.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TextBoxApplyMask.Location = New System.Drawing.Point(6, 233)
        Me.TextBoxApplyMask.Name = "TextBoxApplyMask"
        Me.TextBoxApplyMask.Size = New System.Drawing.Size(251, 22)
        Me.TextBoxApplyMask.TabIndex = 14
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button7.Location = New System.Drawing.Point(301, 233)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(95, 23)
        Me.Button7.TabIndex = 13
        Me.Button7.Text = "Apply Mask"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button6.Location = New System.Drawing.Point(107, 204)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(95, 23)
        Me.Button6.TabIndex = 12
        Me.Button6.Text = "Black Screen"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button5.Location = New System.Drawing.Point(6, 204)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(95, 23)
        Me.Button5.TabIndex = 11
        Me.Button5.Text = "White Screen"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button4.Location = New System.Drawing.Point(201, 6)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 10
        Me.Button4.Text = "Ping"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'CheckBoxDebugImage
        '
        Me.CheckBoxDebugImage.AutoSize = True
        Me.CheckBoxDebugImage.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CheckBoxDebugImage.Location = New System.Drawing.Point(107, 39)
        Me.CheckBoxDebugImage.Name = "CheckBoxDebugImage"
        Me.CheckBoxDebugImage.Size = New System.Drawing.Size(216, 16)
        Me.CheckBoxDebugImage.TabIndex = 9
        Me.CheckBoxDebugImage.Text = "Debug Image (Ignore Serial Port)"
        Me.CheckBoxDebugImage.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button3.Location = New System.Drawing.Point(107, 6)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(88, 23)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "SmallWindow"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(8, 61)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(707, 132)
        Me.Label16.TabIndex = 7
        Me.Label16.Text = resources.GetString("Label16.Text")
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button2.Location = New System.Drawing.Point(6, 35)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(95, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "WinOnAndStart"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'PictureBoxLogo
        '
        Me.PictureBoxLogo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBoxLogo.Location = New System.Drawing.Point(700, 0)
        Me.PictureBoxLogo.Name = "PictureBoxLogo"
        Me.PictureBoxLogo.Size = New System.Drawing.Size(135, 40)
        Me.PictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxLogo.TabIndex = 5
        Me.PictureBoxLogo.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelPortStatus, Me.ToolStripStatusLabelDisplay, Me.ToolStripStatusLabelPrintingTask, Me.ToolStripProgressBarP, Me.ToolStripStatusLabelProgress, Me.ToolStripStatusLabelMessage, Me.ToolStripStatusLabelPointer, Me.ToolStripStatusLabelETEFinishingTime})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 418)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(835, 26)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabelPortStatus
        '
        Me.ToolStripStatusLabelPortStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabelPortStatus.ForeColor = System.Drawing.Color.Red
        Me.ToolStripStatusLabelPortStatus.Name = "ToolStripStatusLabelPortStatus"
        Me.ToolStripStatusLabelPortStatus.Size = New System.Drawing.Size(48, 21)
        Me.ToolStripStatusLabelPortStatus.Text = "未连接"
        '
        'ToolStripStatusLabelDisplay
        '
        Me.ToolStripStatusLabelDisplay.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabelDisplay.ForeColor = System.Drawing.Color.Red
        Me.ToolStripStatusLabelDisplay.Name = "ToolStripStatusLabelDisplay"
        Me.ToolStripStatusLabelDisplay.Size = New System.Drawing.Size(48, 21)
        Me.ToolStripStatusLabelDisplay.Text = "屏幕关"
        '
        'ToolStripStatusLabelPrintingTask
        '
        Me.ToolStripStatusLabelPrintingTask.ForeColor = System.Drawing.Color.Blue
        Me.ToolStripStatusLabelPrintingTask.Name = "ToolStripStatusLabelPrintingTask"
        Me.ToolStripStatusLabelPrintingTask.Size = New System.Drawing.Size(44, 21)
        Me.ToolStripStatusLabelPrintingTask.Text = "无任务"
        '
        'ToolStripProgressBarP
        '
        Me.ToolStripProgressBarP.Maximum = 10000
        Me.ToolStripProgressBarP.Name = "ToolStripProgressBarP"
        Me.ToolStripProgressBarP.Size = New System.Drawing.Size(70, 20)
        '
        'ToolStripStatusLabelProgress
        '
        Me.ToolStripStatusLabelProgress.Name = "ToolStripStatusLabelProgress"
        Me.ToolStripStatusLabelProgress.Size = New System.Drawing.Size(26, 21)
        Me.ToolStripStatusLabelProgress.Text = "0%"
        '
        'ToolStripStatusLabelMessage
        '
        Me.ToolStripStatusLabelMessage.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabelMessage.Name = "ToolStripStatusLabelMessage"
        Me.ToolStripStatusLabelMessage.Size = New System.Drawing.Size(354, 21)
        Me.ToolStripStatusLabelMessage.Spring = True
        Me.ToolStripStatusLabelMessage.Text = "无消息"
        '
        'ToolStripStatusLabelPointer
        '
        Me.ToolStripStatusLabelPointer.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabelPointer.Name = "ToolStripStatusLabelPointer"
        Me.ToolStripStatusLabelPointer.Size = New System.Drawing.Size(37, 21)
        Me.ToolStripStatusLabelPointer.Text = "(0,0)"
        '
        'ToolStripStatusLabelETEFinishingTime
        '
        Me.ToolStripStatusLabelETEFinishingTime.Name = "ToolStripStatusLabelETEFinishingTime"
        Me.ToolStripStatusLabelETEFinishingTime.Size = New System.Drawing.Size(111, 21)
        Me.ToolStripStatusLabelETEFinishingTime.Text = "预计结束时间: 未知"
        '
        'TimerSPRefresh
        '
        Me.TimerSPRefresh.Enabled = True
        '
        'FormGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(835, 444)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PictureBoxLogo)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormGUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "3D3 Printer Utility"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ContextMenuStrip2.ResumeLayout(False)
        CType(Me.NumericUpDownIID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxFramePreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownLayerTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBoxMechanicControl.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBoxSPTerminal.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.GroupBoxDisplay.ResumeLayout(False)
        Me.GroupBoxDisplay.PerformLayout()
        CType(Me.NumericUpDownH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownW, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxSP.ResumeLayout(False)
        Me.GroupBoxSP.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.PictureBoxPreviewPrinting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownPrintingProgress, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.GroupBoxFastCtrl.ResumeLayout(False)
        Me.GroupBoxFastPrintingSetting.ResumeLayout(False)
        Me.GroupBoxFastPrintingSetting.PerformLayout()
        Me.GroupBoxFastSTLSlice.ResumeLayout(False)
        Me.GroupBoxFastSTLSlice.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenTaskFileOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveTaskFileSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CloseAllCToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditEToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents ComboBoxSPBaudrate As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBoxSPort As ComboBox
    Friend WithEvents ButtonSPScan As Button
    Friend WithEvents GroupBoxSP As GroupBox
    Friend WithEvents ButtonSPConnect As Button
    Friend WithEvents GroupBoxDisplay As GroupBox
    Friend WithEvents ButtonDisplaySettingSave As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabelPortStatus As ToolStripStatusLabel
    Friend WithEvents GroupBoxSPTerminal As GroupBox
    Friend WithEvents ButtonSPSend As Button
    Friend WithEvents TextBoxTerminalInput As TextBox
    Friend WithEvents TextBoxOutput As TextBox
    Friend WithEvents CheckBoxClearInput As CheckBox
    Friend WithEvents ToolStripStatusLabelDisplay As ToolStripStatusLabel
    Friend WithEvents NumericUpDownH As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents NumericUpDownW As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents NumericUpDownT As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents NumericUpDownL As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents ButtonDisplayShow As Button
    Friend WithEvents TimerSPRefresh As Timer
    Friend WithEvents ToolStripStatusLabelPrintingTask As ToolStripStatusLabel
    Friend WithEvents ButtonDisplayScan As Button
    Friend WithEvents ComboBoxDisplayList As ComboBox
    Friend WithEvents ButtonRemoveFrame As Button
    Friend WithEvents ButtonAddFrame As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents ListBoxFrame As ListBox
    Friend WithEvents ImportImagePToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NumericUpDownLayerTime As NumericUpDown
    Friend WithEvents Label10 As Label
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBoxCodeBefore As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBoxCodeAfter As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents ListBoxImgLib As ListBox
    Friend WithEvents PictureBoxFramePreview As PictureBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ButtonApplyFrameChange As Button
    Friend WithEvents ButtonDeleteImage As Button
    Friend WithEvents ButtonInsertImage As Button
    Friend WithEvents NumericUpDownIID As NumericUpDown
    Friend WithEvents Label13 As Label
    Friend WithEvents ButtonAppendImage As Button
    Friend WithEvents CheckBoxAutoApply As CheckBox
    Friend WithEvents BatchCopyCToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NumericUpDownPrintingProgress As NumericUpDown
    Friend WithEvents ButtonStartPrinting As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ToolStripProgressBarP As ToolStripProgressBar
    Friend WithEvents Button2 As Button
    Friend WithEvents ButtonCalcETE As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents ToolStripStatusLabelETEFinishingTime As ToolStripStatusLabel
    Friend WithEvents Label16 As Label
    Friend WithEvents ToolStripStatusLabelMessage As ToolStripStatusLabel
    Friend WithEvents PictureBoxPreviewPrinting As PictureBox
    Friend WithEvents Button3 As Button
    Friend WithEvents SliceVerifierVToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents CheckBoxDebugImage As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ToolStripStatusLabelProgress As ToolStripStatusLabel
    Friend WithEvents Button4 As Button
    Friend WithEvents ButtonPause As Button
    Friend WithEvents GroupBoxMechanicControl As GroupBox
    Friend WithEvents Label19 As Label
    Friend WithEvents LabelMachineStatus As Label
    Friend WithEvents ButtonY_10 As Button
    Friend WithEvents ButtonY_1 As Button
    Friend WithEvents ButtonY_01 As Button
    Friend WithEvents ButtonY01 As Button
    Friend WithEvents ButtonY1 As Button
    Friend WithEvents ButtonY10 As Button
    Friend WithEvents Label18 As Label
    Friend WithEvents ButtonX_10 As Button
    Friend WithEvents ButtonX_1 As Button
    Friend WithEvents ButtonX_01 As Button
    Friend WithEvents ButtonX01 As Button
    Friend WithEvents ButtonX1 As Button
    Friend WithEvents ButtonX10 As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents ButtonZ_10 As Button
    Friend WithEvents ButtonZ_1 As Button
    Friend WithEvents ButtonZ_01 As Button
    Friend WithEvents ButtonZ01 As Button
    Friend WithEvents ButtonZ1 As Button
    Friend WithEvents ButtonZ10 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents TextBoxApplyMask As TextBox
    Friend WithEvents CheckBoxLf As CheckBox
    Friend WithEvents ButtonM84 As Button
    Friend WithEvents ButtonG92 As Button
    Friend WithEvents PictureBoxLogo As PictureBox
    Friend WithEvents MaskSlicerMToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ButtonGrblUnlock As Button
    Friend WithEvents ButtonGrblHome As Button
    Friend WithEvents ButtonGrblSetting As Button
    Friend WithEvents Label20 As Label
    Friend WithEvents ButtonM5 As Button
    Friend WithEvents ButtonM3 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents ButtonGHome As Button
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents GroupBoxFastSTLSlice As GroupBox
    Friend WithEvents ButtonFastSTLFileSelect As Button
    Friend WithEvents Label21 As Label
    Friend WithEvents ButtonFastSTLOpen As Button
    Friend WithEvents TextBoxFastSTLFile As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents TextBoxFastLayerThickness As TextBox
    Friend WithEvents GroupBoxFastPrintingSetting As GroupBox
    Friend WithEvents TextBoxFastLayerTime As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents ButtonFastSlicing As Button
    Friend WithEvents GroupBoxFastCtrl As GroupBox
    Friend WithEvents ButtonFastPause As Button
    Friend WithEvents ButtonFastStartStop As Button
    Friend WithEvents ButtonFastHoming As Button
    Friend WithEvents 空心化HToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabelPointer As ToolStripStatusLabel
    Friend WithEvents 切片SToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DObjectSlicerSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImageSplitterIToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GenerateGToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TestPatternGeneratorTToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents 笔刷工具BToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 大小ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripTextBoxBrushSize As ToolStripTextBox
    Friend WithEvents 颜色ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 白色ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 黑色ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button10 As Button
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents 复制ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ButtonOffset As Button
    Friend WithEvents TextBoxOffset As TextBox
    Friend WithEvents Button11 As Button
    Friend WithEvents 时间分层ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button12 As Button
    Friend WithEvents Panel2 As Panel
End Class
