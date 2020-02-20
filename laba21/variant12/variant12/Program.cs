using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace variant12
{
    class Program
    {
        public static XDocument CreateDocument(List<Zachetka> list)
        {
            XDocument task1 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                        new XElement("task1", list.Select(za => new XElement("Zachetka",
                                    new XAttribute("GroupNumber", za.NumberGroup),
                                    new XElement("Course", za.Course),
                                    new XElement("Semestr", za.Semestr),
                                    new XElement("FullName", za.FullName),
                                    new XElement("Number", za.Number),
                                    new XElement("Exams", za.ExamsOuput())))));
            return task1;
        }
        public static XDocument CreateDocGroup<T>(IEnumerable<IGrouping<T, Zachetka>> group)
        {
            XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Grouping"));
            foreach (var item in group)
            {
                doc.Root.Add(new XElement("Group", new XAttribute("GroupAttribute", item.Key),
                                                    item.ToList().Select(za => new XElement("Zachetka",
                                    new XAttribute("GroupNumber", za.NumberGroup),
                                    new XElement("Course", za.Course),
                                    new XElement("Semestr", za.Semestr),
                                    new XElement("FullName", za.FullName),
                                    new XElement("Number", za.Number),
                                    new XElement("Exams", za.ExamsOuput())))));
            }
            return doc;
        }
        public static void SaveDoc(XDocument doc, string fileName)
        {
            doc.Save(Path.Combine(Environment.CurrentDirectory, fileName));
        }
        public static XElement AddZachetka()
        {
            Console.WriteLine("Input values \n " +
                "fullName \n" +
                "number \n" +
                "course \n" +
                "semestr \n" +
                "number group \n");
            string fullName = Console.ReadLine();
            long number = Convert.ToInt64(Console.ReadLine());
            int course = Convert.ToInt32(Console.ReadLine());
            List<Exam> exams = new List<Exam>();
            int semestr = Convert.ToInt32(Console.ReadLine());
            string numberGroup = Console.ReadLine();
            Zachetka za = new Zachetka(course, semestr, numberGroup, fullName, number, exams);
            return new XElement("Zachetka",
                                    new XAttribute("Group Number", za.NumberGroup),
                                    new XElement("Course", za.Course),
                                    new XElement("Semestr", za.Semestr),
                                    new XElement("FullName", za.FullName),
                                    new XElement("Number", za.Number),
                                    new XElement("Exams", za.ExamsOuput()));
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
        static double AverageMark(List<Exam> exams)
        {
            int sum = 0;
            foreach (Exam exam in exams)
            {
                sum += exam.Mark;
            }
            return sum / exams.Count;
        }
        public static void IndividualTasks(List<Zachetka> zachetkas)
        {
            Console.WriteLine("Input number 1-5");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    List<Zachetka> Task1 = zachetkas.OrderBy(el => el.Course).ThenBy(el => el.NumberGroup).ToList();
                    SaveDoc(CreateDocument(Task1), "task1.xml");
                    break;
                case 2:
                    List<List<Zachetka>> Task2 = new List<List<Zachetka>>();
                    XDocument task2 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Zachetkas"));
                    foreach (Zachetka l in zachetkas)
                    {
                        Task2.Add(zachetkas.Where(el => el.NumberGroup == l.NumberGroup).ToList());
                    }
                    foreach (List<Zachetka> list in Task2)
                    {
                        foreach (Zachetka za in list)
                        {
                            task2.Root.Add(new XElement("Zachetka",
                                    new XAttribute("GroupNumber", za.NumberGroup),
                                    new XElement("Course", za.Course),
                                    new XElement("Semestr", za.Semestr),
                                    new XElement("FullName", za.FullName),
                                    new XElement("Number", za.Number),
                                    new XElement("Exams", za.ExamsOuput())));
                        }
                    }
                    SaveDoc(task2, "task2.xml");
                    break;
                case 3:
                    List<Zachetka> Task3 = zachetkas.Where(el => el.Exams.Where(item => item.Mark < 4).ToList().Count != 0).ToList();
                    SaveDoc(CreateDocument(Task3), "task3.xml");
                    break;
                case 4:
                    double Task4 = zachetkas.Sum(el => AverageMark(el.Exams)) / zachetkas.Count;
                    XDocument task4 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Result", Task4));
                    SaveDoc(task4, "task4.xml");
                    break;
                case 5:
                    var groupCourse = zachetkas.GroupBy(el => el.Course);
                    XDocument group = CreateDocGroup(groupCourse);
                    SaveDoc(group, "group.xml");
                    var groupSemestr = zachetkas.GroupBy(el => el.Semestr);
                    XDocument group1 = CreateDocGroup(groupSemestr);
                    SaveDoc(group1, "group1.xml");
                    var groupGroupNumber = zachetkas.GroupBy(el => el.NumberGroup);
                    XDocument group2 = CreateDocGroup(groupGroupNumber);
                    SaveDoc(group2, "group2.xml");
                    var groupFullName = zachetkas.GroupBy(el => el.FullName);
                    XDocument group3 = CreateDocGroup(groupFullName);
                    SaveDoc(group3, "group3.xml");
                    var groupNumber = zachetkas.GroupBy(el => el.Number);
                    XDocument group4 = CreateDocGroup(groupNumber);
                    SaveDoc(group4, "group4.xml");
                    var groupExams = zachetkas.GroupBy(el => el.Exams);
                    XDocument group5 = CreateDocGroup(groupExams);
                    SaveDoc(group5, "group5.xml");
                    break;
                default:
                    throw new Exception("wrong input number");
            }
        }
        public static void Start(List<Zachetka> zachetkas)
        {
            var xDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                            new XElement("Zachetkas", zachetkas.Select(za => new XElement("Zachetka",
                                    new XAttribute("GroupNumber", za.NumberGroup),
                                    new XElement("Course", za.Course),
                                    new XElement("Semestr", za.Semestr),
                                    new XElement("FullName", za.FullName),
                                    new XElement("Number", za.Number),
                                    new XElement("Exams", za.ExamsOuput())))));
            int choice = Choice();
            switch (choice)
            {
                case 1:
                    SaveDoc(xDoc, "xdoc.xml");
                    break;
                case 2:
                    xDoc.Root.Add(AddZachetka());
                    SaveDoc(xDoc, "xdoc.xml");
                    break;
                case 3:
                    IndividualTasks(zachetkas);
                    break;
                case 4:
                    break;
            }
        }
        static void Main(string[] args)
        {
            List<Exam> examsFirst = new List<Exam>()
            {
                new Exam("Math", 8),
                new Exam("Economy", 9),
                new Exam("Kpiyap", 9),
                new Exam("Practica", 9),
                new Exam("TRPO", 9),
                new Exam("ZKI", 9)
            };
            List<Exam> examsSeconds = new List<Exam>()
            {
                new Exam("Math", 4),
                new Exam("Economy", 2),
                new Exam("Kpiyap", 2),
                new Exam("Practica", 1),
                new Exam("TRPO", 7),
                new Exam("ZKI", 6)
            };
            List<Zachetka> zachetkas = new List<Zachetka>()
            {
                new Zachetka(3, 5, "T-795", "T.Z.A", 13959873, examsFirst),
                new Zachetka(4, 7, "D-675", "A.F.A", 23959823, examsSeconds),
                new Zachetka(2, 3, "P-575", "A.A.A", 33959345, examsFirst),
            };
            Start(zachetkas);
            Console.ReadKey();
        }
    }
}
