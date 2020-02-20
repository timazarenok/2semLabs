using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace variant15
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
                if (value < 0)
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
            foreach (Subject sub in Subjects)
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
}
