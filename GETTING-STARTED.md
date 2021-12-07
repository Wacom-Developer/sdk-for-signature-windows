# Getting Started 

## Test environment

A variety of samples are supplied for Windows 7 and above.

To test the samples use a Wacom device such as an STU-500 or a pen/tablet device such as a DTU-1141.

To use a pen/tablet device you will need to install the Wacom driver which provides the wintab interface used by the Signature Library.
See the FAQs for [tablet installation](http://developer-docs.wacom.com/faqs/docs/q-tablet/tablet-installation)


## Download the Wacom Ink SDK for signatures

Download the SDK from https://developer.wacom.com/developer-dashboard

* login using your Wacom ID
* Select **Downloads for signature**
* Download **Wacom Ink SDK for signature for Windows Desktop**
* Accept the End User License Agreement to use the SDK

The downloaded Zip file contains the SDK with documentation.
The folder 'SignatureSDK' is included in the Zip file and contains the Signature Library MSI installer.

## Install the Wacom Ink SDK for signatures

Regardless of your Windows system being 32 or 64 bit, to get started we recommend installing the 32-bit Signature Library:
**Wacom-Signature-SDK-x86-vXX.msi**

This will help later when opening html samples in Internet Explore because by default the 32-bit version is launched.
The conflict from mixing 32/64 bit applications and components is a common support issue.

Run the installer with default options to install the library in:
C:\Program Files (x86)\Common Files\WacomGSS

The Signature Library consists of:
* COM DLLs
* licensing DLLs
* support DLLs
* language translations

----
## Signature Library License

A license must be included in your application code to use the Signature Library.
The licensing scheme has recently been relaxed and the Lite license can be used free of charge for all functions excluding:
- signature encryption
- ISO signature formatting

### Wacom Ink SDK for signature Lite License

The Wacom Ink SDK for signature Lite license is in JSON Web Token (JWT) format and can be copied here:

```
eyJhbGciOiJSUzUxMiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiI3YmM5Y2IxYWIxMGE0NmUxODI2N2E5MTJkYTA2ZTI3NiIsImV4cCI6MjE0NzQ4MzY0NywiaWF0IjoxNTYwOTUwMjcyLCJyaWdodHMiOlsiU0lHX1NES19DT1JFIiwiU0lHQ0FQVFhfQUNDRVNTIl0sImRldmljZXMiOlsiV0FDT01fQU5ZIl0sInR5cGUiOiJwcm9kIiwibGljX25hbWUiOiJTaWduYXR1cmUgU0RLIiwid2Fjb21faWQiOiI3YmM5Y2IxYWIxMGE0NmUxODI2N2E5MTJkYTA2ZTI3NiIsImxpY191aWQiOiJiODUyM2ViYi0xOGI3LTQ3OGEtYTlkZS04NDlmZTIyNmIwMDIiLCJhcHBzX3dpbmRvd3MiOltdLCJhcHBzX2lvcyI6W10sImFwcHNfYW5kcm9pZCI6W10sIm1hY2hpbmVfaWRzIjpbXX0.ONy3iYQ7lC6rQhou7rz4iJT_OJ20087gWz7GtCgYX3uNtKjmnEaNuP3QkjgxOK_vgOrTdwzD-nm-ysiTDs2GcPlOdUPErSp_bcX8kFBZVmGLyJtmeInAW6HuSp2-57ngoGFivTH_l1kkQ1KMvzDKHJbRglsPpd4nVHhx9WkvqczXyogldygvl0LRidyPOsS5H2GYmaPiyIp9In6meqeNQ1n9zkxSHo7B11mp_WXJXl0k1pek7py8XYCedCNW5qnLi4UCNlfTd6Mk9qz31arsiWsesPeR9PN121LBJtiPi023yQU8mgb9piw_a-ccciviJuNsEuRDN3sGnqONG3dMSA
```
In the samples, replace the search string `<<license>>` with the license shown.

To use the excluded functions please contact technical support for suitable sample code and a license:
[developer relations portal.](https://developer.wacom.com/developer-dashboard/support)

## Sample Code

Samples are supplied with a placeholder for the license string.
Before you can use the samples you will need to replace all occurrences of the string `<<license>>` with the Signature Library license shown above.


## JavaScript Samples

To demonstrate the Signature Library you can use standard tools native to Windows, specifically the scripting host CSCRIPT.EXE.
On a 64-bit Windows system there are separate versions for 32 and 64 bit applications.
Which version you run determines which type of ActiveX control is expected.
To get started, install the 32 bit version of the Signature Library and use the 32-bit version of script:
On 64-bit Windows:
  `C:\Windows\SysWOW64\cscript.exe`
On 32-bit Windows:
  `C:\Windows\cscript.exe`

In the samples the batch file RUN-JS.bat automatically starts the 32-bit version of cscript.exe for example:
```
Run-JS.bat CaptureImage.js
```

The javascript code can be readily adapted to VB and C# with only minor syntactic changes.



### Capture Signature

The most fundamental use of the Signature Library is to capture a signature.
The API for this is:

```ruby
  sigCtl = new ActiveXObject("Florentis.SigCtl");
  sigCtl.Licence = "<<license>>";
  dynCapt = new ActiveXObject("Florentis.DynamicCapture");
  rc = dynCapt.Capture(sigCtl,"Who","Why");
```

See the COM API documentation in the SDK for further details of the call.
Run the sample **CaptureImage.js**  to capture a signature:
```
Run-JS.bat CaptureImage.js
```

The signature capture window is displayed.
Its layout and position is not configurable for the reason that a consistent signing experience is enforced.
However there are some minor changes that can be made through registry settings and properties, such as ink colour.
These options are documented in the Signature Library COM API.

For example, to specify red ink:
```
  dynCapt.SetProperty("CaptureInkColor","1.0,0,0");
```

![signature capture](media/SigCaptureAPI.png)



### Create Signature Image

Having captured a signature your application will have a signature object containing contextual information (who/why etc) as well as pen data (x/y/p data).
To create an image use the RenderBitmap API:
```
  flags = 0x1000 | 0x80000 | 0x400000;    //SigObj.outputFilename | SigObj.color32BPP | SigObj.encodeData
  rc = sigCtl.Signature.RenderBitmap(filename, 300, 150, "image/png", 0.5, 0xff0000, 0xffffff, 0.0, 0.0, flags );
```
See the COM API documentation in the SDK for further details of the call.
In the example a PNG image is created with encoded data determined by bit settings in the flags supplied to the call.
The effect of the 'encoded data' setting is to include within the image the binary signature object.
The binary data is encoded in the image pixels using 'steganography' in such a way that it is not immediately visible but can be retrieved.

### Save and load a Signature  
  
A signature image created with encoded data contains all of the signature data.
Provided the image is not changed in any way the data can be loaded into a new signature object.
This is demonstrated in the sample **DecodeImage.js**:
```ruby
  sigCtl = new ActiveXObject("Florentis.SigCtl");
  sig = sigCtl.Signature;
  rc = sig.ReadEncodedBitmap(filename);
```
Run the sample to load sig.png:
```
Run-JS.bat DecodeImage.js
```

A convenient way to communicate and save a signature object is through the SigText property.
The read/write property can be used to save and load a signature.
SigText is a base64 ascii text encoding of the signature object and can be saved in a database or submitted to a url without concerns of data conversion.

This sample creates the file sig.txt:

```
Run-JS.bat CaptureSigText.js
```

This sample reads the txt file and generates a signature image sig.txt.png:
```
Run-JS.bat DecodeSigText.js
```

### Wizard Control

The Wizard control is included as an extension of the Signature control specifically for STU tablets.
The Wizard control guides the user through a set of instruction pages displayed on the signature tablet LCD display, each page requiring a selection by tapping the pen on the tablet surface, for example selecting the 'Next' button.

The instruction pages are scripted to display a combination of:

* Text for general instructions and guidance
* Images 
* Input controls:
    * Radio buttons
    * Check boxes
    * PIN code entry
    * control buttons
* simple line drawing
* signature capture

On a PC display all of this can be achieved using normal Windows controls, e.g. a Windows form.
However, an STU display is not directly accessible to Windows and the Wizard control overcomes this limitation.


#### WizardScript.js

The script demonstrates the principles of using the Wizard control, displaying instruction pages with signature capture:

```
Run-JS.bat WizardScipt.js
```

#### WIzardUpload.js

The script demonstrates uploading an image to the STU display:

```
Run-JS.bat WizardUpload.js stu\640x480.png
```

----
## HTML Samples

The HTML/JavaScript samples can only be used in Internet Explorer because ActiveX support is needed and this is specifically blocked in other browsers for security reasons.
However, the HTML samples can be used to explore the API without using a development system such as Visual Studio, since a simple text editor can be used to make changes to the code.
Please be aware that to use the Signature Library in a different browser such as Firefox or Chrome, additional services are required: see the cross-browser support library SigCaptX.

Open the html samples in Internet Explorer - the only browser which will support ActiveX.

In IE you must 'Allow blocked content' as prompted to allow the ActiveX control to run.
You can remove the prompt through IE Tools...Internet options...Advanced...Security: Allow active content

If you installed the 64-bit version of the Signature Library you will need to run the 64-bit version of Internet Explorer.

### TestSDKCapture.html

Click Start to start signature capture.
Click About to display component version information.
After capturing a signature click Info to display its contextual information (who/why/when).

### TestSDKCapture-SigText.html

After capturing a signature the SigText property is displayed.
To demonstrate restoring a signature from a saved SigText:
* copy the SigText string to the clipboard
* reload the page
* paste the SigText string into the SIgText panel
* click SetSigText


### TestSDKCapture-B64Image-Display.html

In this version RenderBitmap is called to generate a png image.
The image is set in an html img tag


### TestSDKCapture-Hash.html

In this version the signature hash is created using text fields (First/Last name).
Verify compares the current field contents with the data hashed in signature.
If the field contents are changed Verify fails.


### TestSDKCapture-Clipped.html

When used with a tablet device (e.g. Intuos/DTU) the pen trace can be outside of the signature capture window.
The sample demonstrates the effect of clipping data outside the capture window.


### TestSDKWizardControl.html

Demonstrates using the Wizard control for signature capture.

### WizardScript.html

Demonstrates using the Wizard control for signature capture.

### Wizard-PIN-Demo.html

Demonstrates using the Wizard control for PIN code entry.

### WizardScript-Image.html

Demonstrates using images in place of button controls.


### WizardScript-Radio.html

Demonstrates using Radio button controls.


### WizardScript-TANDC-530.html

The 'Terms and Conditions' page demonstrates using colour images with an STU-530.



----
## Java Samples

To run the samples you must first install a Java Development Kit (JDK).
In addition, ensure that the Java components are selected when installing the Signature Library:

![installer options](media/InstallerOptions.png)

The Java components are installed with the core components in
C:\Program Files (x86)\Common Files\WacomGSS

* flsx.jar
* flsx.dll


Batch files are provided to run the samples from a DOS Command prompt as follows:

### 32-bit Java with Signature Library x86
Start a DOS Command prompt and set the path to Java, e.g.
```
path="\Program Files (x86)\Java\jre1.8.0_181\bin"
```
Run the samples by using the supplied batch file, e.g.
```
>Run-Java.bat CaptureImage.java
Compiling CaptureImage ...

Run CaptureImage.java ...
Created Signature image file: sig.png

>
```

### 64-bit Java with Signature Library x64
Start a DOS Command prompt and set the path to Java, e.g.
```
PATH="\Program Files\Java\jdk1.8.0_31\bin"
```
Run the samples by using the supplied batch file, e.g.
```
>Run-Java.x64.bat CaptureImage.java
Compiling CaptureImage ...

Run CaptureImage.java ...
Created Signature image file: sig.png

>
```

| Sample                        | Description                                                                             |
| ----------------------------- | ----------------------------------------------------------------------------------------|
| CaptureImage.java             | Calls signature capture, renders the signature to sig.png  |
| DecodeImage.java              | Reads sig.png, displays contextual information   |
| CaptureImageClipped.java      | When used with a tablet device (e.g. Intuos/DTU) the pen trace can be outside the signature capture window. The sample demonstrates the effect of clipping data outside the capture window. |
| CaptureImageRelative.java     | Demonstrates positioning of the signature  |
| WizardScript.java             | Demonstrates use of the Wizard control  |
| WizardScript_byteArray.java   | Creates a byte array of the signature image |
| WizardUpload.java             | Uploads the specified image file to an STU display  |
| TestSigCapt                   | Eclipse style project for capture |
| TestWizSigCapt                | Eclipse style project for wizard capture    |
| TestWizSigCaptSimulate        | Eclipse style project demonstrates sending button events  |



----
## C# Samples

Visual Studio projects are included in the VS2010 folder.
The projects include references to the interop files installed with the Signature Library.
When you run the installer be sure to include the .NET components:

![installer options](media/InstallerOptions.png)

The interop files are installed with the library in Program Files\Common Files\WacomGSS

Open the .sln solution file to open the project, then build and run.

| Sample                        | Description                                                                             |
| ----------------------------- | ----------------------------------------------------------------------------------------|
| TestSigCapt                   | Calls signature capture and displays the signature |
| TestWizSigCapt                | Uses the Wizard control to capture a signature |
| TestAXSigCapt                 | Demonstrates using the ActiveX control in a Windows form |

----

## Visual Basic Samples
Visual Studio projects are included in the VS2010VB folder.
The projects include references to the interop files installed with the Signature Library.
When you run the installer be sure to include the .NET components as described for C# samples.

Open the .sln solution file to open the project, then build and run.

| Sample                        | Description                                                                             |
| ----------------------------- | ----------------------------------------------------------------------------------------|
| TestSigCapt                   | Calls signature capture and displays the signature |
| TestWizSigCapt                | Uses the Wizard control to capture a signature |


----
## C++ Samples

Visual Studio projects are included in the CPP folder.

Open the .sln solution file to open the project, then build and run.

| Sample                        | Description                                                                             |
| ----------------------------- | ----------------------------------------------------------------------------------------|
| TestSigCaptCPP                | Calls signature capture and displays the signature |
| TestWizSigCaptCPP             | Uses the Wizard control to capture a signature |

----
## Delphi Samples

Embarcadero Delphi projects are included in the Delphi folder.

Open the project files to build and run the samples.

| Sample                        | Description                                                                             |
| ----------------------------- | ----------------------------------------------------------------------------------------|
| TestSigCapt                   | Calls signature capture and displays the signature |
| TestSigCaptHash               | Calls signature capture and demonstrates the hash function |
| TestWizSigCapt                | Uses the Wizard control to capture a signature |

----
----




