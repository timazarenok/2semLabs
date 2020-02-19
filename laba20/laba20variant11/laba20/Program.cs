using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba20variant11
{
    class Luggage
    {
        long flightNumber;
        DateTime timeOfOut;
        string direction;
        string surname;
        int amountOfPlaces;
        double weightOfLuggage;
        public long FlightNumber
        {
            get => flightNumber;
            set
            {
                if (value < 0 || value.ToString().Length != 10)
                {
                    throw new Exception("negative or != 10");
                }
                flightNumber = value;
            }
        }
        public DateTime TimeOfOut { get; set; }
        public string Direction
        {
            get => direction;
            set
            {
                if (!Char.IsUpper(value[0]))
                {
                    throw new Exception("not is upper");
                }
                direction = value;
            }
        }
        public string Surname
        {
            get => surname;
            set
            {
                if (!Char.IsUpper(value[0]))
                {
                    throw new Exception("not is upper");
                }
                surname = value;
            }
        }
        public int AmountOfPlaces
        {
            get => amountOfPlaces;
            set
            {
                if(value < 0)
                {
                    throw new Exception("negative value");
                }
                amountOfPlaces = value;
            }
        }
        public double WeightOfLuggage
        {
            get => weightOfLuggage;
            set
            {
                if(value < 0)
                {
                    throw new Exception("negative value");
                }
                weightOfLuggage = value;
            }
        }
        public Luggage() { }
        public Luggage(long number, DateTime date, string direction, string surname, int amountOfplaces, double weight)
        {
            FlightNumber = number;
            TimeOfOut = date;
            Direction = direction;
            Surname = surname;
            AmountOfPlaces = amountOfplaces;
            WeightOfLuggage = weight;
        }
        public override string ToString()
        {
            return "Flight Number: " + FlightNumber + " Date: "+ TimeOfOut + " Direction: "+ Direction+ " Surname: " + Surname 
                + " Amount of places: " + AmountOfPlaces + " Weight of luggage: "+ WeightOfLuggage;
        }
    }

    class Program
    {
        public static void Start(List<Luggage> luggages)
        {
            Console.WriteLine("Choose number from 1-5");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    List<Luggage> Task1 = luggages.OrderBy(el => el.Surname).ThenBy(el => el.TimeOfOut).ToList();
                    foreach(Luggage item in Task1)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case 2:
                    List<List<Luggage>> Task2 = new List<List<Luggage>>();
                    foreach (Luggage l in luggages)
                    {
                        Task2.Add(luggages.Where(el => el.TimeOfOut == l.TimeOfOut).ToList());
                    }
                    foreach(List<Luggage> list in Task2)
                    {
                        foreach(Luggage l in list)
                        {
                            Console.WriteLine(l);
                        }
                    }
                    break;
                case 3:
                    List<Luggage> Task3 = luggages.Where(el => el.WeightOfLuggage > 20).ToList();
                    foreach (Luggage item in Task3)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case 4:
                    double Task4 = luggages.Sum(el => el.WeightOfLuggage);
                    Console.WriteLine(Task4);
                    break;
                case 5:
                    var groupFlight = luggages.GroupBy(el => el.FlightNumber);
                    var groupDate = luggages.GroupBy(el => el.TimeOfOut);
                    var groupDir = luggages.GroupBy(el => el.Direction);
                    var groupSur = luggages.GroupBy(el => el.Surname);
                    var groupPlaces = luggages.GroupBy(el => el.AmountOfPlaces);
                    var groupWeight = luggages.GroupBy(el => el.WeightOfLuggage);
                    foreach (IGrouping<long, Luggage> item in groupFlight)
                    {
                        Console.WriteLine(item.Key);
                        foreach (Luggage luggage in item)
                        {
                            Console.WriteLine(luggage);
                        }
                    }
                    foreach (IGrouping<DateTime, Luggage> item in groupDate)
                    {
                        Console.WriteLine(item.Key);
                        foreach (Luggage luggage in item)
                        {
                            Console.WriteLine(luggage);
                        }
                    }
                    foreach (IGrouping<string, Luggage> item in groupDir)
                    {
                        Console.WriteLine(item.Key);
                        foreach (Luggage luggage in item)
                        {
                            Console.WriteLine(luggage);
                        }
                    }
                    foreach (IGrouping<string, Luggage> item in groupSur)
                    {
                        Console.WriteLine(item.Key);
                        foreach (Luggage luggage in item)
                        {
                            Console.WriteLine(luggage);
                        }
                    }
                    foreach (IGrouping<int, Luggage> item in groupPlaces)
                    {
                        Console.WriteLine(item.Key);
                        foreach (Luggage luggage in item)
                        {
                            Console.WriteLine(luggage);
                        }
                    }
                    foreach (IGrouping<double, Luggage> item in groupWeight)
                    {
                        Console.WriteLine(item.Key);
                        foreach (Luggage luggage in item)
                        {
                            Console.WriteLine(luggage);
                        }
                    }
                    break;
                default:
                    throw new Exception("Wrong choice number");
            }
        }
        static void Main(string[] args)
        {
            List<Luggage> luggages = new List<Luggage>()
            {
                new Luggage(1234567892, new DateTime(2002, 9, 23), "Croatia", "Huraha", 3, 23.55),
                new Luggage(5678549478, new DateTime(2003, 8, 22), "Berlin", "Rubis", 2, 23.1),
                new Luggage(3456787654, new DateTime(2004, 7, 21), "Minsk", "Borshevskiy", 1, 2.5),
                new Luggage(4567898764, new DateTime(2005, 6, 20), "Samara", "Shukalovich", 2, 4.5),
                new Luggage(2323843343, new DateTime(2006, 5, 19), "Moscow", "Malofey", 5, 12.5),
                new Luggage(1234123421, new DateTime(2007, 4, 18), "Brest", "Zarenok", 4, 34.2),
                new Luggage(9786786754, new DateTime(2008, 3, 25), "Masdrid", "Vorobyov", 2, 21.2),
                new Luggage(9854483473, new DateTime(2009, 2, 26), "London", "Ezhov", 1, 22.7),
                new Luggage(1000000000, new DateTime(2010, 1, 27), "Tokyo", "Kashko", 1, 12.5),
                new Luggage(6660000000, new DateTime(2011, 11, 12), "Vladivostock", "Birulya", 1, 24.5)
            };
            Start(luggages);
            Console.ReadLine();
        }
    }
}
