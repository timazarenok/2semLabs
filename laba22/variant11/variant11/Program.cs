using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace variant11
{
    class Program
    {
        public static void First()
        {
            while (true)
            {
                Console.Write("fir ");
                Thread.Sleep(500);
            }
        }
        public static void Second()
        {
            while (true)
            {
                Console.Write("sec ");
                Thread.Sleep(500);
            }
        }
        public static void Third()
        {
            while (true)
            {
                Console.Write("thi ");
                Thread.Sleep(500);
            }
        }
        static void Main(string[] args)
        {
            Thread f = new Thread(First);
            Thread s = new Thread(Second);
            Thread t = new Thread(Third);
            f.Start();
            s.Start();
            t.Start();
            while (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                f.Abort();
                s.Abort();
                t.Abort();
            }
            Console.ReadKey();
        }
    }
}
