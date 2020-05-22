/*
  DecodeImage
  Reads image file sig.png to report capture details
  (an alternative image filename can be supplied as an argument)
  
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
  print("Reading image file: " + filename);
  sigCtl = new ActiveXObject("Florentis.SigCtl");
  sig = sigCtl.Signature;
  rc = sig.ReadEncodedBitmap(filename);
  if( rc == 0 ) {
    print("Who: \t"+ sig.Who);
    print("Why: \t" + sig.Why);
    print("When: \t" + sig.When);
    print("Additional data: \t" + sig.ExtraData("AdditionalData"));
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