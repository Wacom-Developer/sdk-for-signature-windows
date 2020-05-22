unit FLSIGCTLLib_TLB;

// ************************************************************************ //
// WARNING                                                                    
// -------                                                                    
// The types declared in this file were generated from data read from a       
// Type Library. If this type library is explicitly or indirectly (via        
// another type library referring to this type library) re-imported, or the   
// 'Refresh' command of the Type Library Editor activated while editing the   
// Type Library, the contents of this file will be regenerated and all        
// manual modifications will be lost.                                         
// ************************************************************************ //

// $Rev: 45604 $
// File generated on 23/08/2012 12:07:53 from Type Library described below.

// ************************************************************************  //
// Type Lib: C:\Program Files (x86)\Common Files\Florentis\FlSigCOM.dll (1)
// LIBID: {B0452E4E-DB2A-472D-91EA-9F77C9885A39}
// LCID: 0
// Helpfile: 
// HelpString: FlSigCtl 1.0 Type Library
// DepndLst: 
//   (1) v2.0 stdole, (C:\Windows\SysWOW64\stdole2.tlb)
// SYS_KIND: SYS_WIN32
// Errors:
//   Hint: Symbol 'Type' renamed to 'type_'
//   Hint: Member 'Set' of 'IKey' changed to 'Set_'
//   Hint: Parameter 'Type' of IKey.Set changed to 'Type_'
// ************************************************************************ //
{$TYPEDADDRESS OFF} // Unit must be compiled without type-checked pointers. 
{$WARN SYMBOL_PLATFORM OFF}
{$WRITEABLECONST ON}
{$VARPROPSETTER ON}
{$ALIGN 4}

interface

uses Winapi.Windows, System.Classes, System.Variants, System.Win.StdVCL, Vcl.Graphics, Vcl.OleCtrls, Vcl.OleServer, Winapi.ActiveX;
  


// *********************************************************************//
// GUIDS declared in the TypeLibrary. Following prefixes are used:        
//   Type Libraries     : LIBID_xxxx                                      
//   CoClasses          : CLASS_xxxx                                      
//   DISPInterfaces     : DIID_xxxx                                       
//   Non-DISP interfaces: IID_xxxx                                        
// *********************************************************************//
const
  // TypeLibrary Major and minor versions
  FLSIGCTLLibMajorVersion = 1;
  FLSIGCTLLibMinorVersion = 0;

  LIBID_FLSIGCTLLib: TGUID = '{B0452E4E-DB2A-472D-91EA-9F77C9885A39}';

  DIID__ISigCtlEvents: TGUID = '{2D7573FA-DD24-487E-997C-7D16F25DB508}';
  DIID__ISigCtlEvents2: TGUID = '{7423A831-443B-4774-8214-C1B9331858E0}';
  IID_ISigObj: TGUID = '{DCB4391F-BA9B-4753-B673-E281F91B9397}';
  IID_ISigObj2: TGUID = '{26E59DD5-389B-4D42-ABEC-0FE6B957296D}';
  IID_ISigObj3: TGUID = '{4FCEFD0C-1054-47F0-AF82-4BD571D50A88}';
  CLASS_SigObj: TGUID = '{8615302D-31CD-4E9C-83A4-14F59FDA2D59}';
  IID_IHash: TGUID = '{E490AFE3-E089-498F-8DDF-F9D9A4C7C595}';
  IID_ISigCtl: TGUID = '{BAD4B965-EDF5-4423-8D83-1DFD457FB194}';
  IID_ISigCtl2: TGUID = '{BA4D0AD3-2A59-410D-971D-3B7964975E21}';
  IID_ISigCtl3: TGUID = '{A9F50BB6-6914-4832-A78C-75502C58A76E}';
  IID__ISigCtlFirefox: TGUID = '{D1120052-CE8F-45F6-84D9-B6A33BA3A7EE}';
  CLASS_SigCtl: TGUID = '{963B1D81-38B8-492E-ACBE-74801D009E9E}';
  IID__ISigCtlFirefoxCallback: TGUID = '{5D07FC86-CD9F-490E-B3CC-A69A841D4E33}';
  CLASS_SigCtlSigDisplayProp: TGUID = '{7812668C-3BEF-4E94-86B9-125E51685CDB}';
  CLASS_SigCtlTextDisplayProp: TGUID = '{5CF3D540-B2FB-419B-A2EA-D7EDA7C5A9BA}';
  CLASS_SigCtlBorderProp: TGUID = '{C115D7E8-E35C-4AD0-9D0F-B711F393CE2F}';
  CLASS_Hash: TGUID = '{CD3F0EA4-1CE9-4935-A4F8-71D85DEA2566}';
  IID_IKey: TGUID = '{7511B9C1-5504-44AA-AE43-CBBE9A2668C5}';
  CLASS_Key: TGUID = '{647328CB-036B-4144-9772-A4D00AA5F5D9}';
  IID_ISigCtlXHTML: TGUID = '{656CB7E9-61DD-45B3-A92D-81FECDDBD3F3}';
  IID_ISigCtlXHTML2: TGUID = '{7D70505C-D019-48F1-A4A6-6EA1525366CE}';
  IID_ISigCtlXHTML3: TGUID = '{38505341-4179-4897-93A6-6555B9340279}';
  IID_ISigCtlXHTML4: TGUID = '{6D4C830D-FFE3-4815-B074-E8602DAF4BF5}';
  CLASS_SigCtlXHTML: TGUID = '{F5DC9DFE-FD38-4455-A783-4B3F31B2D229}';
  IID_IImgCtlXHTML: TGUID = '{111EDBBA-8410-4116-8B0F-E4FC322C841D}';
  IID_IImgCtlXHTML2: TGUID = '{DF949DF0-E2E6-440D-A539-A52904C4D92C}';
  IID_IImgCtlXHTML3: TGUID = '{170A8200-045A-4687-9DAD-A017F8E331C6}';
  CLASS_ImgCtlXHTML: TGUID = '{EFFD1818-3060-49A3-9C22-A06F57BBC167}';
  IID_IOnLoadHandler: TGUID = '{1D6154F4-F0DD-4F8B-8F48-F0CA4BA91B27}';
  CLASS_OnLoadHandler: TGUID = '{BF82F9BF-ED09-40F0-859E-17B1CA34113A}';
  IID_ICustomSetup: TGUID = '{94F04BC1-270D-465D-AFFF-7B3B4E89914A}';
  CLASS_CustomSetup: TGUID = '{88BDC7B9-D1CE-4023-9633-996AB8B61779}';

// *********************************************************************//
// Declaration of Enumerations defined in Type Library                    
// *********************************************************************//
// Constants for enum BorderStyle
type
  BorderStyle = TOleEnum;
const
  BdrFlat = $00000000;
  BdrRaised = $00000005;
  BdrEtched = $00000006;
  BdrBump = $00000009;
  BdrSunken = $0000000A;

// Constants for enum TimeZone
type
  TimeZone = TOleEnum;
const
  TimeLocal = $00000000;
  TimeGMT = $00000001;
  TimeUTC = $00000001;

// Constants for enum CaptData
type
  CaptData = TOleEnum;
const
  CaptDigitizer = $0000001A;
  CaptDigitizerDriver = $0000001B;
  CaptMachineOS = $0000001C;
  CaptNetworkCard = $0000001D;

// Constants for enum IntegrityStatus
type
  IntegrityStatus = TOleEnum;
const
  IntegrityOK = $00000000;
  IntegrityFail = $00000001;
  IntegrityMissing = $00000002;
  IntegrityWrongType = $00000003;
  IntegrityInsufficientData = $00000004;
  IntegrityUncertain = $00000005;
  IntegrityUnsupported = $00000006;

// Constants for enum HashType
type
  HashType = TOleEnum;
const
  HashNone = $00000000;
  HashMD5 = $00000001;
  HashSHA1 = $00000002;
  HashSHA224 = $00000003;
  HashSHA256 = $00000004;
  HashSHA384 = $00000005;
  HashSHA512 = $00000006;

// Constants for enum SignedData
type
  SignedData = TOleEnum;
const
  DataGood = $00000000;
  DataNoHash = $00000001;
  DataBadType = $00000002;
  DataBadHash = $00000003;
  DataError = $00000004;
  DataUncertain = $00000005;
  DataSigMoved = $00000006;

// Constants for enum DisplayMode
type
  DisplayMode = TOleEnum;
const
  DspForceFit = $00000000;
  DspUseZoom = $00000001;
  DspBestFit = $00000002;

// Constants for enum RBFlags
type
  RBFlags = TOleEnum;
const
  RenderOutputBinary = $00000800;
  RenderOutputFilename = $00001000;
  RenderOutputPicture = $00200000;
  RenderOutputBase64 = $00002000;
  RenderBackgroundTransparent = $00010000;
  RenderColor1BPP = $00020000;
  RenderColor24BPP = $00040000;
  RenderColor32BPP = $00080000;
  RenderColorAntiAlias = $00100000;
  RenderEncodeData = $00400000;
  RenderWatermark = $00800000;
  RenderClipped = $01000000;
  RenderRelative = $02000000;

// Constants for enum ReadEncodedBitmapResult
type
  ReadEncodedBitmapResult = TOleEnum;
const
  ReadEncodedBitmapOK = $00000000;
  ReadEncodedBitmapFileNotFound = $00000001;
  ReadEncodedBitmapNotImage = $00000002;
  ReadEncodedBitmapSigDataNotFound = $00000003;

// Constants for enum ShowText
type
  ShowText = TOleEnum;
const
  TxtDontShow = $00000000;
  TxtShowLeft = $00000001;
  TxtShowCenter = $00000002;
  TxtShowRight = $00000004;

// Constants for enum CaptureResult
type
  CaptureResult = TOleEnum;
const
  CaptureOK = $00000000;
  CaptureCancel = $00000001;
  CapturePadError = $00000064;
  CaptureError = $00000065;
  CaptureIntegrityKeyInvalid = $00000066;
  CaptureNotLicensed = $00000067;
  CaptureAbort = $000000C8;

// Constants for enum MarkupStatus
type
  MarkupStatus = TOleEnum;
const
  mkupSuccess = $00000000;
  mkupDocError = $00000001;
  mkupEltNotFound = $00000002;
  mkupEltNotEmpty = $00000003;
  mkupEltEmpty = $00000004;
  mkupError = $00000005;

// Constants for enum KeyType
type
  KeyType = TOleEnum;
const
  KeyNone = $00000000;
  KeyMD5 = $00000001;
  KeyMD5MAC = $00000002;
  KeySHA1 = $00000003;
  KeySHA224 = $00000004;
  KeySHA256 = $00000005;
  KeySHA384 = $00000006;
  KeySHA512 = $00000007;
  KeyCAPICOM = $00000008;

// Constants for enum CaptureData
type
  CaptureData = TOleEnum;
const
  CaptOK = $00000000;
  CaptCancel = $00000001;
  CaptPadError = $00000064;
  CaptPITSError = $000000C9;
  CaptError = $000000CA;

type

