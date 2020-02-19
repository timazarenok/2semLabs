using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba20variant13
{
    class House
    {
        string street;
        int number;
        int countFloors;
        int countEnters;
        int flats;
        public string Street
        {
            get => street;
            set
            {
                if (!Char.IsUpper(value[0]))
                {
                    throw new Exception("Value not upper at the beginning");
                }
                street = value;
            }
        }
        public int Number
        {
            get => number;
            set
            {
                if(value < 0)
                {
                    throw new Exception("negative value");
                }
                number = value;
            }
        }
        public int CountFloors
        {
            get => countFloors;
            set
            {
                if (value < 0)
                {
                    throw new Exception("negative value");
                }
                countFloors = value;
            }
        }
        public int CountEntries
        {
            get => countEnters;
            set
            {
                if (value < 0)
                {
                    throw new Exception("negative value");
                }
                countEnters = value;
            }
        }
        public int Flats
        {
            get => flats;
            set
            {
                if (value < 0)
                {
                    throw new Exception("negative value");
                }
                flats = value;
            }
        }
        public House() { }
        public House(string street, int number, int floors, int entries, int flats)
        {
            Street = street;
            Number = number;
            CountFloors = floors;
            CountEntries = entries;
            Flats = flats;
        }
        public override string ToString()
        {
            return $"{Street}, {Number}, floors: {CountFloors}, entries: {CountEntries}, flats on floor: {Flats}";
        }
    }
    class Program
    {
        public static void Start(List<House> houses)
        {
            Console.WriteLine("Input number from 1-5");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    List<House> Task1 = houses.OrderBy(el => el.Street).ThenBy(el => el.Number).ToList();
                    foreach (House h in Task1)
                    {
                        Console.WriteLine(h);
                    }
                    break;
                case 2:
                    List<List<House>> Task2 = new List<List<House>>();
                    foreach (House l in houses)
                    {
                        Task2.Add(houses.Where(el => el.Street == l.Street).ToList());
                    }
                    foreach (List<House> list in Task2)
                    {
                        foreach (House l in list)
                        {
                            Console.WriteLine(l.Number);
                        }
                    }
                    break;
                case 3:
                    List<House> Task3 = houses.Where(el => el.CountEntries % 2 != 0 && el.CountFloors%2 != 0).ToList();
                    foreach(House house in Task3)
                    {
                        Console.WriteLine($"{house.Street}, {house.Number}");
                    }
                    break;
                case 4:
                    List<int> inEachHouse = houses.Select(el => el.CountEntries*(el.CountFloors*el.Flats)).ToList();
                    foreach(int i in inEachHouse)
                    {
                        Console.WriteLine(i);
                    }
                    int amountFloors = inEachHouse.Sum();
                    Console.WriteLine($"All floors in list: {amountFloors}");
                    break;
                case 5:
                    var groupStreet = houses.GroupBy(el => el.Street);
                    foreach (IGrouping<string, House> item in groupStreet)
                    {
                        Console.WriteLine(item.Key);
                        foreach (House za in item)
                        {
                            Console.WriteLine(za);
                        }
                    }
                    var groupNumber = houses.GroupBy(el => el.Number);
                    foreach (IGrouping<string, House> item in groupStreet)
                    {
                        Console.WriteLine(item.Key);
                        foreach (House za in item)
                        {
                            Console.WriteLine(za);
                        }
                    }
                    var groupFloors = houses.GroupBy(el => el.CountFloors);
                    foreach (IGrouping<int, House> item in groupFloors)
                    {
                        Console.WriteLine(item.Key);
                        foreach (House za in item)
                        {
                            Console.WriteLine(za);
                        }
                    }
                    var groupEntries = houses.GroupBy(el => el.CountEntries);
                    foreach (IGrouping<int, House> item in groupEntries)
                    {
                        Console.WriteLine(item.Key);
                        foreach (House za in item)
                        {
                            Console.WriteLine(za);
                        }
                    }
                    var groupFlats = houses.GroupBy(el => el.Flats);
                    foreach (IGrouping<int, House> item in groupFlats)
                    {
                        Console.WriteLine(item.Key);
                        foreach (House za in item)
                        {
                            Console.WriteLine(za);
                        }
                    }
                    break;
                default:
                    throw new Exception("Wrong input number");
            }
        }
        static void Main(string[] args)
        {
            List<House> houses = new List<House>()
            {
                new House("Melnikayte", 20, 8, 4, 4),
                new House("Melnikayte", 12, 8, 4, 4),
                new House("Nezaleshnosti", 187, 10, 6, 6),
                new House("Masherova", 56, 4, 2, 4),
                new House("Kolesnikova", 12, 5, 2, 12),
            };
            Start(houses);
            Console.ReadKey();
        }
    }
}
