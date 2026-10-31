using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class university
    {
        public string Name;
        public int Contact;
        public string Department;
        public void PersonDetails()
        {
            Console.WriteLine("Details are" + Name + " " + Contact + " " + Department);
        }
        public university(string name, int contact, string department)
        {
            Name = name;
            Contact = contact;
            Department = department;
        }
    }
    public class student : university
    {
        public student(string name, int contact, string department) : base(name, contact, department)

        {

        }

    }
    public class teacher : university
    {
        public teacher(string name, int contact, string department) : base(name, contact, department)

        {

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            student S1 = new student("Hadia", 1234, "CS");
            teacher t1 = new teacher("Tayyba", 4567, "CS");
            university u1 = new university("Hadia", 1234, "CS");
           
        }
    }
}
