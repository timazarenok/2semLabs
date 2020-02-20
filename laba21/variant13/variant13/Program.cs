using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace variant13
{
    class Program
    {
        public static XDocument CreateDocument(List<House> list)
        {
            XDocument task1 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                        new XElement("task1", list.Select(h => new XElement("House",
                                    new XAttribute("Street", h.Street),
                                    new XElement("Number", h.Number),
                                    new XElement("CountEntries", h.CountEntries),
                                    new XElement("CountFloors", h.CountFloors),
                                    new XElement("Flats", h.Flats)))));
            return task1;
        }
        public static XDocument CreateDocGroup<T>(IEnumerable<IGrouping<T, House>> group)
        {
            XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Grouping"));
            foreach (var item in group)
            {
                doc.Root.Add(new XElement("Group", new XAttribute("GroupAttribute", item.Key),
                                                    item.ToList().Select(h => new XElement("House",
                                    new XAttribute("Street", h.Street),
                                    new XElement("Number", h.Number),
                                    new XElement("CountEntries", h.CountEntries),
                                    new XElement("CountFloors", h.CountFloors),
                                    new XElement("Flats", h.Flats)))));
            }
            return doc;
        }
        public static void SaveDoc(XDocument doc, string fileName)
        {
            doc.Save(Path.Combine(Environment.CurrentDirectory, fileName));
        }
        public static XElement AddHouse()
        {
            Console.WriteLine("Input values \n " +
                "street \n" +
                "number \n" +
                "amountEntries \n" +
                "amountFloors \n" +
                "flats \n");
            string street = Console.ReadLine();
            int amountEntries = Convert.ToInt32(Console.ReadLine());
            int amountFloors = Convert.ToInt32(Console.ReadLine());
            int flats = Convert.ToInt32(Console.ReadLine());
            int number = Convert.ToInt32(Console.ReadLine());
            House h = new House(street, number, amountEntries, amountFloors, flats);
            return new XElement("House",
                                    new XAttribute("Street", h.Street),
                                    new XElement("Number", h.Number),
                                    new XElement("CountEntries", h.CountEntries),
                                    new XElement("CountFloors", h.CountFloors),
                                    new XElement("Flats", h.Flats));
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
        public static void IndividualTasks(List<House> houses)
        {
            Console.WriteLine("Input number from 1-5");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    List<House> Task1 = houses.OrderBy(el => el.Street).ThenBy(el => el.Number).ToList();
                    SaveDoc(CreateDocument(Task1), "Task1.xml");
                    break;
                case 2:
                    List<List<House>> Task2 = new List<List<House>>();
                    foreach (House l in houses)
                    {
                        Task2.Add(houses.Where(el => el.Street == l.Street).ToList());
                    }
                    XDocument task2 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Houses"));
                    foreach (List<House> list in Task2)
                    {
                        foreach (House h in list)
                        {
                            task2.Root.Add(new XElement("House",
                                    new XAttribute("Street", h.Street),
                                    new XElement("Number", h.Number),
                                    new XElement("CountEntries", h.CountEntries),
                                    new XElement("CountFloors", h.CountFloors),
                                    new XElement("Flats", h.Flats)));
                        }
                    }
                    SaveDoc(task2, "task2.xml");
                    break;
                case 3:
                    List<House> Task3 = houses.Where(el => el.CountEntries % 2 != 0 && el.CountFloors % 2 != 0).ToList();
                    SaveDoc(CreateDocument(Task3), "task3.xml");
                    break;
                case 4:
                    List<int> inEachHouse = houses.Select(el => el.CountEntries * (el.CountFloors * el.Flats)).ToList();
                    XDocument task4 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Houses"));
                    for(int i = 0;i != inEachHouse.Count; ++i)
                    {
                        task4.Root.Add(new XElement("House", new XAttribute("House", houses[i].Number),
                                                        new XElement("Falts", inEachHouse[i])));
                    }
                    int amountFloors = inEachHouse.Sum();
                    task4.Root.Add(new XElement("Amount_flat_in_all_houses", amountFloors));
                    SaveDoc(task4, "task4.xml");
                    break;
                case 5:
                    var groupStreet = houses.GroupBy(el => el.Street);
                    SaveDoc(CreateDocGroup(groupStreet), "group.xml");
                    var groupNumber = houses.GroupBy(el => el.Number);
                    SaveDoc(CreateDocGroup(groupNumber), "group2.xml");                    
                    var groupFloors = houses.GroupBy(el => el.CountFloors);
                    SaveDoc(CreateDocGroup(groupFloors), "group3.xml");
                    var groupEntries = houses.GroupBy(el => el.CountEntries);
                    SaveDoc(CreateDocGroup(groupEntries), "group4.xml");
                    var groupFlats = houses.GroupBy(el => el.Flats);
                    SaveDoc(CreateDocGroup(groupFlats), "group5.xml");
                    break;
                default:
                    throw new Exception("Wrong input number");
            }
        }
        public static void Start(List<House> Houses)
        {
            var xDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                            new XElement("Houses", Houses.Select(h => new XElement("House",
                                    new XAttribute("Street", h.Street),
                                    new XElement("Number", h.Number),
                                    new XElement("CountEntries", h.CountEntries),
                                    new XElement("CountFloors", h.CountFloors),
                                    new XElement("Flats", h.Flats)))));
            int choice = Choice();
            switch (choice)
            {
                case 1:
                    SaveDoc(xDoc, "xdoc.xml");
                    break;
                case 2:
                    xDoc.Root.Add(AddHouse());
                    SaveDoc(xDoc, "xdoc.xml");
                    break;
                case 3:
                    IndividualTasks(Houses);
                    break;
                case 4:
                    break;
            }
        }
        static void Main(string[] args)
        {
            List<House> houses = new List<House>()
            {
                new House("Melnikayte", 20, 8, 4, 4),
                new House("Melnikayte", 12, 8, 4, 4),
                new House("Nezaleshnosti", 187, 10, 6, 6),
                new House("Masherova", 56, 4, 2, 4),
                new House("Kolesnikova", 12, 5, 2, 12),
            };
            Start(houses);
            Console.ReadKey();
        }
    }
}
