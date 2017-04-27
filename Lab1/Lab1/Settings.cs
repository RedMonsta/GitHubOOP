using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Xml;

namespace Lab1
{
    public class Settings
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Color WindowColor { get; set; }
        public Color ButtonsColor { get; set; }

        public string DLLsPath { get; set; }
        public string UserFiguresPath { get; set; }
        public string UserFiguresExtension { get; set; }
        public string SavedPicturesExtension { get; set; }
        public string DefaultSaveLoadPath { get; set; }

        public void GetSettingsFromXMLFile()
        {
            //Дописать trycatch
            try
            {
                var xDoc = new XmlDocument();
                xDoc.Load("Config.xml");
                XmlElement xRoot = xDoc.DocumentElement;
                foreach (XmlNode xnode in xRoot)
                {
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "SizeOptions")
                        {
                            foreach (XmlNode child in childnode.ChildNodes)
                            {
                                if (child.Name == "Width") Width = Convert.ToInt32(child.InnerText);
                                if (child.Name == "Height") Height = Convert.ToInt32(child.InnerText);
                            }
                        }
                        if (childnode.Name == "ColorOptions")
                        {
                            foreach (XmlNode child in childnode.ChildNodes)
                            {
                                if (child.Name == "WindowColor") WindowColor = Color.FromName(child.InnerText.Trim());
                                if (child.Name == "ButtonsColor") ButtonsColor = Color.FromName(child.InnerText.Trim());
                            }
                        }
                    }


                }
            }
            finally
            {

            }
        }

        public void SaveSettingsToXMLFile()
        {
            try
            {
                var xDoc = new XmlDocument();
                xDoc.Load("Config.xml");
                XmlElement xRoot = xDoc.DocumentElement;
                foreach (XmlNode xnode in xRoot)
                {
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "SizeOptions")
                        {
                            foreach (XmlNode child in childnode.ChildNodes)
                            {
                                if (child.Name == "Width") child.InnerText = Width.ToString();
                                if (child.Name == "Height") child.InnerText = Height.ToString();
                            }
                        }
                        //if (childnode.Name == "ColorOptions")
                        //{
                        //    foreach (XmlNode child in childnode.ChildNodes)
                        //    {
                        //        if (child.Name == "WindowColor") WindowColor = Color.FromName(child.InnerText.Trim());
                        //        if (child.Name == "ButtonsColor") ButtonsColor = Color.FromName(child.InnerText.Trim());
                        //    }
                        //}
                    }

                    xDoc.Save("Config.xml");
                }
            }
            finally
            {

            }
        }
    }
}
