using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    class Program
    {
        public static void Print<T>(ICollection<T> list)
        {
            foreach (T el in list)
            {
                Console.WriteLine(el);
            }
        }
        public static void Task2(List<Game> games)
        {
            int count = 0;
            foreach(Game g in games)
            {
                foreach(Game game in games)
                {
                    if(g.Developer == game.Developer)
                    {
                        ++count;
                    }
                }
                if (count > 2)
                {
                    Console.WriteLine(g.Developer);
                }
                count = 0;
            }
        }
        public static void Task5(List<Game> games)
        {
            var groupName = games.GroupBy(el => el.Name);
            foreach(var group in groupName)
            {
                Console.WriteLine(group.Key);
                foreach (Game g in group)
                {
                    Console.WriteLine(g);
                }
            }
            var groupGenre = games.GroupBy(el => el.Genre);
            foreach (var group in groupGenre)
            {
                Console.WriteLine(group.Key);
                foreach (Game g in group)
                {
                    Console.WriteLine(g);
                }
            }
            var groupPlatform = games.GroupBy(el => el.Platform);
            foreach (var group in groupPlatform)
            {
                Console.WriteLine(group.Key);
                foreach (Game g in group)
                {
                    Console.WriteLine(g);
                }
            }
            var groupDeveloper = games.GroupBy(el => el.Developer);
            foreach (var group in groupDeveloper)
            {
                Console.WriteLine(group.Key);
                foreach (Game g in group)
                {
                    Console.WriteLine(g);
                }
            }
            var groupMark = games.GroupBy(el => el.Mark);
            foreach (var group in groupMark)
            {
                Console.WriteLine(group.Key);
                foreach (Game g in group)
                {
                    Console.WriteLine(g);
                }
            }
            var groupDate = games.GroupBy(el => el.Date);
            foreach (var group in groupDate)
            {
                Console.WriteLine(group.Key);
                foreach (Game g in group)
                {
                    Console.WriteLine(g);
                }
            }
        }
        public static void Start(List<Game> games)
        {
            Console.WriteLine("Inpur value from 1-5");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    List<Game> Task1 = games.OrderBy(el => el.Platform).ThenBy(el => el.Name).ToList();
                    Print(Task1);
                    break;
                case 2:
                    Task2(games);
                    break;
                case 3:
                    List<Game> Task3 = games.Where(el => el.Genre.Contains("RPG")).OrderByDescending(el => el.Date).ToList();
                    if(Task3.Count < 0)
                        Console.WriteLine("empty result");
                    else
                        Console.WriteLine(Task3[0]);
                    break;
                case 4:
                    var Task4 = games.GroupBy(el => el.Platform).ToList();
                    foreach(var group in Task4)
                    {
                        Console.WriteLine(group.Key);
                        Console.WriteLine(group.Max(el => el.Mark));
                    }
                    break;
                case 5:
                    Task5(games);
                    break;
                default:
                    throw new Exception("wrong value");
            }
        }
        static void Main(string[] args)
        {
            List<Game> games = new List<Game>()
            {
                new Game("Fifa14", "EA", "Sport", new DateTime(2013, 12, 4), "PSC", 8.5),
                new Game("Fifa20", "EA", "Sport", new DateTime(2020, 11, 4), "PSC", 8.9),
                new Game("NHL", "EA", "Sport", new DateTime(2020, 1, 4), "PSC", 7.3),
                new Game("Tennis", "Tennissprot", "Sport", new DateTime(2020, 3, 4), "PSC", 9.5),
                new Game("NBA", "EA", "Sport", new DateTime(2020, 5, 4), "PSC", 10)
            };
            Start(games);
            Console.ReadKey();
        }
    }
}
