using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if(value < 0)
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
                if(value < 10 && value < 0)
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
                if(grammyNominations < 0)
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
                if(value == "female" || value == "male")
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
    class Program
    {
        public static void Start(List<Artist> artists)
        {
            Console.WriteLine("Input from 1-5");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    List<Artist> Task1 = artists.OrderBy(el => el.Name).ThenBy(el => el.Department).ToList();
                    foreach (Artist art in Task1)
                    {
                        Console.WriteLine(art);
                    }
                    break;
                case 2:
                    List<Artist> Task2 = artists.Where(el => el.AlbomV.GrammyNominations >= 1).ToList();
                    foreach(Artist art in Task2)
                    {
                        Console.WriteLine(art);
                    }
                    break;
                case 3:
                    List<Artist> Task3 = artists.OrderBy(el => el.AlbomV.Songs).ThenBy(el => el.AlbomV.GrammyNominations).ToList();
                    Console.WriteLine(Task3[0]);
                    break;
                case 4:
                    List<Artist> Task4 = artists.Where(el => el.Sex == "female").ToList();
                    Console.WriteLine(Task4.OrderByDescending(el => el.AlbomV.Mark).ToList()[0]);
                    break;
                case 5:
                    var groupName = artists.GroupBy(el => el.Name);
                    foreach (IGrouping<string, Artist> item in groupName)
                    {
                        Console.WriteLine(item.Key);
                        foreach (Artist bk in item)
                        {
                            Console.WriteLine(bk);
                        }
                    }
                    var groupSex = artists.GroupBy(el => el.Sex);
                    foreach (IGrouping<string, Artist> item in groupSex)
                    {
                        Console.WriteLine(item.Key);
                        foreach (Artist bk in item)
                        {
                            Console.WriteLine(bk);
                        }
                    }
                    var groupDepartment = artists.GroupBy(el => el.Department);
                    foreach (IGrouping<string, Artist> item in groupDepartment)
                    {
                        Console.WriteLine(item.Key);
                        foreach (Artist bk in item)
                        {
                            Console.WriteLine(bk);
                        }
                    }
                    var groupWrapper = artists.GroupBy(el => el.AlbomV);
                    foreach (IGrouping<Albom, Artist> item in groupWrapper)
                    {
                        Console.WriteLine(item.Key);
                        foreach (Artist bk in item)
                        {
                            Console.WriteLine(bk);
                        }
                    }
                    break;
                default:
                    throw new Exception("wrong number");
            }
        }
        static void Main(string[] args)
        {
            List<Artist> artists = new List<Artist>()
            {
                new Artist("Pharapoh", "Hip-Hop", "male", new Albom("Phuneral", 10, 7.8, 0)),
                new Artist("Billie Eilish", "Hip-Hop", "female", new Albom("Dont smile at me", 15, 8.4, 6)),
                new Artist("ASAP ROCKY", "Hip-Hop", "male", new Albom("Testing", 14, 8.7, 0)),
                new Artist("Big Baby Tape", "Hip-Hop", "male", new Albom("Dragon Born", 12, 8.5, 0))
            };
            Start(artists);
            Console.ReadKey();
        }
    }
}