// *********************************************************************//
// Forward declaration of types defined in TypeLibrary                    
// *********************************************************************//
  _ISigCtlEvents = dispinterface;
  _ISigCtlEvents2 = dispinterface;
  ISigObj = interface;
  ISigObjDisp = dispinterface;
  ISigObj2 = interface;
  ISigObj2Disp = dispinterface;
  ISigObj3 = interface;
  ISigObj3Disp = dispinterface;
  IHash = interface;
  IHashDisp = dispinterface;
  ISigCtl = interface;
  ISigCtlDisp = dispinterface;
  ISigCtl2 = interface;
  ISigCtl2Disp = dispinterface;
  ISigCtl3 = interface;
  ISigCtl3Disp = dispinterface;
  _ISigCtlFirefox = interface;
  _ISigCtlFirefoxCallback = interface;
  IKey = interface;
  IKeyDisp = dispinterface;
  ISigCtlXHTML = interface;
  ISigCtlXHTMLDisp = dispinterface;
  ISigCtlXHTML2 = interface;
  ISigCtlXHTML2Disp = dispinterface;
  ISigCtlXHTML3 = interface;
  ISigCtlXHTML3Disp = dispinterface;
  ISigCtlXHTML4 = interface;
  ISigCtlXHTML4Disp = dispinterface;
  IImgCtlXHTML = interface;
  IImgCtlXHTMLDisp = dispinterface;
  IImgCtlXHTML2 = interface;
  IImgCtlXHTML2Disp = dispinterface;
  IImgCtlXHTML3 = interface;
  IImgCtlXHTML3Disp = dispinterface;
  IOnLoadHandler = interface;
  IOnLoadHandlerDisp = dispinterface;
  ICustomSetup = interface;
  ICustomSetupDisp = dispinterface;

// *********************************************************************//
// Declaration of CoClasses defined in Type Library                       
// (NOTE: Here we map each CoClass to its Default Interface)              
// *********************************************************************//
  SigObj = ISigObj3;
  SigCtl = ISigCtl3;
  SigCtlSigDisplayProp = IUnknown;
  SigCtlTextDisplayProp = IUnknown;
  SigCtlBorderProp = IUnknown;
  Hash = IHash;
  Key = IKey;
  SigCtlXHTML = ISigCtlXHTML4;
  ImgCtlXHTML = IImgCtlXHTML3;
  OnLoadHandler = IOnLoadHandler;
  CustomSetup = ICustomSetup;


// *********************************************************************//
// DispIntf:  _ISigCtlEvents
// Flags:     (4096) Dispatchable
// GUID:      {2D7573FA-DD24-487E-997C-7D16F25DB508}
// *********************************************************************//
  _ISigCtlEvents = dispinterface
    ['{2D7573FA-DD24-487E-997C-7D16F25DB508}']
    procedure Click; dispid -600;
    procedure DblClick; dispid -601;
    procedure KeyDown(var KeyCode: Smallint; Shift: Smallint); dispid -602;
    procedure KeyPress(var KeyAscii: Smallint); dispid -603;
    procedure KeyUp(var KeyCode: Smallint; Shift: Smallint); dispid -604;
    procedure MouseDown(Button: Smallint; Short: Smallint; x: OLE_XPOS_PIXELS; y: OLE_YPOS_PIXELS); dispid -605;
    procedure MouseUp(Button: Smallint; Short: Smallint; x: OLE_XPOS_PIXELS; y: OLE_YPOS_PIXELS); dispid -607;
    procedure MouseMove(Button: Smallint; Short: Smallint; x: OLE_XPOS_PIXELS; y: OLE_YPOS_PIXELS); dispid -606;
  end;

// *********************************************************************//
// DispIntf:  _ISigCtlEvents2
// Flags:     (4096) Dispatchable
// GUID:      {7423A831-443B-4774-8214-C1B9331858E0}
// *********************************************************************//
  _ISigCtlEvents2 = dispinterface
    ['{7423A831-443B-4774-8214-C1B9331858E0}']
    procedure Click; dispid -600;
    procedure DblClick; dispid -601;
    procedure KeyDown(var KeyCode: Smallint; Shift: Smallint); dispid -602;
    procedure KeyPress(var KeyAscii: Smallint); dispid -603;
    procedure KeyUp(var KeyCode: Smallint; Shift: Smallint); dispid -604;
    procedure MouseDown(Button: Smallint; Short: Smallint; x: OLE_XPOS_PIXELS; y: OLE_YPOS_PIXELS); dispid -605;
    procedure MouseUp(Button: Smallint; Short: Smallint; x: OLE_XPOS_PIXELS; y: OLE_YPOS_PIXELS); dispid -607;
    procedure MouseMove(Button: Smallint; Short: Smallint; x: OLE_XPOS_PIXELS; y: OLE_YPOS_PIXELS); dispid -606;
    procedure PreCapture(const Who: WideString; const Why: WideString; var Continue: WordBool); dispid 1;
    procedure PostCapture(CaptureStatus: Integer); dispid 2;
    procedure Remove; dispid 3;
  end;

// *********************************************************************//
// Interface: ISigObj
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {DCB4391F-BA9B-4753-B673-E281F91B9397}
// *********************************************************************//
  ISigObj = interface(IDispatch)
    ['{DCB4391F-BA9B-4753-B673-E281F91B9397}']
    function Get_SigData: OleVariant; safecall;
    procedure Set_SigData(pVal: OleVariant); safecall;
    procedure Set_SigText(const pstrText: WideString); safecall;
    function Get_SigText: WideString; safecall;
    function Get_IsCaptured: WordBool; safecall;
    function Get_Width: Integer; safecall;
    function Get_Height: Integer; safecall;
    function Get_Who: WideString; safecall;
    function Get_Why: WideString; safecall;
    function Get_When(TZ: TimeZone): TDateTime; safecall;
    function Get_AdditionalData(DataType: CaptData): OleVariant; safecall;
    function Get_Ink: WideString; safecall;
    procedure Set_Ink(const pVal: WideString); safecall;
    procedure Clear; safecall;
    function CheckIntegrity(Key: OleVariant): IntegrityStatus; safecall;
    function CheckSignedData(const Hash: IHash): SignedData; safecall;
    procedure Render(hDCTarg: Integer; hDCRef: Integer; x: Integer; y: Integer; InkWidth: Single; 
                     InkColor: OLE_COLOR; Line: WordBool; Zoom: Smallint; Rotation: Smallint); safecall;
    procedure RenderRect(hDCTarg: Integer; hDCRef: Integer; Left: Integer; Top: Integer; 
                         Right: Integer; Bottom: Integer; InkWidth: Single; InkColor: OLE_COLOR; 
                         Option: DisplayMode; Zoom: Smallint; Rotation: Smallint); safecall;
    property SigData: OleVariant read Get_SigData write Set_SigData;
    property SigText: WideString read Get_SigText write Set_SigText;
    property IsCaptured: WordBool read Get_IsCaptured;
    property Width: Integer read Get_Width;
    property Height: Integer read Get_Height;
    property Who: WideString read Get_Who;
    property Why: WideString read Get_Why;
    property When[TZ: TimeZone]: TDateTime read Get_When;
    property AdditionalData[DataType: CaptData]: OleVariant read Get_AdditionalData;
    property Ink: WideString read Get_Ink write Set_Ink;
  end;

// *********************************************************************//
// DispIntf:  ISigObjDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {DCB4391F-BA9B-4753-B673-E281F91B9397}
// *********************************************************************//
  ISigObjDisp = dispinterface
    ['{DCB4391F-BA9B-4753-B673-E281F91B9397}']
    property SigData: OleVariant dispid 1;
    property SigText: WideString dispid 0;
    property IsCaptured: WordBool readonly dispid 3;
    property Width: Integer readonly dispid 4;
    property Height: Integer readonly dispid 5;
    property Who: WideString readonly dispid 6;
    property Why: WideString readonly dispid 7;
    property When[TZ: TimeZone]: TDateTime readonly dispid 8;
    property AdditionalData[DataType: CaptData]: OleVariant readonly dispid 9;
    property Ink: WideString dispid 10;
    procedure Clear; dispid 20;
    function CheckIntegrity(Key: OleVariant): IntegrityStatus; dispid 21;
    function CheckSignedData(const Hash: IHash): SignedData; dispid 22;
    procedure Render(hDCTarg: Integer; hDCRef: Integer; x: Integer; y: Integer; InkWidth: Single; 
                     InkColor: OLE_COLOR; Line: WordBool; Zoom: Smallint; Rotation: Smallint); dispid 23;
    procedure RenderRect(hDCTarg: Integer; hDCRef: Integer; Left: Integer; Top: Integer; 
                         Right: Integer; Bottom: Integer; InkWidth: Single; InkColor: OLE_COLOR; 
                         Option: DisplayMode; Zoom: Smallint; Rotation: Smallint); dispid 24;
  end;

// *********************************************************************//
// Interface: ISigObj2
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {26E59DD5-389B-4D42-ABEC-0FE6B957296D}
// *********************************************************************//
  ISigObj2 = interface(ISigObj)
    ['{26E59DD5-389B-4D42-ABEC-0FE6B957296D}']
    function Get_CrossedOut: WordBool; safecall;
    function Get_ExtraData(const Key: WideString): WideString; safecall;
    procedure Set_ExtraData(const Key: WideString; const pVal: WideString); safecall;
    function SetProperty(const Name: WideString; Value: OleVariant): WordBool; safecall;
    function GetProperty(const Name: WideString): OleVariant; safecall;
    property CrossedOut: WordBool read Get_CrossedOut;
    property ExtraData[const Key: WideString]: WideString read Get_ExtraData write Set_ExtraData;
  end;

// *********************************************************************//
// DispIntf:  ISigObj2Disp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {26E59DD5-389B-4D42-ABEC-0FE6B957296D}
// *********************************************************************//
  ISigObj2Disp = dispinterface
    ['{26E59DD5-389B-4D42-ABEC-0FE6B957296D}']
    property CrossedOut: WordBool readonly dispid 13;
    property ExtraData[const Key: WideString]: WideString dispid 12;
    function SetProperty(const Name: WideString; Value: OleVariant): WordBool; dispid 25;
    function GetProperty(const Name: WideString): OleVariant; dispid 26;
    property SigData: OleVariant dispid 1;
    property SigText: WideString dispid 0;
    property IsCaptured: WordBool readonly dispid 3;
    property Width: Integer readonly dispid 4;
    property Height: Integer readonly dispid 5;
    property Who: WideString readonly dispid 6;
    property Why: WideString readonly dispid 7;
    property When[TZ: TimeZone]: TDateTime readonly dispid 8;
    property AdditionalData[DataType: CaptData]: OleVariant readonly dispid 9;
    property Ink: WideString dispid 10;
    procedure Clear; dispid 20;
    function CheckIntegrity(Key: OleVariant): IntegrityStatus; dispid 21;
    function CheckSignedData(const Hash: IHash): SignedData; dispid 22;
    procedure Render(hDCTarg: Integer; hDCRef: Integer; x: Integer; y: Integer; InkWidth: Single; 
                     InkColor: OLE_COLOR; Line: WordBool; Zoom: Smallint; Rotation: Smallint); dispid 23;
    procedure RenderRect(hDCTarg: Integer; hDCRef: Integer; Left: Integer; Top: Integer; 
                         Right: Integer; Bottom: Integer; InkWidth: Single; InkColor: OLE_COLOR; 
                         Option: DisplayMode; Zoom: Smallint; Rotation: Smallint); dispid 24;
  end;

// *********************************************************************//
// Interface: ISigObj3
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {4FCEFD0C-1054-47F0-AF82-4BD571D50A88}
// *********************************************************************//
  ISigObj3 = interface(ISigObj2)
    ['{4FCEFD0C-1054-47F0-AF82-4BD571D50A88}']
    function RenderBitmap(const OutputFilename: WideString; DimensionX: Integer; 
                          DimensionY: Integer; const MimeType: WideString; InkWidth: Single; 
                          InkColor: OLE_COLOR; BackgroundColor: OLE_COLOR; PaddingX: Single; 
                          PaddingY: Single; Flags: RBFlags): OleVariant; safecall;
    function Picture(DimensionX: Integer; DimensionY: Integer; const MimeType: WideString; 
                     InkWidth: Single; InkColor: OLE_COLOR; BackgroundColor: OLE_COLOR; 
                     PaddingX: Single; PaddingY: Single; Flags: RBFlags): IPictureDisp; safecall;
    function ReadEncodedBitmap(Bitmap: OleVariant): ReadEncodedBitmapResult; safecall;
  end;

