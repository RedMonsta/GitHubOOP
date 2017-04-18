using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Drawing;

namespace Lab1
{
    public class MyCustomFiguresListBinarySerializer
    {
        private BinaryFormatter formatter { get; set; }

        public MyCustomFiguresListBinarySerializer()
        {
            formatter = new BinaryFormatter();
        }

        public void SaveFiguresList(FileStream fs, FiguresList.FigureList figs)
        {
            SerialFiguresList SerFigsList = new SerialFiguresList(); ;
            for (int i = 0; i < figs.Size(); i++)
            {
                SerialFigure serfig = new SerialFigure(figs.Item(i));
                SerFigsList.Add(serfig);
            }
            formatter.Serialize(fs, SerFigsList);
        }

        public FiguresList.FigureList LoadFiguresList(FileStream fs, List<Type> types)
        {
            FiguresList.FigureList Rezlist = new FiguresList.FigureList();          
            SerialFiguresList SerFigsList = (SerialFiguresList)formatter.Deserialize(fs);
            for (int i = 0; i < SerFigsList.Size(); i++)
            {
                Type typ = null;
                for (int j = 0; j < types.Count(); j++)
                {
                    if (types[j].FullName == SerFigsList.Item(i).figtype) typ = types[j];
                }
                if (typ == null)
                {
                    throw new System.Runtime.Serialization.SerializationException("Unable to load item " + SerFigsList.Item(i).figtype + ": Assembly is not found.");
                }
                var pen = new Pen(SerFigsList.Item(i).penColor, SerFigsList.Item(i).penWidth);
                var fig = (Figure.Figure)Activator.CreateInstance(typ, new Object[] { pen, SerFigsList.Item(i).X1, SerFigsList.Item(i).Y1, SerFigsList.Item(i).X2, SerFigsList.Item(i).Y2 });
                if (fig is MyInterfaces.IFillingable) ((MyInterfaces.IFillingable)fig).isFilled = SerFigsList.Item(i).isFilled;
                Rezlist.Add(fig);
            }
            return Rezlist;      
                
        }
    }   
}
