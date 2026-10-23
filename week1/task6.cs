using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str;
            str = Console.ReadLine();
            Console.Write("you have inputted: ");
            Console.WriteLine(str);
            int num = int.Parse(str);
            Console.Write("The number is: ");
            Console.Write(num);
            Console.ReadKey();
        }
    }
}
