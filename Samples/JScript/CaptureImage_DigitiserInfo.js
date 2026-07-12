/*
  CaptureImage_DigitiserInfo.js
  Capture signature and print out digitiser info in debug window.
  Signature image is output to "sig.png" by default - an alternative name can be supplied as an argument
  
  Copyright (c) 2015 Wacom GmbH. All rights reserved.
*/
function print( txt ) {
  WScript.Echo(txt);
}
main();
function main() {
  filename = "sig.png";
  args = WScript.Arguments;
  if(args.Count() > 0 )
    filename=args(0);
  sigCtl = new ActiveXObject("Florentis.SigCtl");
  sigCtl.SetProperty("Licence", "AgAkAEy2cKydAQVXYWNvbQ1TaWduYXR1cmUgU0RLAgKBAgJkAACIAwEDZQA")
  dynCapt = new ActiveXObject("Florentis.DynamicCapture");
  rc = dynCapt.Capture(sigCtl,"Who","Why");
  if( rc == 0 ) {
    sigCtl.Signature.ExtraData("AdditionalData") = "CaptureImage.js Additional Data";
	var digitiserInfo = sigCtl.Signature.AdditionalData(26);
	print("Digitiser info " + digitiserInfo);
	
	var driver = sigCtl.Signature.AdditionalData(27);
	print("Digitiser info " + driver);
	
    flags = 0x1000 | 0x80000 | 0x400000; //SigObj.outputFilename | SigObj.color32BPP | SigObj.encodeData
    rc = sigCtl.Signature.RenderBitmap(filename, 150, 100, "image/png", 0.5, 0xff0000, 0xffffff, 0.0, 0.0, flags );
    print("Created Signature image file: " + filename);
  }
  else {
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
