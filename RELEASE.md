# Wacom Ink SDK for Signature - Windows

## Version 4.5.5

## History

* Release 4.5.5  15-Nov-2019
    * Fix for WizCtl not reporting pad disconnection
    * Fix for Java exception caused by non-matching signer information
    * Ref. SIGSDK-419 + 420

* Release 4.5.4  07-Nov-2019
    * Fix for wizard apparently freezing between screens on STU 530
    * Fix for "hang" on WizCtl close down
    * Ref. SIGSDK-417 + 418

* Release 4.5.2  30-Sep-2019
    * Fix for Hash string display format issue
    * Move JAR to same installer component as DLL to avoid mismatch

* Release v4.5.1 27-Jun-2019
    * Fix for Java RenderBitMap background colour issue
	
* Release v4.5.0 27-Jun-2019
    * Language strings provided for Greek
    * Fix for AddObject parameter problem with the AxWiZCtl
    * Handle licence expiry dates after 19/01/2038
	
* Release v4.4.0.192 20-May-2019
    * Bug fix for integrity test with eval license and invalid signed data

* Release v4.4.0.191 14-May-2019
    * Bug fix for integrity test with eval license and invalid signed data

* Release v4.4.0 03-May-2019
    * Fixed Java support for ISO and Encryption
    * Fixed integrity test with eval license and invalid signed data
    * Fixed image uploader utility
    * ref: SIGSDK-350 359 360 361 364 

* Release v4.3.1 29-Mar-2019
    * Revised detection of the monitor used for wintab signature capture

* Release v4.2.1 21-Feb-2019
    * Support for encrypted import/export of ISO data
    * Added encryption test

* Release v4.2.0   19-Feb-2019
    * Minimum Java version changed from 1.3 to 1.5
    * Check introduced for mismatched flsx.jar/flsx.dll pairing
    * Updated included version of OpenSSL to 1.1
    * Projects migrated to Visual Studio 2017
	
* Release v4.0.1   22-Oct-2018
    * Rebuild .net interop files

* Release v4.0.1   22-Oct-2018
    * Rebuild .net interop files

* Release v4.0.0   18-Oct-2018
    * Added ISO and Encryption functionality - license dependent
    * Updated icon used in the signature capture window

* Release v3.21.1  27-Sep-2018
    * low pressure strokes rendered darker to avoid apparent loss 

* Release v3.21.0  10-Sep-2018
    * enforces use of a Signature SDK license
    * fixed licensing for Wizard + serial STU-430V
    * fixed CaptureInkColor property in Wizard for STU-540

* Release v3.20.4  26-Mar-2018
    * LMS licensing added

* Release v3.20.3  16-Feb-2018
    * fixed error in 64-bit build for calculating SHA-384 and SHA-512 hashes

* Release v3.20.2  13-Feb-2018
    * fixed BtnsInside simulated button processing

* Release v3.20.1  08-Feb-2018
    * improved RTS pen data
    * revised licensing component - an expired license reverts to evaluation mode

* Release v3.20.0  02-Feb-2018
    * add support for Realtime Stylus (RTS) via Microsoft Ink

* Release v3.19.2  17-Jan-2018
    * fix for STU-541 in Wizard Control

* Release v3.19.0  11-Jan-2018
    * revised directories for installation.
    * Now uses CommonFiles\WacomGSS - can affect existing installations e.g. Java paths
    * improvements to wizard control stability
    * added support for JWT licenses

* Release v3.18.0  03-Oct-2017
    * fix Checkbox FireClick in Wizard control
    * add support for Wizard AddObject base64-endoded image           

* Release v3.17.0  29-Sept-2017
    * delay-loads OpenSSL DLLs
    * fixes issues in wizard associated with double-tap on a button which terminates the wizard
    * includes mitigation for signature mode tapping OK when no ink has been captured

* Release v3.16.0  29-June-2017
    * fixed licence check

* Release v3.15.2  10-May-2017
    * added support for STU-541 - upload utility and support
      Note: the STU-541 is not compatible with the current version of sign pro PDF (v3.2.6)
      This is because the STU-541 is a new type of TLS device and not detected when searching for the normal STU HID devices
    
* Release v3.14.1  20-Jan-2017
    * fix to allow the wizard control interop to be added to a Visual Studio toolbox
    
