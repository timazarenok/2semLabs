using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace variant19
{
    class Program
    {
        public static XDocument CreateDocument(List<Cinema> list)
        {
            XDocument task1 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                        new XElement("task1", list.Select(c => new XElement("Cinema",
                                    new XAttribute("Name", c.Name),
                                    new XElement("Street", c.Street),
                                    new XElement("Mark", c.AmountHalls),
                                    new XElement("Open", c.GetFilms())))));
            return task1;
        }
        public static XDocument CreateDocGroup<T>(IEnumerable<IGrouping<T, Cinema>> group)
        {
            XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Grouping"));
            foreach (var item in group)
            {
                doc.Root.Add(new XElement("Group", new XAttribute("GroupAttribute", item.Key),
                                                    item.ToList().Select(c => new XElement("Cinema",
                                    new XAttribute("Name", c.Name),
                                    new XElement("Street", c.Street),
                                    new XElement("Mark", c.AmountHalls),
                                    new XElement("Open", c.GetFilms())))));
            }
            return doc;
        }
        public static void SaveDoc(XDocument doc, string fileName)
        {
            doc.Save(Path.Combine(Environment.CurrentDirectory, fileName));
        }
        public static XElement AddCinema()
        {
            Console.WriteLine("Input values \n " +
                "name \n" +
                "street \n" +
                "amount of halls \n");
            string name = Console.ReadLine();
            string street = Console.ReadLine();
            int amoountHalls = Convert.ToInt32(Console.ReadLine());
            List<Film> films = new List<Film>();
            Cinema c = new Cinema(name, street, amoountHalls, films);
            return new XElement("Cinema",
                                    new XAttribute("Name", c.Name),
                                    new XElement("Street", c.Street),
                                    new XElement("Mark", c.AmountHalls),
                                    new XElement("Open", c.GetFilms()));
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
        public static void IndividualTasks(List<Cinema> cinemas)
        {
            Console.WriteLine("Input number from 1-5");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    List<Cinema> Task1 = cinemas.OrderBy(el => el.Name).ThenBy(el => el.AmountHalls).ToList();
                    SaveDoc(CreateDocument(Task1), "task1.xml");
                    break;
                case 2:
                    List<Cinema> Task2 = cinemas.Where(el => el.Films.Where(item => item.Genre.Contains("Comedy")).ToList().Count > 0).ToList();
                    SaveDoc(CreateDocument(Task2), "task2.xml");
                    break;
                case 3:
                    List<Cinema> Task3 = cinemas.Where(el => el.Films.Where(item => item.Language.Contains("Russian")).ToList().Count == 0).ToList();
                    SaveDoc(CreateDocument(Task3), "task3.xml");
                    break;
                case 4:
                    List<List<Cinema>> Task4 = new List<List<Cinema>>();
                    foreach (Cinema c in cinemas)
                    {
                        Task4.Add(cinemas.Where(el => el.Street.Contains(c.Street)).ToList());
                    }
                    XDocument task4 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Cinemas"));
                    foreach (List<Cinema> cins in Task4)
                    {
                        foreach (Cinema c in cins)
                        {
                            task4.Root.Add(new XElement("Cinema",
                                    new XAttribute("Name", c.Name),
                                    new XElement("Street", c.Street),
                                    new XElement("Mark", c.AmountHalls),
                                    new XElement("Open", c.GetFilms())));
                        }
                    }
                    SaveDoc(task4, "task4.xml");
                    break;
                case 5:
                    var groupName = cinemas.GroupBy(el => el.Name);
                    SaveDoc(CreateDocGroup(groupName), "group.xml");
                    var groupStreet = cinemas.GroupBy(el => el.Street);
                    SaveDoc(CreateDocGroup(groupStreet), "group1.xml");
                    var groupFilms = cinemas.GroupBy(el => el.Films);
                    SaveDoc(CreateDocGroup(groupFilms), "group2.xml");
                    var groupAmountHalls = cinemas.GroupBy(el => el.AmountHalls);
                    SaveDoc(CreateDocGroup(groupAmountHalls), "group3.xml");
                    break;
                default:
                    throw new Exception("wrong value");
            }
        }
        public static void Start(List<Cinema> Cinemas)
        {
            var xDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                            new XElement("Cinemas", Cinemas.Select(c => new XElement("Cinema",
                                    new XAttribute("Name", c.Name),
                                    new XElement("Street", c.Street),
                                    new XElement("Mark", c.AmountHalls),
                                    new XElement("Open", c.GetFilms())))));
            int choice = Choice();
            switch (choice)
            {
                case 1:
                    SaveDoc(xDoc, "xdoc.xml");
                    break;
                case 2:
                    xDoc.Root.Add(AddCinema());
                    SaveDoc(xDoc, "xdoc.xml");
                    break;
                case 3:
                    IndividualTasks(Cinemas);
                    break;
                case 4:
                    break;
            }
        }
        static void Main(string[] args)
        {
            List<Film> films = new List<Film>()
            {
                new Film("Tima", "Comedy", 40, "Russian"),
                new Film("Ice2", "Love story", 50, "Russian"),
                new Film("Gentlmens", "Comedy", 40, "English"),
                new Film("Sex Education", "Love story", 40, "Russian"),
                new Film("Supernatural", "Fantasy", 60, "English"),
                new Film("Good doctor", "Love story/Comedy", 40, "Russian")
            };
            List<Cinema> cinemas = new List<Cinema>()
            {
                new Cinema("Moscow", "Gde-to", 1, films),
                new Cinema("Mir", "Plosha pobedi", 1, films),
                new Cinema("Belarus", "Frunzenskaya", 5, films),
                new Cinema("Kiyv", "Kuda-to", 4, films),
                new Cinema("Pioner", "Akademia nauk", 1, films),
                new Cinema("Silver screen", "Dana mall", 5, films),
                new Cinema("Oktyabr", "Centre", 3, films)
            };
            Start(cinemas);
        }
    }
}
