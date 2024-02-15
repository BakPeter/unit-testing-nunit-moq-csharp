using TestNinja.Types.Mocking;

namespace TestNinja.Interfaces.Mocking;

public interface IBookingRepository
{
    IQueryable<Booking> GetActiveBookings(int? id);
}