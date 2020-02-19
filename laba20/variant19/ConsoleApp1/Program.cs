using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if(value < 0)
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
    class Program
    {
        public static void Print(List<Cinema> cinemas)
        {
            foreach(Cinema c in cinemas)
            {
                Console.WriteLine(c);
            }
        }
        public static int Task4(List<Cinema> cinemas)
        {
            List<List<Cinema>> Task4 = new List<List<Cinema>>();
            foreach (Cinema c in cinemas)
            {
                Task4.Add(cinemas.Where(el => el.Street.Contains(c.Street)).ToList());
            }
            int result = 0;
            foreach(List<Cinema> cins in Task4)
            {
                foreach(Cinema c in cins)
                {
                    result += c.AmountHalls;
                }
            }
            return result;
        }
        public static void Task3(List<Cinema> cinemas)
        {
            List<Cinema> Task3 = cinemas.Where(el => el.Films.Where(item => item.Language.Contains("Russian")).ToList().Count == 0).ToList();
            foreach (Cinema t in Task3)
            {
                Console.WriteLine(t.Name + " " + t.Street);
            }
        }
        public static void Task2(List<Cinema> cinemas)
        {
            List<Cinema> Task2 = cinemas.Where(el => el.Films.Where(item => item.Genre.Contains("Comedy")).ToList().Count > 0).ToList();
            Print(Task2);
            foreach (Cinema f in Task2)
            {
                Console.WriteLine(f.GetFilms());
            }
        }
        public static void Task5(List<Cinema> cinemas)
        {
            var groupName = cinemas.GroupBy(el => el.Name);
            foreach (var group in groupName)
            {
                foreach (var el in group)
                {
                    Console.WriteLine(el);
                }
            }
            var groupStreet = cinemas.GroupBy(el => el.Street);
            foreach (var group in groupStreet)
            {
                foreach (var el in group)
                {
                    Console.WriteLine(el);
                }
            }
            var groupFilms = cinemas.GroupBy(el => el.Films);
            foreach (var group in groupFilms)
            {
                foreach (var el in group)
                {
                    Console.WriteLine(el.GetFilms());
                }
            }
            var groupAmountHalls = cinemas.GroupBy(el => el.AmountHalls);
            foreach (var group in groupAmountHalls)
            {
                foreach (var el in group)
                {
                    Console.WriteLine(el);
                }
            }
        }
        public static void Start(List<Cinema> cinemas)
        {
            Console.WriteLine("Input number from 1-5");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    List<Cinema> Task1 = cinemas.OrderBy(el => el.Name).ThenBy(el => el.AmountHalls).ToList();
                    Print(Task1);
                    break;
                case 2:
                    Task2(cinemas);
                    break;
                case 3:
                    Task3(cinemas);
                    break;
                case 4:
                    Console.WriteLine(Task4(cinemas));
                    break;
                case 5:
                    Task5(cinemas);
                    break;
                default:
                    throw new Exception("Wrong value");
            }
        }
        static void Main(string[] args)
        {
            List<Film> films = new List<Film>()
            {
                new Film("Tima", "Comedy", 40, "Russian"),
                new Film("Ice2", "Love story", 50, "Russian"),
                new Film("Gentlmens", "Comedy", 40, "English"),
                new Film("Sex Education", "Love story", 40, "Russian"),
                new Film("Supernatural", "Fantasy", 60, "English"),
                new Film("Good doctor", "Love story/Comedy", 40, "Russian")
            };
            List<Cinema> cinemas = new List<Cinema>()
            {
                new Cinema("Moscow", "Gde-to", 1, films),
                new Cinema("Mir", "Plosha pobedi", 1, films),
                new Cinema("Belarus", "Frunzenskaya", 5, films),
                new Cinema("Kiyv", "Kuda-to", 4, films),
                new Cinema("Pioner", "Akademia nauk", 1, films),
                new Cinema("Silver screen", "Dana mall", 5, films),
                new Cinema("Oktyabr", "Centre", 3, films)
            };
            Start(cinemas);
            Start(cinemas);
            Start(cinemas);
            Start(cinemas);
            Start(cinemas);
        }
    }
}
