using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace variant13
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
                if (value < 0)
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
}