<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VBTestSigCapt
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
		Me.sigImage = New System.Windows.Forms.PictureBox()
		Me.btnSign = New System.Windows.Forms.Button()
		Me.txtDisplay = New System.Windows.Forms.TextBox()
		Me.btnExit = New System.Windows.Forms.Button()
		CType(Me.sigImage, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'sigImage
		'
		Me.sigImage.BackColor = System.Drawing.SystemColors.ControlLightLight
		Me.sigImage.Location = New System.Drawing.Point(40, 44)
		Me.sigImage.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
		Me.sigImage.Name = "sigImage"
		Me.sigImage.Size = New System.Drawing.Size(640, 403)
		Me.sigImage.TabIndex = 0
		Me.sigImage.TabStop = False
		'
		'btnSign
		'
		Me.btnSign.BackColor = System.Drawing.SystemColors.ActiveCaption
		Me.btnSign.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.14286!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnSign.Location = New System.Drawing.Point(766, 105)
		Me.btnSign.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
		Me.btnSign.Name = "btnSign"
		Me.btnSign.Size = New System.Drawing.Size(208, 123)
		Me.btnSign.TabIndex = 1
		Me.btnSign.Text = "Sign"
		Me.btnSign.UseVisualStyleBackColor = False
		'
		'txtDisplay
		'
		Me.txtDisplay.Location = New System.Drawing.Point(40, 506)
		Me.txtDisplay.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
		Me.txtDisplay.Multiline = True
		Me.txtDisplay.Name = "txtDisplay"
		Me.txtDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtDisplay.Size = New System.Drawing.Size(640, 389)
		Me.txtDisplay.TabIndex = 2
		'
		'btnExit
		'
		Me.btnExit.BackColor = System.Drawing.SystemColors.ActiveCaption
		Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.14286!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnExit.Location = New System.Drawing.Point(766, 294)
		Me.btnExit.Margin = New System.Windows.Forms.Padding(6)
		Me.btnExit.Name = "btnExit"
		Me.btnExit.Size = New System.Drawing.Size(208, 124)
		Me.btnExit.TabIndex = 3
		Me.btnExit.Text = "Exit"
		Me.btnExit.UseVisualStyleBackColor = False
		'
		'VBTestSigCapt
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ClientSize = New System.Drawing.Size(1094, 967)
		Me.Controls.Add(Me.btnExit)
		Me.Controls.Add(Me.txtDisplay)
		Me.Controls.Add(Me.btnSign)
		Me.Controls.Add(Me.sigImage)
		Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
		Me.Name = "VBTestSigCapt"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Form1"
		CType(Me.sigImage, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents sigImage As System.Windows.Forms.PictureBox
    Friend WithEvents btnSign As System.Windows.Forms.Button
    Friend WithEvents txtDisplay As System.Windows.Forms.TextBox
    Friend WithEvents btnExit As Button
End Class
