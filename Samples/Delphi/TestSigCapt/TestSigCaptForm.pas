(*************************************************************************
  TestSigCaptForm.pas
   
  Delphi Signature Capture

  Demonstrates Signature Capture using Delphi
  
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
    procedure btnSignClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.btnSignClick(Sender: TObject);
var
  sigCtl: TSigCtl;
  res: CaptureResult;
  sigObj1: SigObj;
  fileName: String;
begin
  Memo1.Lines.Add('btnSign was pressed');
  sigCtl := TSigCtl.Create(Self);
  res := sigCtl.Capture('Who', 'Why');
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

procedure TForm1.FormCreate(Sender: TObject);
begin
  Image1.Canvas.Create;
end;

end.
