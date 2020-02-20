using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace variant17
{
    class Program
    {
        public static XDocument CreateDocument(List<Artist> list)
        {
            XDocument task1 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                        new XElement("task1", list.Select(a => new XElement("Artist",
                                    new XAttribute("Name", a.Name),
                                    new XElement("Sex", a.Sex),
                                    new XElement("Department", a.Department),
                                    new XElement("Albom",
                                        new XElement("Name", a.AlbomV.Name),
                                        new XElement("GrammyNominations", a.AlbomV.GrammyNominations),
                                        new XElement("Mark", a.AlbomV.Mark),
                                        new XElement("Songs", a.AlbomV.Songs))))));
            return task1;
        }
        public static XDocument CreateDocGroup<T>(IEnumerable<IGrouping<T, Artist>> group)
        {
            XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Grouping"));
            foreach (var item in group)
            {
                doc.Root.Add(new XElement("Group", new XAttribute("GroupAttribute", item.Key),
                                                    item.ToList().Select(a => new XElement("Artist",
                                    new XAttribute("Name", a.Name),
                                    new XElement("Sex", a.Sex),
                                    new XElement("Department", a.Department),
                                    new XElement("Albom",
                                        new XElement("Name", a.AlbomV.Name),
                                        new XElement("GrammyNominations", a.AlbomV.GrammyNominations),
                                        new XElement("Mark", a.AlbomV.Mark),
                                        new XElement("Songs", a.AlbomV.Songs))))));
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
                "name \n" +
                "sex \n" +
                "department \n" +
                "albom Name \n" +
                "Grammy nominations \n" +
                "Mark \n" +
                "Songs \n");
            string name = Console.ReadLine();
            string sex = Console.ReadLine();
            string department = Console.ReadLine();
            string albomName = Console.ReadLine();
            int grammies = Convert.ToInt32(Console.ReadLine());
            double mark = Convert.ToDouble(Console.ReadLine());
            int songs = Convert.ToInt32(Console.ReadLine());
            Artist a = new Artist(name, department, sex, new Albom(albomName, songs, mark, grammies));
            return new XElement("Artist",
                                    new XAttribute("Name", a.Name),
                                    new XElement("Sex", a.Sex),
                                    new XElement("Department", a.Department),
                                    new XElement("Albom",
                                        new XElement("Name", a.AlbomV.Name),
                                        new XElement("GrammyNominations", a.AlbomV.GrammyNominations),
                                        new XElement("Mark", a.AlbomV.Mark),
                                        new XElement("Songs", a.AlbomV.Songs)));
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
        public static void IndividualTasks(List<Artist> artists)
        {
            Console.WriteLine("Input number 1-5");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    List<Artist> Task1 = artists.OrderBy(el => el.Name).ThenBy(el => el.Department).ToList();
                    SaveDoc(CreateDocument(Task1), "task1.xml");
                    break;
                case 2:
                    List<Artist> Task2 = artists.Where(el => el.AlbomV.GrammyNominations >= 1).ToList();
                    SaveDoc(CreateDocument(Task2), "task2.xml");
                    break;
                case 3:
                    List<Artist> Task3 = artists.OrderBy(el => el.AlbomV.Songs).ThenBy(el => el.AlbomV.GrammyNominations).ToList();
                    XDocument task3 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Artist",
                                    new XAttribute("Name", Task3[0].Name),
                                    new XElement("Sex", Task3[0].Sex),
                                    new XElement("Department", Task3[0].Department),
                                    new XElement("Albom",
                                        new XElement("Name", Task3[0].AlbomV.Name),
                                        new XElement("GrammyNominations", Task3[0].AlbomV.GrammyNominations),
                                        new XElement("Mark", Task3[0].AlbomV.Mark),
                                        new XElement("Songs", Task3[0].AlbomV.Songs))));
                    SaveDoc(task3, "task3.xml");
                    break;
                case 4:
                    List<Artist> Task4 = artists.Where(el => el.Sex == "female").ToList();
                    Task4 = Task4.OrderByDescending(el => el.AlbomV.Mark).ToList();
                    XDocument task4 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Artist",
                                    new XAttribute("Name", Task4[0].Name),
                                    new XElement("Sex", Task4[0].Sex),
                                    new XElement("Department", Task4[0].Department),
                                    new XElement("Albom",
                                        new XElement("Name", Task4[0].AlbomV.Name),
                                        new XElement("GrammyNominations", Task4[0].AlbomV.GrammyNominations),
                                        new XElement("Mark", Task4[0].AlbomV.Mark),
                                        new XElement("Songs", Task4[0].AlbomV.Songs))));
                    SaveDoc(task4, "task4.xml");
                    break;
                case 5:
                    var groupName = artists.GroupBy(el => el.Name);
                    SaveDoc(CreateDocGroup(groupName), "group.xml");
                    var groupSex = artists.GroupBy(el => el.Sex);
                    SaveDoc(CreateDocGroup(groupSex), "group1.xml");
                    var groupDepartment = artists.GroupBy(el => el.Department);
                    SaveDoc(CreateDocGroup(groupDepartment), "group2.xml");
                    var groupWrapper = artists.GroupBy(el => el.AlbomV);
                    SaveDoc(CreateDocGroup(groupWrapper), "group3.xml");
                    break;
                default:
                    throw new Exception("wrong number");
            }
        }
        public static void Start(List<Artist> artists)
        {
            var xDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                            new XElement("Artists", artists.Select(a => new XElement("Artist",
                                    new XAttribute("Name", a.Name),
                                    new XElement("Sex", a.Sex),
                                    new XElement("Department", a.Department),
                                    new XElement("Albom",
                                        new XElement("Name", a.AlbomV.Name),
                                        new XElement("GrammyNominations", a.AlbomV.GrammyNominations),
                                        new XElement("Mark", a.AlbomV.Mark),
                                        new XElement("Songs", a.AlbomV.Songs))))));
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
                    IndividualTasks(artists);
                    break;
                case 4:
                    break;
            }
        }
        static void Main(string[] args)
        {
            List<Artist> artists = new List<Artist>()
            {
                new Artist("Pharapoh", "Hip-Hop", "male", new Albom("Phuneral", 10, 7.8, 0)),
                new Artist("Billie Eilish", "Hip-Hop", "female", new Albom("Dont smile at me", 15, 8.4, 6)),
                new Artist("ASAP ROCKY", "Hip-Hop", "male", new Albom("Testing", 14, 8.7, 0)),
                new Artist("Big Baby Tape", "Hip-Hop", "male", new Albom("Dragon Born", 12, 8.5, 0))
            };
            Start(artists);
        }
    }
}

