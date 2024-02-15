using TestNinja.Interfaces.Fundamentals;
using TestNinja.Services.Fundamentals;
using TestNinja.Types.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals;

[TestFixture]
public class ReservationTests
{
    [SetUp]
    public void Setup()
    {
    }

    // [Test]
    // public void MethodName_Scenario_ExpectedResult()
    // {
    //     // Arrange
    //     // Act
    //     // Assert
    // }

    [Test]
    public void CanBeCancelledBy_AdminCancelling_ReturnsTrue()
    {
        // Arrange
        IReservation reservation = new Reservation();
        // Act
        var result = reservation.CanBeCancelledBy(new User() { IsAdmin = true });
        // Assert
        Assert.IsTrue(result);
        Assert.That(result, Is.True);
        // Assert.AreEqual(result, true);
        // Assert.That(result == true);
    }

    [Test]
    public void CanBeCancelledBy_NotAdminCancelling_ReturnsFalse()
    {
        // Arrange
        IReservation reservation = new Reservation();
        // Act
        var result = reservation.CanBeCancelledBy(new User() { IsAdmin = false });
        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void CanBeCancelledBy_ReservationMadeByUserCancelling_ReturnsTrue()
    {
        // Arrange
        var madeByUser = new User();
        IReservation reservation = new Reservation() { MadeBy = madeByUser };
        // Act
        var result = reservation.CanBeCancelledBy(madeByUser);
        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void CanBeCancelledBy_ReservationNotMadeByUserCancelling_ReturnsFalse()
    {
        // Arrange
        var madeByUser = new User();
        var notMadeByUser = new User();
        IReservation reservation = new Reservation() { MadeBy = madeByUser };
        // Act
        var result = reservation.CanBeCancelledBy(notMadeByUser);
        // Assert
        Assert.IsFalse(result);
    }

}