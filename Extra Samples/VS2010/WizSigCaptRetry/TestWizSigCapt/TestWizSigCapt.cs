/*  TestWizSigCapt.cs
 * 
 *   Allows multiple iterations of wizard script
 *   Copyright (c) 2020 Wacom Co. Ltd.  All rights reserved.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Florentis;
using System.IO;

namespace TestWizSigCapt
{
    public partial class TestWizSigCapt : Form
    {
        bool ScriptIsRunning;               // flag for UI button respones
        bool TimerStarted = false;
        WizardCallback Callback;            // For wizard callback 
        tPad Pad;                           // Pad parameters
        bool isCheck = false;
        System.Windows.Forms.Timer connectTimer = new System.Windows.Forms.Timer(); // Timer for cycling round if connection fails
        int secondsWaited = 0;
        int connectionAttempt = 0;
        int maxAttempts = 20;

        public class tPad
        {
            public string Model;
            public Font TextFont;
            public Font ButtonFont;
            public Font SigLineFont;
            public int signatureLineY;
            public int whoY;
            public int whyY;
            public int buttonWith;

            public tPad(string model, int signatureLineY, int whoY, int whyY, 
                int textFontSize, int buttonFontSize, int signLineSize, int buttonWith)
            {
                this.Model = model;
                this.signatureLineY = signatureLineY;
                this.whoY = whoY;
                this.whyY = whyY;
                this.buttonWith = buttonWith;

                this.TextFont = new Font("Consolas", textFontSize, FontStyle.Regular);
                this.ButtonFont = new Font("Consolas", buttonFontSize, FontStyle.Regular);
                this.SigLineFont = new Font("Consolas", signLineSize, FontStyle.Regular);
            }
        }        

        public TestWizSigCapt()
        {
            InitializeComponent();
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
            txtDisplay.Text += txt + "\r\n";
            txtDisplay.SelectionStart = txtDisplay.Text.Length;  // scroll to end
            txtDisplay.ScrollToCaret();
            txtDisplay.Refresh();
        }

        // Separate routine for connecting to pad so that it can be controlled by a timer which allows a delay
        // between connection attempts
        private bool connectToPad()
        {
            bool success = false;

            ++connectionAttempt;

            // If connection has previously failed then we need to destroy and recreate the WizCtl
            if (connectionAttempt > 1)
            {
                recreateWizCtl();
            }
            WizCtl.Licence = "<<license>>";
            success = WizCtl.PadConnect();

            print("Success " + success);

            if (success == true)
            {
                print("Pad detected: " + WizCtl.PadWidth + " x " + WizCtl.PadHeight);
                switch (WizCtl.PadWidth)
                {
                    case 396: Pad = new tPad("STU-300", 60, 200, 200, 8, 8, 16, 70); // 396 x 100
                        break;
                    case 640: Pad = new tPad("STU-500", 300, 360, 390, 16, 22, 32, 110); // 640 x 800
                        break;
                    case 800: Pad = new tPad("STU-520 or STU-530", 300, 360, 390, 16, 22, 32, 110); // 800 x 480
                        break;
                    case 320: Pad = new tPad("STU-430 or ePad", 100, 130, 150, 10, 12, 16, 110); // 320 x 200
                        break;
                    default: print("No compatible device found");
                        break;
                }
                print(Pad.Model);
                step1();
            }
            else
            {
                secondsWaited += 2;
                print("waiting to connect..."  + secondsWaited);
            }
            return success;
        }

        // Function to destroy existing WizCtl and recreate it.
        // This is needed because WizCtl attempts to find, and connect to, a pad during construction
        // (so that it can initialize itself based on size of pad screen and also potentially resize its window to match). 
        // If it fails to connect to a pad at that point it assumes there isn't one and any subsequent attempt to connect with PadConnect will fail.

        private void recreateWizCtl()
        {
            // Destroy the existing WizCtl
            WizCtl.Dispose();

            // Now recreate it
            this.WizCtl = new Florentis.AxWizCtl();
            this.WizCtl.Licence = "<<license>>";
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestWizSigCapt));
            ((System.ComponentModel.ISupportInitialize)(this.WizCtl)).BeginInit();
            this.WizCtl.Enabled = true;
            this.WizCtl.Location = new System.Drawing.Point(340, 173);
            this.WizCtl.Name = "WizCtl";
            this.WizCtl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WizCtl.OcxState")));
            this.WizCtl.Size = new System.Drawing.Size(402, 242);
            this.WizCtl.TabIndex = 4;
            this.Controls.Add(this.WizCtl);

            // Make sure it's invisible so it doesn't appear on the monitor
            //this.WizCtl.Visible = false;
        }

        // Timer event to allow repeated connections to the pad if one or more fail
        private void tryConnectionEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            connectTimer.Stop();
            ScriptIsRunning = true;

            if (connectionAttempt == maxAttempts)
            {
                print("Maximum no of connection attempts reached - pad is busy. Please try later");
                connectionAttempt = 0;
                closeWizard();
            }
            else
            {
                if (connectToPad() == true)
                {
                    connectTimer.Enabled = false;
                }
                else
                {
                    connectTimer.Enabled = true;
                }
            }
        }

        // Wizard script:
        private void startWizard()
        {
            if (!TimerStarted)
            {
                connectTimer.Tick += new EventHandler(tryConnectionEventProcessor);
                connectTimer.Interval = 2000;
                TimerStarted = true;
            }
            connectTimer.Enabled = true;
            secondsWaited = 0;
            connectTimer.Start();
            print("startWizard");
        }

        
        private void scriptCompleted()
        {
            print("scriptCompleted");
            SigObj sigObj = (SigObj)SigCtl.Signature;
            if (sigObj.IsCaptured)
            {
                sigObj.set_ExtraData("AdditionalData", "C# Wizard test: Additional data");                
                byte[] signature = sigObj.RenderBitmap(null, 200, 150, "image/png", 0.5f, 0xff0000, 0xffffff, -1.0f, -1.0f, RBFlags.RenderOutputBinary | RBFlags.RenderColor32BPP | RBFlags.RenderEncodeData);
                
                using (MemoryStream ms = new MemoryStream(signature))
                {
                    System.Drawing.Image newImage = System.Drawing.Image.FromStream(ms);
                    sigImage.Image = newImage;

                    // work with image here. 
                    // You'll need to keep the MemoryStream open for 
                    // as long as you want to work with your new image. 
                    ms.Dispose();
                }
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
            connectTimer.Enabled = false;
            ScriptIsRunning = false;
            WizCtl.Reset();
            WizCtl.PadDisconnect();
            Callback.EventHandler = null;       // remove handler
            WizCtl.SetEventHandler(Callback);
            connectionAttempt = 0;
        }

        private void step1()
        {
            WizCtl.Reset();

            // insert checkbox
            WizCtl.Font = Pad.TextFont;
            WizCtl.AddObject(ObjectType.ObjectCheckbox, "Check", "centre", "middle", "I have read and I accept the terms and conditions", 2);

            // insert the buttons
            WizCtl.Font = Pad.ButtonFont;
            WizCtl.AddObject(ObjectType.ObjectButton, "Cancel", "left", "bottom", "Cancel", Pad.buttonWith);
            WizCtl.AddObject(ObjectType.ObjectButton, "Next", "right", "bottom", "Next", Pad.buttonWith);

            // set callback when a button is pressed
            Callback.EventHandler = new WizardCallback.Handler(step1_Handler);
            WizCtl.SetEventHandler(Callback);
            WizCtl.Display();

        }
        private void step1_Handler(object clt, object id, object type)
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
                WizCtl.AddObject(ObjectType.ObjectButton, "Cancel", "right", "top", "Cancel", Pad.buttonWith);
                WizCtl.AddObject(ObjectType.ObjectButton, "Clear", "right", "middle", "Clear", Pad.buttonWith);
                WizCtl.AddObject(ObjectType.ObjectButton, "OK", "right", "bottom", "OK", Pad.buttonWith);
            }
            else
            {
                WizCtl.AddObject(ObjectType.ObjectButton, "Cancel", "left", "bottom", "Cancel", Pad.buttonWith);
                WizCtl.AddObject(ObjectType.ObjectButton, "Clear", "center", "bottom", "Clear", Pad.buttonWith);
                WizCtl.AddObject(ObjectType.ObjectButton, "OK", "right", "bottom", "OK", Pad.buttonWith);
            }

            // set callback when a button is pressed
            Callback.EventHandler = new WizardCallback.Handler(step2_Handler);
            WizCtl.SetEventHandler(Callback);
            WizCtl.Display();

        }

        private void step2_Handler(object clt, object id, object type)
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

        private void TestWizSigCapt_Load(object sender, EventArgs e)
        {
            //startWizard();
        }
    }
}
