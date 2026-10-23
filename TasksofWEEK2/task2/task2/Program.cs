using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class Student
    {
        public string name;
        public float ecatMarks;
        public float matricMarks;

        public float fscMarks;

        public float aggregate;

        public Student()
        {

        }
        public Student(Student student)
        {
            name = student.name;
            ecatMarks = student.ecatMarks;
            matricMarks = student.matricMarks;
            fscMarks = student.fscMarks;
            aggregate = student.aggregate;
        }

        static void Main(string[] args)
        {
            Student student = new Student();
            student.name = "Tayyba";
            student.ecatMarks = 298;
            student.matricMarks = 1012;
            student.fscMarks = 995;
            Student student2 = new Student(student);
            student2.name = "Hadia";
            Console.WriteLine(student2.name);
            Console.WriteLine(student.name);

            Console.ReadKey();
        }
          
    }
}
