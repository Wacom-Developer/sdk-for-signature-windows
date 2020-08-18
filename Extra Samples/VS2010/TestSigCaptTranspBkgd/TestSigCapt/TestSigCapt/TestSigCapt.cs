/******************************************************* 

  TestSigCapt.cs
  
  Displays a form with a button to start signature capture.
  Captures the signature with a transparent background and anti-aliasing.
  The signature is saved to sig1.png
  
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
using System.IO;

using Florentis;
namespace TestSigCapt
{
    public partial class TestSigCapt : Form
    {
        SigCtl sigCtl;
        SigObj sigObj;

        public TestSigCapt()
        {
            InitializeComponent();
            sigCtl = new SigCtl();
            sigCtl.Licence = "<<license>>";
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            print("btnSign was pressed");
            
            DynamicCapture dc = new DynamicCaptureClass();
            DynamicCaptureResult res = dc.Capture(sigCtl, "Who", "Why", null, null);
            if (res == DynamicCaptureResult.DynCaptOK)
            {
                print("signature captured successfully");
                sigObj = (SigObj)sigCtl.Signature;
                sigObj.set_ExtraData("AdditionalData", "C# test: Additional data");
				String filename = "sig1.png";
                sigObj.RenderBitmap(filename, 200, 150, "image/png", 0.5f, 0xff0000, 0xffffff, -1.0f, -1.0f, RBFlags.RenderOutputFilename | RBFlags.RenderColor32BPP | RBFlags.RenderBackgroundTransparent | RBFlags.RenderColorAntiAlias | RBFlags.RenderEncodeData);
                sigImage.Load(filename);
            }
            else
            {
                print("Signature capture error res=" + (int)res + "  ( " + res + " )");
                switch (res)
                {
                    case DynamicCaptureResult.DynCaptCancel: print("signature cancelled"); break;
                    case DynamicCaptureResult.DynCaptError: print("no capture service available"); break;
                    case DynamicCaptureResult.DynCaptPadError: print("signing device error"); break;
                    default: print("Unexpected error code "); break;
                }
            }
        }

        private void print(string txt)
        {
            txtDisplay.Text += txt + "\r\n";
            txtDisplay.SelectionStart = txtDisplay.TextLength;
            txtDisplay.ScrollToCaret();
        }
    }
}

