/*
  CaptureSigText
  Captures a signature and creates a SigText file sig.txt
  (an alternative output filename can be supplied as an argument)
  
*/
function print( txt ) {
  WScript.Echo(txt);
}
main();
function main() {
  filename = "sig.txt";
  // Look for commandline arguments
  args = WScript.Arguments;
  if(args.Count() > 0 )
    filename=args(0);
  // Create ActiveX controls
  sigCtl = new ActiveXObject("Florentis.SigCtl");
  sigCtl.SetProperty("Licence","<<license>>");
  dynCapt = new ActiveXObject("Florentis.DynamicCapture");
  // Start Signature Capture
  rc = dynCapt.Capture(sigCtl,"Who","Why");
  if( rc == 0 ) {
    // Capture was successful
    // (optionally) insert some extra data in the signature object
    sigCtl.Signature.ExtraData("AdditionalData") = "CaptureSigText.js Additional Data";

    print("SigText:\n"+sigCtl.Signature.SigText);

    // Save SigText to disk
    var fso = new ActiveXObject("Scripting.FileSystemObject");
    var ForWriting = 2;
    var f = fso.OpenTextFile(filename, ForWriting, true);
    f.Write(sigCtl.Signature.SigText);
    f.Close();
    print("Created Signature Text file: " + filename);
  }
  else {
    // Capture failed:
    print("Capture returned: " + rc);
    switch(rc) {
      case 1:   print("Cancelled");
                break;
      case 100: print("Signature tablet not found");
                break;
      case 103: print("Capture not licensed");
                break;
    }
  }
}