// *********************************************************************//
// DispIntf:  ISigObj3Disp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {4FCEFD0C-1054-47F0-AF82-4BD571D50A88}
// *********************************************************************//
  ISigObj3Disp = dispinterface
    ['{4FCEFD0C-1054-47F0-AF82-4BD571D50A88}']
    function RenderBitmap(const OutputFilename: WideString; DimensionX: Integer; 
                          DimensionY: Integer; const MimeType: WideString; InkWidth: Single; 
                          InkColor: OLE_COLOR; BackgroundColor: OLE_COLOR; PaddingX: Single; 
                          PaddingY: Single; Flags: RBFlags): OleVariant; dispid 27;
    function Picture(DimensionX: Integer; DimensionY: Integer; const MimeType: WideString; 
                     InkWidth: Single; InkColor: OLE_COLOR; BackgroundColor: OLE_COLOR; 
                     PaddingX: Single; PaddingY: Single; Flags: RBFlags): IPictureDisp; dispid 28;
    function ReadEncodedBitmap(Bitmap: OleVariant): ReadEncodedBitmapResult; dispid 29;
    property CrossedOut: WordBool readonly dispid 13;
    property ExtraData[const Key: WideString]: WideString dispid 12;
    function SetProperty(const Name: WideString; Value: OleVariant): WordBool; dispid 25;
    function GetProperty(const Name: WideString): OleVariant; dispid 26;
    property SigData: OleVariant dispid 1;
    property SigText: WideString dispid 0;
    property IsCaptured: WordBool readonly dispid 3;
    property Width: Integer readonly dispid 4;
    property Height: Integer readonly dispid 5;
    property Who: WideString readonly dispid 6;
    property Why: WideString readonly dispid 7;
    property When[TZ: TimeZone]: TDateTime readonly dispid 8;
    property AdditionalData[DataType: CaptData]: OleVariant readonly dispid 9;
    property Ink: WideString dispid 10;
    procedure Clear; dispid 20;
    function CheckIntegrity(Key: OleVariant): IntegrityStatus; dispid 21;
    function CheckSignedData(const Hash: IHash): SignedData; dispid 22;
    procedure Render(hDCTarg: Integer; hDCRef: Integer; x: Integer; y: Integer; InkWidth: Single; 
                     InkColor: OLE_COLOR; Line: WordBool; Zoom: Smallint; Rotation: Smallint); dispid 23;
    procedure RenderRect(hDCTarg: Integer; hDCRef: Integer; Left: Integer; Top: Integer; 
                         Right: Integer; Bottom: Integer; InkWidth: Single; InkColor: OLE_COLOR; 
                         Option: DisplayMode; Zoom: Smallint; Rotation: Smallint); dispid 24;
  end;

// *********************************************************************//
// Interface: IHash
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {E490AFE3-E089-498F-8DDF-F9D9A4C7C595}
// *********************************************************************//
  IHash = interface(IDispatch)
    ['{E490AFE3-E089-498F-8DDF-F9D9A4C7C595}']
    function Get_type_: HashType; safecall;
    procedure Set_type_(pVal: HashType); safecall;
    function Get_Hash: WideString; safecall;
    procedure Add(Data: OleVariant); safecall;
    procedure Clear; safecall;
    property type_: HashType read Get_type_ write Set_type_;
    property Hash: WideString read Get_Hash;
  end;

// *********************************************************************//
// DispIntf:  IHashDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {E490AFE3-E089-498F-8DDF-F9D9A4C7C595}
// *********************************************************************//
  IHashDisp = dispinterface
    ['{E490AFE3-E089-498F-8DDF-F9D9A4C7C595}']
    property type_: HashType dispid 1;
    property Hash: WideString readonly dispid 2;
    procedure Add(Data: OleVariant); dispid 10;
    procedure Clear; dispid 11;
  end;

// *********************************************************************//
// Interface: ISigCtl
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {BAD4B965-EDF5-4423-8D83-1DFD457FB194}
// *********************************************************************//
  ISigCtl = interface(IDispatch)
    ['{BAD4B965-EDF5-4423-8D83-1DFD457FB194}']
    procedure Set_BackColor(pclr: OLE_COLOR); safecall;
    function Get_BackColor: OLE_COLOR; safecall;
    procedure Set_BorderColor(pclr: OLE_COLOR); safecall;
    function Get_BorderColor: OLE_COLOR; safecall;
    procedure Set_BorderStyle(pstyle: Integer); safecall;
    function Get_BorderStyle: Integer; safecall;
    procedure Set_BorderWidth(Width: Integer); safecall;
    function Get_BorderWidth: Integer; safecall;
    procedure _Set_Font(const ppFont: IFontDisp); safecall;
    procedure Set_Font(const ppFont: IFontDisp); safecall;
    function Get_Font: IFontDisp; safecall;
    procedure Set_ForeColor(pclr: OLE_COLOR); safecall;
    function Get_ForeColor: OLE_COLOR; safecall;
    procedure Set_Enabled(pbool: WordBool); safecall;
    function Get_Enabled: WordBool; safecall;
    procedure Set_TabStop(pbool: WordBool); safecall;
    function Get_TabStop: WordBool; safecall;
    procedure Set_Caption(const pstrCaption: WideString); safecall;
    function Get_Caption: WideString; safecall;
    procedure Set_BorderVisible(pbool: WordBool); safecall;
    function Get_BorderVisible: WordBool; safecall;
    function Get_Signature: ISigObj; safecall;
    procedure Set_Signature(const ppVal: ISigObj); safecall;
    function Get_CtlPadding: Smallint; safecall;
    procedure Set_CtlPadding(pVal: Smallint); safecall;
    function Get_DisplayMode: DisplayMode; safecall;
    procedure Set_DisplayMode(pVal: DisplayMode); safecall;
    function Get_Zoom: Smallint; safecall;
    procedure Set_Zoom(pVal: Smallint); safecall;
    function Get_Rotation: Smallint; safecall;
    procedure Set_Rotation(pVal: Smallint); safecall;
    function Get_InkColor: OLE_COLOR; safecall;
    procedure Set_InkColor(pVal: OLE_COLOR); safecall;
    function Get_InkWidth: Single; safecall;
    procedure Set_InkWidth(pVal: Single); safecall;
    function Get_ShowWho: ShowText; safecall;
    procedure Set_ShowWho(pVal: ShowText); safecall;
    function Get_ShowWhen: ShowText; safecall;
    procedure Set_ShowWhen(pVal: ShowText); safecall;
    function Get_WhenFormat: WideString; safecall;
    procedure Set_WhenFormat(const pVal: WideString); safecall;
    function Get_AppData(Key: OleVariant): OleVariant; safecall;
    procedure Set_AppData(Key: OleVariant; pVal: OleVariant); safecall;
    function Capture(const Who: WideString; const Why: WideString; What: OleVariant; Key: OleVariant): CaptureResult; safecall;
    procedure AboutBox; safecall;
    property BackColor: OLE_COLOR read Get_BackColor write Set_BackColor;
    property BorderColor: OLE_COLOR read Get_BorderColor write Set_BorderColor;
    property BorderStyle: Integer read Get_BorderStyle write Set_BorderStyle;
    property BorderWidth: Integer read Get_BorderWidth write Set_BorderWidth;
    property Font: IFontDisp read Get_Font write Set_Font;
    property ForeColor: OLE_COLOR read Get_ForeColor write Set_ForeColor;
    property Enabled: WordBool read Get_Enabled write Set_Enabled;
    property TabStop: WordBool read Get_TabStop write Set_TabStop;
    property Caption: WideString read Get_Caption write Set_Caption;
    property BorderVisible: WordBool read Get_BorderVisible write Set_BorderVisible;
    property Signature: ISigObj read Get_Signature write Set_Signature;
    property CtlPadding: Smallint read Get_CtlPadding write Set_CtlPadding;
    property DisplayMode: DisplayMode read Get_DisplayMode write Set_DisplayMode;
    property Zoom: Smallint read Get_Zoom write Set_Zoom;
    property Rotation: Smallint read Get_Rotation write Set_Rotation;
    property InkColor: OLE_COLOR read Get_InkColor write Set_InkColor;
    property InkWidth: Single read Get_InkWidth write Set_InkWidth;
    property ShowWho: ShowText read Get_ShowWho write Set_ShowWho;
    property ShowWhen: ShowText read Get_ShowWhen write Set_ShowWhen;
    property WhenFormat: WideString read Get_WhenFormat write Set_WhenFormat;
    property AppData[Key: OleVariant]: OleVariant read Get_AppData write Set_AppData;
  end;

// *********************************************************************//
// DispIntf:  ISigCtlDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {BAD4B965-EDF5-4423-8D83-1DFD457FB194}
// *********************************************************************//
  ISigCtlDisp = dispinterface
    ['{BAD4B965-EDF5-4423-8D83-1DFD457FB194}']
    property BackColor: OLE_COLOR dispid -501;
    property BorderColor: OLE_COLOR dispid -503;
    property BorderStyle: Integer dispid -504;
    property BorderWidth: Integer dispid -505;
    property Font: IFontDisp dispid -512;
    property ForeColor: OLE_COLOR dispid -513;
    property Enabled: WordBool dispid -514;
    property TabStop: WordBool dispid -516;
    property Caption: WideString dispid -518;
    property BorderVisible: WordBool dispid -519;
    property Signature: ISigObj dispid 1;
    property CtlPadding: Smallint dispid 2;
    property DisplayMode: DisplayMode dispid 3;
    property Zoom: Smallint dispid 4;
    property Rotation: Smallint dispid 5;
    property InkColor: OLE_COLOR dispid 6;
    property InkWidth: Single dispid 7;
    property ShowWho: ShowText dispid 8;
    property ShowWhen: ShowText dispid 9;
    property WhenFormat: WideString dispid 10;
    property AppData[Key: OleVariant]: OleVariant dispid 11;
    function Capture(const Who: WideString; const Why: WideString; What: OleVariant; Key: OleVariant): CaptureResult; dispid 20;
    procedure AboutBox; dispid -552;
  end;

