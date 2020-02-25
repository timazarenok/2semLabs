using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace variant22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Amount workers: ");
            int amountWorkers = Convert.ToInt32(Console.ReadLine());
            int gold = 0;
            Thread workers = new Thread(() => 
            {
                while (true)
                {
                    gold += amountWorkers * 3;
                    Console.WriteLine(gold);
                    Console.WriteLine("Sleeping...");
                    Thread.Sleep(5000);
                }
            });
            workers.Start();
            Console.ReadKey();
        }
    }
}
