using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace variant20
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 23, 543, 4123, 214, 45, 3451, 234, 1324, 134, 4, 45, 43, 435, 43, 98};
            List<int> list2 = new List<int>() { 1, 23, 543, 4123, 214, 45, 3451, 234, 1324, 134, 4, 45, 43, 435, 43, 98 };
            Thread first = new Thread(() => 
            {
                int temp = 0;
                for(int i = 0; i != list.Count; ++i)
                {
                    for(int j = 0; j != list.Count; ++j)
                    {
                        if(list[i] < list[j])
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
                for (int i = 0; i != list2.Count; ++i)
                {
                    for (int j = 0; j != list2.Count; ++j)
                    {
                        if (list2[i] > list2[j])
                        {
                            Console.WriteLine("second: {0}, {1}", list[i], list[j]);
                            temp = list2[i];
                            list2[i] = list2[j];
                            list2[i] = temp;
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
