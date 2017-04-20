using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class UserFiguresTransformer
    {
        public FiguresList.FigureList TransformToFullList(FiguresList.FigureList srclist)
        {
            var Rezlist = new FiguresList.FigureList();

            for (int i = 0; i < srclist.Size(); i++)
            {
                if (srclist.Item(i) is UserFigure)
                {
                    for (int j = 0; j < ((UserFigure)srclist.Item(i)).Primitives.Size(); j++)
                    {
                        Rezlist.Add(((UserFigure)srclist.Item(i)).Primitives.Item(j));
                    }
                }
                else
                {
                    Rezlist.Add(srclist.Item(i));
                }
            }
            return Rezlist;
        }

        public FiguresList.FigureList TransformOneFigureToPrimitives(FiguresList.FigureList srclist, int index)
        {
            var Rezlist = new FiguresList.FigureList();

            for (int i = 0; i < srclist.Size(); i++)
            {
                if (i == index)
                {
                    for (int j = 0; j < ((UserFigure)srclist.Item(i)).Primitives.Size(); j++)
                    {
                        Rezlist.Add(((UserFigure)srclist.Item(i)).Primitives.Item(j));
                    }
                }
                else
                {
                    Rezlist.Add(srclist.Item(i));
                }
            }

            return Rezlist;
        }
    }
}
