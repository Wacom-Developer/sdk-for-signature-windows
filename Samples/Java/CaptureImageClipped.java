/*
  CaptureImageClipped
  Captures a signature and creates both clipped and unclipped image files
  ie pen data outside of the signature capture window is removed (eg using a Cintiq) 
 
  Copyright (c) 2015 Wacom GmbH. All rights reserved.
*/

import com.florentis.signature.SigCtl;
import com.florentis.signature.SigObj;
import com.florentis.signature.DynamicCapture;
class CaptureImageClipped {

  private static void print(String s) {
 	System.out.println(s);
  }

	public static void main(String args[]) {
    String filename = "sig-clipped.png";
    if( args.length > 0 )
      filename = args[0];
    try
      {
        SigCtl sigCtl = new SigCtl();
        sigCtl.licence("<<license>>");
        DynamicCapture dc = new DynamicCapture();
        int rc = dc.capture(sigCtl, "who", "why", null, null);
        if(rc == 0) {
          SigObj sig = sigCtl.signature();
          sig.extraData("AdditionalData", "CaptureImage.java Additional Data");
          int flags = SigObj.renderClipped | SigObj.outputFilename | SigObj.color32BPP | SigObj.encodeData;
          sig.renderBitmap(filename, 300, 150, "image/png", 0.5f, 0xff0000, 0xffffff, 0.0f, 0.0f, flags );
          print("Created Clipped Signature image file: " + filename);
          filename="sig.png";
          flags = SigObj.outputFilename | SigObj.color32BPP | SigObj.encodeData;
          sig.renderBitmap(filename, 300, 150, "image/png", 0.5f, 0xff0000, 0xffffff, 0.0f, 0.0f, flags );
          print("Created standard Signature image file: " + filename);
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
