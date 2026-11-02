using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airplane_management_system.History;

namespace Airplane_management_system.Flight
{
    // SERVICE LAYER 
    public class FlightService
    {
        public FlightRepository _flightRepo;
        public HistoryService _historyService;

        public FlightService(FlightRepository fr, HistoryService hs)
        {
            _flightRepo = fr;
            _historyService = hs;
        }

        // READ: Get all FLIGHTS
        public List<FlightModel> GetAllFlights()
        {
            return _flightRepo.LoadData();
        }

        // READ: Find flight by ID
        public FlightModel GetFlightById(string id)
        {
            List<FlightModel> flights = GetAllFlights();

            foreach (FlightModel f in flights)
            {
                if (f.FlightID == id)
                {
                    return f;
                }
            }

            return null;
        }

        // CREATE: Add flight
        public bool AddFlight(FlightModel flight)
        {
            List<FlightModel> flights = GetAllFlights();

            foreach (FlightModel f in flights)
            {
                if (f.FlightID == flight.FlightID)
                {
                    return false;
                }
            }

            flights.Add(flight);

            _flightRepo.SaveData(flights);

            _historyService.LogAction(
                "Flight " + flight.FlightID + " Added");

            return true;
        }

        // UPDATE: Update flight
        public bool UpdateFlight(string oldId, FlightModel newFlight)
        {
            List<FlightModel> flights = GetAllFlights();

            foreach (FlightModel f in flights)
            {
                if (f.FlightID == oldId)
                {
                    // Check duplicate ID
                    foreach (FlightModel other in flights)
                    {
                        if (other.FlightID == newFlight.FlightID &&
                            other.FlightID != oldId)
                        {
                            return false;
                        }
                    }

                    int bookedSeats = f.TotalSeats - f.AvailableSeats;

                    if (newFlight.TotalSeats < bookedSeats)
                    {
                        return false;
                    }

                    f.FlightID = newFlight.FlightID;
                    f.Departure = newFlight.Departure;
                    f.Arrival = newFlight.Arrival;
                    f.Date = newFlight.Date;
                    f.Time = newFlight.Time;
                    f.TotalSeats = newFlight.TotalSeats;

                    f.AvailableSeats =
                        newFlight.TotalSeats - bookedSeats;

                    _flightRepo.SaveData(flights);

                    _historyService.LogAction(
                        "Flight " + oldId + " Updated");

                    return true;
                }
            }

            return false;
        }

        // DELETE: Delete flight
        public bool DeleteFlight(string id)
        {
            List<FlightModel> flights = GetAllFlights();

            for (int i = 0; i < flights.Count; i++)
            {
                if (flights[i].FlightID == id)
                {
                    flights.RemoveAt(i);

                    _flightRepo.SaveData(flights);

                    _historyService.LogAction(
                        "Flight " + id + " Deleted");

                    return true;
                }
            }

            return false;
        }

        // SORT: Bubble sort by Flight ID
        public void SortFlights()
        {
            List<FlightModel> flights = GetAllFlights();

            for (int i = 0; i < flights.Count - 1; i++)
            {
                for (int j = 0; j < flights.Count - i - 1; j++)
                {
                    if (string.Compare(
                        flights[j].FlightID,
                        flights[j + 1].FlightID) > 0)
                    {
                        FlightModel temp = flights[j];

                        flights[j] = flights[j + 1];
                        flights[j + 1] = temp;
                    }
                }
            }

            _flightRepo.SaveData(flights);

            _historyService.LogAction(
                "Flights sorted by ID");
        }

        // UPDATE: Change available seats
        public bool UpdateAvailableSeats(string flightId, int change)
        {
            List<FlightModel> flights = GetAllFlights();

            foreach (FlightModel f in flights)
            {
                if (f.FlightID == flightId)
                {
                    if (f.AvailableSeats + change < 0 ||
                        f.AvailableSeats + change > f.TotalSeats)
                    {
                        return false;
                    }

                    f.AvailableSeats = f.AvailableSeats + change;

                    _flightRepo.SaveData(flights);

                    return true;
                }
            }

            return false;
        }

    }
}
