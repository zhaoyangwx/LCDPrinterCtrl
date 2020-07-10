<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BatchCopy
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
        Me.NumericUpDownSa = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NumericUpDownTa = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownTb = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NumericUpDownSb = New System.Windows.Forms.NumericUpDown()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        CType(Me.NumericUpDownSa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownTa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownTb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownSb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "选中"
        '
        'NumericUpDownSa
        '
        Me.NumericUpDownSa.Location = New System.Drawing.Point(59, 7)
        Me.NumericUpDownSa.Name = "NumericUpDownSa"
        Me.NumericUpDownSa.Size = New System.Drawing.Size(54, 21)
        Me.NumericUpDownSa.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "目标"
        '
        'NumericUpDownTa
        '
        Me.NumericUpDownTa.Location = New System.Drawing.Point(59, 34)
        Me.NumericUpDownTa.Name = "NumericUpDownTa"
        Me.NumericUpDownTa.Size = New System.Drawing.Size(54, 21)
        Me.NumericUpDownTa.TabIndex = 3
        '
        'NumericUpDownTb
        '
        Me.NumericUpDownTb.Location = New System.Drawing.Point(142, 34)
        Me.NumericUpDownTb.Name = "NumericUpDownTb"
        Me.NumericUpDownTb.Size = New System.Drawing.Size(54, 21)
        Me.NumericUpDownTb.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(119, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "到"
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button1.Location = New System.Drawing.Point(23, 151)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Location = New System.Drawing.Point(104, 151)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(119, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "到"
        '
        'NumericUpDownSb
        '
        Me.NumericUpDownSb.Location = New System.Drawing.Point(142, 7)
        Me.NumericUpDownSb.Name = "NumericUpDownSb"
        Me.NumericUpDownSb.Size = New System.Drawing.Size(54, 21)
        Me.NumericUpDownSb.TabIndex = 2
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(12, 61)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(108, 16)
        Me.CheckBox1.TabIndex = 5
        Me.CheckBox1.Text = "复制曝光前指令"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(12, 83)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(108, 16)
        Me.CheckBox2.TabIndex = 6
        Me.CheckBox2.Text = "复制曝光后指令"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Checked = True
        Me.CheckBox3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox3.Location = New System.Drawing.Point(12, 105)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(96, 16)
        Me.CheckBox3.TabIndex = 7
        Me.CheckBox3.Text = "复制曝光时间"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(12, 127)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(72, 16)
        Me.CheckBox4.TabIndex = 8
        Me.CheckBox4.Text = "复制图像"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'BatchCopy
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button2
        Me.ClientSize = New System.Drawing.Size(211, 186)
        Me.Controls.Add(Me.CheckBox4)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.NumericUpDownSb)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NumericUpDownTb)
        Me.Controls.Add(Me.NumericUpDownTa)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NumericUpDownSa)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "BatchCopy"
        Me.Text = "BatchCopy"
        CType(Me.NumericUpDownSa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownTa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownTb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownSb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label4 As Label
    Public WithEvents NumericUpDownSa As NumericUpDown
    Public WithEvents NumericUpDownTa As NumericUpDown
    Public WithEvents NumericUpDownTb As NumericUpDown
    Public WithEvents NumericUpDownSb As NumericUpDown
    Public WithEvents CheckBox1 As CheckBox
    Public WithEvents CheckBox2 As CheckBox
    Public WithEvents CheckBox3 As CheckBox
    Public WithEvents CheckBox4 As CheckBox
End Class
