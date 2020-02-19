using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba20variant15
{
    class Surname
    {
        string value;
        public string Value
        {
            get => value;
            set
            {
                if (!Char.IsUpper(value[0]))
                {
                    throw new Exception("wrong value");
                }
                this.value = value;
            }
        }
        public Surname() { }
        public Surname(string value)
        {
            Value = value;
        }
        public override string ToString()
        {
            return $" {Value} ";
        }
    }
    class Subject
    {
        string value;
        public string Value
        {
            get => value;
            set
            {
                if (!Char.IsUpper(value[0]))
                {
                    throw new Exception("wrong value");
                }
                this.value = value;
            }
        }
        public Subject() { }
        public Subject(string value)
        {
            Value = value;
        }
        public override string ToString()
        {
            return $" {Value} ";
        }
    }
    class Department
    {
        string university;
        string name;
        int professors;
        List<Surname> surnames;
        HashSet<Subject> subjects;
        public string University
        {
            get => university;
            set
            {
                if (!Char.IsUpper(value[0]))
                {
                    throw new Exception("wrong value");
                }
                university = value;
            }
        }
        public string Name
        {
            get => name;
            set
            {
                if (!Char.IsUpper(value[0]))
                {
                    throw new Exception("wrong value");
                }
                name = value;
            }
        }
        public int Professors
        {
            get => professors;
            set
            {
                if(value < 0)
                {
                    throw new Exception("wrong value");
                }
                professors = value;
            }
        }
        public List<Surname> Surnames { get; set; }
        public HashSet<Subject> Subjects { get; set; }
        public Department() { }
        public Department(string university, string name, int professors, List<Surname> surnames, HashSet<Subject> subjects)
        {
            University = university;
            Name = name;
            Professors = professors;
            Surnames = surnames;
            Subjects = subjects;
        }
        public string GetSurnames()
        {
            string result = "";
            foreach (Surname sur in Surnames)
            {
                result += sur;
            }
            return result;
        }
        public string GetSubjects()
        {
            string result = "";
            foreach(Subject sub in Subjects)
            {
                result += sub;
            }
            return result;
        }
        public override string ToString()
        {
            return $"{University} {Name} {Professors} {GetSurnames()} {GetSubjects()} ";
        }
    }
    class Program
    {
        public static void Start(List<Department> departments)
        {
            Console.WriteLine("Input number from 1-5");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    List<Department> Task1 = departments.OrderBy(el => el.University).ThenBy(el => el.Name).ToList();
                    foreach (Department d in departments)
                    {
                        Console.WriteLine(d);
                    }
                    break;
                case 2:
                    List<List<Department>> Task2 = new List<List<Department>>();
                    foreach (Department l in departments)
                    {
                        Task2.Add(departments.Where(el => el.Name == l.Name).ToList());
                    }
                    foreach (List<Department> list in Task2)
                    {
                        foreach (Department l in list)
                        {
                            Console.WriteLine(l.University);
                        }
                    }
                    break;
                case 3:
                    foreach(Department d in departments)
                    {
                        Console.WriteLine(d.GetSubjects());
                    }
                    break;
                case 4:
                    List<int> Task4 = departments.Select(el => el.Surnames.Count).ToList();
                    int result = 0;
                    foreach (int i in Task4)
                    {
                        result += i;
                    }
                    Console.WriteLine(result);
                    break;
                case 5:
                    var groupUniversity = departments.GroupBy(el => el.University);
                    foreach (IGrouping<string, Department> item in groupUniversity)
                    {
                        Console.WriteLine(item.Key);
                        foreach (Department st in item)
                        {
                            Console.WriteLine(st);
                        }
                    }
                    var groupName = departments.GroupBy(el => el.Name);
                    foreach (IGrouping<string, Department> item in groupName)
                    {
                        Console.WriteLine(item.Key);
                        foreach (Department st in item)
                        {
                            Console.WriteLine(st);
                        }
                    }
                    var groupProfessors = departments.GroupBy(el => el.Professors);
                    foreach (IGrouping<int, Department> item in groupProfessors)
                    {
                        Console.WriteLine(item.Key);
                        foreach (Department st in item)
                        {
                            Console.WriteLine(st);
                        }
                    }
                    var groupSubject= departments.GroupBy(el => el.Subjects);
                    foreach (IGrouping<HashSet<Subject>, Department> item in groupSubject)
                    {
                        Console.WriteLine("Subjects");
                        foreach (Department st in item)
                        {
                            Console.WriteLine(st);
                        }
                    }
                    var groupSurnames = departments.GroupBy(el => el.Surnames);
                    foreach (IGrouping<List<Surname>, Department> item in groupSurnames)
                    {
                        Console.WriteLine("Surnames");
                        foreach (Department st in item)
                        {
                            Console.WriteLine(st);
                        }
                    }
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
            Console.ReadKey();
        }
    }
}
