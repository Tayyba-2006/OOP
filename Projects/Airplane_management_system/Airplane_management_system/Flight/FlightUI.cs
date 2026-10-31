using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airplane_management_system.History;

namespace Airplane_management_system.Flight
{ 
    // UI LAYER 
    public class FlightUI
    {
        public FlightService _flightService;
        public HistoryUI _historyUI;

        public FlightUI(FlightService fs, HistoryUI hu)
        {
            _flightService = fs;
            _historyUI = hu;
        }

        // ADMIN LOGIN
        public bool AdminLogin()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Clear();

                Console.WriteLine("ADMIN LOGIN");
                Console.Write("Enter username: ");
                string username = Console.ReadLine();

                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                if (username == "Admin" && password == "456")
                {
                    Console.WriteLine("Login successful!");
                    Console.ReadKey();
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid username or password!");
                    Console.ReadKey();
                }
            }

            return false;
        }

        // ADMIN MENU
        public void AdminMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("========== ADMIN MENU ==========");
                Console.WriteLine("1 Add Flight");
                Console.WriteLine("2 View Flights");
                Console.WriteLine("3 Update Flight");
                Console.WriteLine("4 Delete Flight");
                Console.WriteLine("5 Sort Flights");
                Console.WriteLine("6 History");
                Console.WriteLine("7 Logout");

                Console.Write("Choose option: ");
                string opt = Console.ReadLine();

                if (opt == "1")
                    AddFlightUI();

                else if (opt == "2")
                    ViewFlights();

                else if (opt == "3")
                    UpdateFlightUI();

                else if (opt == "4")
                    DeleteFlightUI();

                else if (opt == "5")
                {
                    _flightService.SortFlights();

                    Console.WriteLine("Flights sorted!");
                    Console.ReadKey();
                }

                else if (opt == "6")
                    _historyUI.ShowHistory();

                else if (opt == "7")
                    break;

                else
                {
                    Console.WriteLine("Wrong option!");
                    Console.ReadKey();
                }
            }
        }

        // READ: VIEW FLIGHTS
        public void ViewFlights()
        {
            Console.Clear();

            Console.WriteLine("========== ALL FLIGHTS ==========");

            List<FlightModel> flights =
                _flightService.GetAllFlights();

            if (flights.Count == 0)
            {
                Console.WriteLine("No flights available!");
            }
            else
            {
                foreach (FlightModel f in flights)
                {
                    Console.WriteLine("\nFlight ID: " + f.FlightID);
                    Console.WriteLine("Departure: " + f.Departure);
                    Console.WriteLine("Arrival: " + f.Arrival);
                    Console.WriteLine("Date: " + f.Date);
                    Console.WriteLine("Time: " + f.Time);
                    Console.WriteLine("Total Seats: " + f.TotalSeats);
                    Console.WriteLine("Available Seats: " + f.AvailableSeats);

                    Console.WriteLine("----------------------------");
                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        // CREATE: ADD FLIGHT
        public void AddFlightUI()
        {
            Console.Clear();

            Console.WriteLine("========== ADD FLIGHT ==========");

            FlightModel f = new FlightModel();

            Console.Write("Enter Flight ID: ");
            f.FlightID = Console.ReadLine();

            if (_flightService.GetFlightById(f.FlightID) != null)
            {
                Console.WriteLine("Flight ID already exists!");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter Departure: ");
            f.Departure = Console.ReadLine();

            Console.Write("Enter Arrival: ");
            f.Arrival = Console.ReadLine();

            Console.Write("Enter Date: ");
            f.Date = Console.ReadLine();

            Console.Write("Enter Time: ");
            f.Time = Console.ReadLine();

            Console.Write("Enter Total Seats: ");
            f.TotalSeats = int.Parse(Console.ReadLine());

            f.AvailableSeats = f.TotalSeats;

            bool success = _flightService.AddFlight(f);

            if (success == true)
                Console.WriteLine("Flight added successfully!");
            else
                Console.WriteLine("Flight could not be added!");

            Console.ReadKey();
        }

        // UPDATE: UPDATE FLIGHT
        public void UpdateFlightUI()
        {
            Console.Clear();

            Console.WriteLine("========== UPDATE FLIGHT ==========");

            Console.Write("Enter Flight ID: ");
            string id = Console.ReadLine();

            FlightModel oldFlight =
                _flightService.GetFlightById(id);

            if (oldFlight == null)
            {
                Console.WriteLine("Flight not found!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nEnter new details:");

            FlightModel newFlight = new FlightModel();

            Console.Write("New Flight ID: ");
            newFlight.FlightID = Console.ReadLine();

            Console.Write("New Departure: ");
            newFlight.Departure = Console.ReadLine();

            Console.Write("New Arrival: ");
            newFlight.Arrival = Console.ReadLine();

            Console.Write("New Date: ");
            newFlight.Date = Console.ReadLine();

            Console.Write("New Time: ");
            newFlight.Time = Console.ReadLine();

            Console.Write("New Total Seats: ");
            newFlight.TotalSeats = int.Parse(Console.ReadLine());

            Console.WriteLine("\n---------- OLD RECORD ----------");

            Console.WriteLine("Flight ID: " + oldFlight.FlightID);
            Console.WriteLine("Departure: " + oldFlight.Departure);
            Console.WriteLine("Arrival: " + oldFlight.Arrival);
            Console.WriteLine("Date: " + oldFlight.Date);
            Console.WriteLine("Time: " + oldFlight.Time);
            Console.WriteLine("Seats: " + oldFlight.TotalSeats);

            Console.WriteLine("\n---------- NEW RECORD ----------");

            Console.WriteLine("Flight ID: " + newFlight.FlightID);
            Console.WriteLine("Departure: " + newFlight.Departure);
            Console.WriteLine("Arrival: " + newFlight.Arrival);
            Console.WriteLine("Date: " + newFlight.Date);
            Console.WriteLine("Time: " + newFlight.Time);
            Console.WriteLine("Seats: " + newFlight.TotalSeats);

            bool success = _flightService.UpdateFlight(id, newFlight);

            if (success == true)
                Console.WriteLine("\nUpdated successfully!");
            else
                Console.WriteLine("\nUpdate failed! Check duplicate ID or seat count.");

            Console.ReadKey();
        }

        // DELETE: DELETE FLIGHT
        public void DeleteFlightUI()
        {
            Console.Clear();

            Console.WriteLine("========== DELETE FLIGHT ==========");

            Console.Write("Enter Flight ID: ");
            string id = Console.ReadLine();

            FlightModel f = _flightService.GetFlightById(id);

            if (f == null)
            {
                Console.WriteLine("Flight not found!");
            }
            else
            {
                Console.WriteLine("\nFlight ID: " + f.FlightID);
                Console.WriteLine("Departure: " + f.Departure);
                Console.WriteLine("Arrival: " + f.Arrival);

                bool success = _flightService.DeleteFlight(id);

                if (success == true)
                    Console.WriteLine("\nFlight deleted successfully!");
            }

            Console.ReadKey();
        }

    }
}
