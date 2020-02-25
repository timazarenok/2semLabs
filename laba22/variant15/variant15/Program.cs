using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace variant15
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "task.txt";
        
            Thread threadDelete = new Thread(() => {
                string showText = "";
                while (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    showText = File.ReadAllText(path);
                    Console.WriteLine(showText);
                }
            });

            Thread threadAdd = new Thread(() => {
                string createText = Console.ReadLine();
                File.WriteAllText(path, createText);
            });
            threadAdd.Start();
            threadDelete.Start();
            Console.ReadKey();
        }
    }
}
