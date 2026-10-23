using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str;
            Console.Write("length: ");
            str = Console.ReadLine();
            float length = float.Parse(str);
            float area = length * length;
            Console.Write("the area is: ");
            Console.Write(area);
            Console.ReadKey();
        }
    }
}
