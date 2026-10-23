using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task7
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string str;
            Console.Write("Enter Floating Point Value: ");
            str = Console.ReadLine();
            float num = float.Parse(str);
            Console.Write("The floating value is: ");
            Console.Write(num);
            Console.ReadKey();
        }
    }
}
