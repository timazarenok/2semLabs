using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if(value < 0)
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
            foreach(Order or in Orders)
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
    class Program
    {
        public static void Print<T>(ICollection<T> list)
        {
            foreach(T item in list)
            {
                Console.WriteLine(item);
            }
        }
        public static void Task5(List<Restaraunt> restaraunts)
        {
            var groupName = restaraunts.GroupBy(el => el.Name);
            foreach (var group in groupName)
            {
                foreach (var r in group)
                {
                    Console.WriteLine(r);
                }
            }
            var groupStreet = restaraunts.GroupBy(el => el.Street);
            foreach (var group in groupStreet)
            {
                foreach (var r in group)
                {
                    Console.WriteLine(r);
                }
            }
            var groupMark = restaraunts.GroupBy(el => el.Mark);
            foreach (var group in groupMark)
            {
                foreach (var item in group)
                {
                    Console.WriteLine(item);
                }
            }
            var groupOrders = restaraunts.GroupBy(el => el.Orders);
            foreach (var group in groupOrders)
            {
                foreach (var r in group)
                {
                    Console.WriteLine(r);
                }
            }
        }
        public static void Start(List<Restaraunt> restaraunts)
        {
            Console.WriteLine("Input number from 1-5");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    List<Restaraunt> Task1 = restaraunts.OrderBy(el => el.Name).ThenBy(el => el.Mark).ToList();
                    Print(Task1);
                    break;
                case 2:
                    List<Restaraunt> Task2 = restaraunts.Where(el => el.End > new TimeSpan(22, 0, 0)).ToList();
                    Print(Task2);
                    break;
                case 3:
                    List<Restaraunt> Task3 = restaraunts.Where(el => el.Orders.Where(item => item.Price > 100).ToList().Count > 1).ToList();
                    Print(Task3);
                    break;
                case 4:
                    List<int> Task4 = restaraunts.Select(el => el.Orders.Sum(item => item.Price) / el.Orders.Count).ToList();
                    Print(Task4);
                    Console.WriteLine(Task4.Sum() / Task4.Count);
                    break;
                case 5:
                    Task5(restaraunts);
                    break;
                default:
                    throw new Exception("wrong value");
            }
        }
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>()
            {
                new Order(new DateTime(2002, 5, 23, 5, 4, 4), 25),
                new Order(new DateTime(2010, 1, 14, 2, 23, 4), 35),
                new Order(new DateTime(2043, 2, 16, 1, 15, 4), 55),
                new Order(new DateTime(2022, 3, 18, 9, 21, 4), 75),
                new Order(new DateTime(1890, 4, 19, 2, 23, 4), 25)
            };
            List<Restaraunt> restaraunts = new List<Restaraunt>()
            {
                new Restaraunt("Tima", "Gde-to", 10.0, new TimeSpan(2, 3, 4), new TimeSpan(10, 10, 3), orders),
                new Restaraunt("Denis", "Gde-to2", 9.0, new TimeSpan(5, 13, 24), new TimeSpan(13, 10, 3), orders),
                new Restaraunt("Dima", "Gde-to3", 8.0, new TimeSpan(6, 23, 24), new TimeSpan(14, 10, 3), orders),
                new Restaraunt("Valik", "Gde-to4", 7.0, new TimeSpan(7, 33, 24), new TimeSpan(15, 10, 3), orders),
                new Restaraunt("Vladik", "Gde-to5", 6.0, new TimeSpan(8, 43, 24), new TimeSpan(16, 10, 3), orders),
                new Restaraunt("Vladick", "Gde-to6", 7.0, new TimeSpan(9, 53, 24), new TimeSpan(17, 10, 3), orders)
            };
            Start(restaraunts);
            Console.ReadKey();
        }
    }
}
