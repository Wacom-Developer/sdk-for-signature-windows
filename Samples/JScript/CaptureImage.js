/*
  CaptureImage
  Captures a signature and creates an encoded image file sig.png
  (an alternative output filename can be supplied as an argument)
  
*/
function print( txt ) { // to simplify the code
  WScript.Echo(txt);
}
main();
function main() {
  filename = "sig.png";
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
    sigCtl.Signature.ExtraData("AdditionalData") = "CaptureImage.js Additional Data";
    // create a signature image
    flags = 0x1000 | 0x80000 | 0x400000; //SigObj.outputFilename | SigObj.color32BPP | SigObj.encodeData
    rc = sigCtl.Signature.RenderBitmap(filename, 300, 150, "image/png", 0.5, 0xff0000, 0xffffff, 0.0, 0.0, flags );
    print("Created Signature image file: " + filename);
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
