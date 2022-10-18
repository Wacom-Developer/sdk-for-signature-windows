' 
'  Displays a form with a button to start signature capture
'  The captured signature is encoded in an image file which is displayed on the form
'
'  Copyright (c) 2020 Wacom Co. Ltd. All rights reserved.
'
Imports FLSIGCTLLib
Imports FlSigCaptLib
Imports System.IO
Public Class VBTestSigCapt

    Private Sub btnSign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSign.Click
      print("btnSign clicked")

      Dim sigCtl As New SigCtl
      Dim dc As New DynamicCapture
      Dim res As DynamicCaptureResult
      Dim renderOK As Boolean
        sigCtl.Licence = "<<license>>"

        res = dc.Capture(sigCtl, "who", "why", vbNull, vbNull)
      If (res = DynamicCaptureResult.DynCaptOK) Then
         print("signature captured successfully")
         Dim sigObj As SigObj
         sigObj = sigCtl.Signature
         sigObj.ExtraData("AdditionalData") = "VB test: Additional data"
         Dim filename As New String("sig1.png")
         renderOK = False
         Try
            sigObj.RenderBitmap(filename, 200, 150, "image/png", 0.5F, &HFF0000, &HFFFFFF, 10.0F, 10.0F,
                                   RBFlags.RenderOutputFilename Or RBFlags.RenderColor32BPP Or RBFlags.RenderEncodeData)
            renderOK = True
         Catch RenderError As System.ArgumentException
            print("Argument error when rendering bitmap")
         End Try
         If (renderOK = True) Then
            Dim fs As New FileStream(filename, FileMode.Open, FileAccess.Read)
            sigImage.Image = System.Drawing.Image.FromStream(fs)
            fs.Close()
            fs.Dispose()
         End If
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