// *********************************************************************//
// Interface: ISigCtl2
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {BA4D0AD3-2A59-410D-971D-3B7964975E21}
// *********************************************************************//
  ISigCtl2 = interface(IDispatch)
    ['{BA4D0AD3-2A59-410D-971D-3B7964975E21}']
    procedure Set_BackColor(pclr: OLE_COLOR); safecall;
    function Get_BackColor: OLE_COLOR; safecall;
    procedure Set_BackStyle(pstyle: Integer); safecall;
    function Get_BackStyle: Integer; safecall;
    procedure Set_BorderColor(pclr: OLE_COLOR); safecall;
    function Get_BorderColor: OLE_COLOR; safecall;
    procedure Set_BorderStyle(pstyle: Integer); safecall;
    function Get_BorderStyle: Integer; safecall;
    procedure Set_BorderWidth(Width: Integer); safecall;
    function Get_BorderWidth: Integer; safecall;
    procedure _Set_Font(const ppFont: IFontDisp); safecall;
    procedure Set_Font(const ppFont: IFontDisp); safecall;
    function Get_Font: IFontDisp; safecall;
    procedure Set_ForeColor(pclr: OLE_COLOR); safecall;
    function Get_ForeColor: OLE_COLOR; safecall;
    procedure Set_Enabled(pbool: WordBool); safecall;
    function Get_Enabled: WordBool; safecall;
    procedure Set_TabStop(pbool: WordBool); safecall;
    function Get_TabStop: WordBool; safecall;
    procedure Set_Caption(const pstrCaption: WideString); safecall;
    function Get_Caption: WideString; safecall;
    procedure Set_BorderVisible(pbool: WordBool); safecall;
    function Get_BorderVisible: WordBool; safecall;
    function Get_Signature: IDispatch; safecall;
    procedure Set_Signature(const ppVal: IDispatch); safecall;
    function Get_CtlPadding: Smallint; safecall;
    procedure Set_CtlPadding(pVal: Smallint); safecall;
    function Get_DisplayMode: DisplayMode; safecall;
    procedure Set_DisplayMode(pVal: DisplayMode); safecall;
    function Get_Zoom: Smallint; safecall;
    procedure Set_Zoom(pVal: Smallint); safecall;
    function Get_Rotation: Smallint; safecall;
    procedure Set_Rotation(pVal: Smallint); safecall;
    function Get_InkColor: OLE_COLOR; safecall;
    procedure Set_InkColor(pVal: OLE_COLOR); safecall;
    function Get_InkWidth: Single; safecall;
    procedure Set_InkWidth(pVal: Single); safecall;
    function Get_ShowWho: ShowText; safecall;
    procedure Set_ShowWho(pVal: ShowText); safecall;
    function Get_ShowWhen: ShowText; safecall;
    procedure Set_ShowWhen(pVal: ShowText); safecall;
    function Get_ShowWhy: ShowText; safecall;
    procedure Set_ShowWhy(pVal: ShowText); safecall;
    function Get_WhenFormat: WideString; safecall;
    procedure Set_WhenFormat(const pVal: WideString); safecall;
    function Get_AppData(Key: OleVariant): OleVariant; safecall;
    procedure Set_AppData(Key: OleVariant; pVal: OleVariant); safecall;
    function Get_InputWho: WideString; safecall;
    procedure Set_InputWho(const pVal: WideString); safecall;
    function Get_InputWhy: WideString; safecall;
    procedure Set_InputWhy(const pVal: WideString); safecall;
    function Get_InputData: WideString; safecall;
    procedure Set_InputData(const pVal: WideString); safecall;
    function Get_InputSignature: WideString; safecall;
    procedure Set_InputSignature(const pVal: WideString); safecall;
    function Capture(const Who: WideString; const Why: WideString; What: OleVariant; Key: OleVariant): CaptureResult; safecall;
    procedure AboutBox; safecall;
    function SetProperty(const Name: WideString; Value: OleVariant): WordBool; safecall;
    function GetProperty(const Name: WideString): OleVariant; safecall;
    property BackColor: OLE_COLOR read Get_BackColor write Set_BackColor;
    property BackStyle: Integer read Get_BackStyle write Set_BackStyle;
    property BorderColor: OLE_COLOR read Get_BorderColor write Set_BorderColor;
    property BorderStyle: Integer read Get_BorderStyle write Set_BorderStyle;
    property BorderWidth: Integer read Get_BorderWidth write Set_BorderWidth;
    property Font: IFontDisp read Get_Font write Set_Font;
    property ForeColor: OLE_COLOR read Get_ForeColor write Set_ForeColor;
    property Enabled: WordBool read Get_Enabled write Set_Enabled;
    property TabStop: WordBool read Get_TabStop write Set_TabStop;
    property Caption: WideString read Get_Caption write Set_Caption;
    property BorderVisible: WordBool read Get_BorderVisible write Set_BorderVisible;
    property Signature: IDispatch read Get_Signature write Set_Signature;
    property CtlPadding: Smallint read Get_CtlPadding write Set_CtlPadding;
    property DisplayMode: DisplayMode read Get_DisplayMode write Set_DisplayMode;
    property Zoom: Smallint read Get_Zoom write Set_Zoom;
    property Rotation: Smallint read Get_Rotation write Set_Rotation;
    property InkColor: OLE_COLOR read Get_InkColor write Set_InkColor;
    property InkWidth: Single read Get_InkWidth write Set_InkWidth;
    property ShowWho: ShowText read Get_ShowWho write Set_ShowWho;
    property ShowWhen: ShowText read Get_ShowWhen write Set_ShowWhen;
    property ShowWhy: ShowText read Get_ShowWhy write Set_ShowWhy;
    property WhenFormat: WideString read Get_WhenFormat write Set_WhenFormat;
    property AppData[Key: OleVariant]: OleVariant read Get_AppData write Set_AppData;
    property InputWho: WideString read Get_InputWho write Set_InputWho;
    property InputWhy: WideString read Get_InputWhy write Set_InputWhy;
    property InputData: WideString read Get_InputData write Set_InputData;
    property InputSignature: WideString read Get_InputSignature write Set_InputSignature;
  end;

// *********************************************************************//
// DispIntf:  ISigCtl2Disp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {BA4D0AD3-2A59-410D-971D-3B7964975E21}
// *********************************************************************//
  ISigCtl2Disp = dispinterface
    ['{BA4D0AD3-2A59-410D-971D-3B7964975E21}']
    property BackColor: OLE_COLOR dispid -501;
    property BackStyle: Integer dispid -502;
    property BorderColor: OLE_COLOR dispid -503;
    property BorderStyle: Integer dispid -504;
    property BorderWidth: Integer dispid -505;
    property Font: IFontDisp dispid -512;
    property ForeColor: OLE_COLOR dispid -513;
    property Enabled: WordBool dispid -514;
    property TabStop: WordBool dispid -516;
    property Caption: WideString dispid -518;
    property BorderVisible: WordBool dispid -519;
    property Signature: IDispatch dispid 1;
    property CtlPadding: Smallint dispid 2;
    property DisplayMode: DisplayMode dispid 3;
    property Zoom: Smallint dispid 4;
    property Rotation: Smallint dispid 5;
    property InkColor: OLE_COLOR dispid 6;
    property InkWidth: Single dispid 7;
    property ShowWho: ShowText dispid 8;
    property ShowWhen: ShowText dispid 9;
    property ShowWhy: ShowText dispid 12;
    property WhenFormat: WideString dispid 10;
    property AppData[Key: OleVariant]: OleVariant dispid 11;
    property InputWho: WideString dispid 13;
    property InputWhy: WideString dispid 14;
    property InputData: WideString dispid 15;
    property InputSignature: WideString dispid 16;
    function Capture(const Who: WideString; const Why: WideString; What: OleVariant; Key: OleVariant): CaptureResult; dispid 20;
    procedure AboutBox; dispid -552;
    function SetProperty(const Name: WideString; Value: OleVariant): WordBool; dispid 21;
    function GetProperty(const Name: WideString): OleVariant; dispid 22;
  end;

// *********************************************************************//
// Interface: ISigCtl3
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {A9F50BB6-6914-4832-A78C-75502C58A76E}
// *********************************************************************//
  ISigCtl3 = interface(ISigCtl2)
    ['{A9F50BB6-6914-4832-A78C-75502C58A76E}']
    function Get_Licence: OleVariant; safecall;
    procedure Set_Licence(pVal: OleVariant); safecall;
    procedure Set_Properties(const Param1: WideString); safecall;
    property Licence: OleVariant read Get_Licence write Set_Licence;
    property Properties: WideString write Set_Properties;
  end;

// *********************************************************************//
// DispIntf:  ISigCtl3Disp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {A9F50BB6-6914-4832-A78C-75502C58A76E}
// *********************************************************************//
  ISigCtl3Disp = dispinterface
    ['{A9F50BB6-6914-4832-A78C-75502C58A76E}']
    property Licence: OleVariant dispid 17;
    property Properties: WideString writeonly dispid 18;
    property BackColor: OLE_COLOR dispid -501;
    property BackStyle: Integer dispid -502;
    property BorderColor: OLE_COLOR dispid -503;
    property BorderStyle: Integer dispid -504;
    property BorderWidth: Integer dispid -505;
    property Font: IFontDisp dispid -512;
    property ForeColor: OLE_COLOR dispid -513;
    property Enabled: WordBool dispid -514;
    property TabStop: WordBool dispid -516;
    property Caption: WideString dispid -518;
    property BorderVisible: WordBool dispid -519;
    property Signature: IDispatch dispid 1;
    property CtlPadding: Smallint dispid 2;
    property DisplayMode: DisplayMode dispid 3;
    property Zoom: Smallint dispid 4;
    property Rotation: Smallint dispid 5;
    property InkColor: OLE_COLOR dispid 6;
    property InkWidth: Single dispid 7;
    property ShowWho: ShowText dispid 8;
    property ShowWhen: ShowText dispid 9;
    property ShowWhy: ShowText dispid 12;
    property WhenFormat: WideString dispid 10;
    property AppData[Key: OleVariant]: OleVariant dispid 11;
    property InputWho: WideString dispid 13;
    property InputWhy: WideString dispid 14;
    property InputData: WideString dispid 15;
    property InputSignature: WideString dispid 16;
    function Capture(const Who: WideString; const Why: WideString; What: OleVariant; Key: OleVariant): CaptureResult; dispid 20;
    procedure AboutBox; dispid -552;
    function SetProperty(const Name: WideString; Value: OleVariant): WordBool; dispid 21;
    function GetProperty(const Name: WideString): OleVariant; dispid 22;
  end;

// *********************************************************************//
// Interface: _ISigCtlFirefox
// Flags:     (384) NonExtensible OleAutomation
// GUID:      {D1120052-CE8F-45F6-84D9-B6A33BA3A7EE}
// *********************************************************************//
  _ISigCtlFirefox = interface(IUnknown)
    ['{D1120052-CE8F-45F6-84D9-B6A33BA3A7EE}']
    function Render(hDC: Integer; Left: Integer; Top: Integer; Right: Integer; Bottom: Integer): HResult; stdcall;
    function SetCallback(const Callback: _ISigCtlFirefoxCallback): HResult; stdcall;
    function InsertMarkup(const Id: WideString; const Text: WideString; out result: MarkupStatus): HResult; stdcall;
    function DocumentComplete: HResult; stdcall;
  end;

// *********************************************************************//
// Interface: _ISigCtlFirefoxCallback
// Flags:     (384) NonExtensible OleAutomation
// GUID:      {5D07FC86-CD9F-490E-B3CC-A69A841D4E33}
// *********************************************************************//
  _ISigCtlFirefoxCallback = interface(IUnknown)
    ['{5D07FC86-CD9F-490E-B3CC-A69A841D4E33}']
    function Notify(What: Smallint): HResult; stdcall;
    function SetMarkup(const Id: WideString; const Text: WideString; out result: MarkupStatus): HResult; stdcall;
    function MarkupStatus(const Id: WideString; out result: MarkupStatus): HResult; stdcall;
    function GetSigList(out pEnum: IEnumVARIANT): HResult; stdcall;
    function GetHTML(out pHTML: WideString): HResult; stdcall;
  end;

// *********************************************************************//
// Interface: IKey
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {7511B9C1-5504-44AA-AE43-CBBE9A2668C5}
// *********************************************************************//
  IKey = interface(IDispatch)
    ['{7511B9C1-5504-44AA-AE43-CBBE9A2668C5}']
    function Get_type_: KeyType; safecall;
    procedure Set_(Type_: KeyType; Value: OleVariant); safecall;
    property type_: KeyType read Get_type_;
  end;

// *********************************************************************//
// DispIntf:  IKeyDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {7511B9C1-5504-44AA-AE43-CBBE9A2668C5}
// *********************************************************************//
  IKeyDisp = dispinterface
    ['{7511B9C1-5504-44AA-AE43-CBBE9A2668C5}']
    property type_: KeyType readonly dispid 1;
    procedure Set_(Type_: KeyType; Value: OleVariant); dispid 2;
  end;

// *********************************************************************//
// Interface: ISigCtlXHTML
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {656CB7E9-61DD-45B3-A92D-81FECDDBD3F3}
// *********************************************************************//
  ISigCtlXHTML = interface(IDispatch)
    ['{656CB7E9-61DD-45B3-A92D-81FECDDBD3F3}']
    procedure Set_BackStyle(pclr: Integer); safecall;
    function Get_BackStyle: Integer; safecall;
    procedure Set_BackColor(pclr: OLE_COLOR); safecall;
    function Get_BackColor: OLE_COLOR; safecall;
    procedure Set_BorderColor(pclr: OLE_COLOR); safecall;
    function Get_BorderColor: OLE_COLOR; safecall;
    procedure Set_BorderStyle(pstyle: Integer); safecall;
    function Get_BorderStyle: Integer; safecall;
    procedure Set_BorderVisible(pbool: WordBool); safecall;
    function Get_BorderVisible: WordBool; safecall;
    procedure Set_BorderWidth(Width: Integer); safecall;
    function Get_BorderWidth: Integer; safecall;
    function Get_FileVersion: WideString; safecall;
    procedure _Set_Font(const ppFont: IFontDisp); safecall;
    procedure Set_Font(const ppFont: IFontDisp); safecall;
    function Get_Font: IFontDisp; safecall;
    procedure Set_ForeColor(pclr: OLE_COLOR); safecall;
    function Get_ForeColor: OLE_COLOR; safecall;
    procedure Set_Caption(const pstrCaption: WideString); safecall;
    function Get_Caption: WideString; safecall;
    function Get_DisplayMode: DisplayMode; safecall;
    procedure Set_DisplayMode(pVal: DisplayMode); safecall;
    function Get_Zoom: Smallint; safecall;
    procedure Set_Zoom(pVal: Smallint); safecall;
    function Get_Rotation: Smallint; safecall;
    procedure Set_Rotation(pVal: Smallint); safecall;
    function Get_InkColor: OLE_COLOR; safecall;
    procedure Set_InkColor(pVal: OLE_COLOR); safecall;
    function Get_InkWidth: Single; safecall;
    procedure Set_InkWidth(pVal: Single); safecall;
    function Get_Printer: IDispatch; safecall;
    function Get_ShowWhen: ShowText; safecall;
    procedure Set_ShowWhen(pVal: ShowText); safecall;
    function Get_ShowWho: ShowText; safecall;
    procedure Set_ShowWho(pVal: ShowText); safecall;
    function Get_Signature: IDispatch; safecall;
    procedure Set_Signature(const ppVal: IDispatch); safecall;
    function Get_CtlPadding: Smallint; safecall;
    procedure Set_CtlPadding(pVal: Smallint); safecall;
    function Get_WhenFormat: WideString; safecall;
    procedure Set_WhenFormat(const pVal: WideString); safecall;
    function Get_ShowWhy: ShowText; safecall;
    procedure Set_ShowWhy(pVal: ShowText); safecall;
    function Get_InputWho: WideString; safecall;
    procedure Set_InputWho(const pVal: WideString); safecall;
    function Get_InputWhy: WideString; safecall;
    procedure Set_InputWhy(const pVal: WideString); safecall;
    function Get_InputData: WideString; safecall;
    procedure Set_InputData(const pVal: WideString); safecall;
    procedure AboutBox; safecall;
    function Capture(const Who: WideString; const Why: WideString): CaptureData; safecall;
    function CheckHostDocument: SignedData; safecall;
    function CheckHostDocument2: SignedData; safecall;
    property BackStyle: Integer read Get_BackStyle write Set_BackStyle;
    property BackColor: OLE_COLOR read Get_BackColor write Set_BackColor;
    property BorderColor: OLE_COLOR read Get_BorderColor write Set_BorderColor;
    property BorderStyle: Integer read Get_BorderStyle write Set_BorderStyle;
    property BorderVisible: WordBool read Get_BorderVisible write Set_BorderVisible;
    property BorderWidth: Integer read Get_BorderWidth write Set_BorderWidth;
    property FileVersion: WideString read Get_FileVersion;
    property Font: IFontDisp read Get_Font write Set_Font;
    property ForeColor: OLE_COLOR read Get_ForeColor write Set_ForeColor;
    property Caption: WideString read Get_Caption write Set_Caption;
    property DisplayMode: DisplayMode read Get_DisplayMode write Set_DisplayMode;
    property Zoom: Smallint read Get_Zoom write Set_Zoom;
    property Rotation: Smallint read Get_Rotation write Set_Rotation;
    property InkColor: OLE_COLOR read Get_InkColor write Set_InkColor;
    property InkWidth: Single read Get_InkWidth write Set_InkWidth;
    property Printer: IDispatch read Get_Printer;
    property ShowWhen: ShowText read Get_ShowWhen write Set_ShowWhen;
    property ShowWho: ShowText read Get_ShowWho write Set_ShowWho;
    property Signature: IDispatch read Get_Signature write Set_Signature;
    property CtlPadding: Smallint read Get_CtlPadding write Set_CtlPadding;
    property WhenFormat: WideString read Get_WhenFormat write Set_WhenFormat;
    property ShowWhy: ShowText read Get_ShowWhy write Set_ShowWhy;
    property InputWho: WideString read Get_InputWho write Set_InputWho;
    property InputWhy: WideString read Get_InputWhy write Set_InputWhy;
    property InputData: WideString read Get_InputData write Set_InputData;
  end;

// *********************************************************************//
// DispIntf:  ISigCtlXHTMLDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {656CB7E9-61DD-45B3-A92D-81FECDDBD3F3}
// *********************************************************************//
  ISigCtlXHTMLDisp = dispinterface
    ['{656CB7E9-61DD-45B3-A92D-81FECDDBD3F3}']
    property BackStyle: Integer dispid -502;
    property BackColor: OLE_COLOR dispid -501;
    property BorderColor: OLE_COLOR dispid -503;
    property BorderStyle: Integer dispid -504;
    property BorderVisible: WordBool dispid -519;
    property BorderWidth: Integer dispid -505;
    property FileVersion: WideString readonly dispid 9;
    property Font: IFontDisp dispid -512;
    property ForeColor: OLE_COLOR dispid -513;
    property Caption: WideString dispid -518;
    property DisplayMode: DisplayMode dispid 19;
    property Zoom: Smallint dispid 20;
    property Rotation: Smallint dispid 21;
    property InkColor: OLE_COLOR dispid 1;
    property InkWidth: Single dispid 2;
    property Printer: IDispatch readonly dispid 4;
    property ShowWhen: ShowText dispid 5;
    property ShowWho: ShowText dispid 6;
    property Signature: IDispatch dispid 7;
    property CtlPadding: Smallint dispid 18;
    property WhenFormat: WideString dispid 10;
    property ShowWhy: ShowText dispid 14;
    property InputWho: WideString dispid 15;
    property InputWhy: WideString dispid 16;
    property InputData: WideString dispid 17;
    procedure AboutBox; dispid -552;
    function Capture(const Who: WideString; const Why: WideString): CaptureData; dispid 30;
    function CheckHostDocument: SignedData; dispid 31;
    function CheckHostDocument2: SignedData; dispid 32;
  end;

// *********************************************************************//
// Interface: ISigCtlXHTML2
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {7D70505C-D019-48F1-A4A6-6EA1525366CE}
// *********************************************************************//
  ISigCtlXHTML2 = interface(ISigCtl2)
    ['{7D70505C-D019-48F1-A4A6-6EA1525366CE}']
    function Get_Printer: IDispatch; safecall;
    function CheckHostDocument: SignedData; safecall;
    function CheckHostDocument2: SignedData; safecall;
    property Printer: IDispatch read Get_Printer;
  end;

// *********************************************************************//
// DispIntf:  ISigCtlXHTML2Disp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {7D70505C-D019-48F1-A4A6-6EA1525366CE}
// *********************************************************************//
  ISigCtlXHTML2Disp = dispinterface
    ['{7D70505C-D019-48F1-A4A6-6EA1525366CE}']
    property Printer: IDispatch readonly dispid 100;
    function CheckHostDocument: SignedData; dispid 150;
    function CheckHostDocument2: SignedData; dispid 151;
    property BackColor: OLE_COLOR dispid -501;
    property BackStyle: Integer dispid -502;
    property BorderColor: OLE_COLOR dispid -503;
    property BorderStyle: Integer dispid -504;
    property BorderWidth: Integer dispid -505;
    property Font: IFontDisp dispid -512;
    property ForeColor: OLE_COLOR dispid -513;
    property Enabled: WordBool dispid -514;
    property TabStop: WordBool dispid -516;
    property Caption: WideString dispid -518;
    property BorderVisible: WordBool dispid -519;
    property Signature: IDispatch dispid 1;
    property CtlPadding: Smallint dispid 2;
    property DisplayMode: DisplayMode dispid 3;
    property Zoom: Smallint dispid 4;
    property Rotation: Smallint dispid 5;
    property InkColor: OLE_COLOR dispid 6;
    property InkWidth: Single dispid 7;
    property ShowWho: ShowText dispid 8;
    property ShowWhen: ShowText dispid 9;
    property ShowWhy: ShowText dispid 12;
    property WhenFormat: WideString dispid 10;
    property AppData[Key: OleVariant]: OleVariant dispid 11;
    property InputWho: WideString dispid 13;
    property InputWhy: WideString dispid 14;
    property InputData: WideString dispid 15;
    property InputSignature: WideString dispid 16;
    function Capture(const Who: WideString; const Why: WideString; What: OleVariant; Key: OleVariant): CaptureResult; dispid 20;
    procedure AboutBox; dispid -552;
    function SetProperty(const Name: WideString; Value: OleVariant): WordBool; dispid 21;
    function GetProperty(const Name: WideString): OleVariant; dispid 22;
  end;

// *********************************************************************//
// Interface: ISigCtlXHTML3
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {38505341-4179-4897-93A6-6555B9340279}
// *********************************************************************//
  ISigCtlXHTML3 = interface(ISigCtlXHTML2)
    ['{38505341-4179-4897-93A6-6555B9340279}']
    procedure InsertMarkup(const Id: WideString; const Text: WideString); safecall;
  end;

// *********************************************************************//
// DispIntf:  ISigCtlXHTML3Disp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {38505341-4179-4897-93A6-6555B9340279}
// *********************************************************************//
  ISigCtlXHTML3Disp = dispinterface
    ['{38505341-4179-4897-93A6-6555B9340279}']
    procedure InsertMarkup(const Id: WideString; const Text: WideString); dispid 160;
    property Printer: IDispatch readonly dispid 100;
    function CheckHostDocument: SignedData; dispid 150;
    function CheckHostDocument2: SignedData; dispid 151;
    property BackColor: OLE_COLOR dispid -501;
    property BackStyle: Integer dispid -502;
    property BorderColor: OLE_COLOR dispid -503;
    property BorderStyle: Integer dispid -504;
    property BorderWidth: Integer dispid -505;
    property Font: IFontDisp dispid -512;
    property ForeColor: OLE_COLOR dispid -513;
    property Enabled: WordBool dispid -514;
    property TabStop: WordBool dispid -516;
    property Caption: WideString dispid -518;
    property BorderVisible: WordBool dispid -519;
    property Signature: IDispatch dispid 1;
    property CtlPadding: Smallint dispid 2;
    property DisplayMode: DisplayMode dispid 3;
    property Zoom: Smallint dispid 4;
    property Rotation: Smallint dispid 5;
    property InkColor: OLE_COLOR dispid 6;
    property InkWidth: Single dispid 7;
    property ShowWho: ShowText dispid 8;
    property ShowWhen: ShowText dispid 9;
    property ShowWhy: ShowText dispid 12;
    property WhenFormat: WideString dispid 10;
    property AppData[Key: OleVariant]: OleVariant dispid 11;
    property InputWho: WideString dispid 13;
    property InputWhy: WideString dispid 14;
    property InputData: WideString dispid 15;
    property InputSignature: WideString dispid 16;
    function Capture(const Who: WideString; const Why: WideString; What: OleVariant; Key: OleVariant): CaptureResult; dispid 20;
    procedure AboutBox; dispid -552;
    function SetProperty(const Name: WideString; Value: OleVariant): WordBool; dispid 21;
    function GetProperty(const Name: WideString): OleVariant; dispid 22;
  end;

