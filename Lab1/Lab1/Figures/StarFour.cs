using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Lab1
{
    public class StarFour : Figure
    {
        public StarFour(Pen pens, int x1, int y1, int x2, int y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            pen = new Pen(pens.Brush, pens.Width);
        }
        public override void Draw(Graphics gr)
        {
            //Graphics g = pbox.CreateGraphics();
            gr.DrawLine(pen, X1 + (X2 - X1) / 2, Y1, X1 + (X2 - X1) / 8 * 5, Y1 + (Y2 - Y1) / 8 * 3);
            gr.DrawLine(pen, X1 + (X2 - X1) / 8 * 5, Y1 + (Y2 - Y1) / 8 * 3, X2, Y1 + (Y2 - Y1) / 2);
            gr.DrawLine(pen, X2, Y1 + (Y2 - Y1) / 2, X1 + (X2 - X1) / 8 * 5, Y1 + (Y2 - Y1) / 8 * 5);
            gr.DrawLine(pen, X1 + (X2 - X1) / 8 * 5, Y1 + (Y2 - Y1) / 8 * 5, X1 + (X2 - X1) / 2, Y2);
            gr.DrawLine(pen, X1 + (X2 - X1) / 2, Y2, X1 + (X2 - X1) / 8 * 3, Y1 + (Y2 - Y1) / 8 * 5);
            gr.DrawLine(pen, X1 + (X2 - X1) / 8 * 3, Y1 + (Y2 - Y1) / 8 * 5, X1, Y1 + (Y2 - Y1) / 2);
            gr.DrawLine(pen, X1, Y1 + (Y2 - Y1) / 2, X1 + (X2 - X1) / 8 * 3, Y1 + (Y2 - Y1) / 8 * 3);
            gr.DrawLine(pen, X1 + (X2 - X1) / 8 * 3, Y1 + (Y2 - Y1) / 8 * 3, X1 + (X2 - X1) / 2, Y1);

        }
    }
}
