using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\OOP\\Lab\\tasks\\textfile.txt";
            StreamWriter filevariable = new StreamWriter(path, true);
            filevariable.WriteLine("hello");
            filevariable.Flush();
            filevariable.Close();
        }
    }
}
