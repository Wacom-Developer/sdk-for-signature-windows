 /* TestWizSigCapt.cs
  
  Demonstrates use of the wizard control to input a 4-character PIN code.
  Also displays a shutdown text
  
  Copyright (c) 2020 Wacom Co. Ltd. All rights reserved.
  
********************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Florentis;

namespace TestWizSigCapt
{
    public partial class TestWizSigCapt : Form
    {
        bool ScriptIsRunning;               // flag for UI button respones
        WizardCallback Callback;            // For wizard callback 
        tPad Pad;                           // Pad parameters
        InputObj testInput = new InputObj();
        int pinLength = 0;

        class tPad
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

                this.TextFont = new Font("Verdana", textFontSize, FontStyle.Regular);
                this.ButtonFont = new Font("Verdana", buttonFontSize, FontStyle.Regular);
                this.SigLineFont = new Font("Verdana", signLineSize, FontStyle.Regular);
            }
        }        

        public TestWizSigCapt()
        {
            InitializeComponent();
            WizCtl.Licence = "<<license>>";
            // initialise Wizard script support
            Callback = new WizardCallback();    // Callback provided via InteropAXFlWizCOM
            Callback.EventHandler = null;
            WizCtl.SetEventHandler(Callback);
            ScriptIsRunning = false;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            print("Sign...");
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
                print("Unable to connect to tablet");
        }
        private void scriptCompleted()
        {
            print("scriptCompleted");
            SigObj sigObj = (SigObj)SigCtl.Signature;
            if (sigObj.IsCaptured)
            {
                sigObj.set_ExtraData("AdditionalData", "C# Wizard test: Additional data");
                String filename = "sig1.png";
                sigObj.RenderBitmap(filename, 200, 150, "image/png", 0.5f, 0xff0000, 0xffffff, -1.0f, -1.0f, RBFlags.RenderOutputFilename | RBFlags.RenderColor32BPP | RBFlags.RenderEncodeData);
                sigImage.Load(filename);
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

            WizCtl.AddObject(ObjectType.ObjectText, "txt1", "centre", "middle", "WACOM STU Signature Pad", null);
            WizCtl.AddObject(ObjectType.ObjectDisplayAtShutdown, "txt", 0, 0, null, null);
            WizCtl.Display();

            print("Added shutdown text");

            WizCtl.PadDisconnect();
            Callback.EventHandler = null;       // remove handler
            WizCtl.SetEventHandler(Callback);
        }

        private void step1()
        {
            int x, y;
            int keyWidth = 60;
            String txtPrompt;

            pinLength = 0;

            y = 10;
            x = 30;
            WizCtl.Reset();
            WizCtl.Font = Pad.TextFont;

            // Display prompt.  On the STU-300 this must be shorter and on the left in the middle.
            // Also the starting vertical position for the PIN numbers must be higher and the keys themselves narrower
            if (Pad.Model == "STU-300")
            {
                txtPrompt = "Enter a 4 digit PIN";
                WizCtl.AddObject(ObjectType.ObjectText, "txt", "left", "middle", txtPrompt, null);
                y = 20;
                keyWidth = 20;
            }
            else
            {
                txtPrompt = "Enter a 4 digit PIN code below";
                WizCtl.AddObject(ObjectType.ObjectText, "txt", x, y, txtPrompt, null);
                if (Pad.Model == "STU-430 or ePad")
                {
                    y = 50;
                    keyWidth = 30;
                }
                else
                {
                    y = 10 + 7 * 28;
                }
            }

            x = WizCtl.PadWidth / 2 - keyWidth / 2 - 2 * keyWidth;

            WizCtl.AddObject(ObjectType.ObjectButton, "1", x, y, "1", keyWidth);
            x = WizCtl.PadWidth / 2 - keyWidth / 2;

            WizCtl.AddObject(ObjectType.ObjectButton, "2", x, y, "2", keyWidth);
            x += 2 * keyWidth;

            WizCtl.AddObject(ObjectType.ObjectButton, "3", x, y, "3", keyWidth);

            x = WizCtl.PadWidth / 2 - keyWidth / 2 - 2 * keyWidth;
            y += keyWidth;

            WizCtl.AddObject(ObjectType.ObjectButton, "4", x, y, "4", keyWidth);
            x = WizCtl.PadWidth / 2 - keyWidth / 2;

            WizCtl.AddObject(ObjectType.ObjectButton, "5", x, y, "5", keyWidth);
            x += 2 * keyWidth;

            WizCtl.AddObject(ObjectType.ObjectButton, "6", x, y, "6", keyWidth);

            x = WizCtl.PadWidth / 2 - keyWidth / 2 - 2 * keyWidth;
            y += keyWidth;

            WizCtl.AddObject(ObjectType.ObjectButton, "7", x, y, "7", keyWidth);
            x = WizCtl.PadWidth / 2 - keyWidth / 2;

            WizCtl.AddObject(ObjectType.ObjectButton, "8", x, y, "8", keyWidth);
            x += 2 * keyWidth;

            WizCtl.AddObject(ObjectType.ObjectButton, "9", x, y, "9", keyWidth);

            x = WizCtl.PadWidth / 2 - keyWidth / 2 - 2 * keyWidth;
            y += keyWidth;

            WizCtl.AddObject(ObjectType.ObjectButton, "delete", x, y, "<< Delete", 3 * keyWidth);
            x = WizCtl.PadWidth / 2 - keyWidth / 2 + 2 * keyWidth;

            WizCtl.AddObject(ObjectType.ObjectButton, "0", x, y, "0", keyWidth);

            testInput.MinLength = 1;
            testInput.MaxLength = 4;
            WizCtl.AddObject(ObjectType.ObjectInput, "Input", 0, 0, testInput, null);

            WizCtl.Font = Pad.TextFont;

            // For the STU 300 the echo object must be near the top 
            if (Pad.Model == "STU-300")
            {
                x = WizCtl.PadWidth / 2 - keyWidth / 2 - 2 * keyWidth + 15;
                WizCtl.AddObject(ObjectType.ObjectInputEcho, "", x, "top", null, 8);
            }
            else
            {
                if (Pad.Model == "STU-430 or ePad")
                {
                    y = 25;
                }
                else
                {
                    y = 10 + 4 * 28;
                }
                WizCtl.AddObject(ObjectType.ObjectInputEcho, "", "center", y, null, 8);
            } 


            // Add buttons for Cancel and Next
            WizCtl.Font = Pad.ButtonFont;

            // The STU 300 is very shallow so the buttons must be down the right-hand side instead of along the bottom and they must be narrower
            if (Pad.Model == "STU-300")
            {
                WizCtl.AddObject(ObjectType.ObjectButton, "Cancel", "right", "top", "Cancel", 50);
                WizCtl.AddObject(ObjectType.ObjectButton, "Clear", "right", "middle", "Clear", 50);
                WizCtl.AddObject(ObjectType.ObjectButton, "OK", "right", "bottom", "OK", 50);
            }
            else
            {
                if (Pad.Model == "STU-430 or ePad")
                {
                    WizCtl.AddObject(ObjectType.ObjectButton, "Cancel", "left", "bottom", "Cancel", 70);
                    WizCtl.AddObject(ObjectType.ObjectButton, "Clear", "center", "bottom", "Clear", 70);
                    WizCtl.AddObject(ObjectType.ObjectButton, "OK", "right", "bottom", "OK", 70);
                }
                else
                {
                    WizCtl.AddObject(ObjectType.ObjectButton, "Cancel", "left", "bottom", "Cancel", 200);
                    WizCtl.AddObject(ObjectType.ObjectButton, "Clear", "center", "bottom", "Clear", 200);
                    WizCtl.AddObject(ObjectType.ObjectButton, "OK", "right", "bottom", "OK", 200);
                }
            }

            WizCtl.Display();
            Callback.EventHandler = new WizardCallback.Handler(Step1_Handler);
            WizCtl.SetEventHandler(Callback);
        }

        private void Step1_Handler(object clt, object id, object type)
        {
            switch (id.ToString())
            {
                case "Input":
                    {
                        ++pinLength;
                        if (pinLength == testInput.MaxLength)
                        {
                            print("Maxlength reached: " + testInput.Text);
                            //scriptCompleted();
                        }
                        break;
                    }
                case "Cancel":
                    {
                        print("Code entered: " + id.ToString());
                        print("Pin: " + testInput.Text);
                        scriptCancelled();
                        break;
                    }
                case "OK":
                    {
                        print("Code entered: " + id.ToString());
                        print("Pin: " + testInput.Text);
                        scriptCompleted();
                    }
                    break;
                case "Clear":
                    {
                        print("Code entered: " + id.ToString());
                        print("Pin: " + testInput.Text);
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
            WizCtl.AddObject(ObjectType.ObjectText, "who", "right", 360, "J Smith", null);
            WizCtl.AddObject(ObjectType.ObjectText, "why", "right", 390, "I certify that the information is correct", null);

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
    }
}
