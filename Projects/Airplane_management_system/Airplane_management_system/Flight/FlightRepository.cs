using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Airplane_management_system.Flight
{
    // REPOSITORY LAYER
    public class FlightRepository
    {
        // READ OPERATION
        public List<FlightModel> LoadData()
        {
            List<FlightModel> flights = new List<FlightModel>();

            if (File.Exists("flights.txt") == false)
            {
                return flights;
            }

            string[] lines = File.ReadAllLines("flights.txt");

            for (int i = 0; i + 6 < lines.Length; i = i + 7)
            {
                FlightModel f = new FlightModel();

                f.FlightID = lines[i];
                f.Departure = lines[i + 1];
                f.Arrival = lines[i + 2];
                f.Date = lines[i + 3];
                f.Time = lines[i + 4];
                f.TotalSeats = int.Parse(lines[i + 5]);
                f.AvailableSeats = int.Parse(lines[i + 6]);

                flights.Add(f);
            }

            return flights;
        }

        // WRITE OPERATION
        public void SaveData(List<FlightModel> flights)
        {
            List<string> lines = new List<string>();

            foreach (FlightModel f in flights)
            {
                lines.Add(f.FlightID);
                lines.Add(f.Departure);
                lines.Add(f.Arrival);
                lines.Add(f.Date);
                lines.Add(f.Time);
                lines.Add(f.TotalSeats.ToString());
                lines.Add(f.AvailableSeats.ToString());
            }

            File.WriteAllLines("flights.txt", lines);
        }
    }  
}
