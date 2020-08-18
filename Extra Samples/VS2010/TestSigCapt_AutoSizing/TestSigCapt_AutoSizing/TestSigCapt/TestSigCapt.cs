/******************************************************* 

  TestSigCapt.cs
  
  Displays a form with a button to start signature capture.
  Auto resizes signature image if the captured data is too much to be encoded in the original
  The captured signature is encoded in an image file which is displayed on the form and output to a PNG file
  
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

                if(RenderSignatureAutoSize(filename, 100, 50) == false)
                {
                    print("Too much signature data, please sign again");
                    return;
                }

                try
                {
                    using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                    {
                        sigImage.Image = System.Drawing.Image.FromStream(fs);
                        fs.Close();
                    }

                    // sigImage.Load(filename);
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

        private bool RenderSignatureAutoSize(string filename, int initialWidth, int initialHeight, float multiplier = 1.5f, int tries = 5)
        {
            int width = initialWidth;
            int height = initialHeight;

            for(int i=0; i< tries; i++)
            {
                if(RenderSignature(filename, width, height))
                {
                    return true;
                }
                width = (int)(width * multiplier);
                height = (int)(height * multiplier);
            }
            return false;
        }

        private bool RenderSignature(string filename, int width, int height)
        {
            try
            {
                print("Rendering " + width + " x " + height);
                sigObj.RenderBitmap(filename, width, height, "image/png", 0.5f, 0xff0000, 0xffffff, 10.0f, 10.0f, RBFlags.RenderOutputFilename | RBFlags.RenderColor32BPP | RBFlags.RenderEncodeData);
                return true;
            }
            catch (Exception)
            {
                return false;
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

