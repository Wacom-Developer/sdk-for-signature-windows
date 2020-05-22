/*
  DecodeSigText
  Reads SigText file sig.txt to report capture details
  (an alternative  sig.txt filename can be supplied as an argument)
    
*/
function print( txt ) {
  WScript.Echo(txt);
}
main();
function main() {
  filename = "sig.txt";
  args = WScript.Arguments;
  if(args.Count() > 0 )
    filename=args(0);
  sigCtl = new ActiveXObject("Florentis.SigCtl");
  var fso = new ActiveXObject("Scripting.FileSystemObject");
  var ForReading = 1;
  var f = fso.OpenTextFile(filename, ForReading, false);
  sigCtl.Signature.SigText = f.ReadAll();
  f.Close();

  if( sigCtl.Signature.IsCaptured ) {
    // display signature data available to the api
    var sig = sigCtl.Signature;
    print("Who: \t"+ sig.Who);
    print("Why: \t" + sig.Why);
    print("When: \t" + sig.When);
    print("Additional data: \t" + sig.ExtraData("AdditionalData"));
    
    // create a signature image
    filename += ".png";
    flags = 0x1000 | 0x80000 | 0x400000; //SigObj.outputFilename | SigObj.color32BPP | SigObj.encodeData
    rc = sigCtl.Signature.RenderBitmap(filename, 300, 150, "image/png", 0.5, 0xff0000, 0xffffff, 0.0, 0.0, flags );
    print("Created Signature image file: " + filename);

  }
  else {
    print("Failed to read signature text file: " + filename); 
  }
}