using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using Wheat.Models;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Wheat
{
    public static class XMLIO
    {
        public const string XMLName = "Dishes.xml";
        public static string XMLPath = 
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), XMLName);
        public static void AddDish(DishModel dishModel)
        {
            XmlDocument document = new XmlDocument();
            
            if (!File.Exists(XMLPath))
            {
                XmlNode header = document.CreateXmlDeclaration("1.0", "utf-8", null);
                document.AppendChild(header);
                XmlElement dishModels = document.CreateElement("DishModels");
                document.AppendChild(dishModels);
                document.Save(XMLPath);
            }

            document.Load(XMLPath);
            XmlNode root = document.SelectSingleNode("DishModels");

            XmlElement newDishModel = document.CreateElement("DishModel");
            newDishModel.SetAttribute("IsNonStapleFood", dishModel.IsNonStapleFood.ToString());
            XmlElement name = document.CreateElement("Name");
            name.InnerText = dishModel.Name;
            newDishModel.AppendChild(name);
            XmlElement price = document.CreateElement("Price");
            price.InnerText = dishModel.Price;
            newDishModel.AppendChild(price);
            XmlElement place = document.CreateElement("Place");
            place.InnerText = dishModel.Place;
            newDishModel.AppendChild(place);
            XmlElement taste = document.CreateElement("Taste");
            taste.InnerText = dishModel.Taste;
            newDishModel.AppendChild(taste);
            root.AppendChild(newDishModel);

            document.Save(XMLPath);
        }

        public static void EditDish(DishModel dishModel, DishModel oldDishModel)
        {
            XmlDocument document = new XmlDocument();
            document.Load(XMLPath);

            XmlNode dishModels = document.SelectSingleNode("DishModels");
            XmlNodeList nodeList = dishModels.ChildNodes;
            foreach(XmlElement element in nodeList)
            {
                if (element.ChildNodes[0] == null) return;
                if (element.ChildNodes[0].InnerText == oldDishModel.Name
                    && element.ChildNodes[2].InnerText == dishModel.Place)
                {
                    element.ChildNodes[0].InnerText = dishModel.Name;
                    element.ChildNodes[1].InnerText = dishModel.Price;
                    element.ChildNodes[2].InnerText = dishModel.Place;
                    element.ChildNodes[3].InnerText = dishModel.Taste;
                    element.SetAttribute("IsNonStapleFood", dishModel.IsNonStapleFood.ToString());
                    break;
                }
            }

            document.Save(XMLPath);
        }

        public static void DelDish(DishModel dishModel)
        {
            XmlDocument document = new XmlDocument();

            document.Load(XMLPath);

            XmlNodeList nodeList = document.SelectSingleNode("DishModels").ChildNodes;
            foreach (XmlElement element in nodeList)
            {
                if (element.ChildNodes[0] == null) continue;
                if (element.ChildNodes[0].InnerText == dishModel.Name && element.ChildNodes[2].InnerText == dishModel.Place)
                    element.RemoveAll();
                break;
            }

            document.Save(XMLPath);
        }

        public static void Clear()
        {
            XmlDocument document = new XmlDocument();
            document.Load(XMLPath);

            XmlNode root = document.SelectSingleNode("DishModels");
            XmlNodeList nodeList = root.ChildNodes;
            foreach (XmlNode node in nodeList)
            {
                root.RemoveChild(node);
            }

            document.Save(XMLPath);
        }

        public static ObservableCollection<DishModel> ReadAllDish()
        {
            XmlDocument document = new XmlDocument();
            if (!File.Exists(XMLPath))
            {
                XmlNode header = document.CreateXmlDeclaration("1.0", "utf-8", null);
                document.AppendChild(header);
                XmlElement d = document.CreateElement("DishModels");
                document.AppendChild(d);
                document.Save(XMLPath);
            }
            document.Load(XMLPath);

            var dishModels = new ObservableCollection<DishModel>();

            if (document.InnerXml == null)
                return dishModels;

            XmlNodeList nodeList = document.SelectSingleNode("DishModels").ChildNodes;

            if (nodeList == null || nodeList.Count == 0)
                return dishModels;

            foreach (XmlElement element in nodeList)
            {
                if (element.ChildNodes.Count == 0)
                    continue;
                string name = element.ChildNodes[0].InnerText;
                string price = element.ChildNodes[1].InnerText;
                string place = element.ChildNodes[2].InnerText;
                string taste = element.ChildNodes[3].InnerText;
                bool isNonStapleFood = element.GetAttribute("IsNonStapleFood") == "True" ? true : false;
                DishModel dishModel = new DishModel(name, price, place, taste, isNonStapleFood);
                dishModels.Add(dishModel);
            }

            return dishModels;
        }
    }
}
