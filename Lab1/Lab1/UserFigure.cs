using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1
{
    public class UserFigure : Figure.Figure, MyInterfaces.ISelectable, MyInterfaces.IEditable//, MyInterfaces.IFillingable//, MyInterfaces.IEditable, MyInterfaces.IFillingable, MyInterfaces.ISelectable
    {
        //public List<Figure.Figure> Primitives { get; set; }
       // public List<Figure.Figure> SourceFigure { get; set; }
        public FiguresList.FigureList Primitives { get; set; }
        public FiguresList.FigureList SourceFigures { get; set; }
        private int SrcX1 { get; set; }
        private int SrcY1 { get; set; }
        private int SrcX2 { get; set; }
        private int SrcY2 { get; set; }
        public bool isSelected { get; set; }
        public bool isFilled { get; set; }

        private int MinX { get; set; }
        private int MinY { get; set; }
        private int MaxX { get; set; }
        private int MaxY { get; set; }


        public UserFigure(FiguresList.FigureList srclist, Pen pens, int x1, int y1, int x2, int y2) : base(pens, x1, y1, x2, y2)
        {
            SourceFigures = srclist;
            Primitives = new FiguresList.FigureList();
            SourceFigures = new FiguresList.FigureList();
            SourceFigures = srclist;
            for (int i = 0; i < srclist.Size(); i++)
            {
                Primitives.Add(srclist.Item(i).Copy());
            }
            //foreach (var item in srclist)
            //{
            //    Primitives.Add(item.Copy());
            //}
            Name = "UserFigure";
            GetEdgeCoordinates();
            //SrcX1 = sx1;
            //SrcY1 = sy1;
            //SrcX2 = sx2;
            //SrcY2 = sy2;
            GetRelativeCoords();
        }

        private void GetRelativeCoords()
        {
            for (int i = 0; i < Primitives.Size(); i++)
            {
                Primitives.Item(i).X1 = X1 + (SourceFigures.Item(i).X1 - MinX) * (X2 - X1) / (MaxX - MinX);

                Primitives.Item(i).Y1 = Y1 + (SourceFigures.Item(i).Y1 - MinY) * (Y2 - Y1) / (MaxY - MinY);

                Primitives.Item(i).X2 = X1 + (SourceFigures.Item(i).X2 - MinX) * (X2 - X1) / (MaxX - MinX);

                Primitives.Item(i).Y2 = Y1 + (SourceFigures.Item(i).Y2 - MinY) * (Y2 - Y1) / (MaxY - MinY);


            }
        }

        public override void Edit(int pos, MouseEventArgs e)
        {
            base.Edit(pos, e);
            GetRelativeCoords();
        }

        //public void Fill(Graphics gr)
        //{
        //    foreach (var item in Primitives)
        //    {
        //        if (item is MyInterfaces.IFillingable) 
        //        {
        //            if ( ((MyInterfaces.IFillingable)item).isFilled ) ((MyInterfaces.IFillingable)item).Fill(gr);
        //        }
        //    }
        //}

        public override void Draw(Graphics gr)
        {
            //foreach (var item in Primitives)
            //{
            //    item.Draw(gr);
            //}
            GetRelativeCoords();
            for (int i = 0; i < Primitives.Size(); i++)
            {
                Primitives.Item(i).Draw(gr);
                //Primitives.Item(i).X1++;
                //Primitives.Item(i).Y1++;
                //Primitives.Item(i).X2++;
                //Primitives.Item(i).Y2++;
            }
        }

        public override void ChangePen(Pen pens)
        {
            base.ChangePen(pens);
            //foreach (var item in Primitives)
            //{
            //    item.ChangePen(pens);
            //}
            for (int i = 0; i < Primitives.Size(); i++)
            {
                Primitives.Item(i).ChangePen(pens);
            }
        }

        public override Figure.Figure Copy()
        {
            return null;
            //return new UserFigure( new Pen(pen.color, pen.Width), X1, Y1, X2, Y2);
        }

        
        public List<string> GetPrimitives()
        {
            var list = new List<string>();
            for (int i = 0; i < Primitives.Size(); i++)
            {
                list.Add(Primitives.Item(i).GetName());
            }
            return list;

        }

        private void GetEdgeCoordinates()
        {
            MinX = SourceFigures.Item(0).X1;
            for (int i = 0; i < SourceFigures.Size(); i++)
            {
                if (SourceFigures.Item(i).X1 < MinX) MinX = SourceFigures.Item(i).X1;
            }

            MinY = SourceFigures.Item(0).Y1;
            for (int i = 0; i < SourceFigures.Size(); i++)
            {
                if (SourceFigures.Item(i).Y1 < MinY) MinY = SourceFigures.Item(i).Y1;
            }

            MaxX = SourceFigures.Item(0).X2;
            for (int i = 0; i < SourceFigures.Size(); i++)
            {
                if (SourceFigures.Item(i).X2 > MaxX) MaxX = SourceFigures.Item(i).X2;
            }

            MaxY = SourceFigures.Item(0).Y2;
            for (int i = 0; i < SourceFigures.Size(); i++)
            {
                if (SourceFigures.Item(i).Y2 > MaxY) MaxY = SourceFigures.Item(i).Y2;
            }
        }


    }
}
