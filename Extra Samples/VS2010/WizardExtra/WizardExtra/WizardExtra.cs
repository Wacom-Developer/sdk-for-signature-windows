/******************************************************* 

  WizardExtra.cs
  
  Displays a form with a button to start signature capture using the Wizard script
  The wizard script comprises 3 screens - step1, step2 and step3.
  The first screen just contains a checkbox, the second has 2 radio buttons, 
  the third is the actual signature capture.
  The captured signature is encoded in an image file which is overlaid on the form

  The user can progress through the wizard using either the pen on the STU or the mouse on the PC window.
  One drawback is that the Signature SDK does not allow access to the raw pen data
  as it is being generated so it is not possible to reproduce the inking live.
  This means that the signature is only displayed on the PC window after it has
  been fully captured.

  Copyright (c) 2021 Wacom Co. Ltd. All rights reserved.
  
********************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Windows.Controls;
using Florentis;

namespace WizardExtra
{
  public partial class WizardExtra : Form
  {
    bool ScriptIsRunning;         // flag for UI button respones
    WizardCallback Callback;      // For wizard callback 
    StuProps Pad;                 // Global object for holding properties of the STU pad currently in use
    bool isCheck = false;         // Flag indicating whether the user has ticked the checkbox on the first screen
    bool step1MouseHandlerEnabled = false;
    bool step2MouseHandlerEnabled = false;
    bool step3MouseHandlerEnabled = false;
    double imageRatio;            // Ratio of image size between the pad and the image shown in the form on the PC window
    System.Drawing.Image signatureImage;   // Contains the image of the captured signature
    string MouseUpOrigin;                  // Flag indicating which step() was in process when the mouse was last clicked
    Bitmap bitmapStep1;                    // Image bitmap for step1()
    Bitmap bitmapStep2;                    // Image bitmap for step2()
    Bitmap bitmapStep3;                    // Image bitmap for step3()

    // Declare various objects which will be used to draw the buttons, checkbox and radio buttons on the Windows form
    Button btn1;
    Button btn2;
    Button btn3;
    Checkbox checkBox;
    RadioButton radioButtonFemale, radioButtonMale;

    public static string LicenceKey = "eyJhbGciOiJSUzUxMiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiI3YmM5Y2IxYWIxMGE0NmUxODI2N2E5MTJkYTA2ZTI3NiIsImV4cCI6MjE0NzQ4MzY0NywiaWF0IjoxNTYwOTUwMjcyLCJyaWdodHMiOlsiU0lHX1NES19DT1JFIiwiU0lHQ0FQVFhfQUNDRVNTIl0sImRldmljZXMiOlsiV0FDT01fQU5ZIl0sInR5cGUiOiJwcm9kIiwibGljX25hbWUiOiJTaWduYXR1cmUgU0RLIiwid2Fjb21faWQiOiI3YmM5Y2IxYWIxMGE0NmUxODI2N2E5MTJkYTA2ZTI3NiIsImxpY191aWQiOiJiODUyM2ViYi0xOGI3LTQ3OGEtYTlkZS04NDlmZTIyNmIwMDIiLCJhcHBzX3dpbmRvd3MiOltdLCJhcHBzX2lvcyI6W10sImFwcHNfYW5kcm9pZCI6W10sIm1hY2hpbmVfaWRzIjpbXX0.ONy3iYQ7lC6rQhou7rz4iJT_OJ20087gWz7GtCgYX3uNtKjmnEaNuP3QkjgxOK_vgOrTdwzD-nm-ysiTDs2GcPlOdUPErSp_bcX8kFBZVmGLyJtmeInAW6HuSp2-57ngoGFivTH_l1kkQ1KMvzDKHJbRglsPpd4nVHhx9WkvqczXyogldygvl0LRidyPOsS5H2GYmaPiyIp9In6meqeNQ1n9zkxSHo7B11mp_WXJXl0k1pek7py8XYCedCNW5qnLi4UCNlfTd6Mk9qz31arsiWsesPeR9PN121LBJtiPi023yQU8mgb9piw_a-ccciviJuNsEuRDN3sGnqONG3dMSA";
    public static StringFormat sfCentered;

    public static class Stu300Props
    {
      public const int ButtonHeight = 28;
      public const int ButtonWidth = 80;
      public const int CheckBoxHeightSmall = 10;
      public const int CheckBoxWidthSmall = 10;
      public const int CheckBoxHeightLarge = 20;
      public const int CheckBoxWidthLarge = 20;
      public const int PadWidth = 396;
      public const int PadHeight = 100;
      public const string SigLineX = XAxis.Left;
      public const int SigLineY = 60;
      public const string WhoX = XAxis.Right;
      public const int WhoY = 200;
      public const string WhyX = XAxis.Left;
      public const int WhyY = 200;
      public const int FontSize = 8;
      public const int LargeFontSize = 12;
      public const int ButtonFontSize = 16;
      public const int SignLineSize = 16;
      public const int RadioMaleX = 125;
      public const int RadioMaleY = 40;
      public const int RadioFemaleX = 280;
      public const int RadioFemaleY = 40;
      public const int RadioWidth = 10;
      public const string NextButtonX = XAxis.Right;
      public const string NextButtonY = YAxis.Bottom;
      public const string CancelButtonX = XAxis.Left;
      public const string CancelButtonY = YAxis.Bottom;
      public const string CancelSigButtonX = XAxis.Right;
      public const string CancelSigButtonY = YAxis.Top;
      public const string ClearButtonX = XAxis.Right;
      public const string ClearButtonY = YAxis.Middle;
      public const string OKButtonX = XAxis.Right;
      public const string OKButtonY = YAxis.Bottom;

    }

    public static class Stu500Props
    {
      public const int ButtonFontSize = 32;
      public const int ButtonHeight = 40;
      public const int ButtonWidth = 110;
      public const string CancelButtonX = XAxis.Left;
      public const string CancelButtonY = YAxis.Bottom;
      public const string CancelSigButtonX = XAxis.Left;
      public const string CancelSigButtonY = YAxis.Bottom;
      public const int CheckBoxHeightSmall = 20;
      public const int CheckBoxWidthSmall = 20;
      public const int CheckBoxHeightLarge = 35;
      public const int CheckBoxWidthLarge = 35;
      public const string ClearButtonX = XAxis.Centre;
      public const string ClearButtonY = YAxis.Bottom;
      public const int FontSize = 16;
      public const int LargeFontSize = 22;
      public const string NextButtonX = XAxis.Right;
      public const string NextButtonY = YAxis.Bottom;
      public const string OKButtonX = XAxis.Right;
      public const string OKButtonY = YAxis.Bottom;
      public const int PadWidth = 640;
      public const int PadHeight = 480;
      public const int RadioMaleX = 240;
      public const int RadioMaleY = 100;
      public const int RadioFemaleX = 240;
      public const int RadioFemaleY = 200;
      public const int RadioWidth = 20;
      public const string SigLineX = XAxis.Centre;
      public const int SigLineY = 280;
      public const int SignLineSize = 32;
      public const string WhoX = XAxis.Right;
      public const int WhoY = 350;
      public const string WhyX = XAxis.Left;
      public const int WhyY = 350;
    }

    public static class Stu430Props
    {
      public const int ButtonHeight = 25;
      public const int ButtonFontSize = 16;
      public const int ButtonWidth = 60;
      public const string CancelButtonX = XAxis.Left;
      public const string CancelButtonY = YAxis.Bottom;
      public const string CancelSigButtonX = XAxis.Left;
      public const string CancelSigButtonY = YAxis.Bottom;
      public const int CheckBoxHeightSmall = 15;
      public const int CheckBoxWidthSmall = 15;
      public const int CheckBoxHeightLarge = 25;
      public const int CheckBoxWidthLarge = 25;
      public const string ClearButtonX = XAxis.Centre;
      public const string ClearButtonY = YAxis.Bottom;
      public const int FontSize = 8;
      public const int LargeFontSize = 12;
      public const string NextButtonX = XAxis.Right;
      public const string NextButtonY = YAxis.Bottom;
      public const string OKButtonX = XAxis.Right;
      public const string OKButtonY = YAxis.Bottom;
      public const int PadWidth = 320;
      public const int PadHeight = 200;
      public const int RadioMaleX = 120;
      public const int RadioMaleY = 46;
      public const int RadioFemaleX = 120;
      public const int RadioFemaleY = 96;
      public const int RadioWidth = 12;
      public const string SigLineX = XAxis.Centre;
      public const int SigLineY = 100;
      public const int SignLineSize = 16;
      public const string WhoX = XAxis.Right;
      public const int WhoY = 130;
      public const string WhyX = XAxis.Left;
      public const int WhyY = 130;
    }

    public static class Stu5X0Props
    {
      public const int ButtonFontSize = 32;
      public const int ButtonHeight = 40;
      public const int ButtonWidth = 110;
      public const string CancelButtonX = XAxis.Left;
      public const string CancelButtonY = YAxis.Bottom;
      public const string CancelSigButtonX = XAxis.Left;
      public const string CancelSigButtonY = YAxis.Bottom;
      public const int CheckBoxHeightSmall = 20;
      public const int CheckBoxWidthSmall = 20;
      public const int CheckBoxHeightLarge = 30;
      public const int CheckBoxWidthLarge = 30;
      public const string ClearButtonX = XAxis.Centre;
      public const string ClearButtonY = YAxis.Bottom;
      public const int FontSize = 20;
      public const int LargeFontSize = 26;
      public const string NextButtonX = XAxis.Right;
      public const string NextButtonY = YAxis.Bottom;
      public const string OKButtonX = XAxis.Right;
      public const string OKButtonY = YAxis.Bottom;
      public const int PadWidth = 800;
      public const int PadHeight = 480;
      public const int RadioMaleX = 90;
      public const int RadioMaleY = 200;
      public const int RadioFemaleX = 540;
      public const int RadioFemaleY = 200;
      public const int RadioWidth = 20;
      public const string SigLineX = XAxis.Centre;
      public const int SigLineY = 250;
      public const int SignLineSize = 32;
      public const string WhoX = XAxis.Right;
      public const int WhoY = 330;
      public const string WhyX = XAxis.Left;
      public const int WhyY = 330;
    }

    class StuProps
    {
      public Font ButtonFont;
      public Font LargeFont;
      public Font SigLineFont;
      public Font TextFont;
      public string AcceptButtonImage;
      public int ButtonFontSize;
      public int ButtonHeight;
      public int ButtonWidth;
      public string CancelButtonImage;
      public string CancelButtonX;
      public string CancelButtonY;
      public string CancelSigButtonX;
      public string CancelSigButtonY;
      public int CheckBoxHeightSmall;
      public int CheckBoxWidthSmall;
      public int CheckBoxHeightLarge;
      public int CheckBoxWidthLarge;
      public string ClearButtonImage;
      public string ClearButtonX;
      public string ClearButtonY;
      public int FontSize;
      public int LargeFontSize;
      public string Model;
      public string NextButtonImage;
      public string NextButtonX;
      public string NextButtonY;
      public string OKButtonX;
      public string OKButtonY;
      public int PadHeight;
      public int PadWidth;
      public int RadioMaleX;
      public int RadioMaleY;
      public int RadioFemaleX;
      public int RadioFemaleY;
      public int RadioWidth;
      public string RectX1;
      public string RectY1;
      public string RectX2;
      public string RectY2;
      public string SigLineX;
      public int SigLineY;
      public int SignLineSize;
      public bool supportsColour = false;
      public string WhoX;
      public int WhoY;
      public string WhyX;
      public int WhyY;


      public StuProps(string stuModel)
      {
        this.Model = stuModel;

        string workingDirectory = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        //string imagesDir = projectDirectory + "\\images";
        string imagesDir = ".\\images";

        switch (stuModel)
        {
          case PadModels.STU300:
            this.ButtonHeight = Stu300Props.ButtonHeight;
            this.CheckBoxHeightLarge = Stu300Props.CheckBoxHeightLarge;
            this.CheckBoxWidthLarge = Stu300Props.CheckBoxWidthLarge;
            this.CheckBoxHeightSmall = Stu300Props.CheckBoxHeightSmall;
            this.CheckBoxWidthSmall = Stu300Props.CheckBoxWidthSmall;
            this.PadHeight = Stu300Props.PadHeight;
            this.PadWidth = Stu300Props.PadWidth;
            this.SigLineX = Stu300Props.SigLineX;
            this.SigLineY = Stu300Props.SigLineY;
            this.WhoX = Stu300Props.WhoX;
            this.WhoY = Stu300Props.WhoY;
            this.WhyX = Stu300Props.WhyX;
            this.WhyY = Stu300Props.WhyY;
            this.FontSize = Stu300Props.FontSize;
            this.LargeFontSize = Stu300Props.LargeFontSize;
            this.ButtonFontSize = Stu300Props.ButtonFontSize;
            this.SignLineSize = Stu300Props.SignLineSize;
            this.ButtonWidth = Stu300Props.ButtonWidth;
            this.RadioMaleX = Stu300Props.RadioMaleX;
            this.RadioMaleY = Stu300Props.RadioMaleY;
            this.RadioFemaleX = Stu300Props.RadioFemaleX;
            this.RadioFemaleY = Stu300Props.RadioFemaleY;
            this.RadioWidth = Stu300Props.RadioWidth;
            this.NextButtonX = Stu300Props.NextButtonX;
            this.NextButtonY = Stu300Props.NextButtonY;
            this.CancelButtonX = Stu300Props.CancelButtonX;
            this.CancelButtonY = Stu300Props.CancelButtonY;
            this.CancelSigButtonX = Stu300Props.CancelSigButtonX;
            this.CancelSigButtonY = Stu300Props.CancelSigButtonY;
            this.ClearButtonX = Stu300Props.ClearButtonX;
            this.ClearButtonY = Stu300Props.ClearButtonY;
            this.OKButtonX = Stu300Props.OKButtonX;
            this.OKButtonY = Stu300Props.OKButtonY;

            this.AcceptButtonImage = imagesDir + "\\Accept300.png";
            this.CancelButtonImage = imagesDir + "\\Cancel300.png";
            this.ClearButtonImage = imagesDir + "\\Clear300.png";
            this.NextButtonImage = imagesDir + "\\Next300.png";

            this.RectX1 = "5";
            this.RectY1 = "15";
            this.RectX2 = (this.PadWidth - 3).ToString();
            this.RectY2 = "15";
            break;
          case PadModels.STU430:
            this.ButtonHeight = Stu430Props.ButtonHeight;
            this.CheckBoxHeightLarge = Stu430Props.CheckBoxHeightLarge;
            this.CheckBoxWidthLarge = Stu430Props.CheckBoxWidthLarge;
            this.CheckBoxHeightSmall = Stu430Props.CheckBoxHeightSmall;
            this.CheckBoxWidthSmall = Stu430Props.CheckBoxWidthSmall;
            this.PadHeight = Stu430Props.PadHeight;
            this.PadWidth = Stu430Props.PadWidth;
            this.SigLineX = Stu430Props.SigLineX;
            this.SigLineY = Stu430Props.SigLineY;
            this.WhoX = Stu430Props.WhoX;
            this.WhoY = Stu430Props.WhoY;
            this.WhyX = Stu430Props.WhyX;
            this.WhyY = Stu430Props.WhyY;
            this.FontSize = Stu430Props.FontSize;
            this.LargeFontSize = Stu430Props.LargeFontSize;
            this.ButtonFontSize = Stu430Props.ButtonFontSize;
            this.SignLineSize = Stu430Props.SignLineSize;
            this.ButtonWidth = Stu430Props.ButtonWidth;
            this.RadioMaleX = Stu430Props.RadioMaleX;
            this.RadioMaleY = Stu430Props.RadioMaleY;
            this.RadioFemaleX = Stu430Props.RadioFemaleX;
            this.RadioFemaleY = Stu430Props.RadioFemaleY;
            this.RadioWidth = Stu430Props.RadioWidth;
            this.NextButtonX = Stu430Props.NextButtonX;
            this.NextButtonY = Stu430Props.NextButtonY;
            this.CancelButtonX = Stu430Props.CancelButtonX;
            this.CancelButtonY = Stu430Props.CancelButtonY;
            this.CancelSigButtonX = Stu430Props.CancelSigButtonX;
            this.CancelSigButtonY = Stu430Props.CancelSigButtonY;
            this.ClearButtonX = Stu430Props.ClearButtonX;
            this.ClearButtonY = Stu430Props.ClearButtonY;
            this.OKButtonX = Stu430Props.OKButtonX;
            this.OKButtonY = Stu430Props.OKButtonY;

            this.AcceptButtonImage = imagesDir + "\\Accept430.png";
            this.CancelButtonImage = imagesDir + "\\Cancel430.png";
            this.ClearButtonImage = imagesDir + "\\Clear430.png";
            this.NextButtonImage = imagesDir + "\\Next430.png";

            this.RectX1 = XAxis.Left;
            this.RectY1 = (this.PadHeight / 8).ToString();
            this.RectX2 = XAxis.Right;
            this.RectY2 = (this.PadHeight * 4 / 5).ToString();
            break;
          case PadModels.STU500:
            this.ButtonHeight = Stu500Props.ButtonHeight;
            this.CheckBoxHeightLarge = Stu500Props.CheckBoxHeightLarge;
            this.CheckBoxWidthLarge = Stu500Props.CheckBoxWidthLarge;
            this.CheckBoxHeightSmall = Stu500Props.CheckBoxHeightSmall;
            this.CheckBoxWidthSmall = Stu500Props.CheckBoxWidthSmall;
            this.PadHeight = Stu500Props.PadHeight;
            this.PadWidth = Stu500Props.PadWidth;
            this.SigLineX = Stu500Props.SigLineX;
            this.SigLineY = Stu500Props.SigLineY;
            this.WhoX = Stu500Props.WhoX;
            this.WhoY = Stu500Props.WhoY;
            this.WhyX = Stu500Props.WhyX;
            this.WhyY = Stu500Props.WhyY;
            this.FontSize = Stu500Props.FontSize;
            this.LargeFontSize = Stu500Props.LargeFontSize;
            this.ButtonFontSize = Stu500Props.ButtonFontSize;
            this.SignLineSize = Stu500Props.SignLineSize;
            this.ButtonWidth = Stu500Props.ButtonWidth;
            this.RadioMaleX = Stu500Props.RadioMaleX;
            this.RadioMaleY = Stu500Props.RadioMaleX;
            this.RadioFemaleX = Stu500Props.RadioFemaleX;
            this.RadioFemaleY = Stu500Props.RadioFemaleY;
            this.RadioWidth = Stu500Props.RadioWidth;
            this.NextButtonX = Stu500Props.NextButtonX;
            this.NextButtonY = Stu500Props.NextButtonY;
            this.CancelButtonX = Stu500Props.CancelButtonX;
            this.CancelButtonY = Stu500Props.CancelButtonY;
            this.CancelSigButtonX = Stu500Props.CancelSigButtonX;
            this.CancelSigButtonY = Stu500Props.CancelSigButtonY;
            this.ClearButtonX = Stu500Props.ClearButtonX;
            this.ClearButtonY = Stu500Props.ClearButtonY;
            this.OKButtonX = Stu500Props.OKButtonX;
            this.OKButtonY = Stu500Props.OKButtonY;

            this.AcceptButtonImage = imagesDir + "\\Accept500.png";
            this.CancelButtonImage = imagesDir + "\\Cancel500.png";
            this.ClearButtonImage = imagesDir + "\\Clear500.png";
            this.NextButtonImage = imagesDir + "\\Next500.png";

            this.RectX1 = XAxis.Left;
            this.RectY1 = (this.PadHeight / 8).ToString();
            this.RectX2 = XAxis.Right;
            this.RectY2 = (this.PadHeight * 4 / 5).ToString();
            break;
          case PadModels.STU5X0:
            this.ButtonHeight = Stu5X0Props.ButtonHeight;
            this.CheckBoxHeightLarge = Stu5X0Props.CheckBoxHeightLarge;
            this.CheckBoxWidthLarge = Stu5X0Props.CheckBoxWidthLarge;
            this.CheckBoxHeightSmall = Stu5X0Props.CheckBoxHeightSmall;
            this.CheckBoxWidthSmall = Stu5X0Props.CheckBoxWidthSmall;
            this.PadHeight = Stu5X0Props.PadHeight;
            this.PadWidth = Stu5X0Props.PadWidth;
            this.SigLineX = Stu5X0Props.SigLineX;
            this.SigLineY = Stu5X0Props.SigLineY;
            this.WhoX = Stu5X0Props.WhoX;
            this.WhoY = Stu5X0Props.WhoY;
            this.WhyX = Stu5X0Props.WhyX;
            this.WhyY = Stu5X0Props.WhyY;
            this.FontSize = Stu5X0Props.FontSize;
            this.LargeFontSize = Stu5X0Props.LargeFontSize;
            this.ButtonFontSize = Stu5X0Props.ButtonFontSize;
            this.SignLineSize = Stu5X0Props.SignLineSize;
            this.ButtonWidth = Stu5X0Props.ButtonWidth;
            this.RadioMaleX = Stu5X0Props.RadioMaleX;
            this.RadioMaleY = Stu5X0Props.RadioMaleY;
            this.RadioFemaleX = Stu5X0Props.RadioFemaleX;
            this.RadioFemaleY = Stu5X0Props.RadioFemaleY;
            this.RadioWidth = Stu5X0Props.RadioWidth;
            this.NextButtonX = Stu5X0Props.NextButtonX;
            this.NextButtonY = Stu5X0Props.NextButtonY;
            this.CancelButtonX = Stu5X0Props.CancelButtonX;
            this.CancelButtonY = Stu5X0Props.CancelButtonY;
            this.CancelSigButtonX = Stu5X0Props.CancelSigButtonX;
            this.CancelSigButtonY = Stu5X0Props.CancelSigButtonY;
            this.ClearButtonX = Stu5X0Props.ClearButtonX;
            this.ClearButtonY = Stu5X0Props.ClearButtonY;
            this.OKButtonX = Stu5X0Props.OKButtonX;
            this.OKButtonY = Stu5X0Props.OKButtonY;
            this.supportsColour = true;

            this.AcceptButtonImage = imagesDir + "\\Accept530.png";
            this.CancelButtonImage = imagesDir + "\\Cancel530.png";
            this.ClearButtonImage = imagesDir + "\\Clear530.png";
            this.NextButtonImage = imagesDir + "\\Next530.png";

            this.RectX1 = XAxis.Left;
            this.RectY1 = (this.PadHeight / 8).ToString();
            this.RectX2 = XAxis.Right;
            this.RectY2 = (this.PadHeight * 4 / 5).ToString();
            break;
        }
        this.TextFont = new Font("Verdana", this.FontSize, FontStyle.Regular);
        this.LargeFont = new Font("Verdana", this.LargeFontSize, FontStyle.Regular);
        this.ButtonFont = new Font("Verdana", this.ButtonFontSize, FontStyle.Regular);
        this.SigLineFont = new Font("Verdana", this.SignLineSize, FontStyle.Regular);
      }
    }

    public static class ButtonText
    {
      public const string Cancel = "Cancel";
      public const string Next = "Next";
      public const string OK = "OK";
      public const string Clear = "Clear";
    }

    public static class ButtonTypes
    {
      public const string Next = "Next";
      public const string Cancel = "Cancel";
      public const string Clear = "Clear";
      public const string OK = "OK";
    }

    public static class FontColours
    {
      public const string Blue = "0R 0G 0.8B";
      public const string Green = "0R 0.8G 0B";
      public const string Black = "0R 0G 0B";
      public const string White = "1R 1G 1B";
      public const string Purple = "0.7R 0.3G 1B";
      public const string Red = "0.6R 0G 0.2B";
    }

    public static class PadModels
		{
      public const string STU300 = "STU-300";
      public const string STU430 = "STU-430";
      public const string STU500 = "STU-500";
      public const string STU5X0 = "STU-5X0";

		}

    public static class TextObjectTypes
    {
      public const string Text = "txt";
      public const string Who = "who";
      public const string Why = "why";
    }

    public static class TextStrings
    {
      public const string Certify = "I certify that the information is correct";
      public const string Female = "Female";
      public const string HaveRead = "I have read and I accept the terms and conditions";
      public const string Male = "Male";
      public const string PleaseSign = "Please sign below...";
      public const string SelectGender = "Please select your gender";
      public const string SignatoryName = "J Smith";
    }

    public static class UTF8Text
    {
      public const string Cancel = "取消";
      public const string Next = "下一個";
      public const string OK = "好";
      public const string Clear = "肃清";
    }

    public static class XAxis
		{
      public const string Centre = "centre";
      public const string Left = "left";
      public const string Right = "right";
		}

    public static class YAxis
		{
      public const string Bottom = "bottom";
      public const string Middle = "middle";
      public const string Top = "top";
		}

    // These 2 const values are used for drawing lines or rectangles
    public const Florentis.PrimitiveOptions OUTLINE = (Florentis.PrimitiveOptions)0x04;
    public const int LINEWIDTH = 1;

    // The Checkbox class is used for drawing the checkbox on the first screen, including the text prompt which goes with it
    public class Checkbox
    {
      public int xLeft;
      public int xRight;
      public int yTop;
      public int yBottom;
      public int height;
      public int width;
      public int xConfirmationText, yConfirmationText;
      public int xTick, yTick;
      public Rectangle rectCheckBox;
      public SolidBrush textBrush;

      public Checkbox(Graphics gfx, Font textFont, string padModel, bool largeSize, bool supportsColour, bool ticked, int largeWidth, int largeHeight, int smallWidth, int smallHeight, int imageWidth, int padHeight)
      {
        int yConfirmationText = (padHeight / 2) - 8;
        SizeF textSize = gfx.MeasureString(TextStrings.HaveRead, textFont);

        // Calculate where to place the checkbox and its prompt string - this depends on whether the user wants a small or large one
        if (largeSize)
        {
          height = largeHeight;
          width = largeWidth;
          //Add the width of the checkbox to that of the confirmation string to calculate how to centre them horizontally
          xLeft = (imageWidth - ((int)(textSize.Width) + width)) / 2;
          xRight = xLeft + largeWidth;

          if (padModel == PadModels.STU5X0)
            yTop = yConfirmationText;
          else
            yTop = yConfirmationText - 8;

          yBottom = yTop + largeHeight;

          xTick = xLeft + (int)width / 2;
          yTick = yTop + (int)height / 2;
        }
        else
        {
          height = smallHeight;
          width = smallWidth;
          //Add the width of the checkbox to that of the confirmation string to calculate how to centre them horizontally
          xLeft = (imageWidth - ((int)(textSize.Width) + width)) / 2;
          xRight = xLeft + smallWidth;

          if (padModel == PadModels.STU5X0)
            yTop = yConfirmationText + 5;
          else
            yTop = yConfirmationText;
          yBottom = yTop + smallHeight;

          xTick = xLeft + (int)width / 2;
          yTick = yTop + (int)height / 2;
        }
        xConfirmationText = xLeft + width + 5;

        rectCheckBox = new Rectangle(xLeft, yTop, width, height);

        // Draw the rectangle to create the checkbox
        gfx.FillRectangle(Brushes.White, rectCheckBox);
        gfx.DrawRectangle(Pens.Black, rectCheckBox);

        // If required put a tick in the box
        if (ticked)
          gfx.DrawString("\u2713", textFont, Brushes.Black, this.xTick, this.yTick, sfCentered);

        if (supportsColour)
          textBrush = new SolidBrush(Color.Blue);
        else
          textBrush = new SolidBrush(Color.Black);

        // Finally draw the associated text
        gfx.DrawString(TextStrings.HaveRead, textFont, textBrush, new PointF(xConfirmationText, yConfirmationText));
      }

      public void displayTick(Font textFont, Bitmap bitmap, StringFormat sf)
			{
        using (Graphics g = Graphics.FromImage(bitmap))
        {
          g.DrawString("\u2713", textFont, Brushes.Black, this.xTick, this.yTick, sf);
        }
      }
    }

    // This class is used for the 2 radio buttons on the second screen
    public class RadioButton
    {
      public string label;
      public int xPos;
      public int yPos;
      public int width;
      public int height;
      public Pen blackPen;
      public Pen bluePen;

      public RadioButton(int x, int y, int w, int h, string labelText, bool colourSupported)
      {
        xPos = x;
        yPos = y;
        width = w;
        height = h;
        label = labelText;
      }

      public void drawRadioButton(Graphics gfx, bool selected, Font textFont, bool colourSupported)
      {
        Brush textBrush;
        Pen blackPen = new Pen(Color.Black, 1);
        Pen bluePen = new Pen(Color.Blue, 1);
        Pen drawPen;

        if (colourSupported)
        {
          textBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
          drawPen = bluePen;
        }
        else
        {
          textBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
          drawPen = blackPen;
        }

        // First draw the circle itself
        gfx.DrawEllipse(drawPen, this.xPos, this.yPos, this.width, this.height);

        // Now fill the circle in if this one has been selected
        if (selected)
        {
          fillRadioButton(gfx, colourSupported);
        }

        // Finally draw the label text
        gfx.DrawString(label, textFont, textBrush, new PointF(this.xPos + this.width + 2, this.yPos));
        textBrush.Dispose();
      }

      // This method simply clears out the filling from the radio button to show that it is not selected
      public void clearRadioButton(Graphics gfx)
      {
        SolidBrush whiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        gfx.FillEllipse(whiteBrush, new Rectangle(this.xPos + 1, this.yPos + 1, width - 2, width - 2));
      }

      public void fillRadioButton(Graphics gfx, bool colourSupported)
			{
        Brush fillBrush;

        if (colourSupported)
          fillBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
        else
          fillBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

        gfx.FillEllipse(fillBrush, new Rectangle(this.xPos + 1, this.yPos + 1, width - 2, width - 2));

        fillBrush.Dispose();
      }

      // This method tests whether the user has clicked their mouse on the radio button
      public bool radioClicked(int mouseX, int mouseY)
			{
        bool clicked = false;

        if (mouseX >= this.xPos && mouseX <= this.xPos + width && mouseY >= this.yPos && mouseY <= this.yPos + height)
          clicked = true;

        return clicked;
			}
    }

    // This class is for drawing the buttons along the bottom of the screen
    public class Button
		{
      public int xLeft;
      public int xRight;
      public int yTop;
      public int yBottom;
      public int xText, yText;
      public double imageRatio;
      public StringFormat stringFormat;

      public Button(int x1, int x2, int y1, int y2, int xTxt, int yTxt, double imgRatio, StringFormat sf)
      {
        xLeft = x1;
        xRight = x2;
        yTop = y1;
        yBottom = y2;
        xText = xTxt;
        yText = yTxt;
        imageRatio = imgRatio;
        stringFormat = sf;
      }

      public void drawButton(Bitmap bitmap, Graphics gfx, string padModel, string btnText, string btnImagePath, int btnFontSize, int btnWidth, int btnHeight, bool useExistingImage)
			{
        int btnTextFont = (int)Math.Abs(btnFontSize * imageRatio);
        Font btnFont = new Font(FontFamily.GenericSansSerif, btnTextFont, GraphicsUnit.Pixel);
        System.Drawing.Image btnImage;

        Rectangle rect = new Rectangle(this.xLeft, this.yTop, btnWidth, btnHeight);

        if (useExistingImage)
        {
          // Use pre-defined button images
          btnImage = System.Drawing.Image.FromFile(btnImagePath);

          RectangleF destinationRect = new RectangleF(this.xLeft, this.yTop, btnImage.Width, btnImage.Height);
          RectangleF sourceRect = new RectangleF(0, 0, btnImage.Width, btnImage.Height);

          Graphics gr = Graphics.FromImage(bitmap);
          gr.DrawImage(btnImage, destinationRect, sourceRect, GraphicsUnit.Pixel);
          gr.Dispose();
        }
        else
        if (padModel == PadModels.STU5X0)
        {
          // Use colour buttons for colour devices
          gfx.FillRectangle(Brushes.Green, rect);
          gfx.DrawRectangle(Pens.White, rect);
          gfx.DrawString(btnText, btnFont, Brushes.White, this.xText, this.yText, this.stringFormat);
        }
        else
        {
          gfx.FillRectangle(Brushes.LightGray, rect);
          gfx.DrawRectangle(Pens.Black, rect);
          gfx.DrawString(btnText, btnFont, Brushes.Black, this.xText, this.yText, this.stringFormat);
        }
      }

      // Check to see if the use has clicked the button with the mouse
      public bool buttonClicked(int mouseX, int mouseY)
			{
        bool clicked = false;

        if (mouseX >= this.xLeft && mouseX <= this.xRight && mouseY >= this.yTop && mouseY <= this.yBottom)
          clicked = true;

        return clicked;
			}
    }


    public WizardExtra()
    {
      InitializeComponent();
      SigCtl SigCtl = new SigCtl();

      WizCtl.Licence = LicenceKey; // Set the licence - only needs to be applied to the WizCtl, the SigCtl "inherits" it
      // initialise Wizard script support
      Callback = new WizardCallback();  // Callback provided via InteropAXFlWizCOM
      Callback.EventHandler = null;
      WizCtl.SetEventHandler(Callback);
      ScriptIsRunning = false;

      // Set up the string format global for use in various places
      sfCentered = new StringFormat();
      sfCentered.Alignment = StringAlignment.Center;
      sfCentered.LineAlignment = StringAlignment.Center;
    }

    private void btnSign_Click(object sender, EventArgs e)
    {
      print("Sign...");
      isCheck = false;
      MouseUpOrigin = "";
      if (!ScriptIsRunning)
        startWizard();
      else
        print("Script is already running");
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      print("Cancel...");
      if (ScriptIsRunning)
      {
        scriptCancelled();
      }
      else
        print("Script is not running");
    }

    private void print(string txt)  // Displays a text string to the user indicating progress status
    {
      txtDisplay.Text += txt + "\r\n";
      txtDisplay.SelectionStart = txtDisplay.Text.Length;  // scroll to end
      txtDisplay.ScrollToCaret();
      txtDisplay.Refresh();
    }

    // Wizard script:
    private void startWizard()
    {
      print("startWizard");
      bool success = WizCtl.PadConnect();
      if (success)
      {
        ScriptIsRunning = true;

        switch (WizCtl.PadWidth)
        {
          case Stu300Props.PadWidth:
            Pad = new StuProps(PadModels.STU300); // 396 x 100
            break;
          case Stu500Props.PadWidth:
            Pad = new StuProps(PadModels.STU500); // 640 x 480
            break;
          case Stu5X0Props.PadWidth:
            Pad = new StuProps(PadModels.STU5X0); // 800 x 480
            break;
          case Stu430Props.PadWidth:
            Pad = new StuProps(PadModels.STU430); // 320 x 200
            break;
          default:
            print("No compatible device found");
            break;
        }
        print("Pad detected: " + WizCtl.PadWidth + " x " + WizCtl.PadHeight + " : " + Pad.Model);

        picWizardStep.Size = new System.Drawing.Size((int)(WizCtl.PadWidth * 1), (int)(WizCtl.PadHeight * 1));
        step1();
      }
      else
        print("Unable to connect to tablet");
    }

    private void scriptCompleted()
    {
      print("scriptCompleted");
      SigObj sigObj = (SigObj)SigCtl.Signature;
      if (sigObj.IsCaptured)
      {
        sigObj.set_ExtraData("AdditionalData", "C# Wizard test: Additional data");
        String filename = "sig1.png";

        sigObj.RenderBitmap(filename, Pad.PadWidth, Pad.PadHeight, "image/png", 0.5f, 0xff0000, 0xffffff, -1.0f, -1.0f, RBFlags.RenderOutputFilename | RBFlags.RenderColor32BPP | RBFlags.RenderEncodeData | RBFlags.RenderBackgroundTransparent);
        using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
        {
          signatureImage = System.Drawing.Image.FromStream(fs);
          fs.Close();
        }
        if (chkSigText.Checked)
        {
          print(sigObj.SigText);  // Display the SigText if requested by the user
        }
        print("Extra data: " + sigObj.ExtraData[""]);

        Florentis.CaptData captData = (Florentis.CaptData)26;
        print("Digitizer info: " + sigObj.AdditionalData[captData]);

        overlaySigImage();  // Display the captured signature image on the PC window
      }
      closeWizard();
    }

    private void scriptCancelled()
    {
      print("scriptCancelled");
      picWizardStep.Image = null;
      closeWizard();
    }

    private void closeWizard()
    {
      print("closeWizard()");
      ScriptIsRunning = false;
      WizCtl.Reset();
      WizCtl.Display();
      WizCtl.PadDisconnect();
      Callback.EventHandler = null;     // remove handler
      WizCtl.SetEventHandler(Callback);
    }

    private void step1(bool chkBoxChecked = false)
    {
      string cancelButtonText = ButtonText.Cancel;
      string nextButtonText = ButtonText.Next;
      int chkBoxOption;

      MouseUpOrigin = "step1";  
      WizCtl.Reset();

      imageRatio = (double)picWizardStep.Width / (double)Pad.PadWidth;
      showImageStep1(Pad.PadWidth, Pad.PadHeight, Pad.Model, chkLargeCheckBox.Checked, chkBoxChecked, imageRatio);

      // insert checkbox
      if (chkLargeCheckBox.Checked)
      {
        WizCtl.Font = Pad.LargeFont;
      }
      else
      {
        WizCtl.Font = Pad.TextFont;
      }

      WizCtl.AddPrimitive(PrimitiveType.PrimitiveRectangle, Pad.RectX1, Pad.RectY1, Pad.RectX2, Pad.RectY2, LINEWIDTH, OUTLINE);

      setFontColour(Pad, FontColours.Blue, FontColours.White);
      if (chkBoxChecked)
			{
        chkBoxOption = 3;
			}
      else
			{
        chkBoxOption = 2;
			}
      print("Checkbox option: " + chkBoxOption);
      WizCtl.AddObject(ObjectType.ObjectCheckbox, "Check", XAxis.Centre, YAxis.Middle, TextStrings.HaveRead, chkBoxOption);

      // insert the buttons
      WizCtl.Font = Pad.ButtonFont;

      if (radUTF8.Checked)
      {
        cancelButtonText = UTF8Text.Cancel;
        nextButtonText = UTF8Text.Next;
      }

      if (radImage.Checked)
      {
        WizCtl.AddObject(ObjectType.ObjectImage, ButtonTypes.Cancel, Pad.CancelButtonX, Pad.CancelButtonY, Pad.CancelButtonImage, null);
        WizCtl.AddObject(ObjectType.ObjectImage, ButtonTypes.Next, Pad.NextButtonX, Pad.NextButtonY, Pad.NextButtonImage, null);
      }
      else
      {
        setFontColour(Pad, FontColours.White, FontColours.Green);

        WizCtl.AddObject(ObjectType.ObjectButton, ButtonTypes.Cancel, Pad.CancelButtonX, Pad.CancelButtonY, cancelButtonText, Pad.ButtonWidth);
        WizCtl.AddObject(ObjectType.ObjectButton, ButtonTypes.Next, Pad.NextButtonX, Pad.NextButtonY, nextButtonText, Pad.ButtonWidth);

        setFontColour(Pad, FontColours.Black, FontColours.White);
      }

      // set callback when a button is pressed
      Callback.EventHandler = new WizardCallback.Handler(Step1_Handler);
      WizCtl.SetEventHandler(Callback);
      WizCtl.Display();

    }
    private void Step1_Handler(object clt, object id, object type)
    {
      switch (id.ToString())
      {
        case ButtonTypes.Next:
          {
            if (isCheck)
              step2();
            break;
          }
        case ButtonTypes.Cancel:
          {
            scriptCancelled();
            break;
          }
        case "Check":
          {
            isCheck = !isCheck;
            checkBox.displayTick(Pad.TextFont, bitmapStep1, sfCentered);  // Display the tick on the PC window as well
            picWizardStep.Image = bitmapStep1;
            print("Checked");
            break;
          }
        default:
          {
            print("Unexpected pad event: " + id.ToString());
            break;
          }
      }
    }

    private void step2(bool maleChecked = true)
    {
      //print("Starting step2");
      string cancelButtonText = ButtonText.Cancel;
      string nextButtonText = ButtonText.Next;
      WizCtl.Reset();

      MouseUpOrigin = "step2";

      showImageStep2(Pad.PadWidth, Pad.PadHeight, Pad.Model, maleChecked);

      WizCtl.Font = Pad.TextFont;

      WizCtl.AddPrimitive(PrimitiveType.PrimitiveRectangle, Pad.RectX1, Pad.RectY1, Pad.RectX2, Pad.RectY2, LINEWIDTH, OUTLINE);
      WizCtl.AddObject(ObjectType.ObjectText, TextObjectTypes.Text, XAxis.Centre, YAxis.Top, TextStrings.SelectGender, null);

      setFontColour(Pad, FontColours.Blue, FontColours.White);

      // Add the 2 radio buttons for male and female
      Florentis.ObjectOptions objOptions = new ObjectOptions();

      objOptions.SetProperty("Group", "Gender");
      objOptions.SetProperty("Checked", maleChecked);
      WizCtl.AddObject(ObjectType.ObjectRadioButton, "male", Pad.RadioMaleX, Pad.RadioMaleY, TextStrings.Male, objOptions);

      objOptions.SetProperty("Checked", !maleChecked);
      WizCtl.AddObject(ObjectType.ObjectRadioButton, "female", Pad.RadioFemaleX, Pad.RadioFemaleY, TextStrings.Female, objOptions);

      // insert the buttons
      WizCtl.Font = Pad.ButtonFont;

      if (radUTF8.Checked)
      {
        cancelButtonText = UTF8Text.Cancel;
        nextButtonText = UTF8Text.Next;
      }

      if (radImage.Checked)
      {
        WizCtl.AddObject(ObjectType.ObjectImage, ButtonTypes.Cancel, Pad.CancelButtonX, Pad.CancelButtonY, Pad.CancelButtonImage, null);
        WizCtl.AddObject(ObjectType.ObjectImage, ButtonTypes.Next, Pad.NextButtonX, Pad.NextButtonY, Pad.NextButtonImage, null);
      }
      else
      {
        setFontColour(Pad, FontColours.White, FontColours.Green);

        WizCtl.AddObject(ObjectType.ObjectButton, ButtonTypes.Cancel, Pad.CancelButtonX, Pad.CancelButtonY, cancelButtonText, Pad.ButtonWidth);
        WizCtl.AddObject(ObjectType.ObjectButton, ButtonTypes.Next, Pad.NextButtonX, Pad.NextButtonY, nextButtonText, Pad.ButtonWidth);

        setFontColour(Pad, FontColours.Black, FontColours.White);
      }

      // set callback when a button is pressed
      Callback.EventHandler = new WizardCallback.Handler(Step2_Handler);

      WizCtl.SetEventHandler(Callback);
      WizCtl.Display();

    }
    private void Step2_Handler(object clt, object id, object type)
    {
      //print("Step2_handler");
      if (MouseUpOrigin == "step2")
      {
        switch (id.ToString())
        {
          case "male":
            updateRadioButtons(radioButtonMale, radioButtonFemale);
            break;
          case "female":
            updateRadioButtons(radioButtonFemale, radioButtonMale);
            break;
          case ButtonTypes.Next:
            {
              step3();
              break;
            }
          case ButtonTypes.Cancel:
            {
              scriptCancelled();
              break;
            }
          case "Check":
            {
              isCheck = !isCheck;
              break;
            }
          default:
            {
              print("Unexpected pad event: " + id.ToString());
              break;
            }
        }
      }
    }

    private void updateRadioButtons(RadioButton radioButtonSelected, RadioButton radioButtonUnselected)
		{
      Graphics gfx = Graphics.FromImage(bitmapStep2);
      radioButtonSelected.fillRadioButton(gfx, Pad.supportsColour);
      radioButtonUnselected.clearRadioButton(gfx);
      gfx.Dispose();
      picWizardStep.Image = bitmapStep2;
    }

    private void step3()
    {
      string cancelButtonText = ButtonText.Cancel;
      string clearButtonText = ButtonText.Clear;
      string okButtonText = ButtonText.OK;

      //print("Starting step3");
      MouseUpOrigin = "step3";

      if (radUTF8.Checked)
      {
        cancelButtonText = UTF8Text.Cancel;
        clearButtonText = UTF8Text.Clear;
        okButtonText = UTF8Text.OK;
      }

      WizCtl.Reset();

      showImageStep3(Pad.PadWidth, Pad.PadHeight, Pad.Model);

      WizCtl.AddPrimitive(PrimitiveType.PrimitiveRectangle, Pad.RectX1, Pad.RectY1, Pad.RectX2, Pad.RectY2, LINEWIDTH, OUTLINE);

      // insert message
      WizCtl.Font = Pad.TextFont;
      setFontColour(Pad, FontColours.Blue, FontColours.White);
      WizCtl.AddObject(ObjectType.ObjectText, TextObjectTypes.Text, XAxis.Centre, YAxis.Top, TextStrings.PleaseSign, null);

      // insert a signature line
      WizCtl.Font = Pad.SigLineFont;
      WizCtl.AddObject(ObjectType.ObjectText, TextObjectTypes.Text, Pad.SigLineX, Pad.SigLineY, "X..............................", null);

      // insert the signature control
      WizCtl.Font = Pad.TextFont;
      WizCtl.AddObject(ObjectType.ObjectSignature, "Sig", 0, 0, SigCtl.Signature, null);

      // provide who and why for sig capture
      WizCtl.AddObject(ObjectType.ObjectText, TextObjectTypes.Who, Pad.WhoX, Pad.WhoY, TextStrings.SignatoryName, null);
      WizCtl.AddObject(ObjectType.ObjectText, TextObjectTypes.Why, Pad.WhyX, Pad.WhyY, TextStrings.Certify, null);

      // insert the buttons
      WizCtl.Font = Pad.ButtonFont;

      if (radImage.Checked)
      {
        WizCtl.AddObject(ObjectType.ObjectImage, ButtonTypes.Cancel, Pad.CancelSigButtonX, Pad.CancelSigButtonY, Pad.CancelButtonImage, null);
        WizCtl.AddObject(ObjectType.ObjectImage, ButtonTypes.Clear, Pad.ClearButtonX, Pad.ClearButtonY, Pad.ClearButtonImage, null);
        WizCtl.AddObject(ObjectType.ObjectImage, ButtonTypes.OK, Pad.OKButtonX, Pad.OKButtonY, Pad.AcceptButtonImage, null);
      }
      else
      {
        setFontColour(Pad, FontColours.White, FontColours.Green);

        WizCtl.AddObject(ObjectType.ObjectButton, ButtonTypes.Cancel, Pad.CancelSigButtonX, Pad.CancelSigButtonY, cancelButtonText, Pad.ButtonWidth);
        WizCtl.AddObject(ObjectType.ObjectButton, ButtonTypes.Clear, Pad.ClearButtonX, Pad.ClearButtonY, clearButtonText, Pad.ButtonWidth);
        WizCtl.AddObject(ObjectType.ObjectButton, ButtonTypes.OK, Pad.OKButtonX, Pad.OKButtonY, okButtonText, Pad.ButtonWidth);

        setFontColour(Pad, FontColours.Black, FontColours.White);
      }

      // set callback when a button is pressed
      Callback.EventHandler = new WizardCallback.Handler(Step3_Handler);
      WizCtl.SetEventHandler(Callback);
      WizCtl.Display();

    }

    private void Step3_Handler(object clt, object id, object type)
    {
      if (MouseUpOrigin == "step3")
      {
        switch (id.ToString())
        {
          case ButtonTypes.OK:
            {
              picWizardStep.MouseUp -= step3MouseEventHandler;
              step3MouseHandlerEnabled = false;
              scriptCompleted();
              break;
            }
          case ButtonTypes.Clear:
            {
              break;
            }
          case ButtonTypes.Cancel:
            {
              scriptCancelled();
              break;
            }
          default:
            {
              print("Unexpected pad event: " + id.ToString());
              break;
            }
        }
      }
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void setFontColour(StuProps Pad, string foreColour, string backColour)
    {
      if (Pad.supportsColour)
      {
        // Change button colours if supported
        WizCtl.SetProperty("ObjectForegroundColor", foreColour);
        WizCtl.SetProperty("ObjectBackgroundColor", backColour);
      }
      else
      {
        WizCtl.SetProperty("ObjectForegroundColor", FontColours.Black);
        WizCtl.SetProperty("ObjectBackgroundColor", FontColours.White);
      }
    }

    private void drawCosmeticRectangle(Graphics g, int x, int y, int width, int height)
		{
      Rectangle rectCosmetic = new Rectangle(x, y, width, height);
      g.FillRectangle(Brushes.White, rectCosmetic);
      g.DrawRectangle(Pens.Black, rectCosmetic);
    }


    // Display a copy of the step1 pad image on the Windows form
    private void showImageStep1(int padWidth, int padHeight, string padModel, bool largeCheckBox, bool checkBoxTicked, double imageRatio)
    {
      string cancelButtonText = ButtonText.Cancel;
      string nextButtonText = ButtonText.Next;

      if (radUTF8.Checked)
      {
        cancelButtonText = UTF8Text.Cancel;
        nextButtonText = UTF8Text.Next;
      }

      bitmapStep1 = new Bitmap(padWidth, padHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
      {
        Graphics gfx = Graphics.FromImage(bitmapStep1);
        gfx.PageUnit = GraphicsUnit.Pixel;
        gfx.Clear(Color.White);

        if (padModel == PadModels.STU5X0)
        {
          gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
        }
        else
        {
          // Anti-aliasing should be turned off for monochrome devices.
          gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
        }
        if (Pad.Model != PadModels.STU300)
          drawCosmeticRectangle(gfx, 0, picWizardStep.Height / 9, picWizardStep.Width - 2, picWizardStep.Height * 7 / 10);

        drawButtons(bitmapStep1, gfx, Pad.TextFont, sfCentered, Pad.Model, cancelButtonText, nextButtonText);
     
        checkBox = new Checkbox(gfx, Pad.TextFont, Pad.Model, largeCheckBox, Pad.supportsColour, checkBoxTicked, Pad.CheckBoxHeightLarge, Pad.CheckBoxWidthLarge, Pad.CheckBoxHeightSmall, Pad.CheckBoxWidthSmall, picWizardStep.Width, Pad.PadHeight);

        gfx.Dispose();

        // Finally, use this bitmap for the image background.
        picWizardStep.Image = bitmapStep1;
        picWizardStep.BackgroundImageLayout = ImageLayout.Center;

        if (!step1MouseHandlerEnabled)
        {
          picWizardStep.MouseUp += new System.Windows.Forms.MouseEventHandler(step1MouseEventHandler);
          step1MouseHandlerEnabled = true;
        }
      }
    }

    private void step1MouseEventHandler(object sender, MouseEventArgs e)
    {
      if (MouseUpOrigin == "step1")
      {
        if (btn1.buttonClicked(e.X, e.Y))
        {
          picWizardStep.MouseUp -= step1MouseEventHandler;
          step1MouseHandlerEnabled = false;
          WizCtl.FireClick(ButtonTypes.Cancel);
        }
        else
        if (btn2.buttonClicked(e.X, e.Y))
        {
          picWizardStep.MouseUp -= step1MouseEventHandler;
          step1MouseHandlerEnabled = false;
          if (isCheck)
          {
            MouseUpOrigin = "";
            step2();
          }
        }
        else
        if (e.X >= checkBox.xLeft && e.X <= checkBox.xRight && e.Y >= checkBox.yTop && e.Y <= checkBox.yBottom)
        {
          picWizardStep.MouseUp -= step1MouseEventHandler;
          step1MouseHandlerEnabled = false;

          isCheck = true;
          step1(true);
        }
      }
    }

    // Draw the buttons along the bottom of the screen i.e. on the Windows form, not the pad itself
    private void drawButtons(Bitmap bitmap, Graphics gfx, Font font, StringFormat sf, string stuModel, string btnText1, string btnText2, string btnText3 = "")
		{
      System.Drawing.Image btnImage;
      SizeF btn1TextSize, btn2TextSize, btn3TextSize;
      int btnHeight;
      int btnTextFontSize;
      int btn1TextIndent, btn2TextIndent, btn3TextIndent;
      int btnWidth;
      int xButton1, xButton2, xButton3;
      int xButton1Text, xButton2Text, xButton3Text;
      int yButton1, yButton2, yButton3;
      int yButton1Text, yButton2Text, yButton3Text;

      btnHeight = Pad.ButtonHeight;
      btn1TextIndent = btn2TextIndent = btn3TextIndent = 0;

      switch (Pad.Model)
			{
        case PadModels.STU300:
          if (radUTF8.Checked)
					{
            btn1TextIndent = 18;
					}
          else
					{
            btn1TextIndent = 24;
          }
          btn2TextIndent = 20;
          btn3TextIndent = 15;
          break;
        case PadModels.STU430:
          if (radUTF8.Checked)
          {
            btn1TextIndent = 15;
            btn2TextIndent = 13;
            btn3TextIndent = 20;
          }
          else
					{
            btn1TextIndent = 20;
            btn2TextIndent = 13;
            btn3TextIndent = 15;
          }
          break;
        case PadModels.STU500:
          if (radUTF8.Checked)
					{
            btn1TextIndent = 30;
            btn2TextIndent = 35;
            // If we are using foreign characters on the final screen then the indent for the OK button needs to be a lot less
            if (btnText3 != "" && btnText3 != ButtonText.OK)
              btn3TextIndent = 20;
            else
              btn3TextIndent = 45;
          }
          else
					{
            btn1TextIndent = 40;
            btn2TextIndent = 35;
            btn3TextIndent = 25;
          }
          break;
        case PadModels.STU5X0:
          if (radUTF8.Checked)
          {
            btn1TextIndent = 35;
            btn2TextIndent = 40;
            btn3TextIndent = 47;
          }
          else
          {
            btn1TextIndent = 46;
            btn2TextIndent = 40;
            btn3TextIndent = 36;
          }
          break;
			}
      if (radImage.Checked)
      {
        // We are using pre-defined images for the buttons so find out their width from the file path
        btnImage = System.Drawing.Image.FromFile(Pad.CancelButtonImage);
        btnWidth = btnImage.Width;
        btnHeight = btnImage.Height;
      }
      else
      {
        btnWidth = (int)Math.Abs(Pad.ButtonWidth * imageRatio);
      }

      btnTextFontSize = (int)Math.Abs(Pad.ButtonFontSize * imageRatio);

      btn1TextSize = gfx.MeasureString(btnText1, font);
      btn2TextSize = gfx.MeasureString(btnText2, font);

      if (btnText3 != "")
        btn3TextSize = gfx.MeasureString(btnText3, font);
      else
        btn3TextSize = new SizeF(0.0F, 0.0F);

      // Place the first button at the bottom left for all except the signature screen on the STU-300 where it must be at the top right
      if (btnText3 != "" && Pad.Model == PadModels.STU300)
      {
        xButton1 = picWizardStep.Width - btnWidth - 5;
        xButton1Text = xButton1 + ((btnWidth - (int)btn1TextSize.Width) / 2) + btn1TextIndent;
        yButton1 = 2;
        yButton1Text = yButton1 + 17;

        xButton3 = xButton2 = xButton1;

        xButton2Text = xButton2 + ((btnWidth - (int)btn2TextSize.Width) / 2) + btn2TextIndent;
        xButton3Text = xButton3 + ((btnWidth - (int)btn3TextSize.Width) / 2) + btn3TextIndent;

        yButton2 = yButton1 + Pad.ButtonHeight + 5;
        yButton2Text = yButton2 + 17;

        yButton3 = yButton2 + Pad.ButtonHeight + 5;
        yButton3Text = yButton3 + 17;
      }
      else
      {
        // To calculate the x co-ord of the text on the button subtract the length of the text from the length of the button
        // and divide by 2, then add that on to the x co-ord of the button
        xButton1 = 3;
        xButton1Text = xButton1 + ((btnWidth - (int)btn1TextSize.Width) / 2) + btn1TextIndent;

        if (btnText3 != "")
        {
          xButton2 = (picWizardStep.Width / 2) - (btnWidth / 2);
          xButton2Text = xButton2 + ((btnWidth - (int)btn2TextSize.Width) / 2) + btn2TextIndent;

          xButton3 = picWizardStep.Width - btnWidth - 5;

          if (stuModel == PadModels.STU5X0)
          {
            if (radUTF8.Checked)
              btn3TextIndent -= 30;
            else
              btn3TextIndent = 20;
          }
          else
          if (stuModel == PadModels.STU430)
            btn3TextIndent -= 10;

          xButton3Text = xButton3 + ((btnWidth - (int)btn3TextSize.Width) / 2) + btn3TextIndent;
        }
        else
				{
          // If there are only 2 buttons then the second button co-ords must be calculated for the bottom right-hand corner

          xButton2 = picWizardStep.Width - btnWidth - 5;
          xButton2Text = xButton2 + ((btnWidth - (int)btn2TextSize.Width) / 2) + btn3TextIndent;

          xButton3 = 0;
          xButton3Text = 0;
        }

        // Since the buttons are all along the bottom of the pad for all except the last screen on the STU-300 then they will all have the same y co-ords
        if (stuModel == PadModels.STU5X0)
        {
          if (radImage.Checked)
            yButton1 = picWizardStep.Height - btnHeight - 2;
          else
            yButton1 = picWizardStep.Height - Pad.ButtonHeight - 2;
        } 
        else
          yButton1 = picWizardStep.Height - Pad.ButtonHeight - 5;

        // Divide the height of the text by 2 and subtract from the height of the button to give the y co-ord for the text
        if (stuModel == PadModels.STU5X0)
          yButton1Text = yButton1 + btnHeight - ((int)btn1TextSize.Height / 2) - 2;
        else
          yButton1Text = yButton1 + btnHeight - ((int)btn1TextSize.Height / 2) - 6;

        yButton3 = yButton2 = yButton1;
        yButton3Text = yButton2Text = yButton1Text;
      }

      btn1 = new Button(xButton1, xButton1 + btnWidth - 1, yButton1, yButton1 + btnHeight - 1, xButton1Text, yButton1Text, imageRatio, sfCentered);
      btn1.drawButton(bitmap, gfx, stuModel, btnText1, Pad.CancelButtonImage, btnTextFontSize, btnWidth, btnHeight, radImage.Checked);

      if (btnText3 == "")
      {
        // Only 2 buttons so the second one goes on the bottom right
        btn2 = new Button(xButton2, xButton2 + btnWidth - 1, yButton2, yButton2 + btnHeight - 1, xButton2Text, yButton2Text, imageRatio, sfCentered);
        btn2.drawButton(bitmap, gfx, stuModel, btnText2, Pad.NextButtonImage, btnTextFontSize, btnWidth, btnHeight, radImage.Checked);
      }
      // If 3 are needed then the second one is in the middle
      else
      {
        // There are 3 buttons so the second one goes in the middle, then add the 3rd one at the bottom right
        btn2 = new Button(xButton2, xButton2 + btnWidth - 1, yButton2, yButton2 + btnHeight - 1, xButton2Text, yButton2Text, imageRatio, sfCentered);
        btn2.drawButton(bitmap, gfx, stuModel, btnText2, Pad.ClearButtonImage, btnTextFontSize, btnWidth, btnHeight, radImage.Checked);

        btn3 = new Button(xButton3, xButton3 + btnWidth - 1, yButton3, yButton3 + btnHeight - 1, xButton3Text, yButton3Text, imageRatio, sfCentered);
        btn3.drawButton(bitmap, gfx, stuModel, btnText3, Pad.AcceptButtonImage, btnTextFontSize, btnWidth, btnHeight, radImage.Checked);
      }
    }

    // Display a copy of the step2 pad image on the Windows form
    private void showImageStep2(int padWidth, int padHeight, string padModel, bool maleSelected)
    {
      string cancelButtonText = ButtonText.Cancel;
      string nextButtonText = ButtonText.Next;
      int xPrompt = 0;
      Brush textBrush;

      if (radUTF8.Checked)
      {
        cancelButtonText = UTF8Text.Cancel;
        nextButtonText = UTF8Text.Next;
      }

      bitmapStep2 = new Bitmap(padWidth, padHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
      {
        Graphics gfx = Graphics.FromImage(bitmapStep2);
        gfx.PageUnit = GraphicsUnit.Pixel;
        gfx.Clear(Color.White);

        if (padModel == PadModels.STU5X0)
        {
          gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
        }
        else
        {
          // Anti-aliasing should be turned off for monochrome devices.
          gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
        }
        if (Pad.Model != PadModels.STU300)
          drawCosmeticRectangle(gfx, 1, picWizardStep.Height / 9, picWizardStep.Width - 2, picWizardStep.Height * 7 / 10);

        drawButtons(bitmapStep2, gfx, Pad.TextFont, sfCentered, Pad.Model, cancelButtonText, nextButtonText);

        //measure the prompt string to help calculate where to place it
        SizeF textSize = gfx.MeasureString(TextStrings.SelectGender, Pad.TextFont);
        xPrompt = (picWizardStep.Width - (int)textSize.Width) / 2;

        // Create pens
        Pen blackPen = new Pen(Color.Black, 1);
        Pen bluePen = new Pen(Color.Blue, 1);

        // Draw radio buttons to screen.
        showImageStep2_RadioButtons(bitmapStep2, Pad.RadioMaleX, Pad.RadioMaleY, Pad.RadioFemaleX, Pad.RadioFemaleY, Pad.RadioWidth, maleSelected, TextStrings.Male, TextStrings.Female);

        //create a brush for the prompt text at the top
        if (Pad.supportsColour)
          textBrush = new SolidBrush(Color.Blue);
        else
          textBrush = new SolidBrush(Color.Black);

        gfx.DrawString(TextStrings.SelectGender, Pad.TextFont, textBrush, new PointF(xPrompt, 5));
        gfx.Dispose();

        // Finally, use this bitmap for the image background.
        picWizardStep.Image = bitmapStep2;
        picWizardStep.BackgroundImageLayout = ImageLayout.Stretch;

        if (!step2MouseHandlerEnabled)
        {
          picWizardStep.MouseUp += new System.Windows.Forms.MouseEventHandler(step2MouseEventHandler);
          step2MouseHandlerEnabled = true;
        }
      }
    }

    private void showImageStep2_RadioButtons(Bitmap bitmap, int maleX, int maleY, int femaleX, int femaleY, int radioWidth, bool maleSelected, string maleLabel, string femaleLabel)
		{

      Graphics gfx = Graphics.FromImage(bitmap);

      radioButtonMale = new RadioButton(maleX, maleY, radioWidth, radioWidth, maleLabel, Pad.supportsColour);
      radioButtonMale.drawRadioButton(gfx, maleSelected, Pad.TextFont, Pad.supportsColour);

      radioButtonFemale = new RadioButton(femaleX, femaleY, radioWidth, radioWidth, femaleLabel, Pad.supportsColour);
      radioButtonFemale.drawRadioButton(gfx, !maleSelected, Pad.TextFont, Pad.supportsColour);
    }

    private void step2MouseEventHandler(object sender, MouseEventArgs e)
    {
      if (MouseUpOrigin == "step2")
      {
        if (btn1.buttonClicked(e.X, e.Y))
        {
          picWizardStep.MouseUp -= step2MouseEventHandler;
          step2MouseHandlerEnabled = false;
          WizCtl.FireClick(ButtonTypes.Cancel);
        }
        else
        if (btn2.buttonClicked(e.X, e.Y))
        {
          picWizardStep.MouseUp -= step2MouseEventHandler;
          step2MouseHandlerEnabled = false;
          WizCtl.FireClick(ButtonTypes.Next);
        }
        else
        if (radioButtonMale.radioClicked(e.X, e.Y))
        {
          step2(true);
        }
        else
        if (radioButtonFemale.radioClicked(e.X, e.Y))
        {
          step2(false);
        }
      }
    }

    // Display a copy of the step3 pad image on the Windows form
    private void showImageStep3(int padWidth, int padHeight, string padModel)
    {
      string cancelButtonText = ButtonText.Cancel;
      string clearButtonText = ButtonText.Clear;
      int fontSize = 0;
      string okButtonText = ButtonText.OK;
      string sigLine = "";
      int xPrompt = 0;
      int yReason = 0;
      Brush textBrush;
      SizeF signeeSize;

      switch (Pad.Model)
      {
        case PadModels.STU300:
          sigLine = "X.....................................................";
          break;
        case PadModels.STU430:
          sigLine = "X.....................................................";
          break;
        case PadModels.STU500:
          sigLine = "X...........................................................";
          break;
        case PadModels.STU5X0:
          sigLine = "X...........................................................";
          break;
      }

      if (radUTF8.Checked)
      {
        cancelButtonText = UTF8Text.Cancel;
        clearButtonText = UTF8Text.Clear;
        okButtonText = UTF8Text.OK;
      }

      bitmapStep3 = new Bitmap(padWidth, padHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
      {
        Graphics gfx = Graphics.FromImage(bitmapStep3);
        gfx.PageUnit = GraphicsUnit.Pixel;
        gfx.Clear(Color.White);

        if (padModel == PadModels.STU5X0)
          fontSize = Pad.FontSize - 2;
        else
          fontSize = Pad.FontSize;

        Font font = new Font("Verdana", fontSize);
        Font sigLineFont = new Font("Verdana", fontSize);

        if (padModel == PadModels.STU5X0)
        {
          gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
        }
        else
        {
          // Anti-aliasing should be turned off for monochrome devices.
          gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
        }
        if (Pad.Model != PadModels.STU300)
          drawCosmeticRectangle(gfx, 1, picWizardStep.Height / 9, picWizardStep.Width - 2, picWizardStep.Height * 7 / 10);

        // Next the buttons
        drawButtons(bitmapStep3, gfx, font, sfCentered, Pad.Model, cancelButtonText, clearButtonText, okButtonText);

        //measure the prompt string to help calculate where to start it
        SizeF textSize = gfx.MeasureString(TextStrings.PleaseSign, font);
        xPrompt = (picWizardStep.Width - (int)textSize.Width) / 2;

        //create a brush for the text
        if (Pad.supportsColour)
          textBrush = new SolidBrush(Color.Blue);
        else
          textBrush = new SolidBrush(Color.Black);

        // Draw the "Please sign.." prompt and the signature underlining guide
        gfx.DrawString(TextStrings.PleaseSign, font, textBrush, new PointF(xPrompt, 5));
        gfx.DrawString(sigLine, sigLineFont, textBrush, new PointF(40, picWizardStep.Height * 12 / 20));

        if (Pad.Model != PadModels.STU300)
        {
          if (Pad.Model == PadModels.STU430)
            yReason = (int)picWizardStep.Height * 28 / 40;
          else
            yReason = (int)picWizardStep.Height * 30 / 40;
  
          // Display the "I certify..." message
          gfx.DrawString(TextStrings.Certify, font, textBrush, new PointF(5, yReason));

          // Measure the signatory string to help calculate where to place it
          signeeSize = gfx.MeasureString(TextStrings.SignatoryName, font);
          gfx.DrawString(TextStrings.SignatoryName, font, textBrush, new PointF(picWizardStep.Width - signeeSize.Width - 5, yReason));
        }

        gfx.Dispose();
        font.Dispose();

        // Finally, use this bitmap for the image background.
        picWizardStep.Image = bitmapStep3;
        picWizardStep.BackgroundImageLayout = ImageLayout.Stretch;

        if (!step3MouseHandlerEnabled)
        {
          picWizardStep.MouseUp += new System.Windows.Forms.MouseEventHandler(step3MouseEventHandler);
          step3MouseHandlerEnabled = true;
        }
      }
    }

    private void step3MouseEventHandler(object sender, MouseEventArgs e)
    {
      if (MouseUpOrigin == "step3")
      {
        if (btn1.buttonClicked(e.X, e.Y))
        {
          picWizardStep.MouseUp -= step3MouseEventHandler;
          print("Cancelled");
          WizCtl.FireClick(ButtonTypes.Cancel);
        }
        else
        if (btn2.buttonClicked(e.X, e.Y))
        {
          //print("Middle button clicked");
          WizCtl.FireClick(ButtonTypes.Clear);
        }
        else
        if (btn3.buttonClicked(e.X, e.Y))
        {
          picWizardStep.MouseUp -= step3MouseEventHandler;
          step3MouseHandlerEnabled = false;
          WizCtl.FireClick(ButtonTypes.OK);
        }
      }
    }

    private void overlaySigImage()
		{
      int destImageHeight, destImageWidth;
      int sourceImageHeight, sourceImageWidth;
      int xDest, yDest;

      // Overlay the signature image
      sourceImageWidth = signatureImage.Width;
      sourceImageHeight = signatureImage.Height;

      if (Pad.Model == PadModels.STU300)
      {
        destImageHeight = 94;
        destImageWidth = 300;
        xDest = 5;
        yDest = 5;
      }
      else
      {
        // Let's assume that the signature probably takes up about two-thirds of the pad display
        // so we will aim to overlay that same ratio on the replica window
        // and place it within the cosmetic rectangle
        destImageHeight = (int)(sourceImageHeight * 2 / 3);
        destImageWidth = (int)(sourceImageWidth * 2 / 3);
        xDest = 2;
        yDest = picWizardStep.Height / 8;
      }

      RectangleF destinationRect = new RectangleF(xDest, yDest, destImageWidth, destImageHeight);
      RectangleF sourceRect = new RectangleF(0, 0, sourceImageWidth, sourceImageHeight);

      using (Graphics g = Graphics.FromImage(bitmapStep3))
      {
        g.DrawImage(signatureImage, destinationRect, sourceRect, GraphicsUnit.Pixel);
      }
      picWizardStep.Image = bitmapStep3;
    }
  }
}
