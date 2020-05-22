TestWizSigCapt C# demo using Visual Studio 2010

1.  Install the Wacom Signature SDK
    Includes the ActiveX control interops:
        C:\Program Files\Common Files\Florentis.InteropAxFlSigCOM.dll
        C:\Program Files\Common Files\Florentis.InteropAxFlWizCOM.dll
        

2.  Create a new project in Visual Studio as a C# Windows Forms Application.
    Name: TestWizSigCapt
    In Form1.cs(Design)
    Properties: 
                Text    = TestWizSigCapt
                (Name)  = TestWizSigCapt
    Toolbox:    
                Insert PictureBox
                Properties: Name = sigImage
                            Size = 200,150
                            BackColor = ControlLightLight
                Insert Button
                Properties: Name = btnSign
                            Text = Sign
                Insert Button
                Properties: Name = btnCancel
                            Text = Cancel
                Insert TextBox
                Properties: Name = txtDisplay
                            Multiline = True
                            ScrollBars = Vertical
                         
3.  Insert display code and run:
    Double-click the Sign button to create btnSign_Click() in Form1.cs
    Rename Form1.cs TestWizSigCapt.cs
    Add a print call and function:
    (add the print function first to help the IntelliSense code editor)
        private void btnSign_Click(object sender, EventArgs e)
        {
            print("btnSign clicked");
        }
        private void print(string txt)
        {
            txtDisplay.Text += txt + "\r\n";
            txtDisplay.SelectionStart = txtDisplay.Text.Length;  // scroll to end
            txtDisplay.ScrollToCaret();
            txtDisplay.Refresh();
        }
    Repeat to create btnCancel_Click()
        private void btnCancel_Click(object sender, EventArgs e)
        {
            print("btnCancel clicked");
        }
    
    Build and run.

4.  Add the Wizard and Signature controls to the form design:
    Tools...Choose Toolbox Items
    in the .NET Framework Components tab:
    Browse...
    select and Open:
    C:\Program Files\Common Files\Florentis.InteropAxFlWizCOM.dll
    Browse...
    select and Open:
    C:\Program Files\Common Files\Florentis.InteropAxFlSigCOM.dll
    OK
    The Design Toolbox should now show the .NET components:
    AxWizCtl
    AxSigCtl
    
    Insert AxWizCtl on the form
    Properties:
        (Name):   WizCtl
        Visible:  False
        Zoom:     50
    
    Insert AxSigCtl on the form
    Properties:
        (Name):   SigCtl
        Visible:  False

    
    
5.  Insert the signature capture code:
    Add reference to the ActiveX controls:
      
    In TestWizSigCapt.cs add:
    using Florentis;
    
    Replace the entire namespace:

////////////
namespace TestWizSigCapt
{
    public partial class TestWizSigCapt : Form
    {
        bool ScriptIsRunning;               // flag for UI button respones
        WizardCallback Callback;            // For wizard callback 
        tPad Pad;                           // Pad parameters
        class tPad 
        {
            public string   Model;
            public Font     TextFont;
            public Font     ButtonFont;
            public Font     SigLineFont;
            public int      TextLS;
            public int      ButtonWidth;
        }
        static tPad Pad500()                       // STU-500/520 = 640x480/800x480
        {
            tPad thePad = new tPad();
            thePad.Model = "STU-500";
            thePad.TextFont = new Font("Verdana", 16, FontStyle.Regular);
            thePad.ButtonFont = new Font("Verdana", 22, FontStyle.Regular);
            thePad.SigLineFont = new Font("Verdana", 32, FontStyle.Regular);
            thePad.TextLS = 30;
            thePad.ButtonWidth = 110;
            return thePad;
        }
        static tPad Pad300()                      // STU-300 = 396x100
        {
            tPad thePad = new tPad();
            thePad.Model = "STU-300";
            thePad.TextFont = new Font("Verdana", 8, FontStyle.Regular);
            thePad.ButtonFont = new Font("Verdana", 8, FontStyle.Bold);
            thePad.SigLineFont = new Font("Verdana", 16, FontStyle.Regular);
            thePad.TextLS = 12;
            thePad.ButtonWidth = 70;
            return thePad;
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
            WizCtl.SetProperty("Licence", "AgAZAPZTkH0EBVdhY29tClNESyBTYW1wbGUBAoECA2UA");
            bool success = WizCtl.PadConnect();
            if (success)
            {
                ScriptIsRunning = true;
                print("Pad detected: " + WizCtl.PadWidth + " x " + WizCtl.PadHeight);
                if (WizCtl.PadHeight > 100)
                {
                    print("STU-500");
                    Pad = Pad500();
                }
                else
                {
                    print("STU-300");
                    Pad = Pad300();
                }
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
            WizCtl.PadDisconnect();
            Callback.EventHandler = null;       // remove handler
            WizCtl.SetEventHandler(Callback);
        }

        private void step1()
        {
            int x,y = 0;
            WizCtl.Reset();

            // insert message
            WizCtl.Font = Pad.TextFont;
            WizCtl.AddObject(ObjectType.ObjectText, "txt", "centre", 10, "Please sign below...", null);

            // insert a signature line
            WizCtl.Font = Pad.SigLineFont;
            y = (int)(WizCtl.PadHeight * 0.6);
            WizCtl.AddObject(ObjectType.ObjectText, "txt", "centre", y, "X..............................", null);

            // insert the signature control
            WizCtl.Font = Pad.TextFont;
            WizCtl.AddObject(ObjectType.ObjectSignature, "Sig", 0, 0, SigCtl.Signature, null);
            // provide who and why for sig capture
            y += 2 * Pad.TextLS;
            if (Pad.Model == "STU-300")
                y = WizCtl.PadHeight + 10; // put text off screen (no display)
            WizCtl.AddObject(ObjectType.ObjectText, "who", "right", y, "J Smith", null);
            y += Pad.TextLS;
            WizCtl.AddObject(ObjectType.ObjectText, "why", "right", y, "I certify that the information is correct", null);

            // insert the buttons
            WizCtl.Font = Pad.ButtonFont;
            int xmargin,ymargin;
            xmargin=ymargin=20;
            if (Pad.Model == "STU-300") { xmargin = 5; ymargin = 0; }
            y = (int)(WizCtl.PadHeight - Pad.TextLS - ymargin);
            x = xmargin;
            WizCtl.AddObject(ObjectType.ObjectButton, "Cancel", x, y, "Cancel", Pad.ButtonWidth);
            WizCtl.AddObject(ObjectType.ObjectButton, "Clear", "center", y, "Clear", Pad.ButtonWidth);
            x = WizCtl.PadWidth - Pad.ButtonWidth - xmargin;
            WizCtl.AddObject(ObjectType.ObjectButton, "OK", x, y, "OK", Pad.ButtonWidth);

            // set callback when a button is pressed
            Callback.EventHandler = new WizardCallback.Handler(Step1_Handler);
            WizCtl.SetEventHandler(Callback);
            WizCtl.Display();

        }
        private void Step1_Handler(object clt, object id, object type)
        {
            //print("Step1_Handler Id: " + id.ToString());
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
////////////

    
      Select Build...Solution
      If a warning is issued
      "A reference was created to embedded interop assembly ~~~\stdole.dll' ~~~"
      In the Solution Explorer
      Set the properties for stdole, Florentis.InteropFlSigCOM and Florentis.InteropFlWizCOM to 
        Embed Interop Type:   False
        

      Run       
      Press Sign to start signature capture
      This will call Step1() to display text and buttons on the tablet LCD display.
      After signing press OK to complete the script
      The image file sig1.png will be created and displayed in sigImage
      
      