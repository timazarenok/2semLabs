using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace laba11
{
    class Program
    {
        public static XDocument CreateDocument(List<Luggage> list)
        {
            XDocument task1 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                        new XElement("task1", list.Select(st => new XElement("Luggage",
                                    new XAttribute("Surname", st.Surname),
                                    new XElement("FlightNumber", st.FlightNumber),
                                    new XElement("Direction", st.Direction),
                                    new XElement("TimeOfOut", st.TimeOfOut),
                                    new XElement("WeightOfLuggage", st.WeightOfLuggage),
                                    new XElement("AmountOfPlaces", st.AmountOfPlaces)))));
            return task1;
        }
        public static XDocument CreateDocGroup<T>(IEnumerable<IGrouping<T, Luggage>> group)
        {
            XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Grouping"));
            foreach (var item in group)
            {
                doc.Root.Add(new XElement("Group", new XAttribute("GroupAttribute", item.Key),
                                                    item.ToList().Select(st => new XElement("Luggage",
                                    new XAttribute("Surname", st.Surname),
                                    new XElement("FlightNumber", st.FlightNumber),
                                    new XElement("Direction", st.Direction),
                                    new XElement("TimeOfOut", st.TimeOfOut),
                                    new XElement("WeightOfLuggage", st.WeightOfLuggage),
                                    new XElement("AmountOfPlaces", st.AmountOfPlaces)))));
            }
            return doc;
        }
        public static void SaveDoc(XDocument doc, string fileName)
        {
            doc.Save(Path.Combine(Environment.CurrentDirectory, fileName));
        }
        public static XElement AddLuggage()
        {
            Console.WriteLine("Input values \n " +
                "surname \n" +
                "number \n" +
                "amount of places \n" +
                "date \n" +
                "weight \n" +
                "direction \n");
            string surname = Console.ReadLine();
            long number = Convert.ToInt64(Console.ReadLine());
            int amountOfplaces = Convert.ToInt32(Console.ReadLine());
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            double weight = Convert.ToDouble(Console.ReadLine());
            string direction = Console.ReadLine();
            Luggage lug = new Luggage(number, date, direction, surname, amountOfplaces, weight);
            return new XElement("Student", new XAttribute("Surname", lug.Surname),
                    new XElement("Group", lug.Direction),
                    new XElement("Course", lug.FlightNumber),
                    new XElement("Semestr", lug.AmountOfPlaces),
                    new XElement("Salary", lug.TimeOfOut),
                    new XElement("Marks", lug.WeightOfLuggage));
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
        public static void IndividualTasks(List<Luggage> luggages)
        {
            Console.WriteLine("Choose number from 1-5");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    List<Luggage> Task1 = luggages.OrderBy(el => el.Surname).ThenBy(el => el.TimeOfOut).ToList();
                    XDocument task1 = CreateDocument(Task1);
                    SaveDoc(task1, "task1.xml");
                    break;
                case 2:
                    List<List<Luggage>> Task2 = new List<List<Luggage>>();
                    foreach (Luggage l in luggages)
                    {
                        Task2.Add(luggages.Where(el => el.TimeOfOut == l.TimeOfOut).ToList());
                    }
                    XDocument task2 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Luggages"));
                    foreach (List<Luggage> list in Task2)
                    {
                        foreach (Luggage l in list)
                        {
                            task2.Root.Add(new XElement("Luggage", new XElement("Luggage",
                                    new XAttribute("Surname", l.Surname),
                                    new XElement("FlightNumber", l.FlightNumber),
                                    new XElement("Direction", l.Direction),
                                    new XElement("TimeOfOut", l.TimeOfOut),
                                    new XElement("WeightOfLuggage", l.WeightOfLuggage),
                                    new XElement("AmountOfPlaces", l.AmountOfPlaces))));
                        }
                    }
                    SaveDoc(task2, "task2.xml");
                    break;
                case 3:
                    List<Luggage> Task3 = luggages.Where(el => el.WeightOfLuggage > 20).ToList();
                    XDocument task3 = CreateDocument(Task3);
                    SaveDoc(task3, "task3.xml");
                    break;
                case 4:
                    double Task4 = luggages.Sum(el => el.WeightOfLuggage);
                    XDocument task4 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Result", Task4));
                    SaveDoc(task4, "task4.xml");
                    break;
                case 5:
                    var groupFlight = luggages.GroupBy(el => el.FlightNumber);
                    XDocument group = CreateDocGroup(groupFlight);
                    SaveDoc(group, "group.xml");
                    var groupDate = luggages.GroupBy(el => el.TimeOfOut);
                    XDocument group1 = CreateDocGroup(groupDate);
                    SaveDoc(group1, "group1.xml");
                    var groupDir = luggages.GroupBy(el => el.Direction);
                    XDocument group2 = CreateDocGroup(groupDir);
                    SaveDoc(group2, "group2.xml");
                    var groupSur = luggages.GroupBy(el => el.Surname);
                    XDocument group3 = CreateDocGroup(groupSur);
                    SaveDoc(group3, "group3.xml");
                    var groupPlaces = luggages.GroupBy(el => el.AmountOfPlaces);
                    XDocument group4 = CreateDocGroup(groupPlaces);
                    SaveDoc(group4, "group4.xml");
                    var groupWeight = luggages.GroupBy(el => el.WeightOfLuggage);
                    XDocument group5 = CreateDocGroup(groupWeight);
                    SaveDoc(group5, "group5.xml");
                    break;
                default:
                    throw new Exception("Wrong choice number");
            }
        }
        public static void Start(List<Luggage> luggages)
        {
            var xDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                            new XElement("Students", luggages.Select(l => new XElement("Luggage",
                                    new XAttribute("Surname", l.Surname),
                                    new XElement("FlightNumber", l.FlightNumber),
                                    new XElement("Direction", l.Direction),
                                    new XElement("TimeOfOut", l.TimeOfOut),
                                    new XElement("WeightOfLuggage", l.WeightOfLuggage),
                                    new XElement("AmountOfPlaces", l.AmountOfPlaces)))));
            int choice = Choice();
            switch (choice)
            {
                case 1:
                    SaveDoc(xDoc, "xdoc.xml");
                    break;
                case 2:
                    xDoc.Root.Add(AddLuggage());
                    SaveDoc(xDoc, "xdoc.xml");
                    break;
                case 3:
                    IndividualTasks(luggages);
                    break;
                case 4:
                    break;
            }
        }
        static void Main(string[] args)
        {
            List<Luggage> luggages = new List<Luggage>()
            {
                new Luggage(1234567892, new DateTime(2002, 9, 23), "Croatia", "Huraha", 3, 23.55),
                new Luggage(5678549478, new DateTime(2003, 8, 22), "Berlin", "Rubis", 2, 23.1),
                new Luggage(3456787654, new DateTime(2004, 7, 21), "Minsk", "Borshevskiy", 1, 2.5),
                new Luggage(4567898764, new DateTime(2005, 6, 20), "Samara", "Shukalovich", 2, 4.5),
                new Luggage(2323843343, new DateTime(2006, 5, 19), "Moscow", "Malofey", 5, 12.5),
                new Luggage(1234123421, new DateTime(2007, 4, 18), "Brest", "Zarenok", 4, 34.2),
                new Luggage(9786786754, new DateTime(2008, 3, 25), "Masdrid", "Vorobyov", 2, 21.2),
                new Luggage(9854483473, new DateTime(2009, 2, 26), "London", "Ezhov", 1, 22.7),
                new Luggage(1000000000, new DateTime(2010, 1, 27), "Tokyo", "Kashko", 1, 12.5),
                new Luggage(6660000000, new DateTime(2011, 11, 12), "Vladivostock", "Birulya", 1, 24.5)
            };
            Start(luggages);
            Console.ReadKey();
        }
    }
}