// *********************************************************************//
// Interface: ISigCtlXHTML4
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {6D4C830D-FFE3-4815-B074-E8602DAF4BF5}
// *********************************************************************//
  ISigCtlXHTML4 = interface(ISigCtlXHTML3)
    ['{6D4C830D-FFE3-4815-B074-E8602DAF4BF5}']
    function Get_Licence: OleVariant; safecall;
    procedure Set_Licence(pVal: OleVariant); safecall;
    procedure Set_Properties(const Param1: WideString); safecall;
    property Licence: OleVariant read Get_Licence write Set_Licence;
    property Properties: WideString write Set_Properties;
  end;

// *********************************************************************//
// DispIntf:  ISigCtlXHTML4Disp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {6D4C830D-FFE3-4815-B074-E8602DAF4BF5}
// *********************************************************************//
  ISigCtlXHTML4Disp = dispinterface
    ['{6D4C830D-FFE3-4815-B074-E8602DAF4BF5}']
    property Licence: OleVariant dispid 101;
    property Properties: WideString writeonly dispid 102;
    procedure InsertMarkup(const Id: WideString; const Text: WideString); dispid 160;
    property Printer: IDispatch readonly dispid 100;
    function CheckHostDocument: SignedData; dispid 150;
    function CheckHostDocument2: SignedData; dispid 151;
    property BackColor: OLE_COLOR dispid -501;
    property BackStyle: Integer dispid -502;
    property BorderColor: OLE_COLOR dispid -503;
    property BorderStyle: Integer dispid -504;
    property BorderWidth: Integer dispid -505;
    property Font: IFontDisp dispid -512;
    property ForeColor: OLE_COLOR dispid -513;
    property Enabled: WordBool dispid -514;
    property TabStop: WordBool dispid -516;
    property Caption: WideString dispid -518;
    property BorderVisible: WordBool dispid -519;
    property Signature: IDispatch dispid 1;
    property CtlPadding: Smallint dispid 2;
    property DisplayMode: DisplayMode dispid 3;
    property Zoom: Smallint dispid 4;
    property Rotation: Smallint dispid 5;
    property InkColor: OLE_COLOR dispid 6;
    property InkWidth: Single dispid 7;
    property ShowWho: ShowText dispid 8;
    property ShowWhen: ShowText dispid 9;
    property ShowWhy: ShowText dispid 12;
    property WhenFormat: WideString dispid 10;
    property AppData[Key: OleVariant]: OleVariant dispid 11;
    property InputWho: WideString dispid 13;
    property InputWhy: WideString dispid 14;
    property InputData: WideString dispid 15;
    property InputSignature: WideString dispid 16;
    function Capture(const Who: WideString; const Why: WideString; What: OleVariant; Key: OleVariant): CaptureResult; dispid 20;
    procedure AboutBox; dispid -552;
    function SetProperty(const Name: WideString; Value: OleVariant): WordBool; dispid 21;
    function GetProperty(const Name: WideString): OleVariant; dispid 22;
  end;

// *********************************************************************//
// Interface: IImgCtlXHTML
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {111EDBBA-8410-4116-8B0F-E4FC322C841D}
// *********************************************************************//
  IImgCtlXHTML = interface(IDispatch)
    ['{111EDBBA-8410-4116-8B0F-E4FC322C841D}']
    function Get_ImageHex: WideString; safecall;
    procedure Set_ImageHex(const pVal: WideString); safecall;
    function Get_ImageBase64: WideString; safecall;
    procedure Set_ImageBase64(const pVal: WideString); safecall;
    property ImageHex: WideString read Get_ImageHex write Set_ImageHex;
    property ImageBase64: WideString read Get_ImageBase64 write Set_ImageBase64;
  end;

// *********************************************************************//
// DispIntf:  IImgCtlXHTMLDisp
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {111EDBBA-8410-4116-8B0F-E4FC322C841D}
// *********************************************************************//
  IImgCtlXHTMLDisp = dispinterface
    ['{111EDBBA-8410-4116-8B0F-E4FC322C841D}']
    property ImageHex: WideString dispid 1;
    property ImageBase64: WideString dispid 2;
  end;

// *********************************************************************//
// Interface: IImgCtlXHTML2
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {DF949DF0-E2E6-440D-A539-A52904C4D92C}
// *********************************************************************//
  IImgCtlXHTML2 = interface(IImgCtlXHTML)
    ['{DF949DF0-E2E6-440D-A539-A52904C4D92C}']
    function Get_ResizeToImage: WordBool; safecall;
    procedure Set_ResizeToImage(pVal: WordBool); safecall;
    function SetProperty(const Name: WideString; Value: OleVariant): WordBool; safecall;
    function GetProperty(const Name: WideString): OleVariant; safecall;
    property ResizeToImage: WordBool read Get_ResizeToImage write Set_ResizeToImage;
  end;

// *********************************************************************//
// DispIntf:  IImgCtlXHTML2Disp
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {DF949DF0-E2E6-440D-A539-A52904C4D92C}
// *********************************************************************//
  IImgCtlXHTML2Disp = dispinterface
    ['{DF949DF0-E2E6-440D-A539-A52904C4D92C}']
    property ResizeToImage: WordBool dispid 3;
    function SetProperty(const Name: WideString; Value: OleVariant): WordBool; dispid 20;
    function GetProperty(const Name: WideString): OleVariant; dispid 21;
    property ImageHex: WideString dispid 1;
    property ImageBase64: WideString dispid 2;
  end;

// *********************************************************************//
// Interface: IImgCtlXHTML3
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {170A8200-045A-4687-9DAD-A017F8E331C6}
// *********************************************************************//
  IImgCtlXHTML3 = interface(IImgCtlXHTML2)
    ['{170A8200-045A-4687-9DAD-A017F8E331C6}']
    function Get_Licence: OleVariant; safecall;
    procedure Set_Licence(pVal: OleVariant); safecall;
    procedure Set_Properties(const Param1: WideString); safecall;
    property Licence: OleVariant read Get_Licence write Set_Licence;
    property Properties: WideString write Set_Properties;
  end;

// *********************************************************************//
// DispIntf:  IImgCtlXHTML3Disp
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {170A8200-045A-4687-9DAD-A017F8E331C6}
// *********************************************************************//
  IImgCtlXHTML3Disp = dispinterface
    ['{170A8200-045A-4687-9DAD-A017F8E331C6}']
    property Licence: OleVariant dispid 4;
    property Properties: WideString writeonly dispid 5;
    property ResizeToImage: WordBool dispid 3;
    function SetProperty(const Name: WideString; Value: OleVariant): WordBool; dispid 20;
    function GetProperty(const Name: WideString): OleVariant; dispid 21;
    property ImageHex: WideString dispid 1;
    property ImageBase64: WideString dispid 2;
  end;

// *********************************************************************//
// Interface: IOnLoadHandler
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {1D6154F4-F0DD-4F8B-8F48-F0CA4BA91B27}
// *********************************************************************//
  IOnLoadHandler = interface(IDispatch)
    ['{1D6154F4-F0DD-4F8B-8F48-F0CA4BA91B27}']
    procedure OnLoad; safecall;
  end;

// *********************************************************************//
// DispIntf:  IOnLoadHandlerDisp
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {1D6154F4-F0DD-4F8B-8F48-F0CA4BA91B27}
// *********************************************************************//
  IOnLoadHandlerDisp = dispinterface
    ['{1D6154F4-F0DD-4F8B-8F48-F0CA4BA91B27}']
    procedure OnLoad; dispid 0;
  end;

// *********************************************************************//
// Interface: ICustomSetup
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {94F04BC1-270D-465D-AFFF-7B3B4E89914A}
// *********************************************************************//
  ICustomSetup = interface(IDispatch)
    ['{94F04BC1-270D-465D-AFFF-7B3B4E89914A}']
    function Initialize(const P1: WideString; const P2: WideString): Smallint; safecall;
  end;

// *********************************************************************//
// DispIntf:  ICustomSetupDisp
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {94F04BC1-270D-465D-AFFF-7B3B4E89914A}
// *********************************************************************//
  ICustomSetupDisp = dispinterface
    ['{94F04BC1-270D-465D-AFFF-7B3B4E89914A}']
    function Initialize(const P1: WideString; const P2: WideString): Smallint; dispid 1;
  end;

// *********************************************************************//
// The Class CoSigObj provides a Create and CreateRemote method to          
// create instances of the default interface ISigObj3 exposed by              
// the CoClass SigObj. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoSigObj = class
    class function Create: ISigObj3;
    class function CreateRemote(const MachineName: string): ISigObj3;
  end;


