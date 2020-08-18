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
            ((System.ComponentModel.ISupportInitialize)(this.sigImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WizCtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SigCtl)).BeginInit();
            this.SuspendLayout();
            // 
            // sigImage
            // 
            this.sigImage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.sigImage.Location = new System.Drawing.Point(12, 12);
            this.sigImage.Name = "sigImage";
            this.sigImage.Size = new System.Drawing.Size(200, 150);
            this.sigImage.TabIndex = 0;
            this.sigImage.TabStop = false;
            // 
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(243, 42);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(90, 35);
            this.btnSign.TabIndex = 1;
            this.btnSign.Text = "Sign";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(243, 101);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 35);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtDisplay
            // 
            this.txtDisplay.Location = new System.Drawing.Point(12, 182);
            this.txtDisplay.Multiline = true;
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDisplay.Size = new System.Drawing.Size(322, 113);
            this.txtDisplay.TabIndex = 3;
            // 
            // WizCtl
            // 
            this.WizCtl.Enabled = true;
            this.WizCtl.Location = new System.Drawing.Point(340, 173);
            this.WizCtl.Name = "WizCtl";
            this.WizCtl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WizCtl.OcxState")));
            this.WizCtl.Size = new System.Drawing.Size(402, 242);
            this.WizCtl.TabIndex = 4;
            // 
            // SigCtl
            // 
            this.SigCtl.Location = new System.Drawing.Point(12, 312);
            this.SigCtl.Name = "SigCtl";
            this.SigCtl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("SigCtl.OcxState")));
            this.SigCtl.Size = new System.Drawing.Size(284, 141);
            this.SigCtl.TabIndex = 5;
            this.SigCtl.Visible = false;
            // 
            // TestWizSigCapt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 514);
            this.Controls.Add(this.SigCtl);
            this.Controls.Add(this.WizCtl);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSign);
            this.Controls.Add(this.sigImage);
            this.Name = "TestWizSigCapt";
            this.Text = "TestWizSigCapt";
            this.Load += new System.EventHandler(this.TestWizSigCapt_Load);
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
    }
}

