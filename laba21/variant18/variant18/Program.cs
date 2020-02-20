using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace variant18
{
    class Program
    {
        public static XDocument CreateDocument(List<Restaraunt> list)
        {
            XDocument task1 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                        new XElement("task1", list.Select(r => new XElement("Restaraunt",
                                    new XAttribute("Name", r.Name),
                                    new XElement("Street", r.Street),
                                    new XElement("Mark", r.Mark),
                                    new XElement("Open", r.Start),
                                    new XElement("Close", r.End),
                                    new XElement("Orders", r.GetOrders())))));
            return task1;
        }
        public static XDocument CreateDocGroup<T>(IEnumerable<IGrouping<T, Restaraunt>> group)
        {
            XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Grouping"));
            foreach (var item in group)
            {
                doc.Root.Add(new XElement("Group", new XAttribute("GroupAttribute", item.Key),
                                                    item.ToList().Select(r => new XElement("Restaraunt",
                                    new XAttribute("Name", r.Name),
                                    new XElement("Street", r.Street),
                                    new XElement("Mark", r.Mark),
                                    new XElement("Open", r.Start),
                                    new XElement("Close", r.End),
                                    new XElement("Orders", r.GetOrders())))));
            }
            return doc;
        }
        public static void SaveDoc(XDocument doc, string fileName)
        {
            doc.Save(Path.Combine(Environment.CurrentDirectory, fileName));
        }
        public static XElement AddRestaraunt()
        {
            Console.WriteLine("Input values \n " +
                "name \n" +
                "street \n" +
                "mark \n" +
                "start \n" +
                "end \n");
            string name = Console.ReadLine();
            string street = Console.ReadLine();
            double mark = Convert.ToDouble(Console.ReadLine());
            List<Order> orders = new List<Order>();
            TimeSpan start = TimeSpan.Parse(Console.ReadLine());
            TimeSpan end = TimeSpan.Parse(Console.ReadLine());
            Restaraunt r = new Restaraunt(name, street, mark, start, end, orders);
            return new XElement("Restaraunt",
                                    new XAttribute("Name", r.Name),
                                    new XElement("Street", r.Street),
                                    new XElement("Mark", r.Mark),
                                    new XElement("Open", r.Start),
                                    new XElement("Close", r.End),
                                    new XElement("Orders", r.GetOrders()));
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
        public static void IndividualTasks(List<Restaraunt> restaraunts)
        {
            Console.WriteLine("Input number from 1-5");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    List<Restaraunt> Task1 = restaraunts.OrderBy(el => el.Name).ThenBy(el => el.Mark).ToList();
                    SaveDoc(CreateDocument(Task1), "task1.xml");
                    break;
                case 2:
                    List<Restaraunt> Task2 = restaraunts.Where(el => el.End > new TimeSpan(22, 0, 0)).ToList();
                    SaveDoc(CreateDocument(Task2), "task2.xml");
                    break;
                case 3:
                    List<Restaraunt> Task3 = restaraunts.Where(el => el.Orders.Where(item => item.Price > 100).ToList().Count > 1).ToList();
                    SaveDoc(CreateDocument(Task3), "task3.xml");
                    break;
                case 4:
                    List<int> Task4 = restaraunts.Select(el => el.Orders.Sum(item => item.Price) / el.Orders.Count).ToList();
                    XDocument task4 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("OrdersSum", Task4.Select(sum => new XElement("sum", sum))));
                    task4.Root.Add(new XElement("Average_sum", Task4.Sum() / Task4.Count));
                    SaveDoc(task4, "task4.xml");
                    break;
                case 5:
                    var groupName = restaraunts.GroupBy(el => el.Name);
                    SaveDoc(CreateDocGroup(groupName), "group.xml");
                    var groupStreet = restaraunts.GroupBy(el => el.Street);
                    SaveDoc(CreateDocGroup(groupStreet), "group1.xml");
                    var groupMark = restaraunts.GroupBy(el => el.Mark);
                    SaveDoc(CreateDocGroup(groupMark), "group2.xml");
                    var groupOrders = restaraunts.GroupBy(el => el.Orders);
                    SaveDoc(CreateDocGroup(groupOrders), "group3.xml");
                    break;
                default:
                    throw new Exception("wrong value");
            }
        }
        public static void Start(List<Restaraunt> Restaraunts)
        {
            var xDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                            new XElement("Restaraunts", Restaraunts.Select(r => new XElement("Restaraunt",
                                    new XAttribute("Name", r.Name),
                                    new XElement("Street", r.Street),
                                    new XElement("Mark", r.Mark),
                                    new XElement("Open", r.Start),
                                    new XElement("Close", r.End),
                                    new XElement("Orders", r.GetOrders())))));
            int choice = Choice();
            switch (choice)
            {
                case 1:
                    SaveDoc(xDoc, "xdoc.xml");
                    break;
                case 2:
                    xDoc.Root.Add(AddRestaraunt());
                    SaveDoc(xDoc, "xdoc.xml");
                    break;
                case 3:
                    IndividualTasks(Restaraunts);
                    break;
                case 4:
                    break;
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
        }
    }
}
