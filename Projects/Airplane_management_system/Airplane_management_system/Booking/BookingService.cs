using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airplane_management_system.Flight;

namespace Airplane_management_system.Booking
{
    // SERVICE LAYER
    public class BookingService
    {
        public BookingRepository _bookingRepo;
        public FlightService _flightService;

        public BookingService(BookingRepository br, FlightService fs)
        {
            _bookingRepo = br;
            _flightService = fs;
        }

        // CREATE: BOOK SEAT
        public bool BookSeat(string flightId)
        {
            FlightModel flight =
                _flightService.GetFlightById(flightId);

            if (flight == null)
                return false;

            if (flight.AvailableSeats <= 0)
                return false;

            List<BookingModel> bookings =
                _bookingRepo.LoadBookings();

            BookingModel b = new BookingModel();

            b.FlightID = flightId;

            bookings.Add(b);

            _bookingRepo.SaveBookings(bookings);

            _flightService.UpdateAvailableSeats(flightId, -1);

            return true;
        }

        // DELETE: CANCEL BOOKING
        public bool CancelBooking(string flightId)
        {
            List<BookingModel> bookings =
                _bookingRepo.LoadBookings();

            for (int i = 0; i < bookings.Count; i++)
            {
                if (bookings[i].FlightID == flightId)
                {
                    FlightModel flight =
                        _flightService.GetFlightById(flightId);

                    if (flight == null)
                        return false;

                    bookings.RemoveAt(i);

                    _bookingRepo.SaveBookings(bookings);

                    _flightService.UpdateAvailableSeats(flightId, +1);

                    return true;
                }
            }

            return false;
        }
    }
}
