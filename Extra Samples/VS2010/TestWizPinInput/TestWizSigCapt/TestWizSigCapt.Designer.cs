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
            this.sigImage.Location = new System.Drawing.Point(18, 18);
            this.sigImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sigImage.Name = "sigImage";
            this.sigImage.Size = new System.Drawing.Size(300, 231);
            this.sigImage.TabIndex = 0;
            this.sigImage.TabStop = false;
            // 
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(364, 65);
            this.btnSign.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(135, 54);
            this.btnSign.TabIndex = 1;
            this.btnSign.Text = "Sign";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(364, 155);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 54);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtDisplay
            // 
            this.txtDisplay.Location = new System.Drawing.Point(18, 280);
            this.txtDisplay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDisplay.Multiline = true;
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDisplay.Size = new System.Drawing.Size(481, 171);
            this.txtDisplay.TabIndex = 3;
            // 
            // WizCtl
            // 
            this.WizCtl.Enabled = true;
            this.WizCtl.Location = new System.Drawing.Point(41, 39);
            this.WizCtl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.WizCtl.Name = "WizCtl";
            this.WizCtl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WizCtl.OcxState")));
            this.WizCtl.Size = new System.Drawing.Size(402, 242);
            this.WizCtl.TabIndex = 4;
            this.WizCtl.Visible = false;
            // 
            // SigCtl
            // 
            this.SigCtl.Location = new System.Drawing.Point(18, 280);
            this.SigCtl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SigCtl.Name = "SigCtl";
            this.SigCtl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("SigCtl.OcxState")));
            this.SigCtl.Size = new System.Drawing.Size(284, 141);
            this.SigCtl.TabIndex = 5;
            this.SigCtl.Visible = false;
            // 
            // TestWizSigCapt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 489);
            this.Controls.Add(this.SigCtl);
            this.Controls.Add(this.WizCtl);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSign);
            this.Controls.Add(this.sigImage);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TestWizSigCapt";
            this.Text = "TestWizSigCapt";
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

