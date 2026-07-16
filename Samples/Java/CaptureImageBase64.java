/*
  CaptureImage
  Captures a signature and creates encoded image file sig.png
  (an alternative signature image filename can be supplied as an argument)
  
  Copyright (c) 2015 Wacom GmbH. All rights reserved.
	
*/

import com.florentis.signature.SigCtl;
import com.florentis.signature.SigObj;
import com.florentis.signature.DynamicCapture;
class CaptureImageBase64 {

  private static void print(String s) {
 	System.out.println(s);
  }

	public static void main(String args[]) {
    String filename = "sig.png";
    if( args.length > 0 )
      filename = args[0];
    try
      {
        SigCtl sigCtl = new SigCtl();
        sigCtl.licence("<<<INSERT_LICENSE_HERE>>>");
        DynamicCapture dc = new DynamicCapture();
        int rc = dc.capture(sigCtl, "who", "why", null, null);
        if(rc == 0) {
          SigObj sig = sigCtl.signature();
          sig.extraData("AdditionalData", "CaptureImage.java Additional Data");
          int flags = SigObj.outputBase64 | SigObj.color1BPP;
          var b64 = sig.renderBitmap(null, 300, 150, "image/png", 0.5f, 0xff0000, 0xffffff, 0.0f, 0.0f, flags );
          print("Created B64 string: " + b64);
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
      catch (Exception ex)
      {
        print("Exception: " + ex);    
      }
	}
}
