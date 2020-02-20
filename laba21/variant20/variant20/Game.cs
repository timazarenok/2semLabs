using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace variant20
{
    class Game
    {
        string name;
        string genre;
        string developer;
        public DateTime Date { get; set; }
        string platform;
        double mark;
        public string Name
        {
            get => name;
            set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new Exception("wrong value");
                }
                name = value;
            }
        }
        public string Developer
        {
            get => developer;
            set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new Exception("wrong value");
                }
                developer = value;
            }
        }
        public double Mark
        {
            get => mark;
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new Exception("wrong value");
                }
                mark = value;
            }
        }
        public string Platform
        {
            get => platform;
            set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new Exception("wrong value");
                }
                platform = value;
            }
        }
        public string Genre
        {
            get => genre;
            set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new Exception("wrong value");
                }
                genre = value;
            }
        }
        public Game() { }
        public Game(string name, string developer, string genre, DateTime date, string platform, double mark)
        {
            Name = name;
            Developer = developer;
            Genre = genre;
            Date = date;
            Platform = platform;
            Mark = mark;
        }
        public override string ToString()
        {
            return $"{Name} {Genre} {Developer} {Date} {Platform} {Mark}";
        }
    }
}