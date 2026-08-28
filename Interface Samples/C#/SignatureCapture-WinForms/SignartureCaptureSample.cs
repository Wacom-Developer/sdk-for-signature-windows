using System.Text.RegularExpressions;

using WacomSignatureCaptureLibrary;

using System.Runtime.InteropServices;

namespace SignatureCapture_WinForms
{

    public partial class SignatureCaptureSample : Form
    {
        #region Fields

        /// <summary>
        /// License string supplied by Wacom
        /// </summary>
        /// <remarks>
        /// License can also be set in configuration file, however, to enable signature image display after saving 
        /// in ISO format, License string must be set here 
        /// </remarks>
        private static readonly string LicenseString = "PUT YOUR LICENSE";
        private readonly SignatureCapture m_SigCapt = new SignatureCapture();

        #endregion


        #region Encryption Keys

        /// <summary>
        /// Encryption private key and password 
        /// </summary>
        /// <remarks>For decrypting signature data encrypted by CaptureWindow.GetSignature</remarks>
        private static readonly string EncryptionPrivateKey =
            "-----BEGIN ENCRYPTED PRIVATE KEY-----\n" +
            "MIIFHzBJBgkqhkiG9w0BBQ0wPDAbBgkqhkiG9w0BBQwwDgQIBl6AqVWSlBsCAggA\n" +
            "MB0GCWCGSAFlAwQBKgQQk6H7b8mQ2sRUumupmgzWngSCBNBv1wdCOfCgSycfmWG+\n" +
            "FrBtBewEH4F32t62hyPizoFOq9UrhDYHRS/6+EOlFV4+Oh3hwajpzparCFn2vFiV\n" +
            "HKy1bl5DDvjFUfwntuTudgt11kOoxFxhyTON7Z0kcQFQOifp03EG419yogEWYPTw\n" +
            "cAd72Us1x9MWQDKra6UIE/vPH1L1RvWjQTiWXPeQcvwQIrfMw8kXmRQ9S1afyDmr\n" +
            "R+LKHzP8lCssukKtyNFutXXdIvBUo2aHva3iMqWxSLzG8qhBwiO3oyJnZpHMTrcN\n" +
            "56T2yf6cTR/OPquDlAviZ5W1ZRaIITWFUHPtUUAlYKOIZgGGeduCZmX21J5vggwP\n" +
            "F73QdKWF8MWwQLKBEQd6GaSbAhwbCz4OxffLYyJ7PKZEvR1EGioJwQnVLSgPMYQT\n" +
            "SVdQwTzaaakzJuuJ1M0zHy4tElhzs0VX2Sradahvh6w6mrs3wtCubs4WNZPiKbd0\n" +
            "In4vew02ERuNZom+dx1h4E1LxON3X+Edo+B9aBRWZcqf4Tl2Ihw12bjBlHxe/72h\n" +
            "NwKN0RqPB/PCZgpCjtO9qgJQfb8pCKca/hx+F45m2MRrr8Dwy6sG1miM70Kf0NzB\n" +
            "6uBRIHlyMw99SnXB/7jq7J2iQb4xx9dKfjJ5xSHBw+ejiFhkNz0kv2AwYh8UVwli\n" +
            "K3mCgAs/u71Q/AefkEi4+8VJLd/r72wH5saEUIRk3ZObRcD/ugL+fWcMi8ZQqXQU\n" +
            "ehk1k9RSONyMxGua3Z2jrHnmwvMdtaFEioGWR9u6/lujoYQ52PZsy6TguLYSE0aS\n" +
            "6RTbgNw5ZN720gdjGK+GSNCQznod8bw4TJQdXs5pF4rtJ2KG3CVU3QkY6sIiedzt\n" +
            "jVaZj/ln5vLvwWpm/7W/m6s97gPFfcvL3zwesMbe48iKrIQ4F65D9ZtQfHZFz5Rg\n" +
            "GlIoBqFyXz8OykUEpHgSIBceftKT3ImI5dnWw8u4chYDlE6IFec+3yqoU/8ncjTH\n" +
            "bzWbmzaSwanZ5SMxxbjfNGFgC91t6fPwDhRgESRuvQgZ/7RkmZInmcwJbVHOmu7W\n" +
            "FqNgfv5vJehQ5r/FlNi5bLYavn+Gq4bx4C+jA+nIqwW/5hW8olcUr7S/+11iZl7O\n" +
            "7y8TzItsc4JWVMJ8fkL6h+iG0XiVGq7glNYCgMX+6UVLweN/9EUR0iTeC931yMvF\n" +
            "gKkt25YrGrhqQ5MeqvgjMwWmgj+NZ2QFPb1wpPV+s4eeF3ZmTQmc5UHHtWVnGjpM\n" +
            "3cLqvsnCpF9vMJUj6i79TTf7cCQrUOdG8FO/g1JCtNfrOGCkwmz3p73t4ExfMwQS\n" +
            "qCd6jclHJMKwaGQVcfNVtyK5M0Znx9tKjFh+aGIl0vYeuYTN58NbEcJmO0iQ8zrw\n" +
            "KRcql7KzNzFkXN2PmFAsDFPPEqOfw2QRhsToR+y79OYY11d4cth9juk6Y4u8Vh8X\n" +
            "9SGyQLJCU1ZJR4dYRP7gbA8j9GvuBLmGZktcMyngVWojtL7sAxSGYDIpD7Sd7XRT\n" +
            "6Juw4aDp0UA1Pjj+ABq0D/U2znO7zWF3Krl6OOmJ4xwF9vOdj5zmsU5VM/5xPHaN\n" +
            "DH7zrxL5B2OIGkBR27Z/ZPWyWAf33r6ppMHP+WRfF0eGn6F4G/M1JbQwvnyAV+XQ\n" +
            "rBxeji2hX6nXJ3UopsiZPzAslA==\n" +
            "-----END ENCRYPTED PRIVATE KEY-----\n";
        private static readonly string EncryptionPrivateKeyPassword = "wacom";

        /// <summary>
        /// Encryption public key
        /// </summary>
        /// <remarks>Passed to CaptureWindow.GetSignature to encrypt signature data</remarks>
        private static readonly string EncryptionPublicKey =
            "-----BEGIN PUBLIC KEY-----\n" +
            "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAq9eJJumMd0xSotevVP6w\n" +
            "YHMjQqskmPfWwy5R80GLm3tXvZZBOcfnD9ynzAYXCXjqETDmGhn5tf2bku6jIRAL\n" +
            "mltJrFEJop78MC7bmOnH7dUc+OiV3s3U4KQya4FvLqiFvxyKdaZLhR/6cMdZJob8\n" +
            "KIsdfzX7MWkIJZb23Xb9CtJFk410m+d8cndSXeXMjN3G0NeTbfw6mR26Ag64V2c3\n" +
            "dLXUNHiOHJU+K72PeC2DhzXCVsC7zzI/fP38mQkuODr20IJQCTGKWiYeGwkvvIe6\n" +
            "qwQoCM0ehvtjjjCWO7s5EOyLzJx3C+AYbTxJAV+5xVAuGKa7Kq1nfaifkSeWu1HA\n" +
            "UQIDAQAB\n" +
            "-----END PUBLIC KEY-----\n";

        /// <summary>
        /// Symmetric encryption key
        /// </summary>
        /// <remarks>Passed to CaptureWindow.GetSignature to encrypt signature data
        /// and for decrypting the returned signature data 
        /// </remarks>
        private static readonly string EncryptionSymmetricKey = "WacomSignatureCapture";

        #endregion


        #region Interop

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private void BringToFrontAndFocus()
        {
            SetForegroundWindow(this.Handle);
        }

        #endregion

        #region Initialization

