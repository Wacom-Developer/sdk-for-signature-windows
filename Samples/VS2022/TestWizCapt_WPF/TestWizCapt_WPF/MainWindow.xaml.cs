/******************************************************* 

  MainWindow.xaml.cs
  
  Displays a form with a button to start signature capture using the Wizard script
  The captured signature is encoded in an image file which is displayed on the form

  Copyright (c) 2020 Wacom Co. Ltd. All rights reserved.
  
********************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Florentis;
using stdole;

namespace TestWizCapt_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool ScriptIsRunning;               // flag for UI button respones
        WizardCallback Callback;            // For wizard callback 
        tPad Pad;                           // Pad parameters
        bool isCheck = false;
        static string padFont = "Verdana";

        class tPad
        {
            public string Model;
            public stdole.IFontDisp TextFont;
            public stdole.IFontDisp ButtonFont;
            public stdole.IFontDisp SigLineFont;
            public int signatureLineY;
            public int whoY;
            public int whyY;
            public int buttonWidth;

            public tPad(string model, int signatureLineY, int whoY, int whyY,
                int textFontSize, int buttonFontSize, int signLineSize, int buttonWidth)
            {
                this.Model = model;
                this.signatureLineY = signatureLineY;
                this.whoY = whoY;
                this.whyY = whyY;
                this.buttonWidth = buttonWidth;

                this.TextFont = SetFontProperties(padFont, textFontSize);
                this.ButtonFont = SetFontProperties(padFont, buttonFontSize);
                this.SigLineFont = SetFontProperties(padFont, signLineSize);
            }

            private IFontDisp SetFontProperties(string fontName, int fontSize)
            {
                stdole.IFontDisp fnt = (stdole.IFontDisp)new stdole.StdFont();
                fnt.Name = fontName;
                fnt.Size = (decimal)fontSize;

                return fnt;
            }

        }
        private Florentis.WizCtl WizCtl;
        private Florentis.SigCtl SigCtl;

        public MainWindow()
        {
            InitializeComponent();
            SigCtl = new SigCtl();
            WizCtl = new Florentis.WizCtl();

            WizCtl.Licence = "eyJhbGciOiJSUzUxMiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiI3YmM5Y2IxYWIxMGE0NmUxODI2N2E5MTJkYTA2ZTI3NiIsImV4cCI6MjE0NzQ4MzY0NywiaWF0IjoxNTYwOTUwMjcyLCJyaWdodHMiOlsiU0lHX1NES19DT1JFIiwiU0lHQ0FQVFhfQUNDRVNTIl0sImRldmljZXMiOlsiV0FDT01fQU5ZIl0sInR5cGUiOiJwcm9kIiwibGljX25hbWUiOiJTaWduYXR1cmUgU0RLIiwid2Fjb21faWQiOiI3YmM5Y2IxYWIxMGE0NmUxODI2N2E5MTJkYTA2ZTI3NiIsImxpY191aWQiOiJiODUyM2ViYi0xOGI3LTQ3OGEtYTlkZS04NDlmZTIyNmIwMDIiLCJhcHBzX3dpbmRvd3MiOltdLCJhcHBzX2lvcyI6W10sImFwcHNfYW5kcm9pZCI6W10sIm1hY2hpbmVfaWRzIjpbXX0.ONy3iYQ7lC6rQhou7rz4iJT_OJ20087gWz7GtCgYX3uNtKjmnEaNuP3QkjgxOK_vgOrTdwzD-nm-ysiTDs2GcPlOdUPErSp_bcX8kFBZVmGLyJtmeInAW6HuSp2-57ngoGFivTH_l1kkQ1KMvzDKHJbRglsPpd4nVHhx9WkvqczXyogldygvl0LRidyPOsS5H2GYmaPiyIp9In6meqeNQ1n9zkxSHo7B11mp_WXJXl0k1pek7py8XYCedCNW5qnLi4UCNlfTd6Mk9qz31arsiWsesPeR9PN121LBJtiPi023yQU8mgb9piw_a-ccciviJuNsEuRDN3sGnqONG3dMSA";
            // initialise Wizard script support
            Callback = new WizardCallback();    // Callback provided via InteropAXFlWizCOM
            Callback.EventHandler = null;
            WizCtl.SetEventHandler(Callback);
            ScriptIsRunning = false;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            print("Sign...");
            isCheck = false;
            imgSig.Source = null;
            if (!ScriptIsRunning)
                startWizard();
            else
                print("Script is already running");
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            print("Cancel...");
            if (ScriptIsRunning)
            {
                scriptCancelled();
            }
            else
                print("Script is not running");
        }
        private void print(string txt)
        {
            txtInfo.Text += txt + "\r\n";
            txtInfo.ScrollToEnd();
        }
        // Wizard script:
        private void startWizard()
        {
            print("startWizard");
            bool success = WizCtl.PadConnect();
            if (success)
            {
                ScriptIsRunning = true;
                print("Pad detected: " + WizCtl.PadWidth + " x " + WizCtl.PadHeight);
                switch (WizCtl.PadWidth)
                {
                    case 396:
                        Pad = new tPad("STU-300", 60, 200, 200, 8, 12, 16, 70); // 396 x 100
                        break;
                    case 640:
                        Pad = new tPad("STU-500", 300, 360, 390, 16, 22, 32, 110); // 640 x 800
                        break;
                    case 800:
                        Pad = new tPad("STU-520, 530 or 540", 300, 360, 390, 16, 22, 32, 110); // 800 x 480
                        break;
                    case 320:
                        Pad = new tPad("STU-430 or ePad", 100, 130, 150, 10, 12, 16, 110); // 320 x 200
                        break;
                    default:
                        print("No compatible device found");
                        break;
                }
                print(Pad.Model);
                step1();
            }
            else
                print("Unable to connect to tablet");
        }
        private void scriptCompleted()
        {
            print("scriptCompleted");
            SigObj sigObj = (SigObj)SigCtl.Signature;
            if (sigObj.IsCaptured)
            {
                sigObj.set_ExtraData("AdditionalData", "C# Wizard test: Additional data");
                String dateStr = DateTime.Now.ToString("hhmmss");
                String filename = "C:\\temp\\sig" + dateStr + ".png";
                sigObj.RenderBitmap(filename, 200, 150, "image/png", 0.5f, 0xff0000, 0xffffff, -1.0f, -1.0f, RBFlags.RenderOutputFilename | RBFlags.RenderColor32BPP | RBFlags.RenderEncodeData);

                print("Loading image from " + filename);
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri(filename, UriKind.Absolute);
                src.EndInit();

                imgSig.Source = src;
            }
            closeWizard();
        }
        private void scriptCancelled()
        {
            print("scriptCancelled");
            closeWizard();
        }
        private void closeWizard()
        {
            print("closeWizard()");
            ScriptIsRunning = false;
            WizCtl.Reset();
            WizCtl.Display();
            WizCtl.PadDisconnect();
            Callback.EventHandler = null;       // remove handler
            WizCtl.SetEventHandler(Callback);
        }

        private void step1()
        {
            WizCtl.Reset();

            // insert checkbox
            WizCtl.Font = Pad.TextFont;

            WizCtl.AddObject(ObjectType.ObjectCheckbox, "Check", "centre", "middle", "I have read and I accept the terms and conditions", 2);

            // insert the buttons
            WizCtl.Font = Pad.ButtonFont;
            WizCtl.AddObject(ObjectType.ObjectButton, "Cancel", "left", "bottom", "Cancel", Pad.buttonWidth);
            WizCtl.AddObject(ObjectType.ObjectButton, "Next", "right", "bottom", "Next", Pad.buttonWidth);

            // set callback when a button is pressed
            Callback.EventHandler = new WizardCallback.Handler(Step1_Handler);
            WizCtl.SetEventHandler(Callback);
            WizCtl.Display();

        }
        private void Step1_Handler(object clt, object id, object type)
        {
            switch (id.ToString())
            {
                case "Next":
                    {
                        if (isCheck)
                            step2();
                        break;
                    }
                case "Cancel":
                    {
                        scriptCancelled();
                        break;
                    }
                case "Check":
                    {
                        isCheck = !isCheck;
                        break;
                    }
                default:
                    {
                        print("Unexpected pad event: " + id.ToString());
                        break;
                    }
            }
        }

        private void step2()
        {
            WizCtl.Reset();

            // insert message
            WizCtl.Font = Pad.TextFont;
            WizCtl.AddObject(ObjectType.ObjectText, "txt", "centre", "top", "Please sign below...", null);

            // insert a signature line
            WizCtl.Font = Pad.SigLineFont;
            if (Pad.Model == "STU-300")
            {
                WizCtl.AddObject(ObjectType.ObjectText, "txt", "left", Pad.signatureLineY, "X..............................", null);
            }
            else
            {
                WizCtl.AddObject(ObjectType.ObjectText, "txt", "centre", Pad.signatureLineY, "X..............................", null);
            }

            // insert the signature control
            WizCtl.Font = Pad.TextFont;
            WizCtl.AddObject(ObjectType.ObjectSignature, "Sig", 0, 0, SigCtl.Signature, null);

            // provide who and why for sig capture
            WizCtl.AddObject(ObjectType.ObjectText, "who", "right", Pad.whoY, "J Smith", null);
            WizCtl.AddObject(ObjectType.ObjectText, "why", "right", Pad.whyY, "I certify that the information is correct", null);

            // insert the buttons
            WizCtl.Font = Pad.ButtonFont;
            if (Pad.Model == "STU-300")
            {
                WizCtl.AddObject(ObjectType.ObjectButton, "Cancel", "right", "top", "Cancel", Pad.buttonWidth);
                WizCtl.AddObject(ObjectType.ObjectButton, "Clear", "right", "middle", "Clear", Pad.buttonWidth);
                WizCtl.AddObject(ObjectType.ObjectButton, "OK", "right", "bottom", "OK", Pad.buttonWidth);
            }
            else
            {
                WizCtl.AddObject(ObjectType.ObjectButton, "Cancel", "left", "bottom", "Cancel", Pad.buttonWidth);
                WizCtl.AddObject(ObjectType.ObjectButton, "Clear", "center", "bottom", "Clear", Pad.buttonWidth);
                WizCtl.AddObject(ObjectType.ObjectButton, "OK", "right", "bottom", "OK", Pad.buttonWidth);
            }

            // set callback when a button is pressed
            Callback.EventHandler = new WizardCallback.Handler(Step2_Handler);
            WizCtl.SetEventHandler(Callback);
            WizCtl.Display();

        }

        private void Step2_Handler(object clt, object id, object type)
        {
            switch (id.ToString())
            {
                case "OK":
                    {
                        scriptCompleted();
                        break;
                    }
                case "Clear":
                    {
                        break;
                    }
                case "Cancel":
                    {
                        scriptCancelled();
                        break;
                    }
                default:
                    {
                        print("Unexpected pad event: " + id.ToString());
                        break;
                    }
            }
        }

		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
			System.Windows.Application.Current.Shutdown();
		}
	}
}
