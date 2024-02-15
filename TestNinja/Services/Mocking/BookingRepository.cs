using TestNinja.Interfaces.Mocking;
using TestNinja.Types.Mocking;

namespace TestNinja.Services.Mocking;

public class BookingRepository : IBookingRepository
{
    public IQueryable<Booking> GetActiveBookings(int? excludeBookingId = null)
    {
        var unitOfWork = new BUnitOfWork();
        var bookings =
            unitOfWork.Query<Booking>()
                .Where(
                    b => b.Status != "Cancelled");

        if(excludeBookingId.HasValue)
            bookings =
            unitOfWork.Query<Booking>()
                .Where(b => b.Id != excludeBookingId);
        
        return bookings;
    }
}

public class BUnitOfWork
{
    public IQueryable<T> Query<T>()
    {
        return new List<T>().AsQueryable();
    }
}