using Moq;
using TestNinja.Interfaces.Mocking;
using TestNinja.Services.Mocking;
using TestNinja.Types.Mocking;

namespace TestNinja.UnitTests.Mocking;

[TestFixture]
public class BookingHelper_OverlappingBookingsExistTests
{
    private Booking _existingBooking;
    private Mock<IBookingRepository> _bookingRepository;

    [SetUp]
    public void Setup()
    {
        _existingBooking = new Booking
        {
            Id = 2,
            ArrivalDate = ArriveOn(2017, 1, 15),
            DepartureDate = DepartOn(2017, 1, 20),
            Reference = "a"
        };

        _bookingRepository = new Mock<IBookingRepository>();
        _bookingRepository
            .Setup(r => r.GetActiveBookings(1))
            .Returns(new List<Booking>
            {
                _existingBooking

            }.AsQueryable());
    }

    [Test]
    public void BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
    {
        // Arrange
        var booking = new Booking
        {
            Id = 1,
            ArrivalDate = Before(_existingBooking.ArrivalDate, days: 2),
            DepartureDate = Before(_existingBooking.ArrivalDate)
        };

        // Act
        var result = BookingHelper.OverlappingBookingsExist(booking, _bookingRepository.Object);

        // Assert
        Assert.That(result, Is.Empty);
        //Assert.That(result, Is.EqualTo(string.Empty));
    }

    [Test]
    public void BookingStartsBeforeAndFinishesInTheMiddleOfAnExistingBooking_ReturnExistingBookingsReference()
    {
        var result = BookingHelper.OverlappingBookingsExist(new Booking
        {
            Id = 1,
            ArrivalDate = Before(_existingBooking.ArrivalDate),
            DepartureDate = After(_existingBooking.ArrivalDate)
        }, _bookingRepository.Object);

        Assert.That(result, Is.EqualTo(_existingBooking.Reference));
    }

    [Test]
    public void BookingStartsBeforeAndFinishesAfterAnExistingBooking_ReturnExistingBookingsReference()
    {
        var result = BookingHelper.OverlappingBookingsExist(new Booking
        {
            Id = 1,
            ArrivalDate = Before(_existingBooking.ArrivalDate),
            DepartureDate = After(_existingBooking.DepartureDate)
        }, _bookingRepository.Object);

        Assert.That(result, Is.EqualTo(_existingBooking.Reference));
    }

    [Test]
    public void BookingStartsAndFinishesInTheMiddleOfAnExistingBooking_ReturnExistingBookingsReference()
    {
        var result = BookingHelper.OverlappingBookingsExist(new Booking
        {
            Id = 1,
            ArrivalDate = After(_existingBooking.ArrivalDate),
            DepartureDate = Before(_existingBooking.DepartureDate)
        }, _bookingRepository.Object);

        Assert.That(result, Is.EqualTo(_existingBooking.Reference));
    }

    [Test]
    public void BookingStartsInTheMiddleOfAnExistingBookingButFinishesAfter_ReturnExistingBookingsReference()
    {
        var result = BookingHelper.OverlappingBookingsExist(new Booking
        {
            Id = 1,
            ArrivalDate = After(_existingBooking.ArrivalDate),
            DepartureDate = After(_existingBooking.DepartureDate)
        }, _bookingRepository.Object);

        Assert.That(result, Is.EqualTo(_existingBooking.Reference));
    }

    [Test]
    public void BookingStartsAndFinishesAfterAnExistingBooking_ReturnEmptyString()
    {
        var result = BookingHelper.OverlappingBookingsExist(new Booking
        {
            Id = 1,
            ArrivalDate = After(_existingBooking.DepartureDate),
            DepartureDate = After(_existingBooking.DepartureDate, days: 2)
        }, _bookingRepository.Object);

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void BookingsOverlapButNewBookingIsCancelled_ReturnEmptyString()
    {
        var result = BookingHelper.OverlappingBookingsExist(new Booking
        {
            Id = 1,
            ArrivalDate = After(_existingBooking.ArrivalDate),
            DepartureDate = After(_existingBooking.DepartureDate),
            Status = "Cancelled"
        }, _bookingRepository.Object);

        Assert.That(result, Is.Empty);
    }


    private DateTime Before(DateTime dateTime, int days = 1)
    {
        return dateTime.AddDays(-days);
    }

    private DateTime After(DateTime dateTime, int days = 1)
    {
        return dateTime.AddDays(days);
    }

    private DateTime ArriveOn(int year, int month, int day)
    {
        return new DateTime(year, month, day, 14, 0, 0);
    }

    private DateTime DepartOn(int year, int month, int day)
    {
        return new DateTime(year, month, day, 10, 0, 0);
    }
}