namespace SignatureCapture_WinForms
{
    partial class SignatureCaptureSample
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lstDevices = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtWhy = new TextBox();
            txtWho = new TextBox();
            cbxGuideType = new ComboBox();
            btnCapture = new Button();
            colorDialog1 = new ColorDialog();
            lblTextColor = new Label();
            txtTextColor = new TextBox();
            btnTextColor = new Button();
            btnBkgndColor = new Button();
            txtBkgndColor = new TextBox();
            label5 = new Label();
            lblBkgndColor = new Label();
            btnSigAreaColor = new Button();
            txtSigAreaColor = new TextBox();
            lblSigAreaColor = new Label();
            groupBox1 = new GroupBox();
            label8 = new Label();
            label7 = new Label();
            cbxFontSize = new ComboBox();
            cbxFontName = new ComboBox();
            groupBox2 = new GroupBox();
            label6 = new Label();
            txtMessages = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            cbxEncryption = new ComboBox();
            label9 = new Label();
            imgSignature = new PictureBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgSignature).BeginInit();
            SuspendLayout();
            // 
            // lstDevices
            // 
            lstDevices.DisplayMember = "Name";
            lstDevices.FormattingEnabled = true;
            lstDevices.ItemHeight = 25;
            lstDevices.Location = new Point(179, 12);
            lstDevices.Name = "lstDevices";
            lstDevices.Size = new Size(411, 154);
            lstDevices.TabIndex = 1;
            lstDevices.SelectedIndexChanged += DeviceSelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(64, 25);
            label1.TabIndex = 0;
            label1.Text = "Device";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 185);
            label2.Name = "label2";
            label2.Size = new Size(128, 25);
            label2.TabIndex = 2;
            label2.Text = "Reason ('Why')";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 222);
            label3.Name = "label3";
            label3.Size = new Size(149, 25);
            label3.TabIndex = 4;
            label3.Text = "Signatory ('Who')";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 70);
            label4.Name = "label4";
            label4.Size = new Size(98, 25);
            label4.TabIndex = 4;
            label4.Text = "Guide type";
            // 
            // txtWhy
            // 
            txtWhy.Location = new Point(179, 182);
            txtWhy.Name = "txtWhy";
            txtWhy.Size = new Size(411, 31);
            txtWhy.TabIndex = 3;
            txtWhy.TextChanged += WhyOrWhoChanged;
            txtWhy.Validating += ValidateWhyOrWho;
            // 
            // txtWho
            // 
            txtWho.Location = new Point(179, 219);
            txtWho.Name = "txtWho";
            txtWho.Size = new Size(411, 31);
            txtWho.TabIndex = 5;
            txtWho.TextChanged += WhyOrWhoChanged;
            // 
            // cbxGuideType
            // 
            cbxGuideType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbxGuideType.FormattingEnabled = true;
            cbxGuideType.Location = new Point(168, 67);
            cbxGuideType.Name = "cbxGuideType";
            cbxGuideType.Size = new Size(165, 33);
            cbxGuideType.TabIndex = 5;
            // 
            // btnCapture
            // 
            btnCapture.Enabled = false;
            btnCapture.Location = new Point(180, 615);
            btnCapture.Name = "btnCapture";
            btnCapture.Size = new Size(260, 52);
            btnCapture.TabIndex = 14;
            btnCapture.Text = "Capture Signature";
            btnCapture.UseVisualStyleBackColor = true;
            btnCapture.Click += CaptureButtonClicked;
            // 
            // lblTextColor
            // 
            lblTextColor.BorderStyle = BorderStyle.FixedSingle;
            lblTextColor.Location = new Point(252, 71);
            lblTextColor.Name = "lblTextColor";
            lblTextColor.Size = new Size(27, 27);
            lblTextColor.TabIndex = 5;
            lblTextColor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtTextColor
            // 
            txtTextColor.Location = new Point(167, 69);
            txtTextColor.Name = "txtTextColor";
            txtTextColor.Size = new Size(79, 31);
            txtTextColor.TabIndex = 4;
            txtTextColor.Validating += ValidateColorValue;
            // 
            // btnTextColor
            // 
            btnTextColor.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTextColor.Location = new Point(285, 71);
            btnTextColor.Name = "btnTextColor";
            btnTextColor.Size = new Size(31, 28);
            btnTextColor.TabIndex = 6;
            btnTextColor.Text = "...";
            btnTextColor.UseVisualStyleBackColor = true;
            btnTextColor.Click += TextColorButtonClicked;
            // 
            // btnBkgndColor
            // 
            btnBkgndColor.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBkgndColor.Location = new Point(298, 516);
            btnBkgndColor.Name = "btnBkgndColor";
            btnBkgndColor.Size = new Size(31, 28);
            btnBkgndColor.TabIndex = 11;
            btnBkgndColor.Text = "...";
            btnBkgndColor.UseVisualStyleBackColor = true;
            btnBkgndColor.Click += BkgndColorButtonClicked;
            // 
            // txtBkgndColor
            // 
            txtBkgndColor.Location = new Point(180, 511);
            txtBkgndColor.Name = "txtBkgndColor";
            txtBkgndColor.Size = new Size(78, 31);
            txtBkgndColor.TabIndex = 9;
            txtBkgndColor.Validating += ValidateColorValue;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 514);
            label5.Name = "label5";
            label5.Size = new Size(152, 25);
            label5.TabIndex = 8;
            label5.Text = "Background color";
            // 
            // lblBkgndColor
            // 
            lblBkgndColor.BorderStyle = BorderStyle.FixedSingle;
            lblBkgndColor.Location = new Point(264, 516);
            lblBkgndColor.Name = "lblBkgndColor";
            lblBkgndColor.Size = new Size(27, 27);
            lblBkgndColor.TabIndex = 10;
            lblBkgndColor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSigAreaColor
            // 
            btnSigAreaColor.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSigAreaColor.Location = new Point(286, 32);
            btnSigAreaColor.Name = "btnSigAreaColor";
            btnSigAreaColor.Size = new Size(31, 28);
            btnSigAreaColor.TabIndex = 3;
            btnSigAreaColor.Text = "...";
            btnSigAreaColor.UseVisualStyleBackColor = true;
            btnSigAreaColor.Click += SigAreaColorButtonClicked;
            // 
            // txtSigAreaColor
            // 
            txtSigAreaColor.Location = new Point(167, 30);
            txtSigAreaColor.Name = "txtSigAreaColor";
            txtSigAreaColor.Size = new Size(79, 31);
            txtSigAreaColor.TabIndex = 1;
            txtSigAreaColor.Validating += ValidateColorValue;
            // 
            // lblSigAreaColor
            // 
            lblSigAreaColor.BorderStyle = BorderStyle.FixedSingle;
            lblSigAreaColor.Location = new Point(252, 32);
            lblSigAreaColor.Name = "lblSigAreaColor";
            lblSigAreaColor.Size = new Size(27, 27);
            lblSigAreaColor.TabIndex = 2;
            lblSigAreaColor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(cbxFontSize);
            groupBox1.Controls.Add(cbxFontName);
            groupBox1.Controls.Add(btnTextColor);
            groupBox1.Controls.Add(txtTextColor);
            groupBox1.Controls.Add(lblTextColor);
            groupBox1.Location = new Point(12, 268);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(567, 114);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Text";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 72);
            label8.Name = "label8";
            label8.Size = new Size(55, 25);
            label8.TabIndex = 3;
            label8.Text = "Color";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 33);
            label7.Name = "label7";
            label7.Size = new Size(48, 25);
            label7.TabIndex = 0;
            label7.Text = "Font";
            // 
            // cbxFontSize
            // 
            cbxFontSize.FormattingEnabled = true;
            cbxFontSize.Location = new Point(489, 30);
            cbxFontSize.Name = "cbxFontSize";
            cbxFontSize.Size = new Size(72, 33);
            cbxFontSize.TabIndex = 2;
            // 
            // cbxFontName
            // 
            cbxFontName.FormattingEnabled = true;
            cbxFontName.Location = new Point(167, 30);
            cbxFontName.Name = "cbxFontName";
            cbxFontName.Size = new Size(315, 33);
            cbxFontName.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtSigAreaColor);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(btnSigAreaColor);
            groupBox2.Controls.Add(cbxGuideType);
            groupBox2.Controls.Add(lblSigAreaColor);
            groupBox2.Location = new Point(12, 388);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(567, 115);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Signature area";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 33);
            label6.Name = "label6";
            label6.Size = new Size(55, 25);
            label6.TabIndex = 0;
            label6.Text = "Color";
            // 
            // txtMessages
            // 
            txtMessages.Location = new Point(610, 280);
            txtMessages.Multiline = true;
            txtMessages.Name = "txtMessages";
            txtMessages.ReadOnly = true;
            txtMessages.ScrollBars = ScrollBars.Vertical;
            txtMessages.Size = new Size(509, 387);
            txtMessages.TabIndex = 15;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // cbxEncryption
            // 
            cbxEncryption.FormattingEnabled = true;
            cbxEncryption.Items.AddRange(new object[] { "None", "Symmetric", "Public key" });
            cbxEncryption.Location = new Point(179, 560);
            cbxEncryption.Name = "cbxEncryption";
            cbxEncryption.Size = new Size(166, 33);
            cbxEncryption.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(18, 563);
            label9.Name = "label9";
            label9.Size = new Size(96, 25);
            label9.TabIndex = 12;
            label9.Text = "Encryption";
            // 
            // imgSignature
            // 
            imgSignature.BorderStyle = BorderStyle.Fixed3D;
            imgSignature.Location = new Point(610, 12);
            imgSignature.Name = "imgSignature";
            imgSignature.Size = new Size(509, 238);
            imgSignature.TabIndex = 27;
            imgSignature.TabStop = false;
            // 
            // SignatureCaptureSample
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1140, 689);
            Controls.Add(imgSignature);
            Controls.Add(label9);
            Controls.Add(cbxEncryption);
            Controls.Add(txtMessages);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnBkgndColor);
            Controls.Add(txtBkgndColor);
            Controls.Add(label5);
            Controls.Add(lblBkgndColor);
            Controls.Add(btnCapture);
            Controls.Add(txtWho);
            Controls.Add(txtWhy);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lstDevices);
            MaximizeBox = false;
            Name = "SignatureCaptureSample";
            Text = "Wacom Signature Capture Sample";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgSignature).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstDevices;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtWhy;
        private TextBox txtWho;
        private ComboBox cbxGuideType;
        private Button btnCapture;
        private ColorDialog colorDialog1;
        private Label lblTextColor;
        private TextBox txtTextColor;
        private Button btnTextColor;
        private Button btnBkgndColor;
        private TextBox txtBkgndColor;
        private Label label5;
        private Label lblBkgndColor;
        private Button btnSigAreaColor;
        private TextBox txtSigAreaColor;
        private Label lblSigAreaColor;
        private GroupBox groupBox1;
        private ComboBox cbxFontSize;
        private ComboBox cbxFontName;
        private GroupBox groupBox2;
        private Label label8;
        private Label label7;
        private Label label6;
        private TextBox txtMessages;
        private ErrorProvider errorProvider1;
        private Label label9;
        private ComboBox cbxEncryption;
        private PictureBox imgSignature;
    }
}
