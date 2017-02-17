using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Lab1
{
    public class Rect : RectLike
    {
        public Rect(Pen pens, int x1, int y1, int x2, int y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            pen = new Pen(pens.Brush, pens.Width);
        }
        public override void Draw(PictureBox pbox)
        {
            Graphics g = pbox.CreateGraphics();
            g.DrawRectangle(pen, new Rectangle(X1, Y1, X2 - X1, Y2 - Y1));
        }
        public override void Draw(Graphics gr)
        {
            //Graphics g = pbox.CreateGraphics();
            gr.DrawRectangle(pen, new Rectangle(X1, Y1, X2 - X1, Y2 - Y1));
        }
    }
}
