TestSigCapt VB demo using Visual Studio 2010

1.  Install the Wacom Signature SDK
    Includes the ActiveX controls:
        C:\Program Files\Common Files\FlSigCapt.dll
        C:\Program Files\Common Files\FlSigCOM.dll
        

2.  Create a new project in Visual Studio as a VB Windows Forms Application.
    Name: TestSigCapt
    In Form1.vb(Design)
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
    Double-click the Sign button to create btnSign_Click() in Form1.vb
    Rename Form1.vb TestSigCapt.vb (in Solution Explorer)
    Add a print call and function:

    Private Sub btnSign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSign.Click
        print("btnSign clicked")
    End Sub
    Private Sub print(ByVal txt)
        txtDisplay.Text = txtDisplay.Text & txt & vbCrLf
    End Sub

    Build and run.
    
4.  Insert the signature capture code:
    Add reference to the ActiveX controls:
    Select menu Project...TestSigCapt Properties
      Select References tab
      Select Add
        Browse... to Program Files\Common Files\Florentis
        FlSigCapt.dll
        FlSigCOM.dll
      
    In TestSigCapt.vb add:
   
    Imports FLSIGCTLLib
    Imports FlSigCaptLib
    
    change Public Class VBTestSigCapt btnSign_Click contents to:
    
      Public Class VBTestSigCapt

          Private Sub btnSign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSign.Click
              print("btnSign clicked")

              Dim sigCtl As New SigCtl
              Dim dc As New DynamicCapture
              Dim res As DynamicCaptureResult
              res = dc.Capture(sigCtl, "who", "why", vbNull, vbNull)
              If (res = DynamicCaptureResult.DynCaptOK) Then
                  print("signature captured successfully")
                  Dim sigObj As SigObj
                  sigObj = sigCtl.Signature
                  sigObj.ExtraData("AdditionalData") = "VB test: Additional data"
                  Dim filename As New String("sig1.png")
                  sigObj.RenderBitmap(filename, 200, 150, "image/png", 0.5F, &HFF0000, &HFFFFFF, -1.0F, -1.0F, _
                                     RBFlags.RenderOutputFilename Or RBFlags.RenderColor32BPP Or RBFlags.RenderEncodeData)
                  sigImage.Load(filename)
              Else
                  print("Signature capture error res=" & res)
                  Select Case res
                      Case DynamicCaptureResult.DynCaptCancel
                          print("signature cancelled")
                      Case DynamicCaptureResult.DynCaptError
                          print("no capture service available")
                      Case DynamicCaptureResult.DynCaptPadError
                          print("signing device error")
                      Case Else
                          print("Unexpected error code ")
                  End Select
              End If

          End Sub


          Private Sub print(ByVal txt)
              txtDisplay.Text = txtDisplay.Text & txt & vbCrLf
          End Sub
      End Class
    
    Build and Run       
    Press Sign to start signature capture
    After signing the image file sig1.png will be created and displayed in the form.
   