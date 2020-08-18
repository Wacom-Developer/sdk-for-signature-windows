TestWizSigCapt C# demo using Visual Studio 2010

1.  Install the Wacom Signature SDK
    Includes the ActiveX control interops:
        C:\Program Files\Common Files\Florentis.InteropAxFlSigCOM.dll
        C:\Program Files\Common Files\Florentis.InteropAxFlWizCOM.dll
        

2.  Create a new project in Visual Studio as a VB Windows Forms Application.
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
    Double-click the Sign button to create btnSign_Click() in Form1.vb
    Rename Form1.vb TestSigCapt.vb (in Solution Explorer)
    Add a print call and function:

    Private Sub btnSign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSign.Click
        print("btnSign clicked")
    End Sub
    Private Sub print(ByVal txt)
        txtDisplay.Text = txtDisplay.Text & txt & vbCrLf
        txtDisplay.SelectionStart = txtDisplay.Text.Length  '// scroll to end
        txtDisplay.ScrollToCaret()
        txtDisplay.Refresh()
    End Sub

    Repeat to create btnCancel_Click()
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        print("btnCancel clicked")
    End Sub
    
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

    Warnings may be displayed:
      "A reference was created to embedded interop assembly ~~~\stdole.dll' ~~~"
      Select Project...TestWizSigCapt Properties...References
      The Properties window will be displayed for the selected reference
      Set the properties for stdole, Florentis.InteropFlSigCOM and Florentis.InteropFlWizCOM to 
        Embed Interop Type:   False

        
5.  Insert the signature capture code:
    Add reference to the ActiveX controls:
      
    In TestWizSigCapt.vb 
    
    Replace the entire source:

////////////
Imports Florentis
Public Class TestWizSigCapt

    ' comment
    Dim ScriptIsRunning                '// flag for UI button respones
    Dim Callback As New WizardCallback '// For wizard callback 
    Structure structPad
        Public Model As String
        Public TextFont As Font
        Public ButtonFont As Font
        Public SigLineFont As Font
        Public TextLS As Integer
        Public ButtonWidth As Integer
    End Structure
    Dim Pad As structPad
    Dim Pad500 As structPad
    Dim Pad300 As structPad

    Private Sub initialise()
        Callback.EventHandler = Nothing
        WizCtl.SetEventHandler(Callback)
        ScriptIsRunning = False

        Pad500.Model = "STU-500"
        Pad500.TextFont = New Font("Verdana", 16, FontStyle.Regular)
        Pad500.ButtonFont = New Font("Verdana", 22, FontStyle.Regular)
        Pad500.SigLineFont = New Font("Verdana", 32, FontStyle.Regular)
        Pad500.TextLS = 30
        Pad500.ButtonWidth = 110

        Pad300.Model = "STU-300"
        Pad300.TextFont = New Font("Verdana", 8, FontStyle.Regular)
        Pad300.ButtonFont = New Font("Verdana", 8, FontStyle.Bold)
        Pad300.SigLineFont = New Font("Verdana", 16, FontStyle.Regular)
        Pad300.TextLS = 12
        Pad300.ButtonWidth = 70

    End Sub

    Private Sub btnSign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSign.Click
        print("Sign...")
        initialise()
        If (ScriptIsRunning <> True) Then
            startWizard()
        Else
            print("Script is already running")
        End If
    End Sub
    Private Sub print(ByVal txt)
        txtDisplay.Text = txtDisplay.Text & txt & vbCrLf
        txtDisplay.SelectionStart = txtDisplay.Text.Length  '// scroll to end
        txtDisplay.ScrollToCaret()
        txtDisplay.Refresh()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        print("Cancel...")
        If (ScriptIsRunning = True) Then
            scriptCancelled()
        Else
            print("Script is not running")
        End If
    End Sub

    Private Sub startWizard()
        print("startWizard()")
        Dim success As Boolean
        success = WizCtl.PadConnect()
        If (success = True) Then
            ScriptIsRunning = True
            print("Pad detected: " & WizCtl.PadWidth & " x " & WizCtl.PadHeight)
            If (WizCtl.PadHeight > 100) Then
                print("STU-500")
                Pad = Pad500
            Else
                print("STU-300")
                Pad = Pad300
            End If
            step1()
        Else
            print("Unable to connect to tablet")
        End If
    End Sub
    Private Sub scriptCompleted()
        print("scriptCompleted()")
        Dim sigObj As SigObj
        sigObj = SigCtl.Signature
        sigObj.ExtraData("AdditionalData") = "VB test: Additional data"
        Dim filename As New String("sig1.png")
        sigObj.RenderBitmap(filename, 200, 150, "image/png", 0.5F, &HFF0000, &HFFFFFF, -1.0F, -1.0F, _
                           RBFlags.RenderOutputFilename Or RBFlags.RenderColor32BPP Or RBFlags.RenderEncodeData)
        sigImage.Load(filename)
        closeWizard()
    End Sub

    Private Sub scriptCancelled()
        print("scriptCancelled()")
        closeWizard()
    End Sub
    Private Sub closeWizard()
        print("closeWizard()")
        ScriptIsRunning = False
        WizCtl.Reset()
        WizCtl.Display()
        WizCtl.PadDisconnect()
        Callback.EventHandler = Nothing       '// remove handler
        WizCtl.SetEventHandler(Callback)
    End Sub
    Private Sub step1()
        print("step1()")
        Dim x, y As Integer
        WizCtl.Reset()

        '// insert message
        WizCtl.Font = Pad.TextFont
        WizCtl.AddObject(ObjectType.ObjectText, "txt", "centre", 10, "Please sign below...", Nothing)

        '// insert a signature line
        WizCtl.Font = Pad.SigLineFont
        y = (WizCtl.PadHeight * 0.6)
        WizCtl.AddObject(ObjectType.ObjectText, "txt", "centre", y, "X..............................", Nothing)

        '// insert the signature control
        WizCtl.Font = Pad.TextFont
        WizCtl.AddObject(ObjectType.ObjectSignature, "Sig", 0, 0, SigCtl.Signature, Nothing)
        '// provide who and why for sig capture
        y += 2 * Pad.TextLS
        If (Pad.Model = "STU-300") Then
            y = WizCtl.PadHeight + 10  '// put text off screen (no display)
        End If
        WizCtl.AddObject(ObjectType.ObjectText, "who", "right", y, "J Smith", Nothing)
        y += Pad.TextLS
        WizCtl.AddObject(ObjectType.ObjectText, "why", "right", y, "I certify that the information is correct", Nothing)

        '// insert the buttons
        WizCtl.Font = Pad.ButtonFont
        Dim xmargin, ymargin As Integer
        xmargin = ymargin = 20
        If (Pad.Model = "STU-300") Then
            xmargin = 5
            ymargin = 0
        End If
        y = (WizCtl.PadHeight - Pad.TextLS - ymargin)
        x = xmargin
        WizCtl.AddObject(ObjectType.ObjectButton, "Cancel", x, y, "Cancel", Pad.ButtonWidth)
        WizCtl.AddObject(ObjectType.ObjectButton, "Clear", "center", y, "Clear", Pad.ButtonWidth)
        x = WizCtl.PadWidth - Pad.ButtonWidth - xmargin
        WizCtl.AddObject(ObjectType.ObjectButton, "OK", x, y, "OK", Pad.ButtonWidth)

        '// set callback when a button is pressed
        Callback.EventHandler = New WizardCallback.Handler(AddressOf Step1_Handler)
        WizCtl.SetEventHandler(Callback)
        WizCtl.Display()
    End Sub

    Private Function Step1_Handler(ByVal clt As Object, ByVal id As Object, ByVal type As Object)
        '//print("Step1_Handler Id: " + id.ToString())
        If (id = "OK") Then
            'case "OK":
            scriptCompleted()
        ElseIf (id = "Clear") Then
            'case "Clear":
            print("Clear")
        ElseIf (id = "Cancel") Then
            'case "Cancel":
            scriptCancelled()
        Else
            'default:
            print("Unexpected pad event: " + id)
        End If
        Return Nothing
    End Function

End Class
////////////

    
      Select Build...Solution
        

      Run       
      Press Sign to start signature capture
      This will call Step1() to display text and buttons on the tablet LCD display.
      After signing press OK to complete the script
      The image file sig1.png will be created and displayed in sigImage
      
      