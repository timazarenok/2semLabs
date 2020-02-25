using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace variant16
{
    class Program
    {
        public delegate bool UO(int value);

        public static int[] Fibonachi()
        {
            int[] result = new int[20];
            result[0] = 0;
            result[1] = 1;
            for(int i = 2; i != 20; ++i)
            {
                result[i] = result[i - 1] + result[i - 2];
            }
            return result;
        }
        public static bool IsFibonachi(int value)
        {
            int[] fibonachi = Fibonachi();
            for(int i = 0; i != 20; ++i)
            {
                if(value == fibonachi[i])
                {
                    return true;
                }
            }
            return false;
        } 
        public static bool IsSimple(int value)
        {
            if(value == 0 || value == 1)
            {
                return true;
            }
            for(int i = 2; i != Math.Sqrt(value); ++i)
            {
                if(value % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static void Add(string path, string[] text, UO op)
        {
            using(StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i != text.Length; ++i)
                {
                    if (op(Convert.ToInt32(text[i])))
                        sw.Write(text[i]);
                }
            }
        }
        static void Main(string[] args)
        {
            string createText = "34 54 3244 234 432 432 234 235 983 589 43 627 23 46 34 1 2 3 4 5 6 7 8 9";
            Thread threadAdd = new Thread((path) => {
                File.WriteAllText((string)path, createText);
            });
            string pathI = "task.txt";
            Thread threadFibonachi = new Thread((path) => {
               string[] text;
               using(StreamReader sr = new StreamReader((string)path))
               {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        text = line.Split(' ');
                        Add("fibonachi.txt", text, IsFibonachi);
                    }
               }
                int result = 0;
                using (StreamReader sr = new StreamReader("fibonachi.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        result += line.Length;
                    }
                    Console.WriteLine("fibonachi: " + result);
                }
            });
            Thread threadSimple = new Thread((path) => {
                string[] text;
                using (StreamReader sr = new StreamReader((string)path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        text = line.Split(' ');
                        Add("simple.txt", text, IsSimple);
                    }
                }
                int result = 0;
                using(StreamReader sr = new StreamReader("simple.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        result += line.Split(' ').Length;
                    }
                    Console.WriteLine("simple: "+result);
                }
            });
            threadFibonachi.Start(pathI);
            threadSimple.Start(pathI);
            Console.ReadKey();
        }
    }
}
