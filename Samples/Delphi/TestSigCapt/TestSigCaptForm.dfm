object Form1: TForm1
  Left = 0
  Top = 0
  BorderStyle = bsDialog
  Caption = 'TestSigCapt'
  ClientHeight = 351
  ClientWidth = 481
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
    Left = 16
    Top = 16
    Width = 200
    Height = 150
  end
  object Memo1: TMemo
    Left = 16
    Top = 192
    Width = 433
    Height = 129
    ReadOnly = True
    TabOrder = 0
  end
  object btnSign: TButton
    Left = 272
    Top = 64
    Width = 113
    Height = 57
    Caption = 'Sign'
    TabOrder = 1
    OnClick = btnSignClick
  end
end
