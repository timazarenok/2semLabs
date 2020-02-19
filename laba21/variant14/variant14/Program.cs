using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace variant14
{
    class Program
    {
        public static XElement AddStudent()
        {
            Console.WriteLine("Input values \n " +
                "surname \n" +
                "course \n" +
                "semestr \n" +
                "group \n" +
                "marks \n" +
                "salary \n" +
                "lost lessons \n");
            string surname = Console.ReadLine();
            int course = Convert.ToInt32(Console.ReadLine());
            int semestr = Convert.ToInt32(Console.ReadLine());
            string group = Console.ReadLine();
            double salary = Convert.ToDouble(Console.ReadLine());
            int lostLessons = Convert.ToInt32(Console.ReadLine());
            List<Mark> marks = new List<Mark>(10);
            foreach (Mark el in marks)
            {
                el.Value = 8;
                Console.WriteLine(el.Value);
            }
            Student st = new Student(surname, course, semestr, group, marks, salary, lostLessons);
            return new XElement("Student", new XAttribute("Surname", st.Surname),
                    new XElement("Group", st.Group),
                    new XElement("Course", st.Course),
                    new XElement("Semestr", st.Semestr),
                    new XElement("Salary", st.Salary),
                    new XElement("Marks", st.GetMarks()),
                    new XElement("LostLessons", st.LostLessons));
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
        public static XDocument CreateDocGroup<T>(IEnumerable<IGrouping<T, Student>> group)
        {
            XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Grouping"));
            foreach (var item in group)
            {
                doc.Root.Add(new XElement("Group", new XAttribute("GroupAttribute", item.Key),
                                                    item.ToList().Select(st => new XElement("Student",
                                    new XAttribute("Surname", st.Surname),
                                    new XElement("Group", st.Group),
                                    new XElement("Course", st.Course),
                                    new XElement("Semestr", st.Semestr),
                                    new XElement("Salary", st.Salary),
                                    new XElement("Marks", st.GetMarks()),
                                    new XElement("LostLessons", st.LostLessons)))));
            }
            return doc;
        }
        public static double AverageMark(List<Mark> marks)
        {
            int sum = 0;
            foreach (Mark i in marks)
            {
                sum += i.Value;
            }
            return sum / marks.Count;
        }
        public static XDocument CreateDocument(List<Student> list)
        {
            XDocument task1 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                        new XElement("task1", list.Select(st => new XElement("Student",
                                    new XAttribute("Surname", st.Surname),
                                    new XElement("Group", st.Group),
                                    new XElement("Course", st.Course),
                                    new XElement("Semestr", st.Semestr),
                                    new XElement("Salary", st.Salary),
                                    new XElement("Marks", st.GetMarks()),
                                    new XElement("LostLessons", st.LostLessons)))));
            return task1;
        }
        public static void SaveDoc(XDocument doc, string fileName)
        {
            doc.Save(Path.Combine(Environment.CurrentDirectory, fileName));
        }
        public static void IndividualTasks(List<Student> students)
        {
            Console.WriteLine("Input value from 1-5");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    XDocument task1 = CreateDocument(students.OrderBy(el => el.Surname).ThenBy(el => el.Course).ThenBy(el => el.Group).ToList());
                    SaveDoc(task1, "task1.xml");
                    break;
                case 2:
                    XDocument task2 = CreateDocument(students.Where(el => el.Salary < 60).ToList());
                    SaveDoc(task2, "task2.xml");
                    break;
                case 3:
                    XDocument task3 = CreateDocument(students.Where(el => el.LostLessons < 60 && el.Surname[0].Equals('A')).ToList());
                    SaveDoc(task3, "task3.xml");
                    break;
                case 4:
                    XDocument task4 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Group"));
                    List<double> Task4 = students.Select(el => AverageMark(el.Marks)).ToList();
                    for (int i = 0; i != students.Count; ++i)
                    {
                        task4.Root.Add(new XElement("Element", new XAttribute("Number", students[i].Group), 
                                                            new XElement("Mark", Task4[i])));
                    }
                    double result = Task4.Sum() / Task4.Count;
                    task4.Root.Add(new XElement("AveragMark", result));
                    SaveDoc(task4, "task4.xml");
                    break;
                case 5:
                    var groupFullName = students.GroupBy(el => el.Surname);
                    XDocument group = CreateDocGroup(groupFullName);
                    SaveDoc(group, "group.xml");
                    var groupCourse = students.GroupBy(el => el.Course);
                    XDocument group1 = CreateDocGroup(groupCourse);
                    SaveDoc(group1, "group1.xml");
                    var groupSemestr = students.GroupBy(el => el.Semestr);
                    XDocument group2 = CreateDocGroup(groupSemestr);
                    SaveDoc(group2, "group2.xml");
                    var groupGroup = students.GroupBy(el => el.Group);
                    XDocument group3 = CreateDocGroup(groupGroup);
                    SaveDoc(group3, "group3.xml");
                    var groupMarks = students.GroupBy(el => el.Marks);
                    XDocument group4 = CreateDocGroup(groupMarks);
                    SaveDoc(group4, "group4.xml");
                    var groupSalary = students.GroupBy(el => el.Salary);
                    XDocument group5 = CreateDocGroup(groupSalary);
                    SaveDoc(group5, "group5.xml");
                    var groupLostLessons = students.GroupBy(el => el.LostLessons);
                    XDocument group6 = CreateDocGroup(groupLostLessons);
                    SaveDoc(group6, "group6.xml");
                    break;
                default:
                    throw new Exception("Wrong number");
            }
        }
        public static void Start(List<Student> students)
        {
            int choice = Choice();
            var xDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Students", students.Select(st => new XElement("Student",
                    new XAttribute("Surname", st.Surname),
                    new XElement("Group", st.Group),
                    new XElement("Course", st.Course),
                    new XElement("Semestr", st.Semestr),
                    new XElement("Salary", st.Salary),
                    new XElement("Marks", st.GetMarks()),
                    new XElement("LostLessons", st.LostLessons)))));
            switch (choice)
            {
                case 1:
                    xDoc.Save(Path.Combine(Environment.CurrentDirectory, "xmlDoc.xml"));
                    break;
                case 2:
                    xDoc.Root.Add(AddStudent());
                    xDoc.Save(Path.Combine(Environment.CurrentDirectory, "xmlDoc.xml"));
                    break;
                case 3:
                    IndividualTasks(students);
                    break;
                case 4:
                    break;
                default:
                    throw new Exception("wrong value");
            }
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            List<Mark> marks = new List<Mark>()
            {
                new Mark(10),
                new Mark(9),
                new Mark(8),
                new Mark(10),
                new Mark(5),
                new Mark(6)
            };
            List<Student> students = new List<Student>()
            {
                new Student("Ezhov", 3, 2, "T-795", marks, 24.56, 40),
                new Student("Thief", 4, 2, "T-791", marks, 22.45, 10),
                new Student("Zarenok", 2, 2, "T-792",marks, 23.67, 20),
                new Student("Grom", 1, 1, "T-793", marks, 45.34, 20)
            };
            Start(students);
            Console.ReadKey();
        }
    }
}
