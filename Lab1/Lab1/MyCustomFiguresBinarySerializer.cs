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
    public class MyCustomFiguresBinarySerializer
    {
        private BinaryFormatter formatter { get; set; }

        public MyCustomFiguresBinarySerializer()
        {
            formatter = new BinaryFormatter();
        }

        public void SaveFiguresList(FileStream fs, FiguresList.FigureList figs)
        {
            //var usrfigslist = new FiguresList.FigureList();
            var serfigslist = new SerialFiguresList();
            for (int i = 0; i < figs.Size(); i++)
            {
                var serfig = new SerialFigure(figs.Item(i));
                serfigslist.Add(serfig);
                if (figs.Item(i) is UserFigure)
                {
                    for (int j = 0; j < ((UserFigure)figs.Item(i)).SourceFigures.Size(); j++)
                    {
                        ((UserFigure)figs.Item(i)).SourceFigures.Item(j).isUserFigure = true;
                        serfig = new SerialFigure(((UserFigure)figs.Item(i)).SourceFigures.Item(j));
                        serfigslist.Add(serfig);
                    }
                }               
            }
            formatter.Serialize(fs, serfigslist);
        }

        public FiguresList.FigureList LoadFiguresList(FileStream fs, List<Type> types, List<string> nameslist)
        {
            FiguresList.FigureList Rezlist = new FiguresList.FigureList();
            SerialFiguresList SerFigsList = (SerialFiguresList)formatter.Deserialize(fs);
            UserFigure tmpusrfig = new UserFigure("UserFigure", new Pen(Brushes.Black, 1) , 0, 0, 0, 0);

            int i = 0;
            while (i < SerFigsList.Size())
            {
                //if (SerFigsList.Item(i).Name == "UserFigure" && SerFigsList.Item(i).isUserFigure == false)
                if (CheckUserName(nameslist, SerFigsList.Item(i).Name) && SerFigsList.Item(i).isUserFigure == false)
                {
                    tmpusrfig = new UserFigure(SerFigsList.Item(i).Name, new Pen(SerFigsList.Item(i).penColor, SerFigsList.Item(i).penWidth), SerFigsList.Item(i).X1, SerFigsList.Item(i).Y1, SerFigsList.Item(i).X2, SerFigsList.Item(i).Y2);
                    i++;
                    while (SerFigsList.Item(i).isUserFigure == true)
                    {
                        Type typ = null;
                        for (int j = 0; j < types.Count(); j++)
                        {
                            if (types[j].FullName == SerFigsList.Item(i).figtype) typ = types[j];
                        }
                        if (typ == null)
                        {
                            throw new SerializationException("Unable to load item " + SerFigsList.Item(i).figtype + ": Assembly is not found.");
                        }
                        var pen = new Pen(SerFigsList.Item(i).penColor, SerFigsList.Item(i).penWidth);
                        var fig = (Figure.Figure)Activator.CreateInstance(typ, new Object[] { pen, SerFigsList.Item(i).X1, SerFigsList.Item(i).Y1, SerFigsList.Item(i).X2, SerFigsList.Item(i).Y2 });
                        if (fig is MyInterfaces.IFillingable) ((MyInterfaces.IFillingable)fig).isFilled = SerFigsList.Item(i).isFilled;
                        fig.isUserFigure = SerFigsList.Item(i).isUserFigure;
                        tmpusrfig.SourceFigures.Add(fig);
                        i++;
                        if (i == SerFigsList.Size()) break;
                    }
                    tmpusrfig.OnDeserialize();
                    Rezlist.Add(tmpusrfig);
                    
                }
                //else if (SerFigsList.Item(i).Name != "UserFigure" && SerFigsList.Item(i).isUserFigure == false)
                else if (!CheckUserName(nameslist, SerFigsList.Item(i).Name) && SerFigsList.Item(i).isUserFigure == false)
                {
                    Type typ = null;
                    for (int j = 0; j < types.Count(); j++)
                    {
                        if (types[j].FullName == SerFigsList.Item(i).figtype) typ = types[j];
                    }
                    if (typ == null)
                    {
                        throw new SerializationException("Unable to load item " + SerFigsList.Item(i).figtype + ": Assembly is not found.");
                    }
                    var pen = new Pen(SerFigsList.Item(i).penColor, SerFigsList.Item(i).penWidth);
                    var fig = (Figure.Figure)Activator.CreateInstance(typ, new Object[] { pen, SerFigsList.Item(i).X1, SerFigsList.Item(i).Y1, SerFigsList.Item(i).X2, SerFigsList.Item(i).Y2 });
                    if (fig is MyInterfaces.IFillingable) ((MyInterfaces.IFillingable)fig).isFilled = SerFigsList.Item(i).isFilled;
                    fig.isUserFigure = SerFigsList.Item(i).isUserFigure;
                    Rezlist.Add(fig);
                    i++;
                    if (i == SerFigsList.Size()) break;
                }
                
            }

            return Rezlist;

        }

        private bool CheckUserName(List<string> nameslist, string name)
        {
            bool result = false;

            for (int i = 0; i < nameslist.Count(); i++)
            {
                if (name == nameslist[i]) result = true;
            }
            return result;

        }




    }
}
