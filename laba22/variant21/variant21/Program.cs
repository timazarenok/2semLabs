using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace variant21
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 223, 42, 34, 53, 536, 653, 345, 34, 534, 5346, 6534, 5462, 3245 };
            Thread first = new Thread(() =>
            {
                int temp = 0;
                for (int i = 0; i != list.Count; ++i)
                {
                    for (int j = 0; j != list.Count; ++j)
                    {
                        if (list[i] < list[j])
                        {
                            Console.WriteLine("first: {0}, {1}", list[i], list[j]);
                            temp = list[i];
                            list[i] = list[j];
                            list[i] = temp;
                        }
                    }
                }
            });
            Thread second = new Thread(() =>
            {
                int temp = 0;
                for (int i = 0; i != list.Count; ++i)
                {
                    for (int j = 0; j != list.Count; ++j)
                    {
                        if (list[i] > list[j])
                        {
                            Console.WriteLine("second: {0}, {1}", list[i], list[j]);
                            temp = list[i];
                            list[i] = list[j];
                            list[i] = temp;
                        }
                    }
                }
            });
            first.Start();
            second.Start();
            Console.ReadKey();
        }
    }
}
