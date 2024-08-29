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
        sigCtl.Licence = "eyJhbGciOiJSUzUxMiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiI3YmM5Y2IxYWIxMGE0NmUxODI2N2E5MTJkYTA2ZTI3NiIsImV4cCI6MjE0NzQ4MzY0NywiaWF0IjoxNTYwOTUwMjcyLCJyaWdodHMiOlsiU0lHX1NES19DT1JFIiwiU0lHQ0FQVFhfQUNDRVNTIl0sImRldmljZXMiOlsiV0FDT01fQU5ZIl0sInR5cGUiOiJwcm9kIiwibGljX25hbWUiOiJTaWduYXR1cmUgU0RLIiwid2Fjb21faWQiOiI3YmM5Y2IxYWIxMGE0NmUxODI2N2E5MTJkYTA2ZTI3NiIsImxpY191aWQiOiJiODUyM2ViYi0xOGI3LTQ3OGEtYTlkZS04NDlmZTIyNmIwMDIiLCJhcHBzX3dpbmRvd3MiOltdLCJhcHBzX2lvcyI6W10sImFwcHNfYW5kcm9pZCI6W10sIm1hY2hpbmVfaWRzIjpbXX0.ONy3iYQ7lC6rQhou7rz4iJT_OJ20087gWz7GtCgYX3uNtKjmnEaNuP3QkjgxOK_vgOrTdwzD-nm-ysiTDs2GcPlOdUPErSp_bcX8kFBZVmGLyJtmeInAW6HuSp2-57ngoGFivTH_l1kkQ1KMvzDKHJbRglsPpd4nVHhx9WkvqczXyogldygvl0LRidyPOsS5H2GYmaPiyIp9In6meqeNQ1n9zkxSHo7B11mp_WXJXl0k1pek7py8XYCedCNW5qnLi4UCNlfTd6Mk9qz31arsiWsesPeR9PN121LBJtiPi023yQU8mgb9piw_a-ccciviJuNsEuRDN3sGnqONG3dMSA"

        res = dc.Capture(sigCtl, "who", "why", vbNull, vbNull)
      If (res = DynamicCaptureResult.DynCaptOK) Then
         print("signature captured successfully")
         Dim sigObj As SigObj
         sigObj = sigCtl.Signature
         sigObj.ExtraData("AdditionalData") = "VB test: Additional data"
         Dim filename As New String("sig1.png")
         renderOK = False
         Try
        sigObj.RenderBitmap(filename, 300, 225, "image/png", 0.5F, &HFF0000, &HFFFFFF, 10.0F, 10.0F,
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

  Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
    Application.Exit()
  End Sub
End Class
