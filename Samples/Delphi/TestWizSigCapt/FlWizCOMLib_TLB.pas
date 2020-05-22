unit FlWizCOMLib_TLB;

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
// File generated on 23/08/2012 13:39:54 from Type Library described below.

// ************************************************************************  //
// Type Lib: C:\Program Files (x86)\Common Files\Florentis\FlWizCOM.dll (1)
// LIBID: {19A2C3E4-BCB2-4792-8B58-50D133F3A536}
// LCID: 0
// Helpfile: 
// HelpString: FlWizCOM 1.0 Type Library
// DepndLst: 
//   (1) v2.0 stdole, (C:\Windows\SysWOW64\stdole2.tlb)
// SYS_KIND: SYS_WIN32
// Errors:
//   Hint: Parameter 'Type' of IInputObj.SetEncryption changed to 'Type_'
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
  FlWizCOMLibMajorVersion = 1;
  FlWizCOMLibMinorVersion = 0;

  LIBID_FlWizCOMLib: TGUID = '{19A2C3E4-BCB2-4792-8B58-50D133F3A536}';

  IID__IWizCtlInternal: TGUID = '{1D8175DD-8278-4BE3-9E6E-E02D7B33AE05}';
  DIID__IWizCtlEvents: TGUID = '{28086C7E-1500-48E1-A02C-4046EB99A9F9}';
  IID__IWizCtlFirefoxNotify: TGUID = '{1C44A99A-0E97-4A8B-BFEF-F7563E9AD6BD}';
  IID__IWizCtlFirefox: TGUID = '{3EF91684-997C-4E0F-9642-6A2D1B217533}';
  IID__IWizControllerSupport: TGUID = '{C75F28A2-8288-4ECE-8A9E-6263A7E52147}';
  IID__IInputObjInternal: TGUID = '{F443B7A8-828F-4891-B0A1-8D7BBEB067CA}';
  IID_IWizCtl: TGUID = '{9B96307C-A4E1-4E3B-BADB-169C5CDBB3BB}';
  IID_IWizCtl2: TGUID = '{B8DE88A3-43EE-4122-A136-96D8C2B481CF}';
  CLASS_WizCtl: TGUID = '{7AA34BD8-C52E-4F8B-A890-B478A209071E}';
  IID_IInputObj: TGUID = '{FF3F2210-41D3-450D-90E2-1DAE8D9A80AA}';
  CLASS_InputObj: TGUID = '{39FFD94F-23D9-441F-AC52-D9E09F0A69E7}';
  IID_IObjectOptions: TGUID = '{71DF95F5-7BBE-4331-A027-D9D404A43992}';
  CLASS_ObjectOptions: TGUID = '{678544E8-49A2-45FB-AFC7-DD6C39CD4A6A}';

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

// Constants for enum TextOptions
type
  TextOptions = TOleEnum;
const
  TextAlignLeft = $00000000;
  TextAlignRight = $00000001;
  TextAlignCentre = $00000002;
  TextAlignJustify = $00000003;

// Constants for enum CheckboxOptions
type
  CheckboxOptions = TOleEnum;
const
  CheckboxUnchecked = $00000000;
  CheckboxChecked = $00000001;
  CheckboxDisplayTick = $00000002;
  CheckboxDisplayCross = $00000004;

// Constants for enum PrimitiveOptions
type
  PrimitiveOptions = TOleEnum;
const
  PrimitiveLineSolid = $00000001;
  PrimitiveLineDashed = $00000002;
  PrimitiveOutline = $00000004;
  PrimitiveFill = $00000008;
  PrimitiveFillXOR = $00000010;

// Constants for enum EventType
type
  EventType = TOleEnum;
const
  EvTextClicked = $00000000;
  EvButtonClicked = $00000001;
  EvCheckboxChecked = $00000002;
  EvCheckboxUnchecked = $00000003;
  EvInputMinReached = $00000004;
  EvInputMaxReached = $00000005;
  EvInputExceeded = $00000006;

// Constants for enum InputEchoOptions
type
  InputEchoOptions = TOleEnum;
