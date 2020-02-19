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
                if(value < 0)
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
                if(value == "soft" || value == "solid")
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
                if(value.ToString().Split('.', ',').Length != 2)
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
    class Program
    {
        public static void Start(List<Book> books)
        {
            Console.WriteLine("Input number 1-5");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    List<Book> Task1 = books.OrderBy(el => el.Name).ThenBy(el => el.Price).ToList();
                    foreach (Book bk in Task1)
                    {
                        Console.WriteLine(bk);
                    }
                    break;
                case 2:
                    foreach(Book bk in books)
                    {
                        Console.WriteLine(bk);
                    }
                    break;
                case 3:
                    List<Book> Task3 = books.Where(el => el.Price > 10 && el.Wrapper.Contains("soft")).ToList();
                    foreach (Book bk in Task3)
                    {
                        Console.WriteLine(bk);
                    }
                    break;
                case 4:
                    int pages = books.Select(el => el.Pages).Max();
                    List<Book> Task4 = books.Where(el => el.Pages == pages).ToList();
                    Console.WriteLine(Task4[0]);
                    break;
                case 5:
                    var groupName = books.GroupBy(el => el.Name);
                    foreach (IGrouping<string, Book> item in groupName)
                    {
                        Console.WriteLine(item.Key);
                        foreach (Book bk in item)
                        {
                            Console.WriteLine(bk);
                        }
                    }
                    var groupFullName = books.GroupBy(el => el.FullName);
                    foreach (IGrouping<string, Book> item in groupFullName)
                    {
                        Console.WriteLine(item.Key);
                        foreach (Book bk in item)
                        {
                            Console.WriteLine(bk);
                        }
                    }
                    var groupPages = books.GroupBy(el => el.Pages);
                    foreach (IGrouping<int, Book> item in groupPages)
                    {
                        Console.WriteLine(item.Key);
                        foreach (Book bk in item)
                        {
                            Console.WriteLine(bk);
                        }
                    }
                    var groupWrapper = books.GroupBy(el => el.Wrapper);
                    foreach (IGrouping<string, Book> item in groupWrapper)
                    {
                        Console.WriteLine(item.Key);
                        foreach (Book bk in item)
                        {
                            Console.WriteLine(bk);
                        }
                    }
                    var groupPrice = books.GroupBy(el => el.Price);
                    foreach (IGrouping<double, Book> item in groupPrice)
                    {
                        Console.WriteLine(item.Key);
                        foreach (Book bk in item)
                        {
                            Console.WriteLine(bk);
                        }
                    }
                    break;
                default:
                    throw new Exception("wrong value");
            }
        }
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>()
            {
                new Book("Timas", "T.A.Z", 400, "soft", 50.9),
                new Book("Harry Potter", "G.H.R", 368, "solid", 75.8),
                new Book("Gretter", "K.V.A", 235, "soft", 87.6),
                new Book("Linkityk", "A.A.A", 876, "solid", 105.3),
                new Book("Seryt", "D.M.D", 456, "solid", 56.2),
                new Book("GHERTYK", "T.Y.Q", 765, "soft", 34.1),
            };
            Start(books);
            Console.ReadKey();
        }
    }
}
