/*
  DecodeImage
  Reads image file jsig.png to report capture details
  (an alternative signature image filename can be supplied as an argument)
 
  Copyright (c) 2015 Wacom GmbH. All rights reserved.
   
*/

import com.florentis.signature.SigCtl;
import com.florentis.signature.SigObj;
import com.florentis.signature.DynamicCapture;
class DecodeImage {

  private static void print(String s) {
 	System.out.println(s);
  }

	public static void main(String args[]) {
    try
      {
        String filename = "sig.png";
        if( args.length > 0 )
          filename = args[0];
        print("Reading image file: " + filename);
        SigCtl sigCtl = new SigCtl();
        sigCtl.licence("<<license>>");
        SigObj sig = sigCtl.signature();
        int rc = sig.readEncodedBitmap(filename);
        if(rc == 0) {
          print("Who: \t"+ sig.who());
          print("Why: \t" + sig.why());
          print("When: \t" + sig.when(0));
          print("Additional data: \t" + sig.extraData("AdditionalData"));
        }
        else {
          print("Error reading file: " + rc);
          switch(rc) {
            case 1: print("File not found");
                    break;
            case 2: print("File is not a supported image type");
                    break;
            case 3: print("Encoded signature data not found in image");
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