const
  EchoNoSpacing = $00000000;
  EchoHalfSpacing = $00000001;
  EchoSingleSpacing = $00000002;
  EchoDoubleSpacing = $00000004;
  EchoUnderline = $00000008;

// Constants for enum EncryptAlg
type
  EncryptAlg = TOleEnum;
const
  EncryptNone = $00000000;
  EncryptTripleDES = $00000001;

// Constants for enum ObjectType
type
  ObjectType = TOleEnum;
const
  ObjectText = $00000000;
  ObjectButton = $00000001;
  ObjectCheckbox = $00000002;
  ObjectSignature = $00000003;
  ObjectInput = $00000004;
  ObjectInputEcho = $00000005;
  ObjectHash = $00000006;
  ObjectImage = $00000007;
  ObjectDisplayAtShutdown = $00000008;
  ObjectInking = $00000009;

// Constants for enum PrimitiveType
type
  PrimitiveType = TOleEnum;
const
  PrimitiveLine = $00000000;
  PrimitiveRectangle = $00000001;
  PrimitiveEllipse = $00000002;

type

// *********************************************************************//
// Forward declaration of types defined in TypeLibrary                    
// *********************************************************************//
  _IWizCtlInternal = interface;
  _IWizCtlEvents = dispinterface;
  _IWizCtlFirefoxNotify = interface;
  _IWizCtlFirefox = interface;
  _IWizControllerSupport = interface;
  _IInputObjInternal = interface;
  IWizCtl = interface;
  IWizCtlDisp = dispinterface;
  IWizCtl2 = interface;
  IWizCtl2Disp = dispinterface;
  IInputObj = interface;
  IInputObjDisp = dispinterface;
  IObjectOptions = interface;
  IObjectOptionsDisp = dispinterface;

// *********************************************************************//
// Declaration of CoClasses defined in Type Library                       
// (NOTE: Here we map each CoClass to its Default Interface)              
// *********************************************************************//
  WizCtl = IWizCtl2;
  InputObj = IInputObj;
  ObjectOptions = IObjectOptions;


// *********************************************************************//
// Interface: _IWizCtlInternal
// Flags:     (256) OleAutomation
// GUID:      {1D8175DD-8278-4BE3-9E6E-E02D7B33AE05}
// *********************************************************************//
  _IWizCtlInternal = interface(IUnknown)
    ['{1D8175DD-8278-4BE3-9E6E-E02D7B33AE05}']
    function handleEvent(id: Integer; EvType: OleVariant): HResult; stdcall;
  end;

// *********************************************************************//
// DispIntf:  _IWizCtlEvents
// Flags:     (4096) Dispatchable
// GUID:      {28086C7E-1500-48E1-A02C-4046EB99A9F9}
// *********************************************************************//
  _IWizCtlEvents = dispinterface
    ['{28086C7E-1500-48E1-A02C-4046EB99A9F9}']
    procedure PadEvent(const WizCtl: IDispatch; const id: WideString; EventType: OleVariant); dispid 1;
  end;

// *********************************************************************//
// Interface: _IWizCtlFirefoxNotify
// Flags:     (256) OleAutomation
// GUID:      {1C44A99A-0E97-4A8B-BFEF-F7563E9AD6BD}
// *********************************************************************//
  _IWizCtlFirefoxNotify = interface(IUnknown)
    ['{1C44A99A-0E97-4A8B-BFEF-F7563E9AD6BD}']
    function Notify(what: Smallint): HResult; stdcall;
    function OnPosRectChange(Left: Integer; Top: Integer; Right: Integer; Bottom: Integer): HResult; stdcall;
    function GetDC(out phDC: Integer): HResult; stdcall;
    function handleEvent(const id: WideString; EvType: OleVariant): HResult; stdcall;
  end;

// *********************************************************************//
// Interface: _IWizCtlFirefox
// Flags:     (256) OleAutomation
// GUID:      {3EF91684-997C-4E0F-9642-6A2D1B217533}
// *********************************************************************//
  _IWizCtlFirefox = interface(IUnknown)
    ['{3EF91684-997C-4E0F-9642-6A2D1B217533}']
    function Render(hDC: Integer; Left: Integer; Top: Integer; Right: Integer; Bottom: Integer): HResult; stdcall;
    function SetNotify(const Notify: _IWizCtlFirefoxNotify): HResult; stdcall;
    function OnBeforeNavigate: HResult; stdcall;
    function SetWindow(hWnd: Integer; hDC: Integer): HResult; stdcall;
  end;

// *********************************************************************//
// Interface: _IWizControllerSupport
// Flags:     (256) OleAutomation
// GUID:      {C75F28A2-8288-4ECE-8A9E-6263A7E52147}
// *********************************************************************//
  _IWizControllerSupport = interface(IUnknown)
    ['{C75F28A2-8288-4ECE-8A9E-6263A7E52147}']
    function MeasureObject(ObjType: ObjectType; ObjData: OleVariant; out pWidth: Smallint; 
                           out pHeight: Smallint): HResult; stdcall;
  end;

// *********************************************************************//
// Interface: _IInputObjInternal
// Flags:     (128) NonExtensible
// GUID:      {F443B7A8-828F-4891-B0A1-8D7BBEB067CA}
// *********************************************************************//
  _IInputObjInternal = interface(IUnknown)
    ['{F443B7A8-828F-4891-B0A1-8D7BBEB067CA}']
    function Lock: HResult; stdcall;
    function Unlock: HResult; stdcall;
    function SetValue(const Val: WideString): HResult; stdcall;
  end;

// *********************************************************************//
// Interface: IWizCtl
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {9B96307C-A4E1-4E3B-BADB-169C5CDBB3BB}
// *********************************************************************//
  IWizCtl = interface(IDispatch)
    ['{9B96307C-A4E1-4E3B-BADB-169C5CDBB3BB}']
    procedure Set_BorderStyle(pstyle: Integer); safecall;
    function Get_BorderStyle: Integer; safecall;
    procedure Set_BorderWidth(width: Integer); safecall;
    function Get_BorderWidth: Integer; safecall;
    procedure Set_BackColor(pclr: OLE_COLOR); safecall;
    function Get_BackColor: OLE_COLOR; safecall;
    procedure Set_BorderColor(pclr: OLE_COLOR); safecall;
    function Get_BorderColor: OLE_COLOR; safecall;
    procedure Set_BorderVisible(pbool: WordBool); safecall;
    function Get_BorderVisible: WordBool; safecall;
    procedure _Set_Font(const ppFont: IFontDisp); safecall;
    procedure Set_Font(const ppFont: IFontDisp); safecall;
    function Get_Font: IFontDisp; safecall;
    function Get_InkingPad: WordBool; safecall;
    function Get_EnableWizardDisplay: WordBool; safecall;
    procedure Set_EnableWizardDisplay(pVal: WordBool); safecall;
    function Get_PadWidth: Smallint; safecall;
    procedure Set_PadWidth(pVal: Smallint); safecall;
    function Get_PadHeight: Smallint; safecall;
    procedure Set_PadHeight(pVal: Smallint); safecall;
    function Get_Zoom: Single; safecall;
    procedure Set_Zoom(pVal: Single); safecall;
    function PadConnect: WordBool; safecall;
    procedure PadDisconnect; safecall;
    procedure Reset; safecall;
    procedure AddObject(ObjType: ObjectType; const id: WideString; X: OleVariant; Y: OleVariant; 
                        ObjData: OleVariant; Options: OleVariant); safecall;
    procedure AddPrimitive(PrimType: PrimitiveType; X1: OleVariant; Y1: OleVariant; X2: OleVariant; 
                           Y2: OleVariant; PrimData: OleVariant; Options: OleVariant); safecall;
    function GetObjectState(const id: WideString): OleVariant; safecall;
    procedure SetEventHandler(const Handler: IDispatch); safecall;
    procedure Display; safecall;
    procedure FireClick(const id: WideString); safecall;
    function GetProperty(const Name: WideString): OleVariant; safecall;
    function SetProperty(const Name: WideString; Value: OleVariant): WordBool; safecall;
    property BorderStyle: Integer read Get_BorderStyle write Set_BorderStyle;
    property BorderWidth: Integer read Get_BorderWidth write Set_BorderWidth;
    property BackColor: OLE_COLOR read Get_BackColor write Set_BackColor;
    property BorderColor: OLE_COLOR read Get_BorderColor write Set_BorderColor;
    property BorderVisible: WordBool read Get_BorderVisible write Set_BorderVisible;
    property Font: IFontDisp read Get_Font write Set_Font;
    property InkingPad: WordBool read Get_InkingPad;
    property EnableWizardDisplay: WordBool read Get_EnableWizardDisplay write Set_EnableWizardDisplay;
    property PadWidth: Smallint read Get_PadWidth write Set_PadWidth;
    property PadHeight: Smallint read Get_PadHeight write Set_PadHeight;
    property Zoom: Single read Get_Zoom write Set_Zoom;
  end;

