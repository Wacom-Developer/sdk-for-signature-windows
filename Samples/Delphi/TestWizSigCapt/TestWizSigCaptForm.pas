(*************************************************************************
  TestWizSigCaptForm.pas
   
  Delphi Signature Capture using wizard control

  The project displays a form with a button to start signature capture using the Wizard script
  The captured signature is encoded in an image file which is displayed on the form

  Copyright (c) 2015 Wacom GmbH. All rights reserved.
  
***************************************************************************)
unit TestWizSigCaptForm;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics,
  Controls, Forms, Dialogs, FlWizCOMLib_TLB, StdCtrls, ActiveX, OleCtrls, FLSIGCTLLib_TLB,
  ExtCtrls, Buttons;

type
  TPad = record
    Model: string;
    TextFont: TFont;
    ButtonFont: TFont;
    SigLineFont: TFont;
    SignatureLineY: Integer;
    WhoY: Integer;
    WhyY: Integer;
    ButtonWidth: Integer;
end;

type
  TForm1 = class(TForm, IDispatch)
    btnSign: TButton;
    Memo1: TMemo;
    Image1: TImage;
    btnCancel: TButton;
    procedure btnSignClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure btnCancelClick(Sender: TObject);

  private
    procedure startWizard();
    procedure step1();
    procedure step2();
    procedure scriptCompleted();
    procedure scriptCancelled();
    procedure closeWizard();

    //functions to capture the events.
    function Invoke(DispID: Integer; const IID: TGUID; LocaleID: Integer; Flags: Word; var Params; VarResult, ExceptInfo, ArgErr: Pointer): HResult; stdcall;
    function DoInvoke (DispID: Integer; const IID: TGUID; LocaleID: Integer; Flags: Word; var dps: TDispParams; pDispIds: PDispIdList;  VarResult, ExcepInfo, ArgErr: Pointer): HResult;
    procedure BuildPositionalDispIds (pDispIds: PDispIdList; const dps: TDispParams);
    procedure PadEvent(const WizCtl1: IDispatch; const id: WideString; EventType: OleVariant);

  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  ScriptIsRunning: bool;
  wizCtl: TWizCtl;
  sigCtl: TSigCtl;
  pad: TPad;
  isCheck: bool;

implementation

{$R *.dfm}

function CreateTPad(model: String; signatureLineY, whoY, whyY,
  textFontSize, buttonFontSize, signLineSize, buttonWith: Integer): TPad;
begin
  Result.Model := model;
  Result.SignatureLineY := signatureLineY;
  Result.WhoY := whoY;
  Result.WhyY := whyY;
  Result.ButtonWidth := buttonWith;

  Result.TextFont := TFont.Create;
  Result.TextFont.Name := 'Verdana';
  Result.TextFont.Size := textFontSize;

  Result.ButtonFont := TFont.Create;
  Result.ButtonFont.Name := 'Verdana';
  Result.ButtonFont.Size := buttonFontSize;

  Result.SigLineFont := TFont.Create;
  Result.SigLineFont.Name := 'Verdana';
  Result.SigLineFont.Size := signLineSize;
end;

procedure TForm1.btnCancelClick(Sender: TObject);
begin
  Memo1.Lines.Add('Cancel...');
  if ScriptIsRunning = True then
  begin
    scriptCancelled();
  end
  else
  begin
    Memo1.Lines.Add('Script is not running');
  end;
end;

procedure TForm1.btnSignClick(Sender: TObject);
begin
  Memo1.Lines.Add('Sign...');
  isCheck := false;
  if not ScriptIsRunning then
  begin
    startWizard();
  end
  else
  begin
    Memo1.Lines.Add('Script is already running');
  end;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  ScriptIsRunning := false;
  Image1.Canvas.Create;
end;

procedure TForm1.startWizard;
var
  success: bool;
begin
  wizCtl := TWizCtl.Create(Form1);
  success := wizCtl.DefaultInterface.PadConnect();
  if success then
  begin
    ScriptIsRunning := true;
    Memo1.Lines.Add('Pad detected: '+IntToStr(wizCtl.DefaultInterface.PadWidth)+' x '+IntToStr(wizCtl.DefaultInterface.PadHeight));

    case wizCtl.DefaultInterface.PadWidth of
      396: begin
        pad := CreateTPad('STU-300', 60, 200, 200, 8, 8, 16, 70); // 396 x 100
      end;
      640: begin
        pad := CreateTPad('STU-500', 300, 360, 390, 16, 22, 32, 110); // 640 x 800
      end;
      800: begin
        pad := CreateTPad('STU-520 or STU-530', 300, 360, 390, 16, 22, 32, 110); // 800 x 480
      end;
      320: begin
        pad := CreateTPad('STU-430 or ePad', 100, 130, 150, 10, 12, 16, 110); // 320 x 200
      end;
      else
        Memo1.Lines.Add('No compatible device found');
    end;

    Memo1.Lines.Add(Pad.Model);
    step1();
  end
  else
  begin
    Memo1.Lines.Add('Unable to connect to tablet');
  end;
end;

procedure TForm1.step1;
var
  varNull: OleVariant;
begin
  wizCtl.DefaultInterface.Reset;

  // insert checkbox
  wizCtl.DefaultInterface.Font := IFontDisp(IDispatch(FontToOleFont(pad.TextFont)));
  wizCtl.DefaultInterface.AddObject(ObjectCheckbox, 'Check', 'centre', 'middle', 'I have read and I accept the terms and conditions', 2);

  // insert the buttons
  wizCtl.DefaultInterface.Font := IFontDisp(IDispatch(FontToOleFont(pad.ButtonFont)));
  wizCtl.DefaultInterface.AddObject(ObjectButton, 'Cancel', 'left', 'bottom', 'Cancel', Pad.ButtonWidth);
  wizCtl.DefaultInterface.AddObject(ObjectButton, 'Next', 'right', 'bottom', 'Next', Pad.ButtonWidth);

  // set callback when a button is pressed
  wizCtl.DefaultInterface.SetEventHandler(self);

  wizCtl.DefaultInterface.Display;
end;

procedure TForm1.step2;
var
  varNull: OleVariant;
begin
  wizCtl.DefaultInterface.Reset;

  // insert message
  wizCtl.DefaultInterface.Font := IFontDisp(IDispatch(FontToOleFont(pad.TextFont)));
  wizCtl.DefaultInterface.AddObject(ObjectText, 'txt', 'centre', 'top', 'Please sign below...', varNull);

  // insert a signature line
  wizCtl.DefaultInterface.Font := IFontDisp(IDispatch(FontToOleFont(pad.SigLineFont)));
  if pad.Model = 'STU-300' then
    wizCtl.DefaultInterface.AddObject(ObjectText, 'txt', 'left', pad.SignatureLineY, 'X..............................', varNull)
  else
    wizCtl.DefaultInterface.AddObject(ObjectText, 'txt', 'centre', pad.SignatureLineY, 'X..............................', varNull);

  // insert the signature control
  wizCtl.DefaultInterface.Font := IFontDisp(IDispatch(FontToOleFont(pad.TextFont)));
  sigCtl := TSigCtl.Create(Form1);
  wizCtl.DefaultInterface.AddObject(ObjectSignature, 'Sig', 0, 0, sigCtl.Signature, varNull);

  // provide who and why for sig capture
  wizCtl.DefaultInterface.AddObject(ObjectText, 'who', 'right', pad.WhoY, 'J Smith', varNull);
  wizCtl.DefaultInterface.AddObject(ObjectText, 'why', 'right', pad.WhyY, 'I certify that the information is correct', varNull);

  // insert the buttons
  wizCtl.DefaultInterface.Font := IFontDisp(IDispatch(FontToOleFont(pad.ButtonFont)));
  if Pad.Model = 'STU-300' then
  begin
    wizCtl.DefaultInterface.AddObject(ObjectButton, 'Cancel', 'right', 'top', 'Cancel', Pad.ButtonWidth);
    wizCtl.DefaultInterface.AddObject(ObjectButton, 'Clear', 'right', 'middle', 'Clear', Pad.ButtonWidth);
    wizCtl.DefaultInterface.AddObject(ObjectButton, 'Ok', 'right', 'bottom', 'Ok', Pad.ButtonWidth);
  end
  else
  begin
    wizCtl.DefaultInterface.AddObject(ObjectButton, 'Cancel', 'left', 'bottom', 'Cancel', Pad.ButtonWidth);
    wizCtl.DefaultInterface.AddObject(ObjectButton, 'Clear', 'center', 'bottom', 'Clear', Pad.ButtonWidth);
    wizCtl.DefaultInterface.AddObject(ObjectButton, 'Ok', 'right', 'bottom', 'Ok', Pad.ButtonWidth);
  end;

  // set callback when a button is pressed
  wizCtl.DefaultInterface.SetEventHandler(self);

  wizCtl.DefaultInterface.Display;
end;

function TForm1.Invoke(
  DispID     : Integer;
  const IID  : TGUID;
  LocaleID   : Integer;
  Flags      : Word;
  var Params;
  VarResult,
  ExceptInfo,
  ArgErr     : Pointer
  ): HResult;
var
  dps        : TDispParams absolute Params;
  bHasParams : boolean;
  pDispIds : PDispIdList;
  iDispIdsSize : integer;
begin
  if (Flags AND DISPATCH_METHOD = 0) then
    Raise Exception.Create('Only method call supported');

  pDispIds := nil;
  iDispIdsSize := 0;
  bHasParams := (dps.cArgs > 0);

  if (bHasParams) then
  begin
    iDispIdsSize := dps.cArgs * SizeOf (TDispId);
    GetMem (pDispIds, iDispIdsSize);
  end;

  try
    if (bHasParams) then  BuildPositionalDispIds (pDispIds, dps);
    Result := DoInvoke(DispID, IID, LocaleID, Flags, dps, pDispIds, VarResult, ExceptInfo, ArgErr);
  finally
    if (bHasParams) then
      FreeMem (pDispIds, iDispIdsSize);
  end;

end;

function TForm1.DoInvoke (DispID: Integer; const IID: TGUID; LocaleID: Integer; Flags: Word; var dps: TDispParams; pDispIds: PDispIdList; VarResult, ExcepInfo, ArgErr: Pointer): HResult;
type
  POleVariant = ^OleVariant;
begin
  Result := DISP_E_MEMBERNOTFOUND;
  case DispId of
    0 :
    begin
      PadEvent (IDispatch (dps.rgvarg^ [pDispIds^ [0]].dispval), dps.rgvarg^ [pDispIds^ [1]].bstrval, OleVariant (dps.rgvarg^ [pDispIds^ [2]]));
      Result := S_OK;
    end;
  end;
end;

procedure TForm1.BuildPositionalDispIds (pDispIds: PDispIdList; const dps: TDispParams);
var
  i: integer;
begin
  Assert (pDispIds <> nil);

  { by default, directly arrange in reverse order }
  for i := 0 to dps.cArgs - 1 do
    pDispIds^ [i] := dps.cArgs - 1 - i;

  { check for named args }
  if (dps.cNamedArgs <= 0) then Exit;

  { parse named args }
  for i := 0 to dps.cNamedArgs - 1 do
    pDispIds^ [dps.rgdispidNamedArgs^ [i]] := i;
end;

procedure TForm1.PadEvent(const WizCtl1: IDispatch; const id: WideString; EventType: OleVariant);
begin

  if id = 'Ok' then
    scriptCompleted()
  else if id = 'Cancel' then
    scriptCancelled()
  else if id = 'Next' then
  begin
    if isCheck then
      step2()
  end
  else if id = 'Check' then
    isCheck := not isCheck
  else
    Memo1.Lines.Add('Unexpected pad event: '+id);
end;

procedure TForm1.scriptCompleted;
var
  fileName: String;
  sigObj1: SigObj;
begin
    Memo1.Lines.Add('scriptCompleted()');
    fileName := 'sig1.bmp';
    sigObj1 := SigObj(sigCtl.Signature);

    sigObj1.ExtraData['AditionalData'] := 'Delphi test: Additional data';
    sigObj1.RenderBitmap(fileName, 200, 150, 'image/bmp', 0.5, $ff0000, $ffffff, -1.0, -1.0, RenderOutputFilename or RenderColor32BPP or RenderEncodeData);
    Image1.Picture.LoadFromFile(fileName);

    closeWizard();
end;

procedure TForm1.scriptCancelled;
begin
  Memo1.Lines.Add('scriptCancelled()');
  closeWizard();
end;

procedure TForm1.closeWizard;
begin
  Memo1.Lines.Add('closeWizard()');
  ScriptIsRunning := False;
  wizCtl.DefaultInterface.Reset;
  wizCtl.DefaultInterface.Display;
  wizCtl.DefaultInterface.PadDisconnect;
  wizCtl.DefaultInterface.SetEventHandler(nil);
end;

end.
