/******************************************************* 

  TestAXSigCapt.cs
  
  Displays a form with a button to start signature capture
  The captured signature is encoded in an image file which is displayed on the form.
  This version uses "Ax" versions of the controls - these are .NET wrappers for the
  COM components so that you can put them onto forms

  Copyright (c) 2015 Wacom GmbH. All rights reserved.
  
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

namespace TestAXSigCapt
{
    public partial class TestAXSigCapt : Form
    {
        public TestAXSigCapt()
        {
            InitializeComponent();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            String msg;
            print("btnSign clicked");
            axSigCtl1.Licence = "<<license>>";
            CaptureResult res = axSigCtl1.CtlCapture("Who", "Why");
            switch (res)
            {
                case CaptureResult.CaptureOK:
                    msg = "Signature captured successfully";
                    break;
                case CaptureResult.CaptureCancel:
                    msg = "Signature cancelled";
                    break;
                default: msg = "Capture error: " + res.ToString();
                    break;
            }
            print(msg);
        }
        private void print(string txt)
        {
            txtDisplay.Text += txt + "\r\n";
            txtDisplay.SelectionStart = txtDisplay.Text.Length;  // scroll to end
            txtDisplay.ScrollToCaret();
            txtDisplay.Refresh();
        }
    }
}
