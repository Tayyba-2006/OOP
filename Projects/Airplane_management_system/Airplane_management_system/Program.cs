using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airplane_management_system.Flight;
using Airplane_management_system.Booking;
using Airplane_management_system.History;

namespace Airplane_management_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // HISTORY LAYERS
            HistoryRepository historyRepo =
                new HistoryRepository();

            HistoryService historyService =
                new HistoryService(historyRepo);

            HistoryUI historyUI =
                new HistoryUI(historyService);


            // FLIGHT LAYERS
            FlightRepository flightRepo =
                new FlightRepository();

            FlightService flightService =
                new FlightService(flightRepo, historyService);

            FlightUI flightUI =
                new FlightUI(flightService, historyUI);


            // BOOKING LAYERS
            BookingRepository bookingRepo =
                new BookingRepository();

            BookingService bookingService =
                new BookingService(bookingRepo, flightService);

            BookingUI bookingUI =
                new BookingUI(bookingService, flightService, flightUI);


            // MAIN MENU
            while (true)
            {
                Console.Clear();

                Console.WriteLine("================================================");
                Console.WriteLine("           AIRPLANE MANAGEMENT SYSTEM");
                Console.WriteLine("================================================");

                Console.WriteLine("\n1 Admin");
                Console.WriteLine("2 Customer");
                Console.WriteLine("3 Exit");

                Console.Write("\nChoose option: ");

                string opt = Console.ReadLine();

                if (opt == "1")
                {
                    if (flightUI.AdminLogin() == true)
                    {
                        flightUI.AdminMenu();
                    }
                }

                else if (opt == "2")
                {
                    bookingUI.CustomerMenu();
                }

                else if (opt == "3")
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Wrong option!");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("Thanks for using Airplane Management System!");

        }
    }
}
