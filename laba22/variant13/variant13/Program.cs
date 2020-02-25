using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace variant13
{
    class Program
    {
        public static void First()
        {
            Random r = new Random();
            Console.Write(r.Next(0, 9) + " ");
        }
        static void Main(string[] args)
        {
            Thread one = new Thread(First);
            one.Start();
            Thread sec = new Thread(First);
            sec.Start();
            Thread thi = new Thread(First);
            thi.Start();
            Console.ReadKey();
        }
    }
}
