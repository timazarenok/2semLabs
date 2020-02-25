using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace variant18
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> list = new List<double>();
            Console.WriteLine("input two values");
            int number = Convert.ToInt32(Console.ReadLine());
            int number2 = Convert.ToInt32(Console.ReadLine());
            Thread first = new Thread(() => 
            {
                for (double i = number; i <= number2; i += 0.1)
                {
                    list.Add(23*Math.Pow(i,2)-33);
                }
            });
            first.Start();
            Thread second = new Thread(() =>
            {
                first.Join();
                foreach (double i in list)
                {
                    Console.WriteLine(i);
                }
            });
            second.Start();
            Console.ReadKey();
        }
    }
}
