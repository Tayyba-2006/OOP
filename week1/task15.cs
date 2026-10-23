using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\OOP\\Lab\\tasks\\textfile.txt";
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    Console.WriteLine(record);
                }
                fileVariable.Close();
            }
            else 
            {
                Console.WriteLine("Not Exists");
            }
        }
    }
}
