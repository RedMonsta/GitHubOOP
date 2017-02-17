using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Lab1
{
    public class LetterA : SymbolFigure
    {
        public LetterA(Pen pens, int x1, int y1, int size)
        {
            X1 = x1;
            Y1 = y1;
            FontSize = size;
            pen = new Pen(pens.Brush, pens.Width);
        }
        public override void Draw(PictureBox pbox)
        {
            Graphics g = pbox.CreateGraphics();
            g.DrawLine(pen, X1 + FontSize * 3 / 2, Y1, X1 + FontSize * 3, Y1 + FontSize * 4);
            g.DrawLine(pen, X1 + FontSize * 3 / 2, Y1, X1, Y1 + FontSize * 4);
            g.DrawLine(pen, X1 + 2 + (FontSize * 3 / 2 / 8 * 3), Y1 + (FontSize * 4 / 8 * 5), X1 + 2 + (FontSize * 3 / 2 / 8 * 5) + FontSize * 3 / 2, Y1 + (FontSize * 4 / 8 * 5));
        }

    }
}
