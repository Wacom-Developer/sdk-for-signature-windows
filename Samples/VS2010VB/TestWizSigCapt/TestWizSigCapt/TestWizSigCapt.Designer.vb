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
        CType(Me.sigImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WizCtl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SigCtl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'sigImage
        '
        Me.sigImage.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.sigImage.Location = New System.Drawing.Point(18, 18)
        Me.sigImage.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.sigImage.Name = "sigImage"
        Me.sigImage.Size = New System.Drawing.Size(300, 231)
        Me.sigImage.TabIndex = 0
        Me.sigImage.TabStop = False
        '
        'btnSign
        '
        Me.btnSign.Location = New System.Drawing.Point(354, 74)
        Me.btnSign.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSign.Name = "btnSign"
        Me.btnSign.Size = New System.Drawing.Size(118, 52)
        Me.btnSign.TabIndex = 1
        Me.btnSign.Text = "Sign"
        Me.btnSign.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(354, 155)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(118, 52)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtDisplay
        '
        Me.txtDisplay.Location = New System.Drawing.Point(18, 280)
        Me.txtDisplay.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDisplay.Multiline = True
        Me.txtDisplay.Name = "txtDisplay"
        Me.txtDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDisplay.Size = New System.Drawing.Size(454, 141)
        Me.txtDisplay.TabIndex = 3
        '
        'WizCtl
        '
        Me.WizCtl.Enabled = True
        Me.WizCtl.Location = New System.Drawing.Point(34, 14)
        Me.WizCtl.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.WizCtl.Name = "WizCtl"
        Me.WizCtl.OcxState = CType(resources.GetObject("WizCtl.OcxState"), System.Windows.Forms.AxHost.State)
        Me.WizCtl.Size = New System.Drawing.Size(402, 242)
        Me.WizCtl.TabIndex = 4
        Me.WizCtl.Visible = False
        '
        'SigCtl
        '
        Me.SigCtl.Location = New System.Drawing.Point(4, 280)
        Me.SigCtl.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SigCtl.Name = "SigCtl"
        Me.SigCtl.OcxState = CType(resources.GetObject("SigCtl.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SigCtl.Size = New System.Drawing.Size(284, 141)
        Me.SigCtl.TabIndex = 5
        Me.SigCtl.Visible = False
        '
        'TestWizSigCapt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 455)
        Me.Controls.Add(Me.SigCtl)
        Me.Controls.Add(Me.WizCtl)
        Me.Controls.Add(Me.txtDisplay)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSign)
        Me.Controls.Add(Me.sigImage)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "TestWizSigCapt"
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

End Class