// *********************************************************************//
// OLE Control Proxy class declaration
// Control Name     : TSigCtl
// Help String      : SigCtl Class
// Default Interface: ISigCtl3
// Def. Intf. DISP? : No
// Event   Interface: _ISigCtlEvents2
// TypeFlags        : (2) CanCreate
// *********************************************************************//
  TSigCtlPreCapture = procedure(ASender: TObject; const Who: WideString; const Why: WideString; 
                                                  var Continue: WordBool) of object;
  TSigCtlPostCapture = procedure(ASender: TObject; CaptureStatus: Integer) of object;

  TSigCtl = class(TOleControl)
  private
    FOnPreCapture: TSigCtlPreCapture;
    FOnPostCapture: TSigCtlPostCapture;
    FOnRemove: TNotifyEvent;
    FIntf: ISigCtl3;
    function  GetControlInterface: ISigCtl3;
  protected
    procedure CreateControl;
    procedure InitControlData; override;
    function Get_Signature: IDispatch;
    procedure Set_Signature(const ppVal: IDispatch);
    function Get_AppData(Key: OleVariant): OleVariant;
    procedure Set_AppData(Key: OleVariant; pVal: OleVariant);
    function Get_Licence: OleVariant;
    procedure Set_Licence(pVal: OleVariant);
  public
    function Capture(const Who: WideString; const Why: WideString): CaptureResult; overload;
    function Capture(const Who: WideString; const Why: WideString; What: OleVariant): CaptureResult; overload;
    function Capture(const Who: WideString; const Why: WideString; What: OleVariant; Key: OleVariant): CaptureResult; overload;
    procedure AboutBox;
    function SetProperty(const Name: WideString; Value: OleVariant): WordBool;
    function GetProperty(const Name: WideString): OleVariant;
    property  ControlInterface: ISigCtl3 read GetControlInterface;
    property  DefaultInterface: ISigCtl3 read GetControlInterface;
    property Signature: IDispatch index 1 read GetIDispatchProp write SetIDispatchProp;
    property AppData[Key: OleVariant]: OleVariant read Get_AppData write Set_AppData;
    property Licence: OleVariant index 17 read GetOleVariantProp write SetOleVariantProp;
    property Properties: WideString index 18 write SetWideStringProp;
  published
    property Anchors;
    property  ParentColor;
    property  ParentFont;
    property  Align;
    property  DragCursor;
    property  DragMode;
    property  ParentShowHint;
    property  PopupMenu;
    property  ShowHint;
    property  TabOrder;
    property  Visible;
    property  OnDragDrop;
    property  OnDragOver;
    property  OnEndDrag;
    property  OnEnter;
    property  OnExit;
    property  OnStartDrag;
    property  OnMouseUp;
    property  OnMouseMove;
    property  OnMouseDown;
    property  OnKeyUp;
    property  OnKeyPress;
    property  OnKeyDown;
    property  OnDblClick;
    property  OnClick;
    property BackColor: TColor index -501 read GetTColorProp write SetTColorProp stored False;
    property BackStyle: Integer index -502 read GetIntegerProp write SetIntegerProp stored False;
    property BorderColor: TColor index -503 read GetTColorProp write SetTColorProp stored False;
    property BorderStyle: Integer index -504 read GetIntegerProp write SetIntegerProp stored False;
    property BorderWidth: Integer index -505 read GetIntegerProp write SetIntegerProp stored False;
    property Font: TFont index -512 read GetTFontProp write SetTFontProp stored False;
    property ForeColor: TColor index -513 read GetTColorProp write SetTColorProp stored False;
    property Enabled: WordBool index -514 read GetWordBoolProp write SetWordBoolProp stored False;
    property TabStop: WordBool index -516 read GetWordBoolProp write SetWordBoolProp stored False;
    property Caption: WideString index -518 read GetWideStringProp write SetWideStringProp stored False;
    property BorderVisible: WordBool index -519 read GetWordBoolProp write SetWordBoolProp stored False;
    property CtlPadding: Smallint index 2 read GetSmallintProp write SetSmallintProp stored False;
    property DisplayMode: TOleEnum index 3 read GetTOleEnumProp write SetTOleEnumProp stored False;
    property Zoom: Smallint index 4 read GetSmallintProp write SetSmallintProp stored False;
    property Rotation: Smallint index 5 read GetSmallintProp write SetSmallintProp stored False;
    property InkColor: TColor index 6 read GetTColorProp write SetTColorProp stored False;
    property InkWidth: Single index 7 read GetSingleProp write SetSingleProp stored False;
    property ShowWho: TOleEnum index 8 read GetTOleEnumProp write SetTOleEnumProp stored False;
    property ShowWhen: TOleEnum index 9 read GetTOleEnumProp write SetTOleEnumProp stored False;
    property ShowWhy: TOleEnum index 12 read GetTOleEnumProp write SetTOleEnumProp stored False;
    property WhenFormat: WideString index 10 read GetWideStringProp write SetWideStringProp stored False;
    property InputWho: WideString index 13 read GetWideStringProp write SetWideStringProp stored False;
    property InputWhy: WideString index 14 read GetWideStringProp write SetWideStringProp stored False;
    property InputData: WideString index 15 read GetWideStringProp write SetWideStringProp stored False;
    property InputSignature: WideString index 16 read GetWideStringProp write SetWideStringProp stored False;
    property OnPreCapture: TSigCtlPreCapture read FOnPreCapture write FOnPreCapture;
    property OnPostCapture: TSigCtlPostCapture read FOnPostCapture write FOnPostCapture;
    property OnRemove: TNotifyEvent read FOnRemove write FOnRemove;
  end;

// *********************************************************************//
// The Class CoSigCtlSigDisplayProp provides a Create and CreateRemote method to          
// create instances of the default interface IUnknown exposed by              
// the CoClass SigCtlSigDisplayProp. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoSigCtlSigDisplayProp = class
    class function Create: IUnknown;
    class function CreateRemote(const MachineName: string): IUnknown;
  end;

// *********************************************************************//
// The Class CoSigCtlTextDisplayProp provides a Create and CreateRemote method to          
// create instances of the default interface IUnknown exposed by              
// the CoClass SigCtlTextDisplayProp. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoSigCtlTextDisplayProp = class
    class function Create: IUnknown;
    class function CreateRemote(const MachineName: string): IUnknown;
  end;

// *********************************************************************//
// The Class CoSigCtlBorderProp provides a Create and CreateRemote method to          
// create instances of the default interface IUnknown exposed by              
// the CoClass SigCtlBorderProp. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoSigCtlBorderProp = class
    class function Create: IUnknown;
    class function CreateRemote(const MachineName: string): IUnknown;
  end;

// *********************************************************************//
// The Class CoHash provides a Create and CreateRemote method to          
// create instances of the default interface IHash exposed by              
// the CoClass Hash. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoHash = class
    class function Create: IHash;
    class function CreateRemote(const MachineName: string): IHash;
  end;

// *********************************************************************//
// The Class CoKey provides a Create and CreateRemote method to          
// create instances of the default interface IKey exposed by              
// the CoClass Key. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoKey = class
    class function Create: IKey;
    class function CreateRemote(const MachineName: string): IKey;
  end;


// *********************************************************************//
// OLE Control Proxy class declaration
// Control Name     : TSigCtlXHTML
// Help String      : SigCtlXHTML Class
// Default Interface: ISigCtlXHTML4
// Def. Intf. DISP? : No
// Event   Interface: _ISigCtlEvents2
// TypeFlags        : (2) CanCreate
// *********************************************************************//
  TSigCtlXHTMLPreCapture = procedure(ASender: TObject; const Who: WideString; 
                                                       const Why: WideString; var Continue: WordBool) of object;
  TSigCtlXHTMLPostCapture = procedure(ASender: TObject; CaptureStatus: Integer) of object;

  TSigCtlXHTML = class(TOleControl)
  private
    FOnPreCapture: TSigCtlXHTMLPreCapture;
    FOnPostCapture: TSigCtlXHTMLPostCapture;
    FOnRemove: TNotifyEvent;
    FIntf: ISigCtlXHTML4;
    function  GetControlInterface: ISigCtlXHTML4;
  protected
    procedure CreateControl;
    procedure InitControlData; override;
    function Get_Signature: IDispatch;
    procedure Set_Signature(const ppVal: IDispatch);
    function Get_AppData(Key: OleVariant): OleVariant;
    procedure Set_AppData(Key: OleVariant; pVal: OleVariant);
    function Get_Printer: IDispatch;
    function Get_Licence: OleVariant;
    procedure Set_Licence(pVal: OleVariant);
  public
    function Capture(const Who: WideString; const Why: WideString): CaptureResult; overload;
    function Capture(const Who: WideString; const Why: WideString; What: OleVariant): CaptureResult; overload;
    function Capture(const Who: WideString; const Why: WideString; What: OleVariant; Key: OleVariant): CaptureResult; overload;
    procedure AboutBox;
    function SetProperty(const Name: WideString; Value: OleVariant): WordBool;
    function GetProperty(const Name: WideString): OleVariant;
    function CheckHostDocument: SignedData;
    function CheckHostDocument2: SignedData;
    procedure InsertMarkup(const Id: WideString; const Text: WideString);
    property  ControlInterface: ISigCtlXHTML4 read GetControlInterface;
    property  DefaultInterface: ISigCtlXHTML4 read GetControlInterface;
    property Signature: IDispatch index 1 read GetIDispatchProp write SetIDispatchProp;
    property AppData[Key: OleVariant]: OleVariant read Get_AppData write Set_AppData;
    property Printer: IDispatch index 100 read GetIDispatchProp;
    property Licence: OleVariant index 101 read GetOleVariantProp write SetOleVariantProp;
    property Properties: WideString index 102 write SetWideStringProp;
  published
    property Anchors;
    property  ParentColor;
    property  ParentFont;
    property  Align;
    property  DragCursor;
    property  DragMode;
    property  ParentShowHint;
    property  PopupMenu;
    property  ShowHint;
    property  TabOrder;
    property  Visible;
    property  OnDragDrop;
    property  OnDragOver;
    property  OnEndDrag;
    property  OnEnter;
    property  OnExit;
    property  OnStartDrag;
    property  OnMouseUp;
    property  OnMouseMove;
    property  OnMouseDown;
    property  OnKeyUp;
    property  OnKeyPress;
    property  OnKeyDown;
    property  OnDblClick;
    property  OnClick;
    property BackColor: TColor index -501 read GetTColorProp write SetTColorProp stored False;
    property BackStyle: Integer index -502 read GetIntegerProp write SetIntegerProp stored False;
    property BorderColor: TColor index -503 read GetTColorProp write SetTColorProp stored False;
    property BorderStyle: Integer index -504 read GetIntegerProp write SetIntegerProp stored False;
    property BorderWidth: Integer index -505 read GetIntegerProp write SetIntegerProp stored False;
    property Font: TFont index -512 read GetTFontProp write SetTFontProp stored False;
    property ForeColor: TColor index -513 read GetTColorProp write SetTColorProp stored False;
    property Enabled: WordBool index -514 read GetWordBoolProp write SetWordBoolProp stored False;
    property TabStop: WordBool index -516 read GetWordBoolProp write SetWordBoolProp stored False;
    property Caption: WideString index -518 read GetWideStringProp write SetWideStringProp stored False;
    property BorderVisible: WordBool index -519 read GetWordBoolProp write SetWordBoolProp stored False;
    property CtlPadding: Smallint index 2 read GetSmallintProp write SetSmallintProp stored False;
    property DisplayMode: TOleEnum index 3 read GetTOleEnumProp write SetTOleEnumProp stored False;
    property Zoom: Smallint index 4 read GetSmallintProp write SetSmallintProp stored False;
    property Rotation: Smallint index 5 read GetSmallintProp write SetSmallintProp stored False;
    property InkColor: TColor index 6 read GetTColorProp write SetTColorProp stored False;
    property InkWidth: Single index 7 read GetSingleProp write SetSingleProp stored False;
    property ShowWho: TOleEnum index 8 read GetTOleEnumProp write SetTOleEnumProp stored False;
    property ShowWhen: TOleEnum index 9 read GetTOleEnumProp write SetTOleEnumProp stored False;
    property ShowWhy: TOleEnum index 12 read GetTOleEnumProp write SetTOleEnumProp stored False;
    property WhenFormat: WideString index 10 read GetWideStringProp write SetWideStringProp stored False;
    property InputWho: WideString index 13 read GetWideStringProp write SetWideStringProp stored False;
    property InputWhy: WideString index 14 read GetWideStringProp write SetWideStringProp stored False;
    property InputData: WideString index 15 read GetWideStringProp write SetWideStringProp stored False;
    property InputSignature: WideString index 16 read GetWideStringProp write SetWideStringProp stored False;
    property OnPreCapture: TSigCtlXHTMLPreCapture read FOnPreCapture write FOnPreCapture;
    property OnPostCapture: TSigCtlXHTMLPostCapture read FOnPostCapture write FOnPostCapture;
    property OnRemove: TNotifyEvent read FOnRemove write FOnRemove;
  end;


// *********************************************************************//
// OLE Control Proxy class declaration
// Control Name     : TImgCtlXHTML
// Help String      : ImgCtlXHTML Class
// Default Interface: IImgCtlXHTML3
// Def. Intf. DISP? : No
// Event   Interface: 
// TypeFlags        : (2) CanCreate
// *********************************************************************//
  TImgCtlXHTML = class(TOleControl)
  private
    FIntf: IImgCtlXHTML3;
    function  GetControlInterface: IImgCtlXHTML3;
  protected
    procedure CreateControl;
    procedure InitControlData; override;
    function Get_Licence: OleVariant;
    procedure Set_Licence(pVal: OleVariant);
  public
    property  ControlInterface: IImgCtlXHTML3 read GetControlInterface;
    property  DefaultInterface: IImgCtlXHTML3 read GetControlInterface;
    property Licence: OleVariant index 4 read GetOleVariantProp write SetOleVariantProp;
    property Properties: WideString index 5 write SetWideStringProp;
  published
    property Anchors;
    property  TabStop;
    property  Align;
    property  DragCursor;
    property  DragMode;
    property  ParentShowHint;
    property  PopupMenu;
    property  ShowHint;
    property  TabOrder;
    property  Visible;
    property  OnDragDrop;
    property  OnDragOver;
    property  OnEndDrag;
    property  OnEnter;
    property  OnExit;
    property  OnStartDrag;
  end;

