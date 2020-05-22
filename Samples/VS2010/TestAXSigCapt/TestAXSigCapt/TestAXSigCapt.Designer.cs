namespace TestAXSigCapt
{
    partial class TestAXSigCapt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestAXSigCapt));
            this.btnSign = new System.Windows.Forms.Button();
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.axSigCtl1 = new Florentis.AxSigCtl();
            ((System.ComponentModel.ISupportInitialize)(this.axSigCtl1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(275, 46);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(74, 33);
            this.btnSign.TabIndex = 0;
            this.btnSign.Text = "Sign";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // txtDisplay
            // 
            this.txtDisplay.Location = new System.Drawing.Point(12, 145);
            this.txtDisplay.Multiline = true;
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDisplay.Size = new System.Drawing.Size(371, 139);
            this.txtDisplay.TabIndex = 1;
            // 
            // axSigCtl1
            // 
            this.axSigCtl1.Location = new System.Drawing.Point(12, 12);
            this.axSigCtl1.Name = "axSigCtl1";
            this.axSigCtl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSigCtl1.OcxState")));
            this.axSigCtl1.Size = new System.Drawing.Size(210, 113);
            this.axSigCtl1.TabIndex = 2;
            // 
            // TestAXSigCapt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 296);
            this.Controls.Add(this.axSigCtl1);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.btnSign);
            this.Name = "TestAXSigCapt";
            this.Text = "TestAXSigCapt";
            ((System.ComponentModel.ISupportInitialize)(this.axSigCtl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.TextBox txtDisplay;
        private Florentis.AxSigCtl axSigCtl1;
    }
}

