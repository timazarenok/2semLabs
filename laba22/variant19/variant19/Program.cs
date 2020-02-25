using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace variant19
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread first = new Thread(() => 
            {
                double pi = 0;
                int count = 0;
                for (int i = 1; i != 101; i += 2)
                {
                    if(count % 2 == 0)
                    {
                        pi -= (double)4 / i;
                    }
                    else
                    {
                        pi += (double)4 / i;
                    }
                    count++;
                    Console.WriteLine(pi);
                }
            });
            first.Start();
            Console.ReadKey();
        }
    }
}
