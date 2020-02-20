using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace variant16
{
    class Book
    {
        string name;
        string fullName;
        int pages;
        string wrapper;
        double price;
        public string Name
        {
            get => name;
            set
            {
                if (!Char.IsUpper(value[0]))
                {
                    throw new Exception("wrong value");
                }
                name = value;
            }
        }
        public string FullName
        {
            get => fullName;
            set
            {
                if (!Char.IsUpper(value[0]))
                {
                    throw new Exception("wrong value");
                }
                fullName = value;
            }
        }
        public int Pages
        {
            get => pages;
            set
            {
                if (value < 0)
                {
                    throw new Exception("wrong value");
                }
                pages = value;
            }
        }
        public string Wrapper
        {
            get => wrapper;
            set
            {
                if (value == "soft" || value == "solid")
                {
                    wrapper = value;
                }
                else
                {
                    throw new Exception("wrong value");
                }
            }
        }
        public double Price
        {
            get => price;
            set
            {
                if (value.ToString().Split('.', ',').Length != 2)
                {
                    throw new Exception("wrong value");
                }
                price = value;
            }
        }
        public Book() { }
        public Book(string name, string fullName, int pages, string wrapper, double price)
        {
            Name = name;
            FullName = fullName;
            Pages = pages;
            Wrapper = wrapper;
            Price = price;
        }
        public override string ToString()
        {
            return $"{Name} {FullName} {Pages} {Wrapper} {Price}";
        }
    }
}
