using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Airplane_management_system.Booking
{
    // REPOSITORY LAYER
    public class BookingRepository
    {
        // READ: Load bookings
        public List<BookingModel> LoadBookings()
        {
            List<BookingModel> bookings =
                new List<BookingModel>();

            if (File.Exists("bookings.txt") == false)
                return bookings;

            string[] lines = File.ReadAllLines("bookings.txt");

            foreach (string line in lines)
            {
                BookingModel b = new BookingModel();

                b.FlightID = line;

                bookings.Add(b);
            }

            return bookings;
        }

        // WRITE: Save bookings
        public void SaveBookings(List<BookingModel> bookings)
        {
            List<string> lines = new List<string>();

            foreach (BookingModel b in bookings)
            {
                lines.Add(b.FlightID);
            }

            File.WriteAllLines("bookings.txt", lines);
        }
    }
}
