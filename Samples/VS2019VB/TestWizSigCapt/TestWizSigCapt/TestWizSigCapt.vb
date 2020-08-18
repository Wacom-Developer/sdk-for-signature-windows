' 
'  Displays a form with a button to start signature capture using the Wizard script
'  The captured signature is encoded in an image file which is displayed on the form
'
'  Copyright (c) 2020 Wacom Co. Ltd. All rights reserved.
'
Imports Florentis
Public Class TestWizSigCapt

    ' comment
    Dim ScriptIsRunning                ' flag for UI button respones
    Dim Callback As New WizardCallback ' For wizard callback 
    Structure structPad
        Public Model As String
        Public TextFont As Font
        Public ButtonFont As Font
        Public SigLineFont As Font
        Public SignatureLineY As Integer
        Public WhoY As Integer
        Public whyY As Integer
        Public buttonWith As Integer
    End Structure
    Dim Pad As structPad
    Dim isCheck As Boolean = True

    Function initializePad(ByVal model As String, ByVal signatureLineY As Integer, ByVal whoY As Integer, ByVal whyY As Integer,
                              ByVal textFontSize As Integer, ByVal buttonFontSize As Integer, ByVal signLineSize As Integer,
                              ByVal buttonWith As Integer) As structPad

        Dim myPad As structPad
        myPad.Model = model
        myPad.TextFont = New Font("Verdana", textFontSize, FontStyle.Regular)
        myPad.ButtonFont = New Font("Verdana", buttonFontSize, FontStyle.Bold)
        myPad.SigLineFont = New Font("Verdana", signLineSize, FontStyle.Regular)
        myPad.SignatureLineY = signatureLineY
        myPad.WhoY = whoY
        myPad.whyY = whyY
        myPad.buttonWith = buttonWith

        Return myPad

    End Function

    Private Sub btnSign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSign.Click
        print("Sign...")
        isCheck = False
        Callback.EventHandler = Nothing
        WizCtl.SetEventHandler(Callback)
        ScriptIsRunning = False
        If (ScriptIsRunning <> True) Then
            startWizard()
        Else
            print("Script is already running")
        End If
    End Sub
    Private Sub print(ByVal txt)
        txtDisplay.Text = txtDisplay.Text & txt & vbCrLf
        txtDisplay.SelectionStart = txtDisplay.Text.Length  ' scroll to end
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
        WizCtl.Licence = "<<license>>"
        success = WizCtl.PadConnect()
      If (success = True) Then
         ScriptIsRunning = True
         print("Pad detected: " & WizCtl.PadWidth & " x " & WizCtl.PadHeight)
         Select Case WizCtl.PadWidth
            Case 396
               Pad = initializePad("STU-300", 60, 200, 200, 8, 8, 16, 70) ' 396 x 100
            Case 640
               Pad = initializePad("STU-500", 300, 360, 390, 16, 22, 32, 110) ' 640 x 800
            Case 800
               Pad = initializePad("STU-520 or STU-530", 300, 360, 390, 16, 22, 32, 110) ' 800 x 480
            Case 320
               Pad = initializePad("STU-430 or ePad", 100, 130, 150, 10, 12, 16, 110) ' 320 x 200
            Case Else
               print("No compatible device found")
         End Select
         print(Pad.Model)
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
        Callback.EventHandler = Nothing       ' remove handler
        WizCtl.SetEventHandler(Callback)
    End Sub
    Private Sub step1()
        print("step1()")
        WizCtl.Reset()

        ' insert checkbox
        WizCtl.Font = Pad.TextFont
        WizCtl.AddObject(ObjectType.ObjectCheckbox, "Check", "centre", "middle", "I have read and I accept the terms and conditions", 2)

        ' insert the buttons
        WizCtl.Font = Pad.ButtonFont
        WizCtl.AddObject(ObjectType.ObjectButton, "Cancel", "left", "bottom", "Cancel", Pad.buttonWith)
        WizCtl.AddObject(ObjectType.ObjectButton, "Next", "right", "bottom", "Next", Pad.buttonWith)

        ' set callback when a button is pressed
        Callback.EventHandler = New WizardCallback.Handler(AddressOf Step1_Handler)
        WizCtl.SetEventHandler(Callback)
        WizCtl.Display()
    End Sub

    Private Function Step1_Handler(ByVal clt As Object, ByVal id As Object, ByVal type As Object)
        If (id = "Next") Then
            If (isCheck) Then
                step2()
            End If
        ElseIf (id = "Cancel") Then
            scriptCancelled()
        ElseIf (id = "Check") Then
            isCheck = True
        Else
            'default:
            print("Unexpected pad event: " + id)
        End If
        Return Nothing
    End Function

    Private Sub step2()
        print("step2()")
        WizCtl.Reset()

        ' insert message
        WizCtl.Font = Pad.TextFont
        WizCtl.AddObject(ObjectType.ObjectText, "txt", "centre", "top", "Please sign below...", Nothing)

        ' insert a signature line
        WizCtl.Font = Pad.SigLineFont
        If (Pad.Model = "STU-300") Then
            WizCtl.AddObject(ObjectType.ObjectText, "txt", "left", Pad.SignatureLineY, "X..............................", Nothing)
        Else
            WizCtl.AddObject(ObjectType.ObjectText, "txt", "centre", Pad.SignatureLineY, "X..............................", Nothing)
        End If

        ' insert the signature control
        WizCtl.Font = Pad.TextFont
        WizCtl.AddObject(ObjectType.ObjectSignature, "Sig", 0, 0, SigCtl.Signature, Nothing)

        ' provide who and why for sig capture
        WizCtl.AddObject(ObjectType.ObjectText, "who", "right", Pad.WhoY, "J Smith", Nothing)
        WizCtl.AddObject(ObjectType.ObjectText, "why", "right", Pad.whyY, "I certify that the information is correct", Nothing)

        ' insert the buttons
        WizCtl.Font = Pad.ButtonFont
        If (Pad.Model = "STU-300") Then
            WizCtl.AddObject(ObjectType.ObjectButton, "Cancel", "right", "top", "Cancel", Pad.buttonWith)
            WizCtl.AddObject(ObjectType.ObjectButton, "Clear", "right", "middle", "Clear", Pad.buttonWith)
            WizCtl.AddObject(ObjectType.ObjectButton, "OK", "right", "middle", "OK", Pad.buttonWith)
        Else
            WizCtl.AddObject(ObjectType.ObjectButton, "Cancel", "left", "bottom", "Cancel", Pad.buttonWith)
            WizCtl.AddObject(ObjectType.ObjectButton, "Clear", "center", "bottom", "Clear", Pad.buttonWith)
            WizCtl.AddObject(ObjectType.ObjectButton, "OK", "right", "bottom", "OK", Pad.buttonWith)
        End If

        ' set callback when a button is pressed
        Callback.EventHandler = New WizardCallback.Handler(AddressOf Step2_Handler)
        WizCtl.SetEventHandler(Callback)
        WizCtl.Display()
    End Sub

    Private Function Step2_Handler(ByVal clt As Object, ByVal id As Object, ByVal type As Object)
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
