using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Security.Cryptography;
using System.IO;
using System.Drawing;


namespace Lab1
{
    public class UserFiguresCollector
    {
        private string[] UserFigs;
        List<string> UserFigsList;

        public List<string> GetRightFiguresAssemblies(string path)
        {
            try
            {
                UserFigs = Directory.GetFiles(path, "*.ufg");
                UserFigsList = new List<string>();
                foreach (var figpath in UserFigs)
                {
                    //AddHash(lib, SHAKey);
                    UserFigsList.Add(figpath);
                    // if (CheckingAssemblySignature(lib, SHAKey)) DllList.Add(lib);
                    // else MessageBoxWrongDll("Error of connecting " + lib.ToString() + " to application: wrong file.");
                }
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message, "Error!", MessageBoxButtons.OK);
            }
            return UserFigsList;
        }


    }
}
