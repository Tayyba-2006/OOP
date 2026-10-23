using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Book
    {
        public string title;
        public string[] authors = new string[4];
        public int numberOfAuthors;
        public string publisher;
        public string isbn;
        public double price;
        public int stock;
        public int publicationYear;

        // Default Constructor 
        public Book()
        {
            title = "";
            publisher = "";
            isbn = "";
            price = 0;
            stock = 0;
            publicationYear = 0;
            numberOfAuthors = 0;
        }
        // Parametrized Constructor
        public Book(string title, string publisher, string isbn, double price, int stock, int publicationYear)
        {
            this.title = title;
            this.publisher = publisher;
            this.isbn = isbn;
            this.price = price;
            this.stock = stock;
            this.publicationYear = publicationYear;
            numberOfAuthors = 0;

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
