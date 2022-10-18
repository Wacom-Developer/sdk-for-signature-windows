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
        CType(Me.sigImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'sigImage
        '
        Me.sigImage.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.sigImage.Location = New System.Drawing.Point(22, 24)
        Me.sigImage.Name = "sigImage"
        Me.sigImage.Size = New System.Drawing.Size(200, 150)
        Me.sigImage.TabIndex = 0
        Me.sigImage.TabStop = False
        '
        'btnSign
        '
        Me.btnSign.Location = New System.Drawing.Point(248, 81)
        Me.btnSign.Name = "btnSign"
        Me.btnSign.Size = New System.Drawing.Size(84, 40)
        Me.btnSign.TabIndex = 1
        Me.btnSign.Text = "Sign"
        Me.btnSign.UseVisualStyleBackColor = True
        '
        'txtDisplay
        '
        Me.txtDisplay.Location = New System.Drawing.Point(22, 204)
        Me.txtDisplay.Multiline = True
        Me.txtDisplay.Name = "txtDisplay"
        Me.txtDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDisplay.Size = New System.Drawing.Size(439, 123)
        Me.txtDisplay.TabIndex = 2
        '
        'TestSigCapt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(483, 347)
        Me.Controls.Add(Me.txtDisplay)
        Me.Controls.Add(Me.btnSign)
        Me.Controls.Add(Me.sigImage)
        Me.Name = "TestSigCapt"
        Me.Text = "Form1"
        CType(Me.sigImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents sigImage As System.Windows.Forms.PictureBox
    Friend WithEvents btnSign As System.Windows.Forms.Button
    Friend WithEvents txtDisplay As System.Windows.Forms.TextBox

End Class
