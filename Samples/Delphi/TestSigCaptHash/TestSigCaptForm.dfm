object Form1: TForm1
  Left = 0
  Top = 0
  BorderStyle = bsDialog
  Caption = 'TestSigCapt'
  ClientHeight = 351
  ClientWidth = 600
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
  object Label1: TLabel
    Left = 248
    Top = 16
    Width = 34
    Height = 13
    Caption = 'Name: '
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
    Left = 248
    Top = 54
    Width = 113
    Height = 57
    Caption = 'Sign'
    TabOrder = 1
    OnClick = btnSignClick
  end
  object Edit1: TEdit
    Left = 296
    Top = 13
    Width = 289
    Height = 21
    TabOrder = 2
  end
  object Button1: TButton
    Left = 392
    Top = 54
    Width = 129
    Height = 57
    Caption = 'Verify'
    TabOrder = 3
    OnClick = Button1Click
  end
end
