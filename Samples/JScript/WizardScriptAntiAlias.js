/*
  WizardScriptAntiAlias.js
  Demonstrates a 2 step wizard script in which a transparent signature is captured with anti-aliasing.
  
  Copyright (c) 2019 Wacom. All rights reserved.
*/

var WShell;                   // Windows Scripting Host Shell
var WizCtl;                   // Wizard object
var SigCtl;                   // Signature Control object
var ScriptIsRunning=false;    // script run status
var Pad;                      // Pad coordinates

function TPad(model, signatureLineY, whoY, whyY, textFontSize, buttonFontSize, signLineSize, buttonWith) {
  this.model = model;
  this.signatureLineY = signatureLineY;
  this.whoY = whoY;
  this.whyY = whyY;
  this.buttonWith = buttonWith;
  this.textFontSize = textFontSize;
  this.buttonFontSize = buttonFontSize;
  this.signLineSize = signLineSize;
}

function WizardScriptControl( event ) {
  try {
    //print("WizardScriptControl: " + event);
    switch(event) {
      case "LOAD":      // html page loaded
        print("Create controls...");
        WShell = WSH.CreateObject("WScript.Shell");
		
        SigCtl = new ActiveXObject("Florentis.SigCtl");
		SigCtl.SetProperty("Licence", "<<license>>")
        WizCtl = new ActiveXObject("Florentis.WizCtl");
		WizCtl.SetProperty("Licence", "<<license>>")
		
        WizardScriptControl("START_STOP");
        do{
          rc = WShell.Popup("Running script.\nPress Cancel to stop", 5, "Wizard Script",1);
        } while(rc != 2 && ScriptIsRunning);
        if(ScriptIsRunning) {
          WizardScriptControl("STOP");
          print("Script cancelled");
          }
      break;

      case "START_STOP":
        if( ScriptIsRunning ) {
          WizardScriptControl("STOP");
          return;
          }
        // else start
        // initialise Pad
        rc = WizCtl.PadConnect();
        if( rc != true ) {
          print("Unable to make connection to the Pad");
          WizCtl.Reset();
        }
        else {
          print("Pad detected: " + WizCtl.PadWidth + " x " + WizCtl.PadHeight);
          ScriptIsRunning = true;

          switch (WizCtl.PadWidth) {
            case 396: Pad = new TPad("STU-300", 60, 200, 200, 8, 8, 16, 70);
                         break;
            case 640: Pad = new TPad("STU-500", 300, 360, 390, 16, 22, 32, 110);
                         break;
            case 800: Pad = new TPad("STU-520 or STU-530", 300, 360, 390, 16, 22, 32, 110);
                         break;
            case 320: Pad = new TPad("STU-430 or ePad", 100, 130, 150, 10, 12, 16, 110);
                         break;
            default: print("No compatible device found");
          }
          Step1();
        }
      break;
  

      case "STOP":    // UI button event
        if( !ScriptIsRunning ) {
          print("Script not running");
          return;
          }
        ScriptIsRunning = false;
        WizCtl.Reset();
        WizCtl.Display(); // clear display
        WizCtl.PadDisconnect();
        print("Pad disconnected");
      break;
      
      case "SCRIPT_COMPLETED":
        print("Script completed");
        filename="sig.png";
		var SigObj = SigCtl.Signature;
        SigCtl.Signature.ExtraData("AdditionalData") = "WizardScript.js Additional Data";
		flags = 0x1000 | 0x80000 | 0x400000 | 0x010000 | 0x100000; 
	    //flags = sigObj.outputFilename | sigObj.color32BPP | sigObj.encodeData |sigObj.backgroundTransparent | sigObj.colorAntiAlias;
		rc = SigCtl.Signature.RenderBitmap(filename, 300, 150, "image/png", 0.5, 0xff0000, 0xffffff, 0.0, 0.0, flags );
        print("Created Signature image file: " + filename);
        WizardScriptControl("STOP");
      break;
      
      case "SCRIPT_CANCELLED":
        print("Script cancelled");
        WizardScriptControl("STOP");
      break;
      
      default:
        Error("WizardScriptControl('" + event + "'):  not recognised");
      break;
    }
  }
  catch(e) {
    Exception("WizardScriptControl('" + event + "'): " + e.message);
  }
}
function Exception(txt) {
  print("Exception: " + txt);
}
function Error(txt) {
  print("Error: " + txt);
}
function print(txt) {
  WScript.Echo(txt);
}

//==
//== Wizard Script
//==

