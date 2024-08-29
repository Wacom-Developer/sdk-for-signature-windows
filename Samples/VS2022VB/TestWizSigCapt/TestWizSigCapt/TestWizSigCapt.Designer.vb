<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TestWizSigCapt
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TestWizSigCapt))
		Me.sigImage = New System.Windows.Forms.PictureBox()
		Me.btnSign = New System.Windows.Forms.Button()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.txtDisplay = New System.Windows.Forms.TextBox()
		Me.WizCtl = New Florentis.AxWizCtl()
		Me.SigCtl = New Florentis.AxSigCtl()
		Me.btnExit = New System.Windows.Forms.Button()
		CType(Me.sigImage, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.WizCtl, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.SigCtl, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'sigImage
		'
		Me.sigImage.BackColor = System.Drawing.SystemColors.ControlLightLight
		Me.sigImage.Location = New System.Drawing.Point(22, 22)
		Me.sigImage.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
		Me.sigImage.Name = "sigImage"
		Me.sigImage.Size = New System.Drawing.Size(367, 277)
		Me.sigImage.TabIndex = 0
		Me.sigImage.TabStop = False
		'
		'btnSign
		'
		Me.btnSign.BackColor = System.Drawing.SystemColors.ActiveCaption
		Me.btnSign.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnSign.Location = New System.Drawing.Point(433, 22)
		Me.btnSign.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
		Me.btnSign.Name = "btnSign"
		Me.btnSign.Size = New System.Drawing.Size(144, 62)
		Me.btnSign.TabIndex = 1
		Me.btnSign.Text = "Sign"
		Me.btnSign.UseVisualStyleBackColor = False
		'
		'btnCancel
		'
		Me.btnCancel.BackColor = System.Drawing.SystemColors.ActiveCaption
		Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnCancel.Location = New System.Drawing.Point(432, 125)
		Me.btnCancel.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(144, 62)
		Me.btnCancel.TabIndex = 2
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = False
		'
		'txtDisplay
		'
		Me.txtDisplay.Location = New System.Drawing.Point(22, 336)
		Me.txtDisplay.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
		Me.txtDisplay.Multiline = True
		Me.txtDisplay.Name = "txtDisplay"
		Me.txtDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtDisplay.Size = New System.Drawing.Size(554, 310)
		Me.txtDisplay.TabIndex = 3
		'
		'WizCtl
		'
		Me.WizCtl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.WizCtl.Enabled = True
		Me.WizCtl.Location = New System.Drawing.Point(339, 15)
		Me.WizCtl.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
		Me.WizCtl.Name = "WizCtl"
		Me.WizCtl.OcxState = CType(resources.GetObject("WizCtl.OcxState"), System.Windows.Forms.AxHost.State)
		Me.WizCtl.Size = New System.Drawing.Size(402, 242)
		Me.WizCtl.TabIndex = 4
		'
		'SigCtl
		'
		Me.SigCtl.Location = New System.Drawing.Point(80, 403)
		Me.SigCtl.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
		Me.SigCtl.Name = "SigCtl"
		Me.SigCtl.OcxState = CType(resources.GetObject("SigCtl.OcxState"), System.Windows.Forms.AxHost.State)
		Me.SigCtl.Size = New System.Drawing.Size(331, 164)
		Me.SigCtl.TabIndex = 5
		Me.SigCtl.Visible = False
		'
		'btnExit
		'
		Me.btnExit.BackColor = System.Drawing.SystemColors.ActiveCaption
		Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnExit.Location = New System.Drawing.Point(432, 237)
		Me.btnExit.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
		Me.btnExit.Name = "btnExit"
		Me.btnExit.Size = New System.Drawing.Size(144, 62)
		Me.btnExit.TabIndex = 6
		Me.btnExit.Text = "Exit"
		Me.btnExit.UseVisualStyleBackColor = False
		'
		'TestWizSigCapt
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1483, 713)
		Me.Controls.Add(Me.btnExit)
		Me.Controls.Add(Me.SigCtl)
		Me.Controls.Add(Me.WizCtl)
		Me.Controls.Add(Me.txtDisplay)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnSign)
		Me.Controls.Add(Me.sigImage)
		Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
		Me.Name = "TestWizSigCapt"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "TestWizSigCapt"
		CType(Me.sigImage, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.WizCtl, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.SigCtl, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents sigImage As System.Windows.Forms.PictureBox
	Friend WithEvents btnSign As System.Windows.Forms.Button
	Friend WithEvents btnCancel As System.Windows.Forms.Button
	Friend WithEvents txtDisplay As System.Windows.Forms.TextBox
	Friend WithEvents WizCtl As Florentis.AxWizCtl
	Friend WithEvents SigCtl As Florentis.AxSigCtl
	Friend WithEvents btnExit As Button
End Class
