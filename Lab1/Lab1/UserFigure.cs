using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1
{
    public class UserFigure : Figure.Figure, MyInterfaces.ISelectable, MyInterfaces.IEditable, MyInterfaces.IFillingable
    {
        public FiguresList.FigureList Primitives { get; set; }
        public FiguresList.FigureList SourceFigures { get; set; }
        public bool isSelected { get; set; }
        public bool isFilled { get; set; }

        private int MinX { get; set; }
        private int MinY { get; set; }
        private int MaxX { get; set; }
        private int MaxY { get; set; }


        public UserFigure(string srcname, FiguresList.FigureList srclist, Pen pens, int x1, int y1, int x2, int y2) : base(pens, x1, y1, x2, y2)
        {
            //SourceFigures = srclist;
            Primitives = new FiguresList.FigureList();
            SourceFigures = new FiguresList.FigureList();
            for (int i = 0; i < srclist.Size(); i++)
            {
                SourceFigures.Add(srclist.Item(i).Copy());
            }
            for (int i = 0; i < srclist.Size(); i++)
            {
                Primitives.Add(srclist.Item(i).Copy());
            }
            //Name = "UserFigure";
            Name = srcname;
            GetEdgeCoordinates();
            GetRelativeCoords();
        }

        public UserFigure(string srcname, Pen pens, int x1, int y1, int x2, int y2) : base(pens, x1, y1, x2, y2)
        {
            Primitives = new FiguresList.FigureList();
            SourceFigures = new FiguresList.FigureList();
            //Name = "UserFigure";
            Name = srcname;
        }

        public void OnDeserialize()
        {
            GetEdgeCoordinates();
            for (int i = 0; i < SourceFigures.Size(); i++)
            {
                Primitives.Add(SourceFigures.Item(i).Copy());
            }
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

        public void Fill(Graphics gr)
        {
            return;
        }

        public override void Draw(Graphics gr)
        {
            GetRelativeCoords();
            for (int i = 0; i < Primitives.Size(); i++)
            {
                Primitives.Item(i).Draw(gr);
                if (Primitives.Item(i) is MyInterfaces.IFillingable) if (((MyInterfaces.IFillingable)Primitives.Item(i)).isFilled) ((MyInterfaces.IFillingable)Primitives.Item(i)).Fill(gr);
            }
        }

        public override void ChangePen(Pen pens)
        {
            base.ChangePen(pens);
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

        private void GetEdgeCoordinates()
        {
            if (SourceFigures.Size() > 0)
            {
                MinX = SourceFigures.Item(0).X1;
                for (int i = 0; i < SourceFigures.Size(); i++)
                {
                    //if (SourceFigures.Item(i).Direction == 0 || SourceFigures.Item(i).Direction == 3) if (SourceFigures.Item(i).X1 < MinX) MinX = SourceFigures.Item(i).X1;
                    //if (SourceFigures.Item(i).Direction == 1 || SourceFigures.Item(i).Direction == 2) if (SourceFigures.Item(i).X2 < MinX) MinX = SourceFigures.Item(i).X2;
                    if (SourceFigures.Item(i).X1 < MinX) MinX = SourceFigures.Item(i).X1;
                    if (SourceFigures.Item(i).X2 < MinX) MinX = SourceFigures.Item(i).X2;
                }

                MinY = SourceFigures.Item(0).Y1;
                for (int i = 0; i < SourceFigures.Size(); i++)
                {
                    if (SourceFigures.Item(i).Y1 < MinY) MinY = SourceFigures.Item(i).Y1;
                    if (SourceFigures.Item(i).Y2 < MinY) MinY = SourceFigures.Item(i).Y2;
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
}