// Wizard control enum values
var WizObject = {
  Text:0,
  Button:1,
  Checkbox:2,
  Signature:3
};
// Wizard control enum values
var WizCheckboxOptions = {
  Checked:0,
  DisplayCross:1,
  DisplayTick:2,
  Unchecked:3
};
// Wizard Control primitives
var WizPrimitive = {
  Line:0,
  Rect:1,
  Elipse:2
};

//== PadEventHandler
// Use timeout in IE to run the handler in the script thread
var StepHandler;              // script event handler set for each step
function PadEventHandler( Ctl, Id, Type ) {
  //setTimeout(function(){StepHandler(Ctl,Id,Type)},0);
  StepHandler(Ctl,Id,Type);
}
function SetEventHandler( handler ) {
  WizCtl.SetEventHandler( PadEventHandler );
  StepHandler = handler;
}

//== StepControl
function Step1() {
  try {
    
    WizCtl.Reset();
    WizCtl.Font.Name = "Verdana";
    WizCtl.Font.Bold = false;
    WizCtl.Font.Size = Pad.textFontSize;

    WizCtl.AddObject(WizObject.Text, "txt", "centre", "middle", "Press NEXT to continue", null );

    WizCtl.Font.Size = Pad.buttonFontSize;
    WizCtl.AddObject(WizObject.Button, "Cancel", "left", "bottom", "Cancel", Pad.buttonWith );
    WizCtl.AddObject(WizObject.Button, "Next", "right", "bottom", "Next", Pad.buttonWith );

    WizCtl.Display();

    SetEventHandler(Step1_Handler);
    }  
  catch ( ex ) {
    Exception( "Step1() " + ex.message);
  }
}
function Step1_Handler(Ctl,Id,Type) {
  switch(Id) {
    case "Next":
      Step2();
    break;
    case "Cancel":
      print("Cancel");
      WizardScriptControl("SCRIPT_CANCELLED");
    break;
    default:
      Error("Unexpected Step1 event: " + Id);
    break;
  }
}
function Step2() {
  try {

    WizCtl.Reset();
    WizCtl.Font.Size = Pad.textFontSize;
    WizCtl.AddObject(WizObject.Text, "txt", "center", "top", "Please sign below", null );

    WizCtl.Font.Size = Pad.signLineSize;
    if (Pad.Model == "STU-300") {
      WizCtl.AddObject(WizObject.ObjectText, "txt", "left", Pad.signatureLineY, "X..............................", null);
    } else {
      WizCtl.AddObject(WizObject.ObjectText, "txt", "centre", Pad.signatureLineY, "X..............................", null);
    }

	// insert the signature control
    WizCtl.Font.Size = Pad.textFontSize;
    var sigObj = SigCtl.Signature;
    WizCtl.AddObject(WizObject.Signature, "Sig", 0, 0, sigObj, null );
    
	// provide who and why for sig capture
    WizCtl.AddObject(WizObject.Text, "who", "right", Pad.whoY, "J Smith", null );
    WizCtl.AddObject(WizObject.Text, "why", "right", Pad.whyY, "I certify that the information is correct", null );

	// insert the buttons
    WizCtl.Font.Size = Pad.buttonFontSize;
    if (Pad.Model == "STU-300") {
      WizCtl.AddObject(WizObject.Button, "Cancel", "right", "top", "Cancel", Pad.buttonWith);
      WizCtl.AddObject(WizObject.Button, "Clear", "right", "middle", "Clear", Pad.buttonWith);
      WizCtl.AddObject(WizObject.Button, "OK", "right", "bottom", "OK", Pad.buttonWith);
    } else {
      WizCtl.AddObject(WizObject.Button, "Cancel", "left", "bottom", "Cancel", Pad.buttonWith);
      WizCtl.AddObject(WizObject.Button, "Clear", "center", "bottom", "Clear", Pad.buttonWith);
      WizCtl.AddObject(WizObject.Button, "OK", "right", "bottom", "OK", Pad.buttonWith);
    }
		
    WizCtl.Display();
    SetEventHandler(Step2_Handler);
    }  
  catch ( ex ) {
    Exception( "Step2() " + ex.message);
  }
}
function Step2_Handler(Ctl,Id,Type) {

  switch(Id) {
    case "OK":
      WizardScriptControl("SCRIPT_COMPLETED");
    break;
    case "Clear":
    break;
    case "Cancel":
      WizardScriptControl("SCRIPT_CANCELLED");
    break;
    default:
      Error("Unexpected Step2 event: " + Id);
    break;
  }
}
// == end of Wizard script
main();
function main(){
  WizardScriptControl("LOAD");
}
  