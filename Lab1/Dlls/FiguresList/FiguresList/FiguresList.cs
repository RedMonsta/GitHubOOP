using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace FiguresList
{
    [Serializable]
    public class FigureList
    {
        private List<Figure.Figure> figures;
        public Figure.Figure Last { get { return figures[figures.Count() - 1]; } }

        public FigureList()
        {
            figures = new List<Figure.Figure>();
        }

        public void Add(Figure.Figure item)
        {
            figures.Add(item);
        }

        public bool Remove(Figure.Figure item)
        {
            if (figures.Remove(item)) return true;
            else return false;
        }

        public bool Remove(int index)
        {
            if (figures.Remove(figures[index])) return true;
            else return false;
        }

        public Figure.Figure Item(int index)
        {
            return figures[index];
        }

        public int Size()
        {
            return figures.Count();
        }

        public void DrawAll(Graphics gr)
        {
            foreach (var fig in figures)
            {
                fig.Draw(gr);
                if (fig is MyInterfaces.IFillingable) if (((MyInterfaces.IFillingable)fig).isFilled) ((MyInterfaces.IFillingable)fig).Fill(gr);
                //if (fig.isFilled == true) fig.Fill(gr);
            }
        }

        public void PrintList(ListBox lbox)
        {
            lbox.Items.Clear();
            foreach (var fig in figures)
            {
                lbox.Items.Add(fig.GetName());
            }
        }

        public void AddOneMore(ListBox lbox)
        {
            lbox.Items.Add(figures[figures.Count - 1].GetName());
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
                if (fig is MyInterfaces.ISelectable) ((MyInterfaces.ISelectable)fig).isSelected = false;
        }

        public void DrawAllExcept(Graphics gr, int index)
        {
            for (int i = 0; i < figures.Count; i++)
            {
                if (i != index) figures[i].Draw(gr);
                if (figures[i] is MyInterfaces.IFillingable) if (((MyInterfaces.IFillingable)figures[i]).isFilled) ((MyInterfaces.IFillingable)figures[i]).Fill(gr);
            }
        }

    }
}
