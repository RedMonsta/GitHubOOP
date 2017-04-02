using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    [Serializable]
    public class SerialFiguresList
    {
        private List<SerialFigure> serfigs;

        public SerialFiguresList()
        {
            serfigs = new List<SerialFigure>();
        }

        public void Add(SerialFigure item)
        {
            serfigs.Add(item);
        }

        public void Clear()
        {
            serfigs.Clear();
        }

        public int Size()
        {
            return serfigs.Count();
        }

        public SerialFigure Item(int index)
        {
            return serfigs[index];
        }
    }
}
