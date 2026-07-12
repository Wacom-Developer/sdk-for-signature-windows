TestSigCapt C# demo using Visual Studio 2010

1.  Install the Wacom Signature SDK
    Includes the ActiveX control interops:
        C:\Program Files\Common Files\Florentis.InteropFlSigCapt.dll
        C:\Program Files\Common Files\Florentis.InteropFlSigCOM.dll
        

2.  Create a new project in Visual Studio as a C# Windows Forms Application.
    Name: TestSigCapt
    In Form1.cs(Design)
    Properties: 
                Text    = TestSigCapt
                (Name)  = TestSigCapt
    Toolbox:    
                Insert PictureBox
                Properties: Name = sigImage
                            Size = 200,150
                            BackColor = ControlLightLight
                Insert Button
                Properties: Name = btnSign
                            Text = Sign
                Insert TextBox
                Properties: Name = txtDisplay
                            Multiline = True
                            ScrollBars = Vertical
                         
3.  Insert display code and run:
    Double-click the Sign button to create btnSign_Click() in Form1.cs
    Rename Form1.cs TestSigCapt.cs
    Add a print call and function:
        private void btnSign_Click(object sender, EventArgs e)
        {
            print("btnSign clicked");
        }
        private void print(string txt)
        {
            txtDisplay.Text += txt + "\r\n";
        }
    Build and run.
    
4.  Insert the signature capture code:
    Add reference to the ActiveX controls:
    In the Solution Explorer panel:
      right-click References... Add Reference  
        Browse... to Program Files\Common Files\Florentis
        Select Florentis.InteropFlSigCapt.dll...Add
            Properties: EmbedInteropType = False 
        Select Florentis.InteropFlSigCOM.dll...Add
            Properties: EmbedInteropType = False 
      
    Modify TestSigCapt.cs:

    using Florentis;
    namespace TestSigCapt
    {
        public partial class TestSigCapt : Form
        {
            public TestSigCapt()
            {
                InitializeComponent();
            }

            private void btnSign_Click(object sender, EventArgs e)
            {
                print("btnSign was pressed");
                SigCtl sigCtl = new SigCtl();
                sigCtl.Licence = "AgAZAPZTkH0EBVdhY29tClNESyBTYW1wbGUBAoECA2UA";
                DynamicCapture dc = new DynamicCaptureClass();
                DynamicCaptureResult res = dc.Capture(sigCtl, "Who", "Why", null, null);
                if (res == DynamicCaptureResult.DynCaptOK)
                {
                    print("signature captured successfully");
                    SigObj sigObj = (SigObj) sigCtl.Signature;
                    sigObj.set_ExtraData("AdditionalData", "C# test: Additional data");
                    String filename = "sig1.png";
                    sigObj.RenderBitmap(filename, 200, 150, "image/png", 0.5f, 0xff0000, 0xffffff, -1.0f, -1.0f, RBFlags.RenderOutputFilename | RBFlags.RenderColor32BPP | RBFlags.RenderEncodeData);
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
            }

        }
    }

      Select Build...Build Solution 
       
      Run       
      Press Sign to start signature capture
      After signing the image file sig1.png will be created and displayed in the window.
   