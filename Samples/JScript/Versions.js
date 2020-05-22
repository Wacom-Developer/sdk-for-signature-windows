/*
  Versions
  Report component versions.
  
*/
function print( txt ) {
  WScript.Echo(txt);
}
main();
function main() {
  try {
    print("Component versions:");
    sigCtl = new ActiveXObject("Florentis.SigCtl");
    print("DLL: flSigCtl.dll          v" + sigCtl.GetProperty("Component_FileVersion"));
    sigCapt = new ActiveXObject("Florentis.DynamicCapture");
    print("DLL: flSigCapt.dll         v" + sigCapt.GetProperty("Component_FileVersion"));
    wizCtl = new ActiveXObject("Florentis.WizCtl");
    print("DLL: flWizCtl.dll          v" + wizCtl.GetProperty("Component_FileVersion"));
  }
  catch (ex) {
    print("Exception: " + ex.message);
  }
}
