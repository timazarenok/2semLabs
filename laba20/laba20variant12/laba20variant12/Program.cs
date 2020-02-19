using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace laba20variant12
{
    class Exam
    {
        string subject;
        int mark;
        public string Subject
        {
            get => subject;
            set
            {
                if (!Char.IsUpper(value[0]))
                {
                    throw new Exception("Upper at the beggining not match");
                }
                subject = value;
            }
        }
        public int Mark
        {
            get => mark;
            set
            {
                if(value < 0 || value > 10)
                {
                    throw new Exception("Wrong number mark");
                }
                mark = value;
            }
        }
        public Exam() { }
        public Exam(string subject, int mark)
        {
            Subject = subject;
            Mark = mark;
        }
        public override string ToString()
        {
            return $"{Subject} - {Mark}";
        }
    }
    class Zachetka
    {
        int course;
        int semestr;
        string numberGroup;
        string fullName;
        long number;
        List<Exam> exams;
        public int Course
        {
            get => course;
            set
            {
                if(value < 0)
                {
                    throw new Exception("Wrong number");
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
                    throw new Exception("Wrong number");
                }
                semestr = value;
            }
        }
        public string NumberGroup
        {
            get => numberGroup;
            set
            {
                Regex reg = new Regex(@"^[T,D,P]\-\d{3}$");
                MatchCollection mathes = reg.Matches(value);
                if(mathes.Count < 0)
                {
                    throw new Exception("Wrong value");
                }
                numberGroup = value;
            }
        }
        public string FullName
        {
            get => fullName;
            set
            {
                if (!Char.IsUpper(value[0]))
                {
                    throw new Exception("Not upper at the begining");
                }
                fullName = value;
            }
        }
        public long Number
        {
            get => number;
            set
            {
                if(value.ToString().Length != 8)
                {
                    throw new Exception("wrong amount of digits");
                }
                number = value;
            }
        }
        public List<Exam> Exams { get => exams; set => exams = value; }
        public Zachetka() { }
        public Zachetka(int course, int semestr, string numberGroup, string fullName, long number, List<Exam> exams)
        {
            Course = course;
            Semestr = semestr;
            NumberGroup = numberGroup;
            FullName = fullName;
            Number = number;
            Exams = exams;
        }
        public string ExamsOuput()
        {
            string outPut = "";
            foreach(Exam exam in exams)
            {
                outPut += exam;
            }
            return outPut;
        }
        public override string ToString()
        {
            return $"Course: {Course} Semestr: {Semestr} NumberGroup: {NumberGroup} FullName: {FullName} Number: {Number} Exams: {ExamsOuput()}";
        }
    }
    class Program
    {
        static double AverageMark(List<Exam> exams)
        {
            int sum = 0;
            foreach(Exam exam in exams)
            {
                sum += exam.Mark;
            }
            return sum / exams.Count;
        }
        static public void Start(List<Zachetka> zachetkas)
        {
            Console.WriteLine("Input number 1-5");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    List<Zachetka> Task1 = zachetkas.OrderBy(el => el.Course).ThenBy(el => el.NumberGroup).ToList();
                    foreach(Zachetka za in Task1)
                        Console.WriteLine(za);
                    break;
                case 2:
                    List<List<Zachetka>> Task2 = new List<List<Zachetka>>();
                    foreach (Zachetka l in zachetkas)
                    {
                        Task2.Add(zachetkas.Where(el => el.NumberGroup == l.NumberGroup).ToList());
                    }
                    foreach (List<Zachetka> list in Task2)
                    {
                        foreach (Zachetka l in list)
                        {
                            Console.WriteLine(l.Number);
                        }
                    }
                    break;
                case 3:
                    List<Zachetka> Task3 = zachetkas.Where(el => el.Exams.Where(item => item.Mark < 4).ToList().Count != 0).ToList();
                    foreach(Zachetka za in Task3)
                        Console.WriteLine(za.FullName);
                    break;
                case 4:
                    double Task4 = zachetkas.Sum(el => AverageMark(el.Exams)) / zachetkas.Count;
                    Console.WriteLine(Task4);
                    break;
                case 5:
                    var groupCourse = zachetkas.GroupBy(el => el.Course);
                    foreach (IGrouping<int, Zachetka> item in groupCourse)
                    {
                        Console.WriteLine(item.Key);
                        foreach (Zachetka za in item)
                        {
                            Console.WriteLine(za);
                        }
                    }
                    var groupSemestr = zachetkas.GroupBy(el => el.Semestr);
                    foreach (IGrouping<int, Zachetka> item in groupSemestr)
                    {
                        Console.WriteLine(item.Key);
                        foreach (Zachetka za in item)
                        {
                            Console.WriteLine(za);
                        }
                    }
                    var groupGroupNumber = zachetkas.GroupBy(el => el.NumberGroup);
                    foreach (IGrouping<string, Zachetka> item in groupGroupNumber)
                    {
                        Console.WriteLine(item.Key);
                        foreach (Zachetka za in item)
                        {
                            Console.WriteLine(za);
                        }
                    }
                    var groupFullName = zachetkas.GroupBy(el => el.FullName);
                    foreach (IGrouping<string, Zachetka> item in groupFullName)
                    {
                        Console.WriteLine(item.Key);
                        foreach (Zachetka za in item)
                        {
                            Console.WriteLine(za);
                        }
                    }
                    var groupNumber = zachetkas.GroupBy(el => el.Number);
                    foreach (IGrouping<long, Zachetka> item in groupNumber)
                    {
                        Console.WriteLine(item.Key);
                        foreach (Zachetka za in item)
                        {
                            Console.WriteLine(za);
                        }
                    }
                    var groupExams = zachetkas.GroupBy(el => el.Exams);
                    foreach (IGrouping<List<Exam>, Zachetka> item in groupExams)
                    {
                        Console.WriteLine(item.Key);
                        foreach (Zachetka za in item)
                        {
                            Console.WriteLine(za);
                        }
                    }
                    break;
                default:
                    throw new Exception("wrong input number");
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