* Release v3.13.2  13-Dec-2016
    * STU-540 improvements
    * Licence required to remove 'Evaluation' 

* Release v3.12.0  16-Nov-2016
    * STU-540 support added

* Release v3.11.0  05-Nov-2016
    * WILL rendering fix

* Release v3.10.1  1-Aug-2016
    * Support for Asynchronous Capture

* Release v3.9.0  17-June-2016
    * Support for SigCaptX

* Release v3.8.0  
    * Internal test release
  
* Release v3.7.0  30-March-2016
    * Minor bug fixes
    
* Release v3.6.0  18-January-2016
    * Fix capture window sizing for monitors (incl DTU) in portrait mode
    * Changed tablet mapping behaviour for opaque wintab tablets. These are now mapped into the signature capture window.

* Release v3.5.0  12-January-2016
    * Fixed timing data in signatures captured via WizCtl on STU-430 and STU-530

* Release v3.4.0  05-January-2016
    * Fixed LoadImageFromURL to support direct or proxy connection to the internet (determined by config in registry)
    * Add support to WizCtl to specify Ink colour / width
    * Add general Wizard colour support: 
      Can set foreground and background colours for all primitives (text/rect/ellipse/line) and objects (button etc.)
    * Added changes needed to handle unusual signature data more robustly when timestamps wrap
    * Added serial interface support to Signature SDK (DynamicCapture) and WizCtl (Support for STU-430V/G and STU-530V/G)
    * Bugfix: Added back image offsetting that was disabled when WILL rendering was introduced
    * Fixed some font size and button outline rendering issues in Signature Capture

* Release v3.3.0  17-December-2015
    Internal release for SignatureScope

* Release v3.2.0  30-September-2015
    Following issues resolved:
     * Florentis assertion failure on Windows 10
     * Pen dot inconsistency on STU 530
     * eSeal renderBitMap error

* Release v3.0.4  05-March-2015
    Major enhancement:
    Revised signature capture using WILL (Wacom Ink Layer Language)
    Options added to configure signature capture include:
      CaptureInkWidth, CaptureInkColour, CaptureBackground 
    For full details see Signature-Components-API.pdf and <a href="file/Signature-SDK/doc/Signature-SDK-Release-V3.pdf">Signature-SDK-Release-V3.pdf</a>

* Release v1.27.0  15-December-2014
    Component updates:
    * resolves potential for inconsistent detection of STU-500 tablet dimensions (ref: SPPS-37)

* Release v1.26.0  14-November-2014
    Component updates:
    * installer option to select STU Shared mode (for use with WIndows7 + Office 2013)
      e.g. msiexec STUSHARED=1 /i Wacom-Signature-SDK-x86-1.26.0.msi

* Release v1.25.1  10-November-2014
    Component updates:
    * Added Wizard control radio button functionality: AddObject(ObjectRadioButton,...)

* Release v1.24.0  19-September-2014
    Component updates:
    * Wizard control updated for faster operation with colour STU-520 and STU-530 - see setProperty(ForceMonochrome,true)

* Release v1.23.3  23-July-2014
    Component updates:
    * Licence requirement removed for Wacom tablets.

* Release v1.22.4  26-June-2014
    Component updates:
    * fix to java interface for Wizard control timing in XP
    * CAB file created

* Release v1.22.1  19-June-2014
    Component updates:
    * fix to java interface for Licence CheckResult

* Release v1.21.5  10-June-2014
    Component updates:
    * installer option to add component folders to the PATH environment variable
      e.g. msiexec ADDPATH=Win32 /i Wacom-Signature-SDK-x86-1.21.5.msi
    
    * change to WizCtl to optionally display the hourglass icon on the STU-430/530.
      Registry setting is:
        [HKEY_LOCAL_MACHINE\SOFTWARE\Florentis\sd]
        "WizardShowWait"=dword:00000000
      If setting is missing or non-zero, hourglass icon will be displayed on STU-530s and -430s
      Running installers from the command line with "WIZARDSHOWWAIT=0" will create the setting, otherwise the hourglass remains enabled by default
      e.g. msiexec WIZARDSHOWWAIT=0 /i Wacom-Signature-SDK-x86-1.21.5.msi


* Release v1.20.3  09-May-2014
    Component updates:
    * change java WizCtl.reset() (icon was displayed on the STU-530)

