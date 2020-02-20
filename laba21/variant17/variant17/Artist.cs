using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace variant17
{
    class Albom
    {
        string name;
        int songs;
        double mark;
        int grammyNominations;
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
        public int Songs
        {
            get => songs;
            set
            {
                if (value < 0)
                {
                    throw new Exception("wrong number");
                }
                songs = value;
            }
        }
        public double Mark
        {
            get => mark;
            set
            {
                if (value < 10 && value < 0)
                {
                    throw new Exception("wrong value");
                }
                mark = value;
            }
        }
        public int GrammyNominations
        {
            get => grammyNominations;
            set
            {
                if (grammyNominations < 0)
                {
                    throw new Exception("Wrong value");
                }
                grammyNominations = value;
            }
        }
        public Albom() { }
        public Albom(string name, int songs, double mark, int grammyNominations)
        {
            Name = name;
            Songs = songs;
            Mark = mark;
            GrammyNominations = grammyNominations;
        }
        public override string ToString()
        {
            return $"{Name} {Songs} {Mark} {GrammyNominations}";
        }
    }
    class Artist
    {
        string name;
        string sex;
        string department;
        Albom albomV;
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
        public string Sex
        {
            get => sex;
            set
            {
                if (value == "female" || value == "male")
                {
                    sex = value;
                }
                else
                {
                    throw new Exception("wrong value");
                }
            }
        }
        public string Department
        {
            get => department;
            set
            {
                if (!Char.IsUpper(value[0]))
                {
                    throw new Exception("wrong value");
                }
                department = value;
            }
        }
        public Albom AlbomV { get; set; }
        public Artist() { }
        public Artist(string name, string department, string sex, Albom albom)
        {
            Name = name;
            Department = department;
            Sex = sex;
            AlbomV = albom;
        }
        public override string ToString()
        {
            return $"{Name} {Department} {Sex} {AlbomV}";
        }
    }
}