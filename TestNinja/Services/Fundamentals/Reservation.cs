using TestNinja.Interfaces.Fundamentals;
using TestNinja.Types.Fundamentals;

namespace TestNinja.Services.Fundamentals;

public class Reservation : IReservation
{
    public User MadeBy { get; set; }
    public bool CanBeCancelledBy(User user)
    {
        return MadeBy == user || user.IsAdmin;
    }
}