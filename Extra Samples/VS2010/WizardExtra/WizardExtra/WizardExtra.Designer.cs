namespace WizardExtra
{
  partial class WizardExtra
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardExtra));
			this.btnSign = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.txtDisplay = new System.Windows.Forms.TextBox();
			this.WizCtl = new Florentis.AxWizCtl();
			this.SigCtl = new Florentis.AxSigCtl();
			this.chkSigText = new System.Windows.Forms.CheckBox();
			this.chkLargeCheckBox = new System.Windows.Forms.CheckBox();
			this.radStandard = new System.Windows.Forms.RadioButton();
			this.radUTF8 = new System.Windows.Forms.RadioButton();
			this.radImage = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnExit = new System.Windows.Forms.Button();
			this.picWizardStep = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.WizCtl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SigCtl)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picWizardStep)).BeginInit();
			this.SuspendLayout();
			// 
			// btnSign
			// 
			this.btnSign.BackColor = System.Drawing.SystemColors.HotTrack;
			this.btnSign.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.btnSign.Location = new System.Drawing.Point(41, 1068);
			this.btnSign.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnSign.Name = "btnSign";
			this.btnSign.Size = new System.Drawing.Size(141, 56);
			this.btnSign.TabIndex = 1;
			this.btnSign.Text = "&Sign";
			this.btnSign.UseVisualStyleBackColor = false;
			this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.BackColor = System.Drawing.SystemColors.HotTrack;
			this.btnCancel.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.btnCancel.Location = new System.Drawing.Point(309, 1068);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(141, 56);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// txtDisplay
			// 
			this.txtDisplay.Location = new System.Drawing.Point(1332, 12);
			this.txtDisplay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtDisplay.Multiline = true;
			this.txtDisplay.Name = "txtDisplay";
			this.txtDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDisplay.Size = new System.Drawing.Size(602, 731);
			this.txtDisplay.TabIndex = 3;
			// 
			// WizCtl
			// 
			this.WizCtl.Enabled = true;
			this.WizCtl.Location = new System.Drawing.Point(1406, 828);
			this.WizCtl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.WizCtl.Name = "WizCtl";
			this.WizCtl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WizCtl.OcxState")));
			this.WizCtl.Size = new System.Drawing.Size(402, 242);
			this.WizCtl.TabIndex = 4;
			this.WizCtl.Visible = false;
			// 
			// SigCtl
			// 
			this.SigCtl.Location = new System.Drawing.Point(1454, 915);
			this.SigCtl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.SigCtl.Name = "SigCtl";
			this.SigCtl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("SigCtl.OcxState")));
			this.SigCtl.Size = new System.Drawing.Size(331, 164);
			this.SigCtl.TabIndex = 5;
			this.SigCtl.Visible = false;
			// 
			// chkSigText
			// 
			this.chkSigText.AutoSize = true;
			this.chkSigText.Location = new System.Drawing.Point(321, 885);
			this.chkSigText.Name = "chkSigText";
			this.chkSigText.Size = new System.Drawing.Size(141, 24);
			this.chkSigText.TabIndex = 6;
			this.chkSigText.Text = "Output SigText";
			this.chkSigText.UseVisualStyleBackColor = true;
			// 
			// chkLargeCheckBox
			// 
			this.chkLargeCheckBox.AutoSize = true;
			this.chkLargeCheckBox.Location = new System.Drawing.Point(321, 931);
			this.chkLargeCheckBox.Name = "chkLargeCheckBox";
			this.chkLargeCheckBox.Size = new System.Drawing.Size(150, 24);
			this.chkLargeCheckBox.TabIndex = 7;
			this.chkLargeCheckBox.Text = "Large Checkbox";
			this.chkLargeCheckBox.UseVisualStyleBackColor = true;
			// 
			// radStandard
			// 
			this.radStandard.AutoSize = true;
			this.radStandard.Checked = true;
			this.radStandard.Location = new System.Drawing.Point(30, 40);
			this.radStandard.Name = "radStandard";
			this.radStandard.Size = new System.Drawing.Size(100, 24);
			this.radStandard.TabIndex = 8;
			this.radStandard.TabStop = true;
			this.radStandard.Text = "Standard";
			this.radStandard.UseVisualStyleBackColor = true;
			// 
			// radUTF8
			// 
			this.radUTF8.AutoSize = true;
			this.radUTF8.Location = new System.Drawing.Point(30, 86);
			this.radUTF8.Name = "radUTF8";
			this.radUTF8.Size = new System.Drawing.Size(74, 24);
			this.radUTF8.TabIndex = 9;
			this.radUTF8.TabStop = true;
			this.radUTF8.Text = "UTF8";
			this.radUTF8.UseVisualStyleBackColor = true;
			// 
			// radImage
			// 
			this.radImage.AutoSize = true;
			this.radImage.Location = new System.Drawing.Point(30, 131);
			this.radImage.Name = "radImage";
			this.radImage.Size = new System.Drawing.Size(79, 24);
			this.radImage.TabIndex = 10;
			this.radImage.TabStop = true;
			this.radImage.Text = "Image";
			this.radImage.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radStandard);
			this.groupBox1.Controls.Add(this.radImage);
			this.groupBox1.Controls.Add(this.radUTF8);
			this.groupBox1.Location = new System.Drawing.Point(41, 828);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(228, 171);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Button type:";
			// 
			// btnExit
			// 
			this.btnExit.BackColor = System.Drawing.SystemColors.HotTrack;
			this.btnExit.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.btnExit.Location = new System.Drawing.Point(575, 1068);
			this.btnExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(141, 56);
			this.btnExit.TabIndex = 11;
			this.btnExit.Text = "E&xit";
			this.btnExit.UseVisualStyleBackColor = false;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// picWizardStep
			// 
			this.picWizardStep.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.picWizardStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picWizardStep.Location = new System.Drawing.Point(12, 12);
			this.picWizardStep.Name = "picWizardStep";
			this.picWizardStep.Size = new System.Drawing.Size(1014, 731);
			this.picWizardStep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picWizardStep.TabIndex = 12;
			this.picWizardStep.TabStop = false;
			// 
			// WizardExtra
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(2009, 1217);
			this.Controls.Add(this.picWizardStep);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.chkLargeCheckBox);
			this.Controls.Add(this.chkSigText);
			this.Controls.Add(this.SigCtl);
			this.Controls.Add(this.WizCtl);
			this.Controls.Add(this.txtDisplay);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSign);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "WizardExtra";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "WizardExtra";
			((System.ComponentModel.ISupportInitialize)(this.WizCtl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SigCtl)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picWizardStep)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Button btnSign;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.TextBox txtDisplay;
    private Florentis.AxWizCtl WizCtl;
    private Florentis.AxSigCtl SigCtl;
		private System.Windows.Forms.CheckBox chkSigText;
		private System.Windows.Forms.CheckBox chkLargeCheckBox;
		private System.Windows.Forms.RadioButton radStandard;
		private System.Windows.Forms.RadioButton radUTF8;
		private System.Windows.Forms.RadioButton radImage;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.PictureBox picWizardStep;
	}
}

