/*
  CaptureImage_Binary.js
  Captures a signature as a byte array, then reads encoded data from the array
  and prints on monitor.
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
    var sigObj = sigCtl.Signature;
    sigCtl.Signature.ExtraData("AdditionalData") = "CaptureImage.js Additional Data";
    flags = 0x000800 | 0x080000 | 0x400000; // SigObj.outputBinary | SigObj.color32BPP | SigObj.encodeData
    var binarySigData = sigCtl.Signature.RenderBitmap("", 300, 150, "image/png", 0.5, 0xff0000, 0xffffff, 0.0, 0.0, flags );
	
	sig = sigCtl.Signature;
	rc = sig.ReadEncodedBitmap(binarySigData);
	if( rc == 0 ) 
	{
		print("Who: \t"+ sig.Who);
		print("Why: \t" + sig.Why);
		print("When: \t" + sig.When);
		print("Additional data: \t" + sig.ExtraData("AdditionalData"));
	}
	else 
	{
       print("Error reading file: " + rc);
       switch(rc) 
	   {
          case 1: print("File not found");
                  break;
          case 2: print("File is not a supported image type");
                  break;
          case 3: print("Encoded signature data not found in image");
                  break;
       }
	}
	//print(binarySigData);
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
