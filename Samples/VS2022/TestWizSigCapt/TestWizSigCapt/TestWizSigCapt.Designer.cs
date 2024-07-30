namespace TestWizSigCapt
{
    partial class TestWizSigCapt
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestWizSigCapt));
			this.sigImage = new System.Windows.Forms.PictureBox();
			this.btnSign = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.txtDisplay = new System.Windows.Forms.TextBox();
			this.WizCtl = new Florentis.AxWizCtl();
			this.SigCtl = new Florentis.AxSigCtl();
			this.btnExit = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.sigImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.WizCtl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SigCtl)).BeginInit();
			this.SuspendLayout();
			// 
			// sigImage
			// 
			this.sigImage.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.sigImage.Location = new System.Drawing.Point(22, 22);
			this.sigImage.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.sigImage.Name = "sigImage";
			this.sigImage.Size = new System.Drawing.Size(579, 431);
			this.sigImage.TabIndex = 0;
			this.sigImage.TabStop = false;
			// 
			// btnSign
			// 
			this.btnSign.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.btnSign.FlatAppearance.BorderColor = System.Drawing.Color.Green;
			this.btnSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSign.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnSign.Location = new System.Drawing.Point(689, 22);
			this.btnSign.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.btnSign.Name = "btnSign";
			this.btnSign.Size = new System.Drawing.Size(181, 91);
			this.btnSign.TabIndex = 1;
			this.btnSign.Text = "Sign";
			this.btnSign.UseVisualStyleBackColor = false;
			this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Green;
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(689, 190);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(181, 91);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// txtDisplay
			// 
			this.txtDisplay.Location = new System.Drawing.Point(14, 478);
			this.txtDisplay.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.txtDisplay.Multiline = true;
			this.txtDisplay.Name = "txtDisplay";
			this.txtDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDisplay.Size = new System.Drawing.Size(587, 432);
			this.txtDisplay.TabIndex = 3;
			// 
			// WizCtl
			// 
			this.WizCtl.Enabled = true;
			this.WizCtl.Location = new System.Drawing.Point(644, 668);
			this.WizCtl.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.WizCtl.Name = "WizCtl";
			this.WizCtl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WizCtl.OcxState")));
			this.WizCtl.Size = new System.Drawing.Size(402, 242);
			this.WizCtl.TabIndex = 4;
			this.WizCtl.Visible = false;
			// 
			// SigCtl
			// 
			this.SigCtl.Location = new System.Drawing.Point(76, 709);
			this.SigCtl.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.SigCtl.Name = "SigCtl";
			this.SigCtl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("SigCtl.OcxState")));
			this.SigCtl.Size = new System.Drawing.Size(331, 164);
			this.SigCtl.TabIndex = 5;
			this.SigCtl.Visible = false;
			// 
			// btnExit
			// 
			this.btnExit.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.Green;
			this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnExit.Location = new System.Drawing.Point(689, 362);
			this.btnExit.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(181, 91);
			this.btnExit.TabIndex = 6;
			this.btnExit.Text = "Exit";
			this.btnExit.UseVisualStyleBackColor = false;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// TestWizSigCapt
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1086, 925);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.SigCtl);
			this.Controls.Add(this.WizCtl);
			this.Controls.Add(this.txtDisplay);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSign);
			this.Controls.Add(this.sigImage);
			this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.Name = "TestWizSigCapt";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Wizard Signature Capture";
			((System.ComponentModel.ISupportInitialize)(this.sigImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.WizCtl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SigCtl)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sigImage;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtDisplay;
        private Florentis.AxWizCtl WizCtl;
        private Florentis.AxSigCtl SigCtl;
		private System.Windows.Forms.Button btnExit;
	}
}

