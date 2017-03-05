using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab1
{
    public abstract class Figure : ISelectable, IEditable
    {
        //public virtual void Draw(PictureBox pbox) { }
        public Figure(Pen pens, int x1, int y1, int x2, int y2)
        {
            /*if (x1 < x2) { X1 = x1; X2 = x2; }
            else { X1 = x2; X2 = x1; }
            if (y1 < y2) { Y1 = y1; Y2 = y2; }
            else { Y1 = y2; Y2 = y1; }*/


            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            //pen = new Pen(pens.Brush, pens.Width);
            isSelectable = true;
            isEditable = true;

            isSelected = false;
               
            pen = (Pen)pens.Clone();
        }

        public void GetPen(Pen pn)
        {
            //pen.Brush = pn.Brush;
            pen = (Pen)pn.Clone();
        }

        public abstract void Draw(Graphics gr);

        public void SelectFigure(Graphics gr)
        {
            gr.Clear(Color.Transparent);
            this.isSelected = true;
            var pens = new Pen(Brushes.Gray, 1);
            pens.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            gr.DrawLine(pens, X1, Y1, X2, Y1);
            gr.DrawLine(pens, X2, Y1, X2, Y2);
            gr.DrawLine(pens, X2, Y2, X1, Y2);
            gr.DrawLine(pens, X1, Y2, X1, Y1);
            pens.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            gr.DrawEllipse(pens, X1 - 3, Y1 - 3, 6, 6);
            gr.DrawEllipse(pens, X1 - 3, Y2 - 3, 6, 6);
            gr.DrawEllipse(pens, X2 - 3, Y1 - 3, 6, 6);
            gr.DrawEllipse(pens, X2 - 3, Y2 - 3, 6, 6);
            gr.DrawEllipse(pens, (X1 + X2) / 2 - 3, Y1 - 3, 6, 6);
            gr.DrawEllipse(pens, (X1 + X2) / 2 - 3, Y2 - 3, 6, 6);
            gr.DrawEllipse(pens, X1 - 3, (Y1 + Y2) / 2 - 3, 6, 6);
            gr.DrawEllipse(pens, X2 - 3, (Y1 + Y2) / 2 - 3, 6, 6);
            gr.DrawEllipse(pens, (X1 + X2) / 2 - 4, (Y1 + Y2) / 2 - 4, 8, 8);
            gr.DrawLine(pens, (X1 + X2) / 2 - 3, (Y1 + Y2) / 2 - 3, (X1 + X2) / 2 + 3, (Y1 + Y2) / 2 + 3);
            gr.DrawLine(pens, (X1 + X2) / 2 - 3, (Y1 + Y2) / 2 + 3, (X1 + X2) / 2 + 3, (Y1 + Y2) / 2 - 3);
        }

        public Pen pen;
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }

        public bool isSelectable { get; set; }
        public bool isSelected { get; set; }
        public bool isEditable { get; set; }
    }
}
