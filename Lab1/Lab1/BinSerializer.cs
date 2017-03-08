using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab1
{
    public class BinSerializer
    {
        public BinSerializer()
        {
            formatter = new BinaryFormatter();
        }

        public void Save(FileStream fs, object obj)
        {
            formatter.Serialize(fs, obj);
        }

        public object Load(FileStream fs)
        {
            return formatter.Deserialize(fs);
        }

        private BinaryFormatter formatter;
    }
}
