/******************************************************* 

  TestSigCapt.cs
  
  Displays a form with a button to start signature capture.
  The captured signature is encoded in a byte array in memory and is displayed on the form
  
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

                try
                {
                    byte[] binaryData = sigObj.RenderBitmap("", 200, 150, "image/png", 0.5f, 0xff0000, 0xffffff, 10.0f, 10.0f, RBFlags.RenderOutputBinary | RBFlags.RenderColor32BPP) as byte[];
					using (MemoryStream memStream = new MemoryStream(binaryData)) 
					{
						System.Drawing.Image newImage = System.Drawing.Image.FromStream(memStream);
						sigImage.Image = newImage;

						// work with image here. 
						// You'll need to keep the MemoryStream open for 
						// as long as you want to work with your new image. 
                        memStream.Dispose();
					} 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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

