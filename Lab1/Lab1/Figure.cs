using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

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

            position = -1;
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

        public void Edit(MouseEventArgs e)
        {
         /*   if (position == 1)
            {
                X1 = e.X;
                Y1 = e.Y;
                return;
            }*/

            switch (position)
            {
                case 1:
                    {
                        X1 = e.X;
                        Y1 = e.Y;
                        break;
                    }
                case 2:
                    {
                        Y1 = e.Y;
                        break;
                    }

                default: { break; }
            }
            //int pos = -1;
            if (e.X < X1 + 10 && e.X > X1 - 10 && e.Y < Y1 + 10 && e.Y > Y1 - 10) { position = 1; }
            else if (e.X < (X1 + X2) / 2 + 10 && e.X > (X1 + X2) / 2 - 10 && e.Y < Y1 + 10 && e.Y > Y1 - 10) { position = 2; }
            else if (e.X < X2 + 5 && e.X > X2 - 5 && e.Y < Y1 + 5 && e.Y > Y1 - 5) { position = 5; }
            else if (e.X < X1 + 5 && e.X > X1 - 5 && e.Y < Y2 + 5 && e.Y > Y2 - 5) { position = 3; }
            else if (e.X < X2 + 5 && e.X > X2 - 5 && e.Y < Y2 + 5 && e.Y > Y2 - 5) { position = 4; }
            
            else if (e.X < (X1 + X2) / 2 + 5 && e.X > (X1 + X2) / 2 - 5 && e.Y < Y2 + 5 && e.Y > Y2 - 5) { position = 6; }
            else if (e.X < X1 + 5 && e.X > X1 - 5 && e.Y < (Y1 + Y2) / 2 + 5 && e.Y > (Y1 + Y2) / 2 - 5) { position = 7; }
            else if (e.X < X2 + 5 && e.X > X2 - 5 && e.Y < (Y1 + Y2) / 2 + 5 && e.Y > (Y1 + Y2) / 2 - 5) { position = 8; }
            else if (e.X < (X1 + X2) / 2 + 5 && e.X > (X1 + X2) / 2 - 5 && e.Y < (Y1 + Y2) / 2 + 5 && e.Y > (Y1 + Y2) / 2 - 5) { position = 0; }
            else position = -1;
            /*switch (position)
                 {
                 case 1:
                     {
                         X1 = e.X;
                         Y1 = e.Y;
                         break;
                     }
                case 2:
                    {
                        Y1 = e.Y;
                        break;
                    }

                 default: { break; } 
             }*/
             

            /*if (e.X < this.X1 + 5 && e.X > this.X1 - 5 && e.Y < this.Y1 + 5 && e.Y > this.Y1 - 5)
            {
                this.X1 = e.X;
                this.Y1 = e.Y;
            }*/
        }

        public Pen pen;
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }

        private int position { get; set; }
        public bool isSelectable { get; set; }
        public bool isSelected { get; set; }
        public bool isEditable { get; set; }
        
    }
}
