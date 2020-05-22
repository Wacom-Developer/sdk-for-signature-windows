/*
  CaptureImage_B64.js
  Captures a signature as a B64 string and prints on monitor
  
  Copyright © 2019 Wacom. All Rights Reserved.
*/
function print( txt ) {
  WScript.Echo(txt);
}
main();
function main() {
  sigCtl = new ActiveXObject("Florentis.SigCtl");
  sigCtl.SetProperty("Licence", "<<license>>")
  dynCapt = new ActiveXObject("Florentis.DynamicCapture");
  rc = dynCapt.Capture(sigCtl,"Who","Why");
  if( rc == 0 ) {
    sigCtl.Signature.ExtraData("AdditionalData") = "CaptureImage.js Additional Data";
    flags = 0x2000 | 0x80000 | 0x400000; //SigObj.outputBase64 | SigObj.color32BPP | SigObj.encodeData
    var myB64 = sigCtl.Signature.RenderBitmap("", 300, 150, "image/png", 0.5, 0xff0000, 0xffffff, 0.0, 0.0, flags );
	print(myB64);
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
