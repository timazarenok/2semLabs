using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace variant16
{
    class Program
    {
        public static XDocument CreateDocument(List<Book> list)
        {
            XDocument task1 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                        new XElement("task1", list.Select(b => new XElement("Book",
                                    new XAttribute("FullName", b.FullName),
                                    new XElement("Name", b.Name),
                                    new XElement("Pages", b.Pages),
                                    new XElement("Price", b.Price),
                                    new XElement("Wrapper", b.Wrapper)))));
            return task1;
        }
        public static XDocument CreateDocGroup<T>(IEnumerable<IGrouping<T, Book>> group)
        {
            XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Grouping"));
            foreach (var item in group)
            {
                doc.Root.Add(new XElement("Group", new XAttribute("GroupAttribute", item.Key),
                                                    item.ToList().Select(b => new XElement("Book",
                                    new XAttribute("FullName", b.FullName),
                                    new XElement("Name", b.Name),
                                    new XElement("Pages", b.Pages),
                                    new XElement("Price", b.Price),
                                    new XElement("Wrapper", b.Wrapper)))));
            }
            return doc;
        }
        public static void SaveDoc(XDocument doc, string fileName)
        {
            doc.Save(Path.Combine(Environment.CurrentDirectory, fileName));
        }
        public static XElement AddBook()
        {
            Console.WriteLine("Input values \n " +
                "fullName \n" +
                "pages \n" +
                "price \n" +
                "wrapper \n" +
                "name \n");
            string fullName = Console.ReadLine();
            int pages = Convert.ToInt32(Console.ReadLine());
            double price = Convert.ToDouble(Console.ReadLine());
            string wrapper = Console.ReadLine();
            string name = Console.ReadLine();
            Book b = new Book(name, fullName, pages, wrapper, price);
            return new XElement("Book",
                                    new XAttribute("FullName", b.FullName),
                                    new XElement("Name", b.Name),
                                    new XElement("Pages", b.Pages),
                                    new XElement("Price", b.Price),
                                    new XElement("Wrapper", b.Wrapper));
        }
        public static int Choice()
        {
            Console.WriteLine("Choose: \n" +
                "1 - save doc \n" +
                "2 - add object \n" +
                "3 - individual tasks \n" +
                "4 - out \n");
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }
        public static void IndividualTasks(List<Book> books)
        {
            Console.WriteLine("Input number 1-5");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    List<Book> Task1 = books.OrderBy(el => el.Name).ThenBy(el => el.Price).ToList();
                    SaveDoc(CreateDocument(Task1), "task1.xml");
                    break;
                case 2:
                    SaveDoc(CreateDocument(books), "task2.xml");
                    break;
                case 3:
                    List<Book> Task3 = books.Where(el => el.Price > 10 && el.Wrapper.Contains("soft")).ToList();
                    SaveDoc(CreateDocument(Task3), "task3.xml");
                    break;
                case 4:
                    int pages = books.Select(el => el.Pages).Max();
                    List<Book> Task4 = books.Where(el => el.Pages == pages).ToList();
                    XDocument task4 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Book",
                                    new XAttribute("FullName", Task4[0].FullName),
                                    new XElement("Name", Task4[0].Name),
                                    new XElement("Pages", Task4[0].Pages),
                                    new XElement("Price", Task4[0].Price),
                                    new XElement("Wrapper", Task4[0].Wrapper)));
                    SaveDoc(task4, "task4.xml");
                    break;
                case 5:
                    var groupName = books.GroupBy(el => el.Name);
                    SaveDoc(CreateDocGroup(groupName), "group1.xml");
                    var groupFullName = books.GroupBy(el => el.FullName);
                    SaveDoc(CreateDocGroup(groupFullName), "group2.xml");
                    var groupPages = books.GroupBy(el => el.Pages);
                    SaveDoc(CreateDocGroup(groupPages), "group3.xml");
                    var groupWrapper = books.GroupBy(el => el.Wrapper);
                    SaveDoc(CreateDocGroup(groupWrapper), "group4.xml");
                    var groupPrice = books.GroupBy(el => el.Price);
                    SaveDoc(CreateDocGroup(groupPrice), "group5.xml");
                    break;
                default:
                    throw new Exception("wrong value");
            }
        }
        public static void Start(List<Book> books)
        {
            var xDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                            new XElement("Students", books.Select(b => new XElement("Book",
                                    new XAttribute("FullName", b.FullName),
                                    new XElement("Name", b.Name),
                                    new XElement("Pages", b.Pages),
                                    new XElement("Price", b.Price),
                                    new XElement("Wrapper", b.Wrapper)))));
            int choice = Choice();
            switch (choice)
            {
                case 1:
                    SaveDoc(xDoc, "xdoc.xml");
                    break;
                case 2:
                    xDoc.Root.Add(AddBook());
                    SaveDoc(xDoc, "xdoc.xml");
                    break;
                case 3:
                    IndividualTasks(books);
                    break;
                case 4:
                    break;
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
        }
    }
}
