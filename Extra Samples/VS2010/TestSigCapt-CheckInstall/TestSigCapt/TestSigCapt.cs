/******************************************************* 

  TestSigCapt.cs
  
  Displays a form with a button to start signature capture and also checks to see if the SDK is already installed
  If the 32-bit components are not installed then an error message is displayed.
  If the SDK is installed then the user presses the [Sign] button to capture a signature which is encoded 
  in an image file which is displayed on the form
  
  Copyright (c) 2020 Wacom Ltd. All rights reserved.
  
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
        public TestSigCapt()
        {
            InitializeComponent();

            this.Shown += new EventHandler(TestSigCapt_Shown);  // Add event handler for the Form.Shown() event
        }
        private void TestSigCapt_Shown(Object sender, EventArgs e)
        {
            try
            {
                // Call a separate function to test for the creation of the signature object.
                // Trying to create it in the event handler doesn't allow the catch statement to work properly
                TestSigObject();
            }
            catch (System.IO.FileNotFoundException exFileNotFound)
            {
                string errorMsg = "Unable to initialise Wacom Signature Control - please make sure the Signature SDK and its .NET components have been installed.  See below for further information";
                print(errorMsg);
                print(" ");
                print(exFileNotFound.Message);
                print(" ");
                print("Press [Exit] to exit the program");
                btnExit.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
           
        }

				// This is the function which actually tests to see whether the Signature SDK has been installed
				// If it hasn't then the object instantiation will fail because the program can't find the DLLs
        private void TestSigObject()
        {
            SigCtl sigCtl = new SigCtl();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            //  This is just an extra test which shouldn't really be needed because the installation of the SDK
            //  has already been checked in the Form.Shown() event
            try
            {
                captureSig();
            }
            catch (System.IO.FileNotFoundException exFileNotFound)
            {
                string errorMsg = "Unable to initialise Wacom Signature Control - please make sure the Signature SDK and its .NET components have been installed.  See below for further information\n\n" + exFileNotFound.Message;

                MessageBox.Show(errorMsg);
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }

        private void captureSig()
        {
            print("btnSign was pressed");
            SigCtl sigCtl = new SigCtl();
            sigCtl.Licence = "eyJhbGciOiJSUzUxMiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiI3YmM5Y2IxYWIxMGE0NmUxODI2N2E5MTJkYTA2ZTI3NiIsImV4cCI6MjE0NzQ4MzY0NywiaWF0IjoxNTYwOTUwMjcyLCJyaWdodHMiOlsiU0lHX1NES19DT1JFIiwiU0lHQ0FQVFhfQUNDRVNTIl0sImRldmljZXMiOlsiV0FDT01fQU5ZIl0sInR5cGUiOiJwcm9kIiwibGljX25hbWUiOiJTaWduYXR1cmUgU0RLIiwid2Fjb21faWQiOiI3YmM5Y2IxYWIxMGE0NmUxODI2N2E5MTJkYTA2ZTI3NiIsImxpY191aWQiOiJiODUyM2ViYi0xOGI3LTQ3OGEtYTlkZS04NDlmZTIyNmIwMDIiLCJhcHBzX3dpbmRvd3MiOltdLCJhcHBzX2lvcyI6W10sImFwcHNfYW5kcm9pZCI6W10sIm1hY2hpbmVfaWRzIjpbXX0.ONy3iYQ7lC6rQhou7rz4iJT_OJ20087gWz7GtCgYX3uNtKjmnEaNuP3QkjgxOK_vgOrTdwzD-nm-ysiTDs2GcPlOdUPErSp_bcX8kFBZVmGLyJtmeInAW6HuSp2-57ngoGFivTH_l1kkQ1KMvzDKHJbRglsPpd4nVHhx9WkvqczXyogldygvl0LRidyPOsS5H2GYmaPiyIp9In6meqeNQ1n9zkxSHo7B11mp_WXJXl0k1pek7py8XYCedCNW5qnLi4UCNlfTd6Mk9qz31arsiWsesPeR9PN121LBJtiPi023yQU8mgb9piw_a-ccciviJuNsEuRDN3sGnqONG3dMSA";
            DynamicCapture dc = new DynamicCaptureClass();
            DynamicCaptureResult res = dc.Capture(sigCtl, "Who", "Why", null, null);
            if (res == DynamicCaptureResult.DynCaptOK)
            {
                print("signature captured successfully");
                SigObj sigObj = (SigObj)sigCtl.Signature;
                sigObj.set_ExtraData("AdditionalData", "C# test: Additional data");
                String filename = "sig1.png";
                try
                {
                    sigObj.RenderBitmap(filename, 200, 150, "image/png", 0.5f, 0xff0000, 0xffffff, 10.0f, 10.0f, RBFlags.RenderOutputFilename | RBFlags.RenderColor32BPP | RBFlags.RenderEncodeData);

                    using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                    {
                        sigImage.Image = System.Drawing.Image.FromStream(fs);
                        fs.Close();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

