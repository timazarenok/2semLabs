using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace variant14
{
    class Program
    {
        public static void Mul()
        {
            int result = 1;
            while (result != Math.Pow(2, 10))
            {
                Console.WriteLine("mul: "+ result);
                result *= 2;
            }
            Console.WriteLine("mul: "+ result);
            Thread.Sleep(400);
        }
        public static void Sum()
        {
            int result = 0;
            while (result != Math.Pow(2, 10))
            {
                Console.WriteLine("sum: " + result);
                result += 2;
            }
            Console.WriteLine("sum: "+result);
            Thread.Sleep(400);
        }
        public static void Pow()
        {
            Console.WriteLine("pow: " + Math.Pow(2,10));
            Thread.Sleep(400);
        }
        static void Main(string[] args)
        {
            Thread mul = new Thread(new ThreadStart(Mul));
            mul.Start();
            Thread sum = new Thread(new ThreadStart(Sum));
            sum.Start();
            Thread pow = new Thread(new ThreadStart(Pow));
            pow.Start();
            Console.ReadKey();
        }
    }
}
