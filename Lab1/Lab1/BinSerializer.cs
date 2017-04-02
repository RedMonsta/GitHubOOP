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

namespace Lab1
{
    public class BinSerializer
    {
        private BinaryFormatter formatter { get; set; }

        public BinSerializer()
        {
            formatter = new BinaryFormatter();
        }

        public void Save(string destname, FigureList figs)
        {
            File.Delete(destname);
            for (int i = 0; i < figs.Size(); i++)
            {
                FileStream tempfile = new FileStream("./temp.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                formatter.Serialize(tempfile, figs.Item(i));
                tempfile.Close();
                StreamReader reader = new StreamReader("./temp.txt", Encoding.UTF8);              
                StreamWriter sw = File.AppendText(destname);
                sw.WriteLine("{");
                sw.Write(reader.ReadToEnd());
                sw.WriteLine();
                sw.WriteLine("}");
                sw.Close();
                reader.Close();
                //File.Delete("./temp.txt");
            }

        }

        //public void Load(string srcname)
        //{
        //    StreamReader reader = new StreamReader(srcname, Encoding.UTF8);
        //    //StreamWriter sw = File.AppendText("./rez.txt");
        //    StreamWriter sw = File.CreateText("./rez1.txt");
        //    while (!reader.EndOfStream)
        //    {
        //        string temp = reader.ReadLine();
        //        if (temp == "{")
        //        {
        //            string line = "";
        //            while (true)
        //            {
        //                line = reader.ReadLine();
        //                if (line == "}") break;
        //                else sw.WriteLine(line);
        //            }
        //            break;
        //        }

        //    }
        //    sw.Close();
        //    reader.Close();
        //}


        public void SaveFig(FileStream fs, object obj)
        {
            formatter.Serialize(fs, obj);
        }

        public object LoadFig(FileStream fs)
        {
            return formatter.Deserialize(fs);
        }

    }

    
}
