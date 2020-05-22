/*
  WizardUpload
  Upload file to STU tablet
  Usage:
    WizardUpload ImageFilename // upload image file and leave displayed
    WizardUpload               // clear display (ie no file supplied)
	
  Copyright (c) 2015 Wacom GmbH. All rights reserved.
  
*/

import com.florentis.signature.WizCtl;

class WizardUpload {

  private static void print(String s) {
 	System.out.println(s);
  }

	public static void main(String args[]) {
    try
      {
        String filename = "";
        if( args.length > 0 ) {
          filename = args[0];
          print("Upload image file: " + filename);
        }
        WizCtl wizCtl = new WizCtl();
        wizCtl.licence("<<license>>");
        boolean rc = wizCtl.padConnect();
        if( rc != true ) {
          print("Unable to make connection to the Pad. Check it is plugged in and try again.");
          System.exit(0);
        }

        if( filename.length() != 0 ) {
          wizCtl.addObject(7, "", "center", "middle", filename, null);
          wizCtl.addObject(8, "", 0, 0, null, null);
        }
        else {
          wizCtl.reset();
        }
        wizCtl.display();
        wizCtl.padDisconnect();
      }
      catch (Exception ex)
      {
        print("Exception: " + ex);    
      }
	}
}
