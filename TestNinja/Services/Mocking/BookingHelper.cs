using TestNinja.Interfaces.Mocking;
using TestNinja.Types.Mocking;

namespace TestNinja.Services.Mocking;

public static class BookingHelper
{
    public static string OverlappingBookingsExist(Booking booking, IBookingRepository bookingRepository)
    {
        if (booking.Status == "Cancelled")
            return string.Empty;

        var bookings = bookingRepository.GetActiveBookings(booking.Id);

        var overlappingBooking =
            bookings.FirstOrDefault(
                b =>
                    booking.ArrivalDate < b.DepartureDate
                    && b.ArrivalDate < booking.DepartureDate);
        return overlappingBooking == null ? string.Empty : overlappingBooking.Reference;
    }
}