// *********************************************************************//
// The Class CoOnLoadHandler provides a Create and CreateRemote method to          
// create instances of the default interface IOnLoadHandler exposed by              
// the CoClass OnLoadHandler. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoOnLoadHandler = class
    class function Create: IOnLoadHandler;
    class function CreateRemote(const MachineName: string): IOnLoadHandler;
  end;

// *********************************************************************//
// The Class CoCustomSetup provides a Create and CreateRemote method to          
// create instances of the default interface ICustomSetup exposed by              
// the CoClass CustomSetup. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoCustomSetup = class
    class function Create: ICustomSetup;
    class function CreateRemote(const MachineName: string): ICustomSetup;
  end;

procedure Register;

resourcestring
  dtlServerPage = 'ActiveX';

  dtlOcxPage = 'ActiveX';

implementation

uses System.Win.ComObj;

class function CoSigObj.Create: ISigObj3;
begin
  Result := CreateComObject(CLASS_SigObj) as ISigObj3;
end;

class function CoSigObj.CreateRemote(const MachineName: string): ISigObj3;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_SigObj) as ISigObj3;
end;

procedure TSigCtl.InitControlData;
const
  CEventDispIDs: array [0..2] of DWORD = (
    $00000001, $00000002, $00000003);
  CTFontIDs: array [0..0] of DWORD = (
    $FFFFFE00);
  CControlData: TControlData2 = (
    ClassID:      '{963B1D81-38B8-492E-ACBE-74801D009E9E}';
    EventIID:     '{7423A831-443B-4774-8214-C1B9331858E0}';
    EventCount:   3;
    EventDispIDs: @CEventDispIDs;
    LicenseKey:   nil (*HR:$80004002*);
    Flags:        $0000001F;
    Version:      500;
    FontCount:    1;
    FontIDs:      @CTFontIDs);
begin
  ControlData := @CControlData;
  TControlData2(CControlData).FirstEventOfs := UIntPtr(@@FOnPreCapture) - UIntPtr(Self);
end;

procedure TSigCtl.CreateControl;

  procedure DoCreate;
  begin
    FIntf := IUnknown(OleObject) as ISigCtl3;
  end;

begin
  if FIntf = nil then DoCreate;
end;

function TSigCtl.GetControlInterface: ISigCtl3;
begin
  CreateControl;
  Result := FIntf;
end;

function TSigCtl.Get_Signature: IDispatch;
begin
  Result := DefaultInterface.Signature;
end;

procedure TSigCtl.Set_Signature(const ppVal: IDispatch);
begin
  DefaultInterface.Signature := ppVal;
end;

function TSigCtl.Get_AppData(Key: OleVariant): OleVariant;
begin
  Result := DefaultInterface.AppData[Key];
end;

procedure TSigCtl.Set_AppData(Key: OleVariant; pVal: OleVariant);
begin
  DefaultInterface.AppData[Key] := pVal;
end;

function TSigCtl.Get_Licence: OleVariant;
begin
  Result := DefaultInterface.Licence;
end;

procedure TSigCtl.Set_Licence(pVal: OleVariant);
begin
  DefaultInterface.Licence := pVal;
end;

function TSigCtl.Capture(const Who: WideString; const Why: WideString): CaptureResult;
var
  EmptyParam: OleVariant;
begin
  EmptyParam := System.Variants.EmptyParam;
  Result := DefaultInterface.Capture(Who, Why, EmptyParam, EmptyParam);
end;

function TSigCtl.Capture(const Who: WideString; const Why: WideString; What: OleVariant): CaptureResult;
var
  EmptyParam: OleVariant;
begin
  EmptyParam := System.Variants.EmptyParam;
  Result := DefaultInterface.Capture(Who, Why, What, EmptyParam);
end;

function TSigCtl.Capture(const Who: WideString; const Why: WideString; What: OleVariant; 
                         Key: OleVariant): CaptureResult;
begin
  Result := DefaultInterface.Capture(Who, Why, What, Key);
end;

procedure TSigCtl.AboutBox;
begin
  DefaultInterface.AboutBox;
end;

function TSigCtl.SetProperty(const Name: WideString; Value: OleVariant): WordBool;
begin
  Result := DefaultInterface.SetProperty(Name, Value);
end;

function TSigCtl.GetProperty(const Name: WideString): OleVariant;
begin
  Result := DefaultInterface.GetProperty(Name);
end;

class function CoSigCtlSigDisplayProp.Create: IUnknown;
begin
  Result := CreateComObject(CLASS_SigCtlSigDisplayProp) as IUnknown;
end;

class function CoSigCtlSigDisplayProp.CreateRemote(const MachineName: string): IUnknown;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_SigCtlSigDisplayProp) as IUnknown;
end;

class function CoSigCtlTextDisplayProp.Create: IUnknown;
begin
  Result := CreateComObject(CLASS_SigCtlTextDisplayProp) as IUnknown;
end;

class function CoSigCtlTextDisplayProp.CreateRemote(const MachineName: string): IUnknown;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_SigCtlTextDisplayProp) as IUnknown;
end;

class function CoSigCtlBorderProp.Create: IUnknown;
begin
  Result := CreateComObject(CLASS_SigCtlBorderProp) as IUnknown;
end;

class function CoSigCtlBorderProp.CreateRemote(const MachineName: string): IUnknown;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_SigCtlBorderProp) as IUnknown;
end;

class function CoHash.Create: IHash;
begin
  Result := CreateComObject(CLASS_Hash) as IHash;
end;

class function CoHash.CreateRemote(const MachineName: string): IHash;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_Hash) as IHash;
end;

class function CoKey.Create: IKey;
begin
  Result := CreateComObject(CLASS_Key) as IKey;
end;

class function CoKey.CreateRemote(const MachineName: string): IKey;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_Key) as IKey;
end;

procedure TSigCtlXHTML.InitControlData;
const
  CEventDispIDs: array [0..2] of DWORD = (
    $00000001, $00000002, $00000003);
  CTFontIDs: array [0..0] of DWORD = (
    $FFFFFE00);
  CControlData: TControlData2 = (
    ClassID:      '{F5DC9DFE-FD38-4455-A783-4B3F31B2D229}';
    EventIID:     '{7423A831-443B-4774-8214-C1B9331858E0}';
    EventCount:   3;
    EventDispIDs: @CEventDispIDs;
    LicenseKey:   nil (*HR:$80004002*);
    Flags:        $0000001F;
    Version:      500;
    FontCount:    1;
    FontIDs:      @CTFontIDs);
begin
  ControlData := @CControlData;
  TControlData2(CControlData).FirstEventOfs := UIntPtr(@@FOnPreCapture) - UIntPtr(Self);
end;

procedure TSigCtlXHTML.CreateControl;

  procedure DoCreate;
  begin
    FIntf := IUnknown(OleObject) as ISigCtlXHTML4;
  end;

begin
  if FIntf = nil then DoCreate;
end;

function TSigCtlXHTML.GetControlInterface: ISigCtlXHTML4;
begin
  CreateControl;
  Result := FIntf;
end;

function TSigCtlXHTML.Get_Signature: IDispatch;
begin
  Result := DefaultInterface.Signature;
end;

procedure TSigCtlXHTML.Set_Signature(const ppVal: IDispatch);
begin
  DefaultInterface.Signature := ppVal;
end;

function TSigCtlXHTML.Get_AppData(Key: OleVariant): OleVariant;
begin
  Result := DefaultInterface.AppData[Key];
end;

procedure TSigCtlXHTML.Set_AppData(Key: OleVariant; pVal: OleVariant);
begin
  DefaultInterface.AppData[Key] := pVal;
end;

function TSigCtlXHTML.Get_Printer: IDispatch;
begin
  Result := DefaultInterface.Printer;
end;

function TSigCtlXHTML.Get_Licence: OleVariant;
begin
  Result := DefaultInterface.Licence;
end;

procedure TSigCtlXHTML.Set_Licence(pVal: OleVariant);
begin
  DefaultInterface.Licence := pVal;
end;

function TSigCtlXHTML.Capture(const Who: WideString; const Why: WideString): CaptureResult;
var
  EmptyParam: OleVariant;
begin
  EmptyParam := System.Variants.EmptyParam;
  Result := DefaultInterface.Capture(Who, Why, EmptyParam, EmptyParam);
end;

function TSigCtlXHTML.Capture(const Who: WideString; const Why: WideString; What: OleVariant): CaptureResult;
var
  EmptyParam: OleVariant;
begin
  EmptyParam := System.Variants.EmptyParam;
  Result := DefaultInterface.Capture(Who, Why, What, EmptyParam);
end;

function TSigCtlXHTML.Capture(const Who: WideString; const Why: WideString; What: OleVariant; 
                              Key: OleVariant): CaptureResult;
begin
  Result := DefaultInterface.Capture(Who, Why, What, Key);
end;

procedure TSigCtlXHTML.AboutBox;
begin
  DefaultInterface.AboutBox;
end;

function TSigCtlXHTML.SetProperty(const Name: WideString; Value: OleVariant): WordBool;
begin
  Result := DefaultInterface.SetProperty(Name, Value);
end;

function TSigCtlXHTML.GetProperty(const Name: WideString): OleVariant;
begin
  Result := DefaultInterface.GetProperty(Name);
end;

function TSigCtlXHTML.CheckHostDocument: SignedData;
begin
  Result := DefaultInterface.CheckHostDocument;
end;

function TSigCtlXHTML.CheckHostDocument2: SignedData;
begin
  Result := DefaultInterface.CheckHostDocument2;
end;

procedure TSigCtlXHTML.InsertMarkup(const Id: WideString; const Text: WideString);
begin
  DefaultInterface.InsertMarkup(Id, Text);
end;

procedure TImgCtlXHTML.InitControlData;
const
  CControlData: TControlData2 = (
    ClassID:      '{EFFD1818-3060-49A3-9C22-A06F57BBC167}';
    EventIID:     '';
    EventCount:   0;
    EventDispIDs: nil;
    LicenseKey:   nil (*HR:$80004002*);
    Flags:        $00000000;
    Version:      500);
begin
  ControlData := @CControlData;
end;

procedure TImgCtlXHTML.CreateControl;

  procedure DoCreate;
  begin
    FIntf := IUnknown(OleObject) as IImgCtlXHTML3;
  end;

begin
  if FIntf = nil then DoCreate;
end;

function TImgCtlXHTML.GetControlInterface: IImgCtlXHTML3;
begin
  CreateControl;
  Result := FIntf;
end;

function TImgCtlXHTML.Get_Licence: OleVariant;
begin
  Result := DefaultInterface.Licence;
end;

procedure TImgCtlXHTML.Set_Licence(pVal: OleVariant);
begin
  DefaultInterface.Licence := pVal;
end;

class function CoOnLoadHandler.Create: IOnLoadHandler;
begin
  Result := CreateComObject(CLASS_OnLoadHandler) as IOnLoadHandler;
end;

class function CoOnLoadHandler.CreateRemote(const MachineName: string): IOnLoadHandler;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_OnLoadHandler) as IOnLoadHandler;
end;

class function CoCustomSetup.Create: ICustomSetup;
begin
  Result := CreateComObject(CLASS_CustomSetup) as ICustomSetup;
end;

class function CoCustomSetup.CreateRemote(const MachineName: string): ICustomSetup;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_CustomSetup) as ICustomSetup;
end;

procedure Register;
begin
  RegisterComponents(dtlOcxPage, [TSigCtl, TSigCtlXHTML, TImgCtlXHTML]);
end;

end.
