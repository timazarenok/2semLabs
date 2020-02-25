using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace variant12
{
    class Counter
    {
        int a;
        int b;
        public int A
        {
            get => a;
            set => a = value; 
        }
        public int B
        {
            get => b;
            set => b = value;
        }
        public Counter() { }
        public Counter(int a, int b)
        {
            A = a;
            B = b;
        }
    }
    class Program
    {
        public static void First(object obj)
        {
            Counter c = (Counter)obj;
            for(int i = c.A; i != c.B; ++i)
            {
                Console.WriteLine("f: " + Math.Sin(i));
            }
        }
        public static void Second(object obj)
        {
            Counter c = (Counter)obj;
            for (int i = c.A; i != c.B; ++i)
            {
                Console.WriteLine("s: " + (4 * Math.Pow(i, 2) - 2 * i - 22));
            }
        }
        public static void Third(object obj)
        {
            Counter c = (Counter)obj;
            for (int i = c.A; i != c.B; ++i)
            {
                Console.WriteLine("t: " + Math.Log10(Math.Pow(i, 2) / Math.Pow(i, 3)));
            }
        }
        static void Main(string[] args)
        {
            Counter count = new Counter();
            Console.WriteLine("input two value a and b");
            count.A = Convert.ToInt32(Console.ReadLine());
            count.B = Convert.ToInt32(Console.ReadLine());
            Thread t = new Thread(new ParameterizedThreadStart(First));
            t.Start(count);
            Thread t1 = new Thread(new ParameterizedThreadStart(Second));
            t1.Start(count);
            Thread t2 = new Thread(new ParameterizedThreadStart(Third));
            t2.Start(count);
            Console.ReadKey();
        }
    }
}