// *********************************************************************//
// DispIntf:  IWizCtlDisp
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {9B96307C-A4E1-4E3B-BADB-169C5CDBB3BB}
// *********************************************************************//
  IWizCtlDisp = dispinterface
    ['{9B96307C-A4E1-4E3B-BADB-169C5CDBB3BB}']
    property BorderStyle: Integer dispid -504;
    property BorderWidth: Integer dispid -505;
    property BackColor: OLE_COLOR dispid -501;
    property BorderColor: OLE_COLOR dispid -503;
    property BorderVisible: WordBool dispid -519;
    property Font: IFontDisp dispid -512;
    property InkingPad: WordBool readonly dispid 1;
    property EnableWizardDisplay: WordBool dispid 2;
    property PadWidth: Smallint dispid 3;
    property PadHeight: Smallint dispid 4;
    property Zoom: Single dispid 5;
    function PadConnect: WordBool; dispid 10;
    procedure PadDisconnect; dispid 11;
    procedure Reset; dispid 12;
    procedure AddObject(ObjType: ObjectType; const id: WideString; X: OleVariant; Y: OleVariant; 
                        ObjData: OleVariant; Options: OleVariant); dispid 13;
    procedure AddPrimitive(PrimType: PrimitiveType; X1: OleVariant; Y1: OleVariant; X2: OleVariant; 
                           Y2: OleVariant; PrimData: OleVariant; Options: OleVariant); dispid 14;
    function GetObjectState(const id: WideString): OleVariant; dispid 15;
    procedure SetEventHandler(const Handler: IDispatch); dispid 16;
    procedure Display; dispid 17;
    procedure FireClick(const id: WideString); dispid 18;
    function GetProperty(const Name: WideString): OleVariant; dispid 19;
    function SetProperty(const Name: WideString; Value: OleVariant): WordBool; dispid 20;
  end;

// *********************************************************************//
// Interface: IWizCtl2
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {B8DE88A3-43EE-4122-A136-96D8C2B481CF}
// *********************************************************************//
  IWizCtl2 = interface(IWizCtl)
    ['{B8DE88A3-43EE-4122-A136-96D8C2B481CF}']
    function Get_Licence: OleVariant; safecall;
    procedure Set_Licence(pVal: OleVariant); safecall;
    procedure Set_Properties(const Param1: WideString); safecall;
    property Licence: OleVariant read Get_Licence write Set_Licence;
    property Properties: WideString write Set_Properties;
  end;

// *********************************************************************//
// DispIntf:  IWizCtl2Disp
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {B8DE88A3-43EE-4122-A136-96D8C2B481CF}
// *********************************************************************//
  IWizCtl2Disp = dispinterface
    ['{B8DE88A3-43EE-4122-A136-96D8C2B481CF}']
    property Licence: OleVariant dispid 6;
    property Properties: WideString writeonly dispid 7;
    property BorderStyle: Integer dispid -504;
    property BorderWidth: Integer dispid -505;
    property BackColor: OLE_COLOR dispid -501;
    property BorderColor: OLE_COLOR dispid -503;
    property BorderVisible: WordBool dispid -519;
    property Font: IFontDisp dispid -512;
    property InkingPad: WordBool readonly dispid 1;
    property EnableWizardDisplay: WordBool dispid 2;
    property PadWidth: Smallint dispid 3;
    property PadHeight: Smallint dispid 4;
    property Zoom: Single dispid 5;
    function PadConnect: WordBool; dispid 10;
    procedure PadDisconnect; dispid 11;
    procedure Reset; dispid 12;
    procedure AddObject(ObjType: ObjectType; const id: WideString; X: OleVariant; Y: OleVariant; 
                        ObjData: OleVariant; Options: OleVariant); dispid 13;
    procedure AddPrimitive(PrimType: PrimitiveType; X1: OleVariant; Y1: OleVariant; X2: OleVariant; 
                           Y2: OleVariant; PrimData: OleVariant; Options: OleVariant); dispid 14;
    function GetObjectState(const id: WideString): OleVariant; dispid 15;
    procedure SetEventHandler(const Handler: IDispatch); dispid 16;
    procedure Display; dispid 17;
    procedure FireClick(const id: WideString); dispid 18;
    function GetProperty(const Name: WideString): OleVariant; dispid 19;
    function SetProperty(const Name: WideString; Value: OleVariant): WordBool; dispid 20;
  end;

// *********************************************************************//
// Interface: IInputObj
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {FF3F2210-41D3-450D-90E2-1DAE8D9A80AA}
// *********************************************************************//
  IInputObj = interface(IDispatch)
    ['{FF3F2210-41D3-450D-90E2-1DAE8D9A80AA}']
    function Get_MinLength: Smallint; safecall;
    procedure Set_MinLength(pVal: Smallint); safecall;
    function Get_MaxLength: Smallint; safecall;
    procedure Set_MaxLength(pVal: Smallint); safecall;
    function Get_Text: WideString; safecall;
    function Get_Data: OleVariant; safecall;
    function Get_EncryptionType: Integer; safecall;
    procedure Clear; safecall;
    procedure SetEncryption(Type_: Integer; Key: OleVariant); safecall;
    function GetProperty(const Name: WideString): OleVariant; safecall;
    function SetProperty(const Name: WideString; Value: OleVariant): WordBool; safecall;
    property MinLength: Smallint read Get_MinLength write Set_MinLength;
    property MaxLength: Smallint read Get_MaxLength write Set_MaxLength;
    property Text: WideString read Get_Text;
    property Data: OleVariant read Get_Data;
    property EncryptionType: Integer read Get_EncryptionType;
  end;

// *********************************************************************//
// DispIntf:  IInputObjDisp
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {FF3F2210-41D3-450D-90E2-1DAE8D9A80AA}
// *********************************************************************//
  IInputObjDisp = dispinterface
    ['{FF3F2210-41D3-450D-90E2-1DAE8D9A80AA}']
    property MinLength: Smallint dispid 1;
    property MaxLength: Smallint dispid 2;
    property Text: WideString readonly dispid 0;
    property Data: OleVariant readonly dispid 3;
    property EncryptionType: Integer readonly dispid 4;
    procedure Clear; dispid 10;
    procedure SetEncryption(Type_: Integer; Key: OleVariant); dispid 11;
    function GetProperty(const Name: WideString): OleVariant; dispid 20;
    function SetProperty(const Name: WideString; Value: OleVariant): WordBool; dispid 21;
  end;

// *********************************************************************//
// Interface: IObjectOptions
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {71DF95F5-7BBE-4331-A027-D9D404A43992}
// *********************************************************************//
  IObjectOptions = interface(IDispatch)
    ['{71DF95F5-7BBE-4331-A027-D9D404A43992}']
    function GetProperty(const Name: WideString): OleVariant; safecall;
    function SetProperty(const Name: WideString; Value: OleVariant): WordBool; safecall;
  end;

// *********************************************************************//
// DispIntf:  IObjectOptionsDisp
// Flags:     (4544) Dual NonExtensible OleAutomation Dispatchable
// GUID:      {71DF95F5-7BBE-4331-A027-D9D404A43992}
// *********************************************************************//
  IObjectOptionsDisp = dispinterface
    ['{71DF95F5-7BBE-4331-A027-D9D404A43992}']
    function GetProperty(const Name: WideString): OleVariant; dispid 1;
    function SetProperty(const Name: WideString; Value: OleVariant): WordBool; dispid 2;
  end;


