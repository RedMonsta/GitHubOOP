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
        public string SaveLoadPath { get; set; }

        private readonly int MinHeight = 200;
        private readonly int MaxHeight = 800;
        private readonly int MinWidth = 300;
        private readonly int MaxWidth = 1500;
        private readonly string DefaultDLLsPath = "Dlls";
        private readonly string DefaultUserFiguresPath = "UserFigures";
        private readonly string DefaultUserFiguresExtension = "ufg";
        private readonly string DefaultSavedPicturesExtension = "mpp";
        private readonly string DefaultSaveLoadPath = "SavedPictures";


        public void GetSettingsFromXMLFile()
        {
            try
            {
                DLLsPath = DefaultDLLsPath;
                UserFiguresPath = DefaultUserFiguresPath;
                UserFiguresExtension = DefaultUserFiguresExtension;
                SavedPicturesExtension = DefaultSavedPicturesExtension;
                SaveLoadPath = DefaultSaveLoadPath;

                var xDoc = new XmlDocument();
                xDoc.Load("Config.xml");
                XmlElement xRoot = xDoc.DocumentElement;
                foreach (XmlNode xnode in xRoot)
                {
                    if (xnode.Name == "VisualOptions")
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
                    if (xnode.Name == "FilesOptions")
                    {
                        foreach (XmlNode childnode in xnode.ChildNodes)
                        {
                            if (childnode.Name == "DLLsPath") DLLsPath = childnode.InnerText;
                            if (childnode.Name == "UserFiguresPath") UserFiguresPath = childnode.InnerText;
                            if (childnode.Name == "UserFiguresExtension") UserFiguresExtension = childnode.InnerText;
                            if (childnode.Name == "SavedPicturesExtension") SavedPicturesExtension = childnode.InnerText;
                            if (childnode.Name == "SaveLoadPath") SaveLoadPath = childnode.InnerText;
                        }
                    }
                }

                if (Width < MinWidth) Width = MinWidth;
                if (Width > MaxWidth) Width = MaxWidth;
                if (Height < MinHeight) Height = MinHeight;
                if (Height > MaxHeight) Height = MaxHeight;

                //XmlNode childnode = xRoot.SelectSingleNode("//VisualOptions/SizeOptions/Width");
                //Width = Convert.ToInt32(childnode.InnerText);
                //childnode = xRoot.SelectSingleNode("//VisualOptions/SizeOptions/Height");
                //Height = Convert.ToInt32(childnode.InnerText);

            }
            finally
            {

            }
        }

        public void SaveSettingsToXMLFile()
        {
            try
            {
                if (Width < MinWidth) Width = MinWidth;
                if (Width > MaxWidth) Width = MaxWidth;
                if (Height < MinHeight) Height = MinHeight;
                if (Height > MaxHeight) Height = MaxHeight;

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
                        if (childnode.Name == "ColorOptions")
                        {
                            foreach (XmlNode child in childnode.ChildNodes)
                            {
                                if (child.Name == "WindowColor") child.InnerText = WindowColor.Name.ToString();
                                if (child.Name == "ButtonsColor") child.InnerText = ButtonsColor.Name.ToString();
                            }
                        }
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
