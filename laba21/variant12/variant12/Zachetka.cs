using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace variant12
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
                if (value < 0 || value > 10)
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
                if (value < 0)
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
                if (mathes.Count < 0)
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
                if (value.ToString().Length != 8)
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
            foreach (Exam exam in exams)
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
}