// *********************************************************************//
// OLE Control Proxy class declaration
// Control Name     : TWizCtl
// Help String      : WizCtl Class
// Default Interface: IWizCtl2
// Def. Intf. DISP? : No
// Event   Interface: _IWizCtlEvents
// TypeFlags        : (2) CanCreate
// *********************************************************************//
  TWizCtlPadEvent = procedure(ASender: TObject; const WizCtl: IDispatch; const id: WideString; 
                                                EventType: OleVariant) of object;

  TWizCtl = class(TOleControl)
  private
    FOnPadEvent: TWizCtlPadEvent;
    FIntf: IWizCtl2;
    function  GetControlInterface: IWizCtl2;
  protected
    procedure CreateControl;
    procedure InitControlData; override;
    function Get_Licence: OleVariant;
    procedure Set_Licence(pVal: OleVariant);
  public
    property  ControlInterface: IWizCtl2 read GetControlInterface;
    property  DefaultInterface: IWizCtl2 read GetControlInterface;
    property Licence: OleVariant index 6 read GetOleVariantProp write SetOleVariantProp;
    property Properties: WideString index 7 write SetWideStringProp;
  published
    property Anchors;
    property  ParentColor;
    property  ParentFont;
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
    property OnPadEvent: TWizCtlPadEvent read FOnPadEvent write FOnPadEvent;
  end;

// *********************************************************************//
// The Class CoInputObj provides a Create and CreateRemote method to          
// create instances of the default interface IInputObj exposed by              
// the CoClass InputObj. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoInputObj = class
    class function Create: IInputObj;
    class function CreateRemote(const MachineName: string): IInputObj;
  end;

// *********************************************************************//
// The Class CoObjectOptions provides a Create and CreateRemote method to          
// create instances of the default interface IObjectOptions exposed by              
// the CoClass ObjectOptions. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoObjectOptions = class
    class function Create: IObjectOptions;
    class function CreateRemote(const MachineName: string): IObjectOptions;
  end;

procedure Register;

resourcestring
  dtlServerPage = 'ActiveX';

  dtlOcxPage = 'ActiveX';

implementation

uses System.Win.ComObj;

procedure TWizCtl.InitControlData;
const
  CEventDispIDs: array [0..0] of DWORD = (
    $00000001);
  CControlData: TControlData2 = (
    ClassID:      '{7AA34BD8-C52E-4F8B-A890-B478A209071E}';
    EventIID:     '{28086C7E-1500-48E1-A02C-4046EB99A9F9}';
    EventCount:   1;
    EventDispIDs: @CEventDispIDs;
    LicenseKey:   nil (*HR:$80004002*);
    Flags:        $00000005;
    Version:      500);
begin
  ControlData := @CControlData;
  TControlData2(CControlData).FirstEventOfs := UIntPtr(@@FOnPadEvent) - UIntPtr(Self);
end;

procedure TWizCtl.CreateControl;

  procedure DoCreate;
  begin
    FIntf := IUnknown(OleObject) as IWizCtl2;
  end;

begin
  if FIntf = nil then DoCreate;
end;

function TWizCtl.GetControlInterface: IWizCtl2;
begin
  CreateControl;
  Result := FIntf;
end;

function TWizCtl.Get_Licence: OleVariant;
begin
  Result := DefaultInterface.Licence;
end;

procedure TWizCtl.Set_Licence(pVal: OleVariant);
begin
  DefaultInterface.Licence := pVal;
end;

class function CoInputObj.Create: IInputObj;
begin
  Result := CreateComObject(CLASS_InputObj) as IInputObj;
end;

class function CoInputObj.CreateRemote(const MachineName: string): IInputObj;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_InputObj) as IInputObj;
end;

class function CoObjectOptions.Create: IObjectOptions;
begin
  Result := CreateComObject(CLASS_ObjectOptions) as IObjectOptions;
end;

class function CoObjectOptions.CreateRemote(const MachineName: string): IObjectOptions;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_ObjectOptions) as IObjectOptions;
end;

procedure Register;
begin
  RegisterComponents(dtlOcxPage, [TWizCtl]);
end;

end.
