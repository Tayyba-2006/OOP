using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airplane_management_system.Flight;

namespace Airplane_management_system.Booking
{
    // UI LAYER 
    public class BookingUI
    {
        public BookingService _bookingService;
        public FlightService _flightService;
        public FlightUI _flightUI;

        public BookingUI(BookingService bs, FlightService fs, FlightUI fu)
        {
            _bookingService = bs;
            _flightService = fs;
            _flightUI = fu;
        }

        // CUSTOMER MENU
        public void CustomerMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("========== CUSTOMER MENU ==========");
                Console.WriteLine("1 View Flights");
                Console.WriteLine("2 Search Flight");
                Console.WriteLine("3 Book Seat");
                Console.WriteLine("4 Cancel Booking");
                Console.WriteLine("5 Exit");

                Console.Write("Choose option: ");
                string opt = Console.ReadLine();

                if (opt == "1")
                    _flightUI.ViewFlights();

                else if (opt == "2")
                    SearchFlightUI();

                else if (opt == "3")
                    BookSeatUI();

                else if (opt == "4")
                    CancelBookingUI();

                else if (opt == "5")
                    break;

                else
                {
                    Console.WriteLine("Wrong option!");
                    Console.ReadKey();
                }
            }
        }

        // READ: SEARCH FLIGHT
        public void SearchFlightUI()
        {
            Console.Clear();

            Console.WriteLine("========== SEARCH FLIGHT ==========");

            Console.Write("Enter Departure: ");
            string dep = Console.ReadLine();

            Console.Write("Enter Arrival: ");
            string arr = Console.ReadLine();

            List<FlightModel> flights =
                _flightService.GetAllFlights();

            bool found = false;

            foreach (FlightModel f in flights)
            {
                if (f.Departure == dep && f.Arrival == arr)
                {
                    Console.WriteLine("\nFlight ID: " + f.FlightID);
                    Console.WriteLine("Departure: " + f.Departure);
                    Console.WriteLine("Arrival: " + f.Arrival);
                    Console.WriteLine("Date: " + f.Date);
                    Console.WriteLine("Time: " + f.Time);
                    Console.WriteLine("Total Seats: " + f.TotalSeats);
                    Console.WriteLine("Available Seats: " + f.AvailableSeats);

                    if (f.AvailableSeats == 0)
                    {
                        Console.WriteLine("Fully booked!");
                    }

                    Console.WriteLine("----------------------------");

                    found = true;
                }
            }

            if (found == false)
            {
                Console.WriteLine("No matching flight found!");
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }

        // CREATE: BOOK SEAT
        public void BookSeatUI()
        {
            Console.Clear();

            Console.WriteLine("========== BOOK SEAT ==========");

            Console.Write("Enter Flight ID: ");
            string id = Console.ReadLine();

            bool success = _bookingService.BookSeat(id);

            if (success == true)
                Console.WriteLine("Seat booked successfully!");
            else
                Console.WriteLine("Flight not found or fully booked!");

            Console.ReadKey();
        }

        // DELETE: CANCEL BOOKING
        public void CancelBookingUI()
        {
            Console.Clear();

            Console.WriteLine("========== CANCEL BOOKING ==========");

            Console.Write("Enter Flight ID: ");
            string id = Console.ReadLine();

            bool success = _bookingService.CancelBooking(id);

            if (success == true)
                Console.WriteLine("Booking cancelled successfully!");
            else
                Console.WriteLine("No booking found for this flight!");

            Console.ReadKey();
        }
    }
}
