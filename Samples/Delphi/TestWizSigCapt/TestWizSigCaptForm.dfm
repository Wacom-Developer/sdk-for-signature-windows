object Form1: TForm1
  Left = 472
  Top = 109
  BorderStyle = bsDialog
  Caption = 'TestWizSigCapt'
  ClientHeight = 298
  ClientWidth = 425
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Image1: TImage
    Left = 24
    Top = 8
    Width = 200
    Height = 150
  end
  object btnSign: TButton
    Left = 248
    Top = 16
    Width = 153
    Height = 49
    Caption = 'Sign'
    TabOrder = 0
    OnClick = btnSignClick
  end
  object Memo1: TMemo
    Left = 24
    Top = 179
    Width = 377
    Height = 105
    TabOrder = 1
  end
  object btnCancel: TButton
    Left = 248
    Top = 96
    Width = 153
    Height = 49
    Caption = 'Cancel'
    TabOrder = 2
    OnClick = btnCancelClick
  end
end
