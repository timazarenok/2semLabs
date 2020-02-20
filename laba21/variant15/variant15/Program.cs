using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace variant15
{
    class Program
    {
        public static XDocument CreateDocument(List<Department> list)
        {
            XDocument task1 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                        new XElement("task1", list.Select(d => new XElement("Department",
                                    new XAttribute("University", d.University),
                                    new XElement("Name", d.Name),
                                    new XElement("Professors", d.Professors),
                                    new XElement("Subjects", d.GetSubjects()),
                                    new XElement("Surnames", d.GetSurnames())))));
            return task1;
        }
        public static XDocument CreateDocGroup<T>(IEnumerable<IGrouping<T, Department>> group)
        {
            XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Grouping"));
            foreach (var item in group)
            {
                doc.Root.Add(new XElement("Group", new XAttribute("GroupAttribute", item.Key),
                                                    item.ToList().Select(d => new XElement("Department",
                                    new XAttribute("University", d.University),
                                    new XElement("Name", d.Name),
                                    new XElement("Professors", d.Professors),
                                    new XElement("Subjects", d.GetSubjects()),
                                    new XElement("Surnames", d.GetSurnames())))));
            }
            return doc;
        }
        public static void SaveDoc(XDocument doc, string fileName)
        {
            doc.Save(Path.Combine(Environment.CurrentDirectory, fileName));
        }
        public static XElement AddDepartment()
        {
            Console.WriteLine("Input values \n " +
                "university \n" +
                "name \n" +
                "professors \n");
            string university = Console.ReadLine();
            string name = Console.ReadLine();
            int professors = Convert.ToInt32(Console.ReadLine());
            List<Surname> surnames = new List<Surname>();
            HashSet<Subject> subjects = new HashSet<Subject>();
            Department d = new Department(university, name, professors, surnames, subjects);
            return new XElement("Department",
                                    new XAttribute("University", d.University),
                                    new XElement("Name", d.Name),
                                    new XElement("Professors", d.Professors),
                                    new XElement("Subjects", d.GetSubjects()),
                                    new XElement("Surnames", d.GetSurnames()));
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
        public static void IndividualTasks(List<Department> departments)
        {
            Console.WriteLine("Input number from 1-5");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    List<Department> Task1 = departments.OrderBy(el => el.University).ThenBy(el => el.Name).ToList();
                    SaveDoc(CreateDocument(Task1), "task1.xml");
                    break;
                case 2:
                    List<List<Department>> Task2 = new List<List<Department>>();
                    foreach (Department l in departments)
                    {
                        Task2.Add(departments.Where(el => el.Name == l.Name).ToList());
                    }
                    XDocument task2 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Departments"));
                    foreach (List<Department> list in Task2)
                    {
                        foreach (Department d in list)
                        {
                            task2.Root.Add(new XElement("Department",
                                    new XAttribute("University", d.University),
                                    new XElement("Name", d.Name),
                                    new XElement("Professors", d.Professors),
                                    new XElement("Subjects", d.GetSubjects()),
                                    new XElement("Surnames", d.GetSurnames())));
                        }
                    }
                    SaveDoc(task2, "task2.xml");
                    break;
                case 3:
                    XDocument task3 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Departments"));
                    foreach (Department d in departments)
                    {
                        task3.Root.Add(new XElement("Department", new XAttribute("Name", d.Name), new XElement("subjects", d.GetSubjects())));
                    }
                    SaveDoc(task3, "task3.xml");
                    break;
                case 4:
                    List<int> Task4 = departments.Select(el => el.Surnames.Count).ToList();
                    int result = 0;
                    foreach (int i in Task4)
                    {
                        result += i;
                    }
                    XDocument task4 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("SurnamesOfAllUniversities", result));
                    SaveDoc(task4, "task4.xml");
                    break;
                case 5:
                    var groupUniversity = departments.GroupBy(el => el.University);
                    SaveDoc(CreateDocGroup(groupUniversity), "group.xml");
                    var groupName = departments.GroupBy(el => el.Name);
                    SaveDoc(CreateDocGroup(groupName), "group1.xml");
                    var groupProfessors = departments.GroupBy(el => el.Professors);
                    SaveDoc(CreateDocGroup(groupProfessors), "group2.xml");
                    var groupSubject = departments.GroupBy(el => el.Subjects);
                    SaveDoc(CreateDocGroup(groupSubject), "group3.xml");
                    var groupSurnames = departments.GroupBy(el => el.Surnames);
                    SaveDoc(CreateDocGroup(groupSurnames), "group4.xml");
                    break;
            }
        }
        public static void Start(List<Department> departments)
        {
            var xDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                            new XElement("Departments", departments.Select(d => new XElement("Department",
                                    new XAttribute("University", d.University),
                                    new XElement("Name", d.Name),
                                    new XElement("Professors", d.Professors),
                                    new XElement("Subjects", d.GetSubjects()),
                                    new XElement("Surnames", d.GetSurnames())))));
            int choice = Choice();
            switch (choice)
            {
                case 1:
                    SaveDoc(xDoc, "xdoc.xml");
                    break;
                case 2:
                    xDoc.Root.Add(AddDepartment());
                    SaveDoc(xDoc, "xdoc.xml");
                    break;
                case 3:
                    IndividualTasks(departments);
                    break;
                case 4:
                    break;
            }
        }
        static void Main(string[] args)
        {
            List<Surname> surnames = new List<Surname>()
            {
                new Surname("Zarenok"),
                new Surname("Rubis"),
                new Surname("Vorobyov"),
                new Surname("Chekurin"),
                new Surname("Borshevskii")
            };
            HashSet<Subject> subjects = new HashSet<Subject>()
            {
                new Subject("English"),
                new Subject("Kpiyap"),
                new Subject("ZKI"),
                new Subject("TRPO"),
                new Subject("Math")
            };
            List<Department> departments = new List<Department>()
            {
                new Department("College of buisiness and law", "Programmers", 7, surnames, subjects),
                new Department("College of buisiness and law", "Layers", 10, surnames, subjects),
                new Department("Bntu", "Stupids", 15, surnames, subjects),
                new Department("BGU", "Gamers", 16, surnames, subjects),
                new Department("BGuir", "Economists", 17, surnames, subjects),
            };
            Start(departments);
        }
    }
}
