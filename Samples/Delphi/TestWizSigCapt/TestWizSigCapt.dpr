program TestWizSigCapt;

uses
  Forms,
  TestWizSigCaptForm in 'TestWizSigCaptForm.pas' {Form1},
  FlWizCOMLib_TLB in 'c:\dev\sdk2 examples\delphi\DemoButtons\FlWizCOMLib_TLB.pas',
  FLSIGCTLLib_TLB in 'c:\dev\sdk2 examples\delphi\DemoButtons\FLSIGCTLLib_TLB.pas';

{$R *.res}

begin
  Application.Initialize;
  //Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
