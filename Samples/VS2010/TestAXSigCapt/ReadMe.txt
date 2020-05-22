TestAXSigCapt C# demo using the ActiveX control with Visual Studio 2010

1.  Install the Wacom Signature SDK
    Includes the ActiveX control interops:
        C:\Program Files\Common Files\Florentis.InteropAxFlSigCOM
        C:\Program Files\Common Files\Florentis.InteropFlSigCapt.dll
        C:\Program Files\Common Files\Florentis.InteropFlSigCOM.dll
        
2.  Create a new project in Visual Studio as a C# Windows Forms Application.
    Name: TestAXSigCapt
    Add references to interops:
    In Solution Explorer, right-click References...Add Reference
    In Browse tab, select:
        C:\Program Files\Common Files\Florentis.InteropAxFlSigCOM
        C:\Program Files\Common Files\Florentis.InteropFlSigCapt.dll
        C:\Program Files\Common Files\Florentis.InteropFlSigCOM.dll
    Right click references..Preferences
    For the 3 interops set Embed Interop Type = False
    
    In Solution Explorer, rename Form1 to TestAXSigCapt
    
3.  In TestAXSigCapt design view:
    Properties: 
                Text    = TestAXSigCapt
                (Name)  = TestAXSigCapt
    Toolbox:    
                Insert Button
                Properties: Name = btnSign
                            Text = Sign
                Insert TextBox
                Properties: Name = txtDisplay
                            Multiline = True
                            ScrollBars = Vertical
                Insert AxSigCtl
                Properties: Name = axSigCtl1
                            BackColor = ControlLightLight
                  
    If AxSigCtl is not in the design Toolbox, add it via:
    Tools...Choose Toolbox Items
    In .NET Framework Components browse to:
        C:\Program Files\Common Files\Florentis.InteropAxFlSigCOM
                         
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
      
    Modify TestAXSigCapt.cs:

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

      Select Build...Build Solution 
       
      Run       
      Press Sign to start signature capture
      After signing the image file sig1.png will be created and displayed in the window.
   