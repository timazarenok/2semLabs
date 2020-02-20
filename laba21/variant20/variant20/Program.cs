using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace variant20
{
    class Program
    {
        public static XDocument CreateDocument(List<Game> list)
        {
            XDocument task1 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                        new XElement("task1", list.Select(g => new XElement("Game",
                                    new XAttribute("Name", g.Name),
                                    new XElement("Street", g.Developer),
                                    new XElement("Mark", g.Genre),
                                    new XElement("Open", g.Date),
                                    new XElement("Platform", g.Platform),
                                    new XElement("Mark", g.Mark)))));
            return task1;
        }
        public static XDocument CreateDocGroup<T>(IEnumerable<IGrouping<T, Game>> group)
        {
            XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Grouping"));
            foreach (var item in group)
            {
                doc.Root.Add(new XElement("Group", new XAttribute("GroupAttribute", item.Key),
                                                    item.ToList().Select(g => new XElement("Game",
                                    new XAttribute("Name", g.Name),
                                    new XElement("Street", g.Developer),
                                    new XElement("Mark", g.Genre),
                                    new XElement("Open", g.Date),
                                    new XElement("Platform", g.Platform),
                                    new XElement("Mark", g.Mark)))));
            }
            return doc;
        }
        public static void SaveDoc(XDocument doc, string fileName)
        {
            doc.Save(Path.Combine(Environment.CurrentDirectory, fileName));
        }
        public static XElement AddGame()
        {
            Console.WriteLine("Input values \n " +
                "name \n" +
                "genre \n" +
                "developer \n" +
                "date \n " +
                "platform \n" +
                "mark \n");
            string name = Console.ReadLine();
            string genre = Console.ReadLine();
            string developer = Console.ReadLine();
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            string platform = Console.ReadLine();
            double mark = Convert.ToDouble(Console.ReadLine());
            Game g = new Game(name, developer, genre, date, platform, mark);
            return new XElement("Game",
                                    new XAttribute("Name", g.Name),
                                    new XElement("Street", g.Developer),
                                    new XElement("Mark", g.Genre),
                                    new XElement("Open", g.Date),
                                    new XElement("Platform", g.Platform),
                                    new XElement("Mark", g.Mark));
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
        public static void IndividualTasks(List<Game> games)
        {
            Console.WriteLine("Input number from 1-5");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    List<Game> Task1 = games.OrderBy(el => el.Platform).ThenBy(el => el.Name).ToList();
                    SaveDoc(CreateDocument(Task1), "task1.xml");
                    break;
                case 2:
                    XDocument task2 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Developers"));
                    int count = 0;
                    foreach (Game g in games)
                    {
                        foreach (Game game in games)
                        {
                            if (g.Developer == game.Developer)
                            {
                                ++count;
                            }
                        }
                        if (count > 2)
                        {
                            task2.Root.Add(new XElement("Developer", g.Developer));
                        }
                        count = 0;
                    }
                    SaveDoc(task2, "task2.xml");
                    break;
                case 3:
                    List<Game> Task3 = games.Where(el => el.Genre.Contains("RPG")).OrderByDescending(el => el.Date).ToList();
                    XDocument task3 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Game"));
                    if (Task3.Count < 0)
                        Console.WriteLine("empty result");
                    else
                        task3.Root.Add();
                    break;
                case 4:
                    var Task4 = games.GroupBy(el => el.Platform).ToList();
                    XDocument task4 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("marks"));
                    foreach (var group in Task4)
                    {
                        task4.Root.Add(new XElement("Game", new XAttribute("Platform", group.Key),
                                  new XElement("Mark", group.Max(el => el.Mark))));
                    }
                    SaveDoc(task4, "task4.xml");
                    break;
                case 5:
                    var groupName = games.GroupBy(el => el.Name);
                    SaveDoc(CreateDocGroup(groupName), "group.xml");
                    var groupGenre = games.GroupBy(el => el.Genre);
                    SaveDoc(CreateDocGroup(groupGenre), "group1.xml");
                    var groupPlatform = games.GroupBy(el => el.Platform);
                    SaveDoc(CreateDocGroup(groupPlatform), "group2.xml");
                    var groupDeveloper = games.GroupBy(el => el.Developer);
                    SaveDoc(CreateDocGroup(groupDeveloper), "group3.xml");
                    var groupMark = games.GroupBy(el => el.Mark);
                    SaveDoc(CreateDocGroup(groupMark), "group4.xml");
                    var groupDate = games.GroupBy(el => el.Date);
                    SaveDoc(CreateDocGroup(groupDate), "group5.xml");
                    break;
                default:
                    throw new Exception("wrong value");
            }
        }
        public static void Start(List<Game> games)
        {
            var xDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                            new XElement("Games", games.Select(g => new XElement("Game",
                                    new XAttribute("Name", g.Name),
                                    new XElement("Street", g.Developer),
                                    new XElement("Mark", g.Genre),
                                    new XElement("Open", g.Date),
                                    new XElement("Platform", g.Platform),
                                    new XElement("Mark", g.Mark)))));
            int choice = Choice();
            switch (choice)
            {
                case 1:
                    SaveDoc(xDoc, "xdoc.xml");
                    break;
                case 2:
                    xDoc.Root.Add(AddGame());
                    SaveDoc(xDoc, "xdoc.xml");
                    break;
                case 3:
                    IndividualTasks(games);
                    break;
                case 4:
                    break;
            }
        }
        static void Main(string[] args)
        {
            List<Game> games = new List<Game>()
            {
                new Game("Fifa14", "EA", "Sport", new DateTime(2013, 12, 4), "PSC", 8.5),
                new Game("Fifa20", "EA", "Sport", new DateTime(2020, 11, 4), "PSC", 8.9),
                new Game("NHL", "EA", "Sport", new DateTime(2020, 1, 4), "PSC", 7.3),
                new Game("Tennis", "Tennissprot", "Sport", new DateTime(2020, 3, 4), "PSC", 9.5),
                new Game("NBA", "EA", "Sport", new DateTime(2020, 5, 4), "PSC", 10)
            };
            Start(games);
        }
    }
}
