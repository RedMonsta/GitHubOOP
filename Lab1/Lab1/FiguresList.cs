using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Lab1
{
    [Serializable]
    public class FigureList
    {
        private List<Figure> figures;
        public Figure Last { get { return figures[figures.Count() - 1]; } }
        //private Figure last;
        public FigureList()
        {
            figures = new List<Figure>();
        }

        public void Add(Figure item)
        {
            figures.Add(item);
        }

        public bool Remove(Figure item)
        {
            if (figures.Remove(item)) return true;
            else return false;
        }

        public bool Remove(int index)
        {
            if (figures.Remove(figures[index])) return true;
            else return false;
        }

        public Figure Item(int index)
        {
            return figures[index];
        }

        /*private Figure getlast()
        {
            return new Line( new Pen(Brushes.AliceBlue, 3), 0, 0, 100, 100);
            //return figures[figures.Count() - figures.Count()];
        }*/

        public int Size()
        {
            return figures.Count();
        }

        public void DrawAll(Graphics gr)
        {
            //for (int i = 0; i < figures.Count; i++)
            foreach (var fig in figures)
                fig.Draw(gr);
        }

        public void PrintList(ListBox lbox)
        {
            lbox.Items.Clear();
            foreach (var fig in figures)
            {
                lbox.Items.Add((fig.ToString()).Substring(5));          
            }
        }

        public void AddOneMore(ListBox lbox)
        {
            //lbox.Items.Add((Last.ToString()).Substring(5));
            lbox.Items.Add(figures[figures.Count - 1].ToString().Substring(5));
        }

        public void Clear()
        {
            figures.Clear();
        }

        public int MouseSelect(MouseEventArgs e)
        {
            for (int i = figures.Count() - 1; i >= 0; i--)   
            {
                if (figures[i].X1 < figures[i].X2 && figures[i].Y1 < figures[i].Y2)
                    if (e.X > figures[i].X1 && e.X < figures[i].X2 && e.Y > figures[i].Y1 && e.Y < figures[i].Y2) return i;
                if (figures[i].X2 < figures[i].X1 && figures[i].Y1 < figures[i].Y2)
                    if (e.X > figures[i].X2 && e.X < figures[i].X1 && e.Y > figures[i].Y1 && e.Y < figures[i].Y2) return i;
                if (figures[i].X1 < figures[i].X2 && figures[i].Y2 < figures[i].Y1)
                    if (e.X > figures[i].X1 && e.X < figures[i].X2 && e.Y > figures[i].Y2 && e.Y < figures[i].Y1) return i;
                if (figures[i].X2 < figures[i].X1 && figures[i].Y2 < figures[i].Y1)
                    if (e.X > figures[i].X2 && e.X < figures[i].X1 && e.Y > figures[i].Y2 && e.Y < figures[i].Y1) return i;
            }
            return -1;
        }

        public void AllOff()
        {
            foreach (var fig in figures)
                fig.isSelected = false;
        }

        public void DrawAllExcept(Graphics gr, int index)
        {
            for (int i = 0; i < figures.Count; i++)
                if (i != index) figures[i].Draw(gr);
        }

    }
}
