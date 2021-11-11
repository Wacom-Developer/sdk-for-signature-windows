using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WizardExtra
{
	public partial class Step1 : Form
	{
		public Step1(int padWidth, int padHeight)
		{
      Bitmap m_bitmap;
      InitializeComponent();

      m_bitmap = new Bitmap(padWidth, padHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
      {
        Graphics gfx = Graphics.FromImage(m_bitmap);
        gfx.Clear(Color.White);

        // Uses pixels for units as DPI won't be accurate for tablet LCD.
        Font font = new Font(FontFamily.GenericSansSerif, 20, GraphicsUnit.Pixel);
        StringFormat sf = new StringFormat();
        sf.Alignment = StringAlignment.Center;
        sf.LineAlignment = StringAlignment.Center;

        if (true)
        {
          gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
        }
        else
        {
          // Anti-aliasing should be turned off for monochrome devices.
          gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
        }

        gfx.Dispose();
        font.Dispose();

        // Finally, use this bitmap for the window background.
        this.BackgroundImage = m_bitmap;
        this.BackgroundImageLayout = ImageLayout.Stretch;
      }
    }
  }
}