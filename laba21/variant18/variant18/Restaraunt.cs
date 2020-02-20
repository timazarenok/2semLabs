using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace variant18
{
    class Order
    {
        int price;
        public DateTime PaymentTime { get; set; }
        public int Price
        {
            get => price;
            set
            {
                if (value < 0)
                {
                    throw new Exception("wring value");
                }
                price = value;
            }
        }
        public Order() { }
        public Order(DateTime time, int price)
        {
            PaymentTime = time;
            Price = price;
        }
        public override string ToString()
        {
            return $"{PaymentTime} price: {Price}";
        }
    }
    class Restaraunt
    {
        string name;
        string street;
        double mark;
        public string Name
        {
            get => name;
            set
            {
                if (!Char.IsUpper(value[0]))
                {
                    throw new Exception("wring value");
                }
                name = value;
            }
        }
        public string Street
        {
            get => street;
            set
            {
                if (!Char.IsUpper(value[0]))
                {
                    throw new Exception("wring value");
                }
                street = value;
            }
        }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public double Mark
        {
            get => mark;
            set
            {
                if (value > 10 && value < 0)
                {
                    throw new Exception("wrong value");
                }
                mark = value;
            }
        }
        public List<Order> Orders { get; set; }
        public Restaraunt() { }
        public Restaraunt(string name, string street, double mark, TimeSpan start, TimeSpan end, List<Order> orders)
        {
            Name = name;
            Street = street;
            Mark = mark;
            Start = start;
            End = end;
            Orders = orders;
        }
        public string GetOrders()
        {
            string result = "";
            foreach (Order or in Orders)
            {
                result += or;
            }
            return result;
        }
        public override string ToString()
        {
            return $"{Name} {Street} {Mark} {GetOrders()}";
        }
    }
}