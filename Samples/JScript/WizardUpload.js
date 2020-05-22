/*
  WizardUpload.js
  Upload file to STU tablet
  Usage:
    WizardUpload ImageFilename // upload image file and leave displayed
    WizardUpload               // clear display (ie no file supplied)

*/
function print( txt ) {
  WScript.Echo(txt);
}
main();
function main() {
  filename = "";
  args = WScript.Arguments;
  if(args.Count() > 0 ) {
    filename=args(0);
    print("Upload image file: " + filename);
    }
  WizCtl = new ActiveXObject("Florentis.WizCtl");
  WizCtl.SetProperty("Licence","<<license>>");
  rc = WizCtl.PadConnect();
  if( rc != true ) {
    print("Unable to make connection to the Pad. Check it is plugged in and try again.");
    return;
  }

  if( filename.length != 0 ) {
    WizCtl.AddObject(7, "", "center", "middle", filename, null);
    WizCtl.AddObject(8, "", 0, 0, null, null);
  }
  else {
    WizCtl.Reset();
  }
  WizCtl.Display();
  WizCtl.PadDisconnect();
}
