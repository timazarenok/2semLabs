using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace variant14
{
    class Mark
    {
        public int Value { get; set; }
        public Mark() { }
        public Mark(int value)
        {
            Value = value;
        }
        public override string ToString()
        {
            return $"{Value}";
        }
    }
    class Student
    {
        string surname;
        int course;
        int semestr;
        string group;
        public List<Mark> Marks { get; set; }
        double salary;
        int lostLessons;
        public string Surname
        {
            get => surname;
            set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new Exception("wrong value");
                }
                surname = value;
            }
        }
        public int Course
        {
            get => course;
            set
            {
                if (value < 0)
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
        public Student() { }
        public Student(string surname, int course, int semestr, string group, List<Mark> marks, double salary, int lostLessons)
        {
            Surname = surname;
            Course = course;
            Semestr = semestr;
            Group = group;
            Marks = marks;
            Salary = salary;
            LostLessons = lostLessons;
        }
        public string GetMarks()
        {
            string result = "";
            foreach(Mark mark in Marks)
            {
                result += mark + " ";
            }
            return result;
        }
        public override string ToString()
        {
            return $"{Surname} {Course} {Semestr} {Group} {Salary} {LostLessons} {GetMarks()}";
        }
    }
}