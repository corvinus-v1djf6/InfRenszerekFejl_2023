using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zh2gyak.Entities
{
    public abstract class Product : Button
    {
        private string _foodName;

        public string Title
        {
            get { return _foodName; }
            set
            {
                _foodName = value;
                Text = Title;
            }
        }

        private int _calories;

        public int Calories
        {
            get { return _calories; }
            set
            {
                _calories = value;
                Display();
            }
        }

        public Product()
        {
            Width = 150;
            Height = 50;
        }

        protected abstract void Display();

    }
}
