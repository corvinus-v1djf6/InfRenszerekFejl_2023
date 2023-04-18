using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using zh2gyak.Entities;

namespace zh2gyak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            AutoScroll = true;

            GetProducts();
            //var valami = GetXml("Menu.xml");

            DisplayProducts();
        }

        private void GetProducts()
        {
            //var xmlText = GetXml("Menu.xml");

            var xml = new XmlDocument();
            xml.LoadXml(GetXml("Menu.xml"));

            foreach (XmlElement element in xml.DocumentElement)
            {
                var name = element.SelectSingleNode("name").InnerText;
                var calories = element.SelectSingleNode("calories").InnerText;
                var description = element.SelectSingleNode("description").InnerText;
                var type = element.SelectSingleNode("type").InnerText;

                if (type == "food")
                {
                    var p = new Food()
                    {
                        Title = name,
                        Calories = int.Parse(calories),
                        Description = description
                    };
                    _products.Add(p);
                }
                else
                {
                    var p = new Drink()
                    {
                        Title = name,
                        //Description = description,
                        Calories = int.Parse(calories)
                    };
                    _products.Add(p);
                }
            }
        }

        private string GetXml(string fileName)
        {
            using (var sr = new StreamReader(fileName, Encoding.Default))
            {
                var xml = sr.ReadToEnd(); // A ReadToEnd-et el lehet mondani nekik, lehet, hogy nem tudják
                return xml;

                //ugyan az mint fennt
                /*var output = "";
                while (!sr.EndOfStream)
                {
                    output += "\n" + sr.ReadLine();
                }
                return output;*/
            }
        }


        private void DisplayProducts()
        {
            var topPosition = 0;
            var sortedProducts = from p in _products
                                 orderby p.Title
                                 select p;
            foreach (var item in sortedProducts)
            {
                item.Left = 0;
                item.Top = topPosition;
                Controls.Add(item);
                topPosition += item.Height;
            }
        }

    }
}
