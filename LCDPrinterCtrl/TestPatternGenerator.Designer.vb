<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TestPatternGenerator
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumericUpDownW = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NumericUpDownH = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.NumericUpDownLayerThickness = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownMinTime = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownTimeIntv = New System.Windows.Forms.NumericUpDown()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.NumericUpDownFeedRateDown = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownFeedRateUp = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.NumericUpDownPatternDistance = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.NumericUpDownPatternWidth = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownTotalThickness = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.NumericUpDownLiftDistance = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.NumericUpDownEdgeDistanceW = New System.Windows.Forms.NumericUpDown()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.NumericUpDownDisplayH = New System.Windows.Forms.NumericUpDown()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.NumericUpDownDisplayW = New System.Windows.Forms.NumericUpDown()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.NumericUpDownEdgeDistanceH = New System.Windows.Forms.NumericUpDown()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.NumericUpDownPatternHeight = New System.Windows.Forms.NumericUpDown()
        CType(Me.NumericUpDownW, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownLayerThickness, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownMinTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownTimeIntv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownFeedRateDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownFeedRateUp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownPatternDistance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownPatternWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownTotalThickness, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownLiftDistance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownEdgeDistanceW, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownDisplayH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownDisplayW, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownEdgeDistanceH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownPatternHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "打印区域 (mm)"
        '
        'NumericUpDownW
        '
        Me.NumericUpDownW.DecimalPlaces = 2
        Me.NumericUpDownW.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NumericUpDownW.Location = New System.Drawing.Point(53, 71)
        Me.NumericUpDownW.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NumericUpDownW.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NumericUpDownW.Name = "NumericUpDownW"
        Me.NumericUpDownW.Size = New System.Drawing.Size(64, 21)
        Me.NumericUpDownW.TabIndex = 1
        Me.NumericUpDownW.Value = New Decimal(New Integer() {1218, 0, 0, 65536})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "长"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(123, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "宽"
        '
        'NumericUpDownH
        '
        Me.NumericUpDownH.DecimalPlaces = 2
        Me.NumericUpDownH.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NumericUpDownH.Location = New System.Drawing.Point(182, 71)
        Me.NumericUpDownH.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NumericUpDownH.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NumericUpDownH.Name = "NumericUpDownH"
        Me.NumericUpDownH.Size = New System.Drawing.Size(64, 21)
        Me.NumericUpDownH.TabIndex = 3
        Me.NumericUpDownH.Value = New Decimal(New Integer() {685, 0, 0, 65536})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 201)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 12)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "层厚 (mm)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 253)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 12)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "最短时间 (ms)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 282)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 12)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "时间间隔 (ms)"
        '
        'NumericUpDownLayerThickness
        '
        Me.NumericUpDownLayerThickness.DecimalPlaces = 3
        Me.NumericUpDownLayerThickness.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.NumericUpDownLayerThickness.Location = New System.Drawing.Point(140, 199)
        Me.NumericUpDownLayerThickness.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NumericUpDownLayerThickness.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NumericUpDownLayerThickness.Name = "NumericUpDownLayerThickness"
        Me.NumericUpDownLayerThickness.Size = New System.Drawing.Size(106, 21)
        Me.NumericUpDownLayerThickness.TabIndex = 8
        Me.NumericUpDownLayerThickness.Value = New Decimal(New Integer() {5, 0, 0, 131072})
        '
        'NumericUpDownMinTime
        '
        Me.NumericUpDownMinTime.Location = New System.Drawing.Point(140, 253)
        Me.NumericUpDownMinTime.Maximum = New Decimal(New Integer() {3600000, 0, 0, 0})
        Me.NumericUpDownMinTime.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDownMinTime.Name = "NumericUpDownMinTime"
        Me.NumericUpDownMinTime.Size = New System.Drawing.Size(106, 21)
        Me.NumericUpDownMinTime.TabIndex = 9
        Me.NumericUpDownMinTime.Value = New Decimal(New Integer() {200, 0, 0, 0})
        '
        'NumericUpDownTimeIntv
        '
        Me.NumericUpDownTimeIntv.Location = New System.Drawing.Point(140, 280)
        Me.NumericUpDownTimeIntv.Maximum = New Decimal(New Integer() {3600000, 0, 0, 0})
        Me.NumericUpDownTimeIntv.Name = "NumericUpDownTimeIntv"
        Me.NumericUpDownTimeIntv.Size = New System.Drawing.Size(106, 21)
        Me.NumericUpDownTimeIntv.TabIndex = 10
        Me.NumericUpDownTimeIntv.Value = New Decimal(New Integer() {200, 0, 0, 0})
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button1.Location = New System.Drawing.Point(37, 387)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(89, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "生成"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 304)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(173, 12)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "移动速度 (上升/下降, mm/min)"
        '
        'NumericUpDownFeedRateDown
        '
        Me.NumericUpDownFeedRateDown.Location = New System.Drawing.Point(133, 324)
        Me.NumericUpDownFeedRateDown.Maximum = New Decimal(New Integer() {3600000, 0, 0, 0})
        Me.NumericUpDownFeedRateDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDownFeedRateDown.Name = "NumericUpDownFeedRateDown"
        Me.NumericUpDownFeedRateDown.Size = New System.Drawing.Size(113, 21)
        Me.NumericUpDownFeedRateDown.TabIndex = 14
        Me.NumericUpDownFeedRateDown.Value = New Decimal(New Integer() {300, 0, 0, 0})
        '
        'NumericUpDownFeedRateUp
        '
        Me.NumericUpDownFeedRateUp.Location = New System.Drawing.Point(14, 324)
        Me.NumericUpDownFeedRateUp.Maximum = New Decimal(New Integer() {3600000, 0, 0, 0})
        Me.NumericUpDownFeedRateUp.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDownFeedRateUp.Name = "NumericUpDownFeedRateUp"
        Me.NumericUpDownFeedRateUp.Size = New System.Drawing.Size(113, 21)
        Me.NumericUpDownFeedRateUp.TabIndex = 13
        Me.NumericUpDownFeedRateUp.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 95)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 12)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "图案 (mm)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 138)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 12)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "间距"
        '
        'NumericUpDownPatternDistance
        '
        Me.NumericUpDownPatternDistance.DecimalPlaces = 2
        Me.NumericUpDownPatternDistance.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NumericUpDownPatternDistance.Location = New System.Drawing.Point(71, 136)
        Me.NumericUpDownPatternDistance.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NumericUpDownPatternDistance.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NumericUpDownPatternDistance.Name = "NumericUpDownPatternDistance"
        Me.NumericUpDownPatternDistance.Size = New System.Drawing.Size(64, 21)
        Me.NumericUpDownPatternDistance.TabIndex = 18
        Me.NumericUpDownPatternDistance.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 112)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(17, 12)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "长"
        '
        'NumericUpDownPatternWidth
        '
        Me.NumericUpDownPatternWidth.DecimalPlaces = 2
        Me.NumericUpDownPatternWidth.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NumericUpDownPatternWidth.Location = New System.Drawing.Point(53, 109)
        Me.NumericUpDownPatternWidth.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NumericUpDownPatternWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NumericUpDownPatternWidth.Name = "NumericUpDownPatternWidth"
        Me.NumericUpDownPatternWidth.Size = New System.Drawing.Size(64, 21)
        Me.NumericUpDownPatternWidth.TabIndex = 16
        Me.NumericUpDownPatternWidth.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'NumericUpDownTotalThickness
        '
        Me.NumericUpDownTotalThickness.DecimalPlaces = 3
        Me.NumericUpDownTotalThickness.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.NumericUpDownTotalThickness.Location = New System.Drawing.Point(140, 226)
        Me.NumericUpDownTotalThickness.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NumericUpDownTotalThickness.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NumericUpDownTotalThickness.Name = "NumericUpDownTotalThickness"
        Me.NumericUpDownTotalThickness.Size = New System.Drawing.Size(106, 21)
        Me.NumericUpDownTotalThickness.TabIndex = 21
        Me.NumericUpDownTotalThickness.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 228)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 12)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "总厚度 (mm)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 350)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 12)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "抬升距离 (mm)"
        '
        'NumericUpDownLiftDistance
        '
        Me.NumericUpDownLiftDistance.DecimalPlaces = 3
        Me.NumericUpDownLiftDistance.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.NumericUpDownLiftDistance.Location = New System.Drawing.Point(140, 348)
        Me.NumericUpDownLiftDistance.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NumericUpDownLiftDistance.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NumericUpDownLiftDistance.Name = "NumericUpDownLiftDistance"
        Me.NumericUpDownLiftDistance.Size = New System.Drawing.Size(106, 21)
        Me.NumericUpDownLiftDistance.TabIndex = 23
        Me.NumericUpDownLiftDistance.Value = New Decimal(New Integer() {25, 0, 0, 65536})
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 174)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 12)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "边距"
        '
        'NumericUpDownEdgeDistanceW
        '
        Me.NumericUpDownEdgeDistanceW.DecimalPlaces = 2
        Me.NumericUpDownEdgeDistanceW.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NumericUpDownEdgeDistanceW.Location = New System.Drawing.Point(94, 172)
        Me.NumericUpDownEdgeDistanceW.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NumericUpDownEdgeDistanceW.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NumericUpDownEdgeDistanceW.Name = "NumericUpDownEdgeDistanceW"
        Me.NumericUpDownEdgeDistanceW.Size = New System.Drawing.Size(73, 21)
        Me.NumericUpDownEdgeDistanceW.TabIndex = 25
        Me.NumericUpDownEdgeDistanceW.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button2.Location = New System.Drawing.Point(132, 387)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(89, 23)
        Me.Button2.TabIndex = 26
        Me.Button2.Text = "使用当前图案"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(123, 30)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(17, 12)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "宽"
        '
        'NumericUpDownDisplayH
        '
        Me.NumericUpDownDisplayH.Location = New System.Drawing.Point(182, 28)
        Me.NumericUpDownDisplayH.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NumericUpDownDisplayH.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDownDisplayH.Name = "NumericUpDownDisplayH"
        Me.NumericUpDownDisplayH.Size = New System.Drawing.Size(64, 21)
        Me.NumericUpDownDisplayH.TabIndex = 30
        Me.NumericUpDownDisplayH.Value = New Decimal(New Integer() {1080, 0, 0, 0})
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 30)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(17, 12)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "长"
        '
        'NumericUpDownDisplayW
        '
        Me.NumericUpDownDisplayW.Location = New System.Drawing.Point(53, 28)
        Me.NumericUpDownDisplayW.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NumericUpDownDisplayW.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDownDisplayW.Name = "NumericUpDownDisplayW"
        Me.NumericUpDownDisplayW.Size = New System.Drawing.Size(64, 21)
        Me.NumericUpDownDisplayW.TabIndex = 28
        Me.NumericUpDownDisplayW.Value = New Decimal(New Integer() {1920, 0, 0, 0})
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 9)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(83, 12)
        Me.Label16.TabIndex = 27
        Me.Label16.Text = "显示区域 (px)"
        '
        'NumericUpDownEdgeDistanceH
        '
        Me.NumericUpDownEdgeDistanceH.DecimalPlaces = 2
        Me.NumericUpDownEdgeDistanceH.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NumericUpDownEdgeDistanceH.Location = New System.Drawing.Point(173, 172)
        Me.NumericUpDownEdgeDistanceH.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NumericUpDownEdgeDistanceH.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NumericUpDownEdgeDistanceH.Name = "NumericUpDownEdgeDistanceH"
        Me.NumericUpDownEdgeDistanceH.Size = New System.Drawing.Size(73, 21)
        Me.NumericUpDownEdgeDistanceH.TabIndex = 32
        Me.NumericUpDownEdgeDistanceH.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(123, 112)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(17, 12)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "宽"
        '
        'NumericUpDownPatternHeight
        '
        Me.NumericUpDownPatternHeight.DecimalPlaces = 2
        Me.NumericUpDownPatternHeight.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NumericUpDownPatternHeight.Location = New System.Drawing.Point(182, 109)
        Me.NumericUpDownPatternHeight.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NumericUpDownPatternHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NumericUpDownPatternHeight.Name = "NumericUpDownPatternHeight"
        Me.NumericUpDownPatternHeight.Size = New System.Drawing.Size(64, 21)
        Me.NumericUpDownPatternHeight.TabIndex = 34
        Me.NumericUpDownPatternHeight.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'TestPatternGenerator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(260, 422)
        Me.Controls.Add(Me.NumericUpDownPatternHeight)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.NumericUpDownEdgeDistanceH)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.NumericUpDownDisplayH)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.NumericUpDownDisplayW)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.NumericUpDownEdgeDistanceW)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.NumericUpDownLiftDistance)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.NumericUpDownTotalThickness)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.NumericUpDownPatternDistance)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.NumericUpDownPatternWidth)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.NumericUpDownFeedRateDown)
        Me.Controls.Add(Me.NumericUpDownFeedRateUp)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.NumericUpDownTimeIntv)
        Me.Controls.Add(Me.NumericUpDownMinTime)
        Me.Controls.Add(Me.NumericUpDownLayerThickness)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NumericUpDownH)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NumericUpDownW)
        Me.Controls.Add(Me.Label1)
        Me.Name = "TestPatternGenerator"
        Me.Text = "测试图案"
        CType(Me.NumericUpDownW, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownLayerThickness, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownMinTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownTimeIntv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownFeedRateDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownFeedRateUp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownPatternDistance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownPatternWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownTotalThickness, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownLiftDistance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownEdgeDistanceW, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownDisplayH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownDisplayW, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownEdgeDistanceH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownPatternHeight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents NumericUpDownW As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents NumericUpDownH As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents NumericUpDownLayerThickness As NumericUpDown
    Friend WithEvents NumericUpDownMinTime As NumericUpDown
    Friend WithEvents NumericUpDownTimeIntv As NumericUpDown
    Friend WithEvents Button1 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents NumericUpDownFeedRateDown As NumericUpDown
    Friend WithEvents NumericUpDownFeedRateUp As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents NumericUpDownPatternDistance As NumericUpDown
    Friend WithEvents Label10 As Label
    Friend WithEvents NumericUpDownPatternWidth As NumericUpDown
    Friend WithEvents NumericUpDownTotalThickness As NumericUpDown
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents NumericUpDownLiftDistance As NumericUpDown
    Friend WithEvents Label13 As Label
    Friend WithEvents NumericUpDownEdgeDistanceW As NumericUpDown
    Friend WithEvents Button2 As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents NumericUpDownDisplayH As NumericUpDown
    Friend WithEvents Label15 As Label
    Friend WithEvents NumericUpDownDisplayW As NumericUpDown
    Friend WithEvents Label16 As Label
    Friend WithEvents NumericUpDownEdgeDistanceH As NumericUpDown
    Friend WithEvents Label17 As Label
    Friend WithEvents NumericUpDownPatternHeight As NumericUpDown
End Class
