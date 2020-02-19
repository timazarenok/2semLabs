using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace laba20variant14
{
    class Mark
    {
        int value;
        public int Value
        {
            get => value;
            set
            {
                if(value > 10 || value < 0)
                {
                    throw new Exception("Wrong value");
                }
                this.value = value;
            }
        }
        public Mark() { }
        public Mark(int value)
        {
            Value = value;
        }
        public override string ToString()
        {
            return $"Mark: {Value}";
        }
    }
    class Student
    {
        string fullName;
        int course;
        int semestr;
        int lostLessons;
        string group;
        double salary;
        List<Mark> marks;
        public string FullName
        {
            get => fullName;
            set
            {
                if (!Char.IsUpper(value[0]))
                {
                    throw new Exception("value is not upper at the beginning");
                }
                fullName = value;
            }
        }
        public int Course
        {
            get => course;
            set
            {
                if(value < 0)
                {
                    throw new Exception("negative value");
                }
                course = value;
            }
        }
        public int Semestr
        {
            get => semestr;
            set
            {
                if (value < 0)
                {
                    throw new Exception("negative value");
                }
                semestr = value;
            }
        }
        public int LostLessons
        {
            get => lostLessons;
            set
            {
                if (value < 0)
                {
                    throw new Exception("negative value");
                }
                lostLessons = value;
            }
        }
        public string Group
        {
            get => group;
            set
            {
                Regex reg = new Regex(@"^[T,D,P,K]\-\d{3}");
                if (!reg.IsMatch(value))
                {
                    throw new Exception("wrong value");
                }
                group = value;
            }
        }
        public double Salary
        {
            get => salary;
            set
            {
                if (value.ToString().Split('.', ',').Length != 2)
                {
                    throw new Exception("wrong value");
                }
                salary = value;
            }
        }
        public List<Mark> Marks
        {
            get => marks;
            set
            {
                marks = value;
            }
        }
        public Student() { }
        public Student(string fullName, int course, int semestr, int lostLessons, string group, double salary, List<Mark> marks)
        {
            FullName = fullName;
            Course = course;
            Semestr = semestr;
            LostLessons = lostLessons;
            Group = group;
            Salary = salary;
            Marks = marks;
        }
        public string GetMarks()
        {
            string result = "";
            foreach(Mark i in Marks)
            {
                result += i + " ";
            }
            return result;
        }
        public override string ToString()
        {
            return $"{FullName} course: {Course} Semestr: {Semestr} lost lessons: {LostLessons} \n " +
                $"Group: {Group} Salary: {Salary} Marks: {GetMarks()}";
        }
    }
    class Program
    {
        public static double AverageMark(List<Mark> marks)
        {
            int sum = 0;
            foreach (Mark i in marks)
            {
                sum += i.Value;
            }
            return sum / marks.Count;
        }
        public static void Print<T>(ICollection<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        public static void PrintGroup<T,TT>(IEnumerable<IGrouping<T,TT>> group) 
        {
            foreach (var item in group)
            {
                Console.WriteLine(item.Key);
                Print((ICollection<TT>)item);
            }
        }
        public static void Start(List<Student> students)
        {
            Console.WriteLine("Input value from 1-5");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    Print(students.OrderBy(el => el.FullName).ThenBy(el => el.Course).ThenBy(el => el.Group).ToList());
                    break;
                case 2:
                    Print(students.Where(el => el.Salary < 60).ToList());
                    break;
                case 3:
                    Print(students.Where(el => el.LostLessons < 60 && el.FullName[3].Equals('A')).ToList());
                    break;
                case 4:
                    List<double> Task4 = students.Select(el => AverageMark(el.Marks)).ToList();
                    for(int i = 0; i != students.Count; ++i)
                    {
                        Console.WriteLine(students[i].Group + " :" + Task4[i]);
                    }
                    double result = Task4.Sum() / Task4.Count;
                    Console.WriteLine($"Average mark in all groups: {result}");
                    break;
                case 5:
                    var groupFullName = students.GroupBy(el => el.FullName);
                    PrintGroup(groupFullName);
                    var groupCourse = students.GroupBy(el => el.Course);
                    PrintGroup(groupCourse);
                    var groupSemestr = students.GroupBy(el => el.Semestr);
                    PrintGroup(groupSemestr);
                    var groupGroup = students.GroupBy(el => el.Group);
                    PrintGroup(groupGroup);
                    var groupMarks = students.GroupBy(el => el.Marks);
                    PrintGroup(groupMarks);
                    var groupSalary = students.GroupBy(el => el.Salary);
                    PrintGroup(groupSalary);
                    var groupLostLessons = students.GroupBy(el => el.LostLessons);
                    PrintGroup(groupLostLessons);
                    break;
                default:
                    throw new Exception("Wrong number");
            }
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
                new Student("T.Z.A", 3, 2, 40, "T-795", 24.56, marks),
                new Student("A.A.A", 4, 2, 10, "T-791", 22.45,marks),
                new Student("V.B.E", 2, 2, 20, "T-792", 23.67,marks),
                new Student("C.P.U", 1, 1, 1, "T-793", 19.56,marks)
            };
            Start(students);
            Start(students);
            Start(students);
            Start(students);
            Start(students);
            Console.ReadKey();
        }
    }
}
