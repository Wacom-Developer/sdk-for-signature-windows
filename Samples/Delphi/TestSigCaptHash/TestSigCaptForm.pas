(*************************************************************************
  TestSigCaptForm.pas
   
  Delphi Signature Capture

  The project displays a form with a button to start signature capture
  Contents of the Name field are added to the hash in the signature object.
  Press Verify to check that the current Name field contents match the signed contents 
  The captured signature is encoded in an image file which is displayed on the form
  
  Copyright (c) 2015 Wacom GmbH. All rights reserved.
  
***************************************************************************)
unit TestSigCaptForm;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics,
  Controls, Forms, Dialogs, FLSIGCTLLib_TLB, StdCtrls,
  ExtCtrls;

type
  TForm1 = class(TForm)
    Image1: TImage;
    Memo1: TMemo;
    btnSign: TButton;
    Label1: TLabel;
    Edit1: TEdit;
    Button1: TButton;
    procedure btnSignClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  sigObj1: SigObj;

implementation

{$R *.dfm}

procedure TForm1.btnSignClick(Sender: TObject);
var
  sigCtl: TSigCtl;
  hashObj: Hash;
  res: CaptureResult;
  fileName: String;
begin
  Memo1.Lines.Add('btnSign was pressed');
  sigCtl := TSigCtl.Create(Self);
  hashObj := CoHash.Create();
  hashObj.type_ := HashMD5;
  hashObj.add(Edit1.Text);
  res := sigCtl.Capture('Who', 'Why', hashObj);
  if res = CaptureOK then
  begin
    Memo1.Lines.Add('Signature captured successfully');
    fileName := 'sig1.bmp';
    sigObj1 := SigObj(sigCtl.Signature);
    sigObj1.ExtraData['AdditionalData'] := 'Delphi test: Additional data';
    sigObj1.RenderBitmap(fileName, 200, 150, 'image/bmp', 0.5, $ff0000, $ffffff, -1.0, -1.0, RenderOutputFilename or RenderColor32BPP or RenderEncodeData);
    Image1.Picture.LoadFromFile(fileName);
  end
  else
  begin
    Memo1.Lines.Add('Signature capture error res='+IntToStr(res));
    case res of
    CaptureCancel: begin Memo1.Lines.Add('Signature cancelled'); end;
    CaptureError: begin Memo1.Lines.Add('No capture service available'); end;
    CapturePadError: begin Memo1.Lines.Add('Signing device error'); end;
    else begin Memo1.Lines.Add('Unexpected error code'); end;
    end;
  end;
end;

procedure TForm1.Button1Click(Sender: TObject);
var
  hashObj: Hash;
  res: IntegrityStatus;
begin
  if ((sigObj1 <> nil) and (sigObj1.IsCaptured)) then
  begin
    hashObj := CoHash.Create();
    hashObj.type_ := HashMD5;
    hashObj.add(Edit1.Text);
    res := sigObj1.CheckSignedData(hashObj);
    if (res = IntegrityOK) then
    begin
      Memo1.Lines.Add('Signature Data Ok');
    end
    else begin
      Memo1.Lines.Add('Signature Data Invalid');
    end;
  end
  else begin
    Memo1.Lines.Add('No signature captured');
  end;

end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  Image1.Canvas.Create;
end;

end.