* Release v1.20.2  08-May-2014
    Component updates:
    * Improved Wizard support in Java - addition of Close() method and revised internal thread control.
    * restore Java 1.5+ compatibility
    * restore XP compatibility

* Release v1.19.1  14-April-2014
    Component updates:
    -	Improved renderBitmap with increased pen width

* Release v1.18.0  12-March-2014
    Component updates:
    -	DPI awareness added for Macbook support

* Release v1.17.0  06-March-2014
    Component updates:
    -	fix to ensure the signature capture window is displayed on the DTU-1031 when using Windows XP

* Release v1.16.0  10-Feb-2014
    Component updates:
    -	Wizard control updated to use the zone update api added to STU-430/530 models:
      -STU display updates are restricted to the area being changed, such as a check box.
      -When the complete display is updated, an hourglass icon is first displayed to indicate that the update is in process.

* Release v1.15.2  21-01-2014
    Component updates:
    -	Improvements to capture window positioning for multiple monitors
    -	Cintiq Companion, STU-430 and STU-530 added to device detection (for licensing)
    -	fixed problem in pad disconnect in wizard 
    -	added patch for Win 8.1 power save issue

* Release v1.14.0  (internal use only)
  
* Release v1.13.0  07-11-2013
    Component updates:
    * Added optional registry value stuShared to override exclusive open

* Release v1.12.2  01-11-2013
    Component updates:
    * Added compression to signature capture image upload (most noticable on serial connections)
    * Improved serial connection speed when encryption not enabled.
    * Fixes to Wizard control when run on non-standard DPI screens.

* Release v1.11.2  23-10-2013
    Added support for STU-430, STU-530

* Release v1.10.0  27-06-2013
    Installer End-User Licence Agreement text updated to remove the need for an NDA

* Release v1.9.0   03-06-2013
    Component updates:
    * SigCapt v2.59, SigCOM v2.60
        Fixed problem rendering signatures captured on a digitizer which (incorrectly) reports pressure as zero when the pen is down
        Added registry setting for MIME type for generic SigCtl (SDK installer: type = application/x-florentis-sigctl) 
    * Licensing
        Added checks on plausibility of trial licence end date

* Release v1.8.3   01-03-2013
    Component updates:
    * SigCapt
        Improved diagnostics for cintiq mapping.
        Added auto selection of Map Digitizer according to the HWC_INTEGRATED bit set.
        Merged changes from Vinae STUTabletCore v1.1.35
        (STU) pad connection changed to open exclusively.
    * SigCOM
        Fixed problem in SigObj.RenderBitmap with monochrome (1BPP) images
    * Wizard control:
        fix Wizard initialisation error with pen on STU surface
        added support for Banking SDK
    * Java interface (flsx.dll)
        enable AddObject bytearray
        add FireClick() support
        improve COM Unicode error reporting
    * Licensing:
        fix issue with time-limited (trial) licenses
        
      
* Release v1.6.2   25-07-2012
    Installer updated to allow installation of the Components only.
    The Components remain unchanged.

* Release v1.6.1   22-06-2012
    Component updates:
    * add Wizard Java object types
    * revised wintab capture (missing pen strokes reported)

* Release v1.6   19-06-2012
    Component updates:
    * add options to clip signature capture and render for a capture window smaller than the device (eg Cintiq)
    * add relative option to renderBitmap - positions the signature in the image as it was signed on the device
    * revised STU encryption support
    * 64-bit wintab enabled
  
* Release v1.5   30-05-2012
    Component updates:
    * corrected size of capture window when the digitizer is larger than the PC screen
    * added new property "RenderClipped"
	
* Release v1.4   23-04-2012
    Component updates:
    * revised handling of pen outside capture window
  
* Release v1.3   05-03-2012
    Component updates:
    * revised signature rendering for HID interface
    * revised retry for STU Display conflict 

* Release v1.2   20-02-2012
    * version numbers corrected in Florentis.InteropAxFlSigCOM.dll, Florentis.InteropAxFlWizCOM.dll

* Release v1.1.0 15-02-2012
    Component updates:
    * revised signature capture and licence for HID interface
    * revised Demo licence support
    * revised language detection: GetProperty("UILanguage") returns language in use
    * version resources added to MUI language files 

* Release v1.0.0 13-01-2012
    First release of Florentis-Wacom product rebranding

