using TestNinja.Types.Fundamentals;

namespace TestNinja.Interfaces.Fundamentals;

public interface IReservation
{
    public User MadeBy { get; set; }
    public bool CanBeCancelledBy(User user);
}