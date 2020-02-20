using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace variant19
{
    class Film
    {
        string name;
        int amountSessions;
        string genre;
        string language;
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
        public int AmountSessions
        {
            get => amountSessions;
            set
            {
                if (value < 0)
                {
                    throw new Exception("wrong value");
                }
                amountSessions = value;
            }
        }
        public string Language
        {
            get => language;
            set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new Exception("wrong value");
                }
                language = value;
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
        public Film() { }
        public Film(string name, string genre, int amountSessions, string language)
        {
            Name = name;
            Genre = genre;
            AmountSessions = amountSessions;
            Language = language;
        }
        public override string ToString()
        {
            return $"{Name} {Genre} sessions: {AmountSessions} {Language}";
        }
    }
    class Cinema
    {
        string name;
        string street;
        int amountHalls;
        public List<Film> Films { get; set; }
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
        public string Street
        {
            get => street;
            set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new Exception("wrong value");
                }
                street = value;
            }
        }
        public int AmountHalls
        {
            get => amountHalls;
            set
            {
                if (value < 0)
                {
                    throw new Exception("wrong value");
                }
                amountHalls = value;
            }
        }
        public string GetFilms()
        {
            string result = "";
            foreach (Film f in Films)
            {
                result += f + " ";
            }
            return result;
        }
        public Cinema() { }
        public Cinema(string name, string street, int amountHalls, List<Film> films)
        {
            Name = name;
            Street = street;
            AmountHalls = amountHalls;
            Films = films;
        }
        public override string ToString()
        {
            return $"{Street} {Name} {AmountHalls} {GetFilms()}";
        }
    }
}