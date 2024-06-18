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
        sigCtl.licence("eyJhbGciOiJSUzUxMiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiI3YmM5Y2IxYWIxMGE0NmUxODI2N2E5MTJkYTA2ZTI3NiIsImV4cCI6MjE0NzQ4MzY0NywiaWF0IjoxNTYwOTUwMjcyLCJyaWdodHMiOlsiU0lHX1NES19DT1JFIiwiU0lHQ0FQVFhfQUNDRVNTIl0sImRldmljZXMiOlsiV0FDT01fQU5ZIl0sInR5cGUiOiJwcm9kIiwibGljX25hbWUiOiJTaWduYXR1cmUgU0RLIiwid2Fjb21faWQiOiI3YmM5Y2IxYWIxMGE0NmUxODI2N2E5MTJkYTA2ZTI3NiIsImxpY191aWQiOiJiODUyM2ViYi0xOGI3LTQ3OGEtYTlkZS04NDlmZTIyNmIwMDIiLCJhcHBzX3dpbmRvd3MiOltdLCJhcHBzX2lvcyI6W10sImFwcHNfYW5kcm9pZCI6W10sIm1hY2hpbmVfaWRzIjpbXX0.ONy3iYQ7lC6rQhou7rz4iJT_OJ20087gWz7GtCgYX3uNtKjmnEaNuP3QkjgxOK_vgOrTdwzD-nm-ysiTDs2GcPlOdUPErSp_bcX8kFBZVmGLyJtmeInAW6HuSp2-57ngoGFivTH_l1kkQ1KMvzDKHJbRglsPpd4nVHhx9WkvqczXyogldygvl0LRidyPOsS5H2GYmaPiyIp9In6meqeNQ1n9zkxSHo7B11mp_WXJXl0k1pek7py8XYCedCNW5qnLi4UCNlfTd6Mk9qz31arsiWsesPeR9PN121LBJtiPi023yQU8mgb9piw_a-ccciviJuNsEuRDN3sGnqONG3dMSA");
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