        /// <summary>
        /// Constructor
        /// </summary>
        public SignatureCaptureSample()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(LicenseString))
            {
                m_SigCapt.License.Add(LicenseString);
            }
        }

        /// <summary>
        /// Initialize fields, populate lists etc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // List devices
            RefreshDeviceList();

            // Populate lists of options for configuration overrides.
            // In each case, string.Empty first item indicates acceptance of defaults

            // List font names
            var installedFonts = FontFamily.Families.Select(f => f.Name).ToList();

            cbxFontName.Items.Add(string.Empty);
            cbxFontName.Items.AddRange(installedFonts.ToArray());
            cbxFontName.SelectedIndex = 0;

            // List a selection of font sizes
            cbxFontSize.Items.Add(string.Empty);
            for (int size = 8; size <= 16; size += 2)
            {
                cbxFontSize.Items.Add(size);
            }
            cbxFontSize.SelectedIndex = 0;

            // List signature guide types
            cbxGuideType.DataSource = new List<string> { string.Empty, "none", "line", "box" };
        }

        #endregion


        #region SignatureCapture

        /// <summary>
        /// Initiate signature capture
        /// </summary>
        /// <param name="device">The device to use</param>
        private void CaptureSignature(ISignatureDevice device)
        {
            try
            {

                if (!SetConfiguration())
                    return;

                var captWnd = m_SigCapt.CreateCaptureWindow(device, txtWho.Text, txtWhy.Text, null, out CaptureResult errorType, out string errorDesc);
                if (captWnd == null || errorType != CaptureResult.CaptureResult_Pending)
                {
                    AppendMessage($"CreateCaptureWindow failed. Error={errorType} '{errorDesc}'");
                }
                else
                {
                    captWnd.OnButtonClick += CaptWnd_OnButtonClick;
                    captWnd.OnError += CaptWnd_OnError;
                    captWnd.OnClose += CaptWnd_OnClose;

                    // Disable this form while capture window is active
                    this.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                AppendMessage($"Exception. {ex.Message}");
            }
        }

        /// <summary>
        /// Refresh list of attached devices
        /// </summary>
        private void RefreshDeviceList()
        {
            try
            {
                lstDevices.Items.Clear();
                SignatureDeviceList m_signatureDeviceList = m_SigCapt.GetDeviceList();
                m_signatureDeviceList.OnSignatureDeviceListChanged += OnSignatureDeviceListChanged;
                m_signatureDeviceList.OnSignatureDeviceAdded += OnSignatureDeviceAdded;
                m_signatureDeviceList.OnSignatureDeviceRemoved += OnSignatureDeviceRemoved;

                foreach (ISignatureDevice device in m_signatureDeviceList)
                {
                    lstDevices.Items.Add(device);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception in RefreshList: {ex.Message}\n{ex.StackTrace}");
            }
            EnableCapture();
        }


        /// <summary>
        /// Demonstrates overriding configuration settings
        /// </summary>
        /// <returns>
        /// true  - configuration updated
        /// false - validation of input failed
        /// </returns>
        private bool SetConfiguration()
        {
            if (!ValidateColors())
                return false;

            // Return Configuration to defaults (or values set in config file)
            m_SigCapt.Configuration.Reset();

            // Each font - inside, outside and buttons - can be set independently but in this sample
            // we set them all to be the same
            List<string> fontSettings = new List<string>
            {
                "InsideFont",
                "OutsideFont",
                "Buttons.Font"
            };
            if (cbxFontName.SelectedIndex > 0)
            {
                foreach (string font in fontSettings)
                {
                    m_SigCapt.Configuration.SetValue($"CaptureWindow.{font}.Facename", cbxFontName.SelectedItem);
                }
            }
            if (cbxFontSize.SelectedIndex > 0)
            {
                foreach (string font in fontSettings)
                {
                    m_SigCapt.Configuration.SetValue($"CaptureWindow.{font}.Size", cbxFontSize.SelectedItem);
                }
            }
            if (txtTextColor.Text.Length > 0)
            {
                foreach (string font in fontSettings)
                {
                    m_SigCapt.Configuration.SetValue($"CaptureWindow.{font}.Color", txtTextColor.Text);
                }
            }

            if (txtSigAreaColor.Text.Length > 0)
            {
                m_SigCapt.Configuration.SetValue("CaptureWindow.SignatureArea.Color", txtSigAreaColor.Text);
            }
            if (cbxGuideType.SelectedIndex > 0)
            {
                m_SigCapt.Configuration.SetValue("CaptureWindow.SignatureArea.GuideType", cbxGuideType.SelectedItem);
            }
            if (txtBkgndColor.Text.Length > 0)
            {
                m_SigCapt.Configuration.SetValue("CaptureWindow.BackgroundColor", txtBkgndColor.Text);
            }
            return true;
        }

        /// <summary>
        /// Save signature (optionally) and display its image
        /// </summary>
        /// <param name="captureWindow"></param>
        private void SaveAndDisplaySignature(ICaptureWindow captureWindow)
        {
            try
            {
                using SaveFileDialog saveFileDialog = new()
                {
                    Filter = "FSS files (*.fss)|*.fss|" +
                             "Text files (*.txt)|*.txt|" +
                             "ISO files (*.iso)|*.iso|" +
                             "ISO XML files (*.xml)|*.xml",
                    Title = "Save signature",
                    DefaultExt = "fss",
                    AddExtension = true,
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                };

                object? signature = null;
                uint importIsoFlags = 0;
                EncryptionType encryptionType = EncryptionType.EncryptionType_None;
                string encryptionKey = string.Empty;

                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    switch (cbxEncryption.SelectedItem as string)
                    {
                        case "Symmetric":
                            encryptionType = EncryptionType.EncryptionType_Symmetric;
                            encryptionKey = EncryptionSymmetricKey;
                            break;

                        case "Public key":
                            encryptionType = EncryptionType.EncryptionType_PublicKey;
                            encryptionKey = EncryptionPublicKey;
                            break;
                    }

                    string fileName = saveFileDialog.FileName;

                    switch (Path.GetExtension(fileName))
                    {
                        case ".fss":
                            signature = captureWindow.GetSignature(SignatureStorageType.SignatureStorageType_SigData, encryptionType, encryptionKey);
                            if (signature is byte[] sigData)
                            {
                                File.WriteAllBytes(fileName, sigData);

                                AppendMessage($"SigData: {Convert.ToHexString(sigData, 0, 16)}...");
                            }
                            else
                            {
                                AppendMessage($"Failed to get signature data");
                            }
                            break;

                        case ".txt":
                            signature = captureWindow.GetSignature(SignatureStorageType.SignatureStorageType_SigText, encryptionType, encryptionKey);
                            if (signature is string sigText)
                            {
                                File.WriteAllText(fileName, sigText);

                                AppendMessage($"SigText: {sigText.Substring(0, 32)}...");
                            }
                            else
                            {
                                AppendMessage($"Failed to get signature data");
                            }
                            break;

                        case ".iso":
                            signature = captureWindow.GetSignature(SignatureStorageType.SignatureStorageType_ISO_19794_7_2021, encryptionType, encryptionKey);
                            if (signature is byte[] isoBytes)
                            {
                                File.WriteAllBytes(fileName, isoBytes);

                                AppendMessage($"ISO 2021: {Convert.ToHexString(isoBytes, 0, 16)}...");
                            }
                            else
                            {
                                AppendMessage($"Failed to get signature data");
                            }
                            importIsoFlags = encryptionType == EncryptionType.EncryptionType_None
                                ? (uint)FLSIGCTLLib.ImportIsoFlags.ImportIsoFlag_iso19784_7_binary
                                : (uint)FLSIGCTLLib.ImportIsoFlags.ImportIsoFlag_iso19784_7_encrypted_binary;
                            break;

                        case ".xml":
                            signature = captureWindow.GetSignature(SignatureStorageType.SignatureStorageType_ISO_19785_3_2015_XML_FULL, encryptionType, encryptionKey);
                            if (signature is string isoStr)
                            {
                                File.WriteAllText(fileName, isoStr);

                                AppendMessage($"ISO_19785_3_2015_11: {isoStr.Substring(0, 32)}...");
                            }
                            else
                            {
                                AppendMessage($"Failed to get signature data");
                            }
                            importIsoFlags = encryptionType == EncryptionType.EncryptionType_None
                                ? (uint)FLSIGCTLLib.ImportIsoFlags.ImportIsoFlag_iso19785_3_xml
                                : (uint)FLSIGCTLLib.ImportIsoFlags.ImportIsoFlag_iso19784_7_encrypted_text;
                            break;

                    }
                }


                // Use SigObj to generate and display image of captured signature
                // NOTE: If signature has been saved as ISO, it cannot then be obtained in a non-ISO format, so GetSignature(ISigObj) would fail.
                //       In that case, we have to import the ISO into SigObj, which requires a license. If a valid license string has not been set
                //       above, we can't get a signature image here.
                FLSIGCTLLib.ISigObj4? sigObj = null;
                if (importIsoFlags == 0)
                {
                    sigObj = captureWindow.GetSignature(SignatureStorageType.SignatureStorageType_ISigObj) as FLSIGCTLLib.ISigObj4;
                }
                else if (!string.IsNullOrEmpty(LicenseString))
                {
                    sigObj = new FLSIGCTLLib.SigObj();

                    sigObj.SetProperty("License", LicenseString);
                    switch (encryptionType)
                    {
                        case EncryptionType.EncryptionType_None:
                            break;

                        case EncryptionType.EncryptionType_Symmetric:
                            sigObj.SetProperty("EncryptionPassword", EncryptionSymmetricKey);
                            break;

                        case EncryptionType.EncryptionType_PublicKey:
                            sigObj.SetProperty("EncryptionPrivateKey", $"{EncryptionPrivateKey},{EncryptionPrivateKeyPassword}");
                            break;
                    }
                    sigObj.ImportIso(signature, importIsoFlags, null);
                }
                if (sigObj != null && sigObj.IsCaptured)
                {
                    var b64 = sigObj.RenderBitmap(null, imgSignature.Width, imgSignature.Height, "image/png", 0.5f, 0xFF0000, 0xFFFFFF, 0, 0, FLSIGCTLLib.RBFlags.RenderOutputBase64 | FLSIGCTLLib.RBFlags.RenderColor32BPP) as string;
                    if (!string.IsNullOrEmpty(b64))
                    {
                        imgSignature.Image = Base64ToImage(b64);
                    }
                }
                else
                {
                    imgSignature.Image = null;
                }
            }
            catch (Exception ex)
            {
                AppendMessage($"Exception: {ex.Message}");
            }
        }


        #endregion


        #region Capture Window Event Handling

        /// <summary>
        /// Handle capture window closing
        /// </summary>
        /// <param name="captWnd">The capture window</param>
        /// <param name="result">Capture result (reason for window closing)</param>
        /// <param name="errorDescription">If window closed due to an error, description of that error</param>
        private void CaptWnd_OnClose(ICaptureWindow captWnd, CaptureResult result, string errorDescription)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<ICaptureWindow, CaptureResult, string>(CaptWnd_OnClose), captWnd, result, errorDescription);
                return;
            }

            // Re-enable this form
            this.Enabled = true;
            SetForegroundWindow(this.Handle);

            AppendMessage($"Capture window closed. Result={result}");
            if (result == CaptureResult.CaptureResult_Success)
            {
                SaveAndDisplaySignature(captWnd);
            }
            else if (!string.IsNullOrEmpty(errorDescription))
            {
                AppendMessage($"Capture window error: {errorDescription}");
            }
        }

        /// <summary>
        /// Handle error in capture window
        /// </summary>
        /// <param name="captWnd">The capture window</param>
        /// <param name="errorType">Type of error</param>
        /// <param name="description">Description of error</param>
        private void CaptWnd_OnError(ICaptureWindow captWnd, CaptureResult errorType, string description)
        {
            AppendMessage($"Error {errorType}: {description}");
        }

        /// <summary>
        /// Handle click of button in capture window
        /// </summary>
        /// <param name="captWnd">The capture window</param>
        /// <param name="ButtonId">Id of button clicked (OK, Clear or Cancel)</param>
        private void CaptWnd_OnButtonClick(ICaptureWindow captWnd, ButtonId ButtonId)
        {
            AppendMessage($"Button {ButtonId} clicked");
        }

        #endregion


        #region UI Event Handling

        /// <summary>
        /// Select color for capture window text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextColorButtonClicked(object sender, EventArgs e)
        {
            SelectColor(txtTextColor, lblTextColor);
        }

        /// <summary>
        /// Select background color for capture window 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BkgndColorButtonClicked(object sender, EventArgs e)
        {
            SelectColor(txtBkgndColor, lblBkgndColor);
        }

        /// <summary>
        /// Select background color for signature area within capture window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SigAreaColorButtonClicked(object sender, EventArgs e)
        {
            SelectColor(txtSigAreaColor, lblSigAreaColor);
        }

        /// <summary>
        /// Initiate signature capture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptureButtonClicked(object sender, EventArgs e)
        {
            if (lstDevices.SelectedItem != null)
            {
                CaptureSignature(lstDevices.SelectedItem as ISignatureDevice);
            }
        }

        /// <summary>
        /// Enable capture if a device is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeviceSelectionChanged(object sender, EventArgs e)
        {
            EnableCapture();
        }

        private void WhyOrWhoChanged(object sender, EventArgs e)
        {
            EnableCapture();
        }

        #endregion


        #region Validation

        /// <summary>
        /// Validation event for Why & Who values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidateWhyOrWho(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    errorProvider1.SetError(textBox, "Value is required");
                }
                else
                {
                    errorProvider1.Clear();
                }
            }
        }

        /// <summary>
        /// Ensure any colors entered are in correct format
        /// </summary>
        /// <returns>true if values are valid</returns>
        private bool ValidateColors()
        {
            List<TextBox> colors = new List<TextBox>
            {
                txtTextColor,
                txtSigAreaColor,
                txtBkgndColor
            };
            bool valid = true;

            foreach (TextBox textBox in colors)
            {
                if (!IsColorValid(textBox))
                {
                    valid = false;
                }
            }
            return valid;
        }

        /// <summary>
        /// Validate a color value string
        /// </summary>
        /// <param name="textBox">TextBox containing color value string</param>
        /// <returns>true if textBox is empty or contains a color value in the correct format</returns>
        /// <remarks>Sets error icon on textBox if string is invalid</remarks>
        private bool IsColorValid(TextBox textBox)
        {
            bool valid = false;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                valid = true;    // use default
            }
            else
            {
                Regex hexPattern = new Regex("^#[0-9A-Fa-f]{6}$");
                valid = hexPattern.IsMatch(textBox.Text);
                if (!valid)
                {
                    errorProvider1.SetError(textBox, "Not a valid color string");
                }
                else
                {
                    errorProvider1.Clear();
                }
            }
            return valid;
        }

        /// <summary>
        /// Validation event for color textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidateColorValue(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (!IsColorValid(textBox))
                {
                    // Cancel the event and select the text to be corrected by the user.
                    e.Cancel = true;
                    textBox.Select(0, textBox.Text.Length);
                }
            }
        }

        #endregion


        #region Utilities

        /// <summary>
        /// Appends a status message to the message window
        /// </summary>
        /// <param name="message"></param>
        private void AppendMessage(string message)
        {
            if (txtMessages.InvokeRequired)
            {
                txtMessages.Invoke(new Action<string>(AppendMessage), message);
            }
            else
            {
                txtMessages.AppendText(message + Environment.NewLine);
            }
        }

        /// <summary>
        /// Enables Capture button if a device is selected
        /// </summary>
        private void EnableCapture()
        {
            if (lstDevices.SelectedIndex >= 0
                && !string.IsNullOrEmpty(txtWho.Text)
                && !string.IsNullOrEmpty(txtWhy.Text))
            {
                btnCapture.Enabled = true;
            }
            else
            {
                btnCapture.Enabled = false;
            }
        }

        /// <summary>
        /// Use ColorDialog to select a color
        /// </summary>
        /// <param name="textBox">TextBox to display color value string</param>
        /// <param name="label">Control to display selected color</param>
        private void SelectColor(TextBox textBox, Label label)
        {
            var color = GetColor(textBox);

            if (color.HasValue)
            {
                colorDialog1.Color = color.Value;
            }
            else
            {
                colorDialog1.Reset();
            }
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                SetColor(colorDialog1.Color, textBox, label);
            }
        }

        /// <summary>
        /// Displays formatted color value string and actual color in a pair of controls
        /// </summary>
        /// <param name="color">Color to set</param>
        /// <param name="textBox">TextBox to display color value string</param>
        /// <param name="label">Control to display selected color</param>
        private void SetColor(Color color, TextBox textBox, Label label)
        {
            textBox.Text = $"#{color.R:X2}{color.G:X2}{color.B:X2}";
            label.BackColor = color;
        }

        /// <summary>
        /// Reads formatted color value string and returns the color it represents
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        private Color? GetColor(TextBox textBox)
        {
            string hex = textBox.Text;
            if (hex.Length != 7 || hex[0] != '#')
            {
                return null;
            }
            try
            {
                int r = int.Parse(hex.Substring(1, 2));
                int g = int.Parse(hex.Substring(3, 2));
                int b = int.Parse(hex.Substring(5, 2));
                return Color.FromArgb(r, g, b);
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Converts a Base64 representation of a signature image into an Image object
        /// </summary>
        /// <param name="base64String"></param>
        /// <returns></returns>
        public static Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            var imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image

            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                ms.Position = 0;
                return Image.FromStream(ms);
            }
        }

        #endregion




        private void OnSignatureDeviceListChanged(SignatureDeviceList sender)
        {
            lstDevices.Invoke(() => RefreshDeviceList());
        }

        private void OnSignatureDeviceAdded(SignatureDeviceList sender, ISignatureDevice signatureDevice)
        {
            //lstDevices.Invoke(() => RefreshList());
        }

        private void OnSignatureDeviceRemoved(SignatureDeviceList sender, ISignatureDevice signatureDevice)
        {
            //lstDevices.Invoke(() => RefreshList());
        }
    }
}
