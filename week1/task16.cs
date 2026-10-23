using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task12
{
    internal class Program
    {
       
        static int add(int num1, int num2)
        {
            return num1 + num2;
        }
        
        
        static void Main(string[] args)
        {
            int num1, num2;

            Console.Write("Enter 1st number: ");
            num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter 2nd number: ");
            num2 = int.Parse(Console.ReadLine());
            int result = add(num1, num2);
            Console.WriteLine("Sum is : ", result);
            Console.Read();

        }
    }
}
