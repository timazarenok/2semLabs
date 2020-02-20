using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace laba11
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
                if (value < 0)
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
                if (value < 0)
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
            return "Flight Number: " + FlightNumber + " Date: " + TimeOfOut + " Direction: " + Direction + " Surname: " + Surname
                + " Amount of places: " + AmountOfPlaces + " Weight of luggage: " + WeightOfLuggage;
        }
    }
}