# unit-testing-nunit-moq-csharp

## Table of content

- [Udemy course](#udemy-course)
- [Code Tamplates](#code-templates)
  - [General](#general)
  - [String tests](#string-tests)
  - [Array tests](#array-tests)
  - [Return type tests](#return-type-tests)
  - [Return Void tests](#return-type-tests)
  - [Exeption tests](#exeption-tests)
  - [Event tests](#event-tests)
  - [Create mocked object](#create-mocked-object)
  - [Interaction between objects Verify](#interaction-between-objects-verify)
  - [Moked object method value returned](#moked-object-method-value-returned)
  - [Moked object method generic args](#moked-object-method-generic-args)
  - [Test with helper methods](#test-with-helper-methods)
- [Comments](#comments)

## Udemy coure

**[`^ top ^`](#unit-testing-nunit-moq-csharp)** | **[`^ Table of content ^`](#table-of-content)**

https://www.udemy.com/course/unit-testing-csharp/

## Code Templates

**[`^ top ^`](#unit-testing-nunit-moq-csharp)** | **[`^ Table of content ^`](#table-of-content)**

### general

```
// public class TestsClassNameTests
// {
//     [SetUp]
//     public void Setup() { }
//
//     [TearDown]
//     public void Teardown() { }
//
//     [Test]
//     public void MethodName_Scenario_ExpectedBehaviour()
//     {
//         // Arrange
//         // Act
//         // Assert
//     }
// }
```

```
[Test]
[TestCase(2,1,2)]
[TestCase(1,2,2)]
[TestCase(1,1,1)]
public void Max_WhenCalled_ReturnsTheGraterArgument(int arg1, int arg2, int expectedResult)
{
    // Arrange
    // Act
    var result = _math.Max(arg1, arg2);

    // Assert
    Assert.That(result, Is.EqualTo(expectedResult));
}
```

```
[Test]
[Test]
[Ignore("Reason for Ignoring the test")]
public void MethodName_Scenario_ExpectedBehaviour()
{
    // Arrange
    // Act
    // Assert
}
```

### string-tests

**[`^ top ^`](#unit-testing-nunit-moq-csharp)** | **[`^ Table of content ^`](#table-of-content)**

```
[Test]
public void FormatAsBold_WhenCalled_ReturnsTheArgumentStringEnclosedWithStrongElement()
{
    // Arrange
    // Act
    var result = _htmlFormatter.FormatAsBold("abc");

    // Assert

    // Specific
    Assert.That(result, Is.EqualTo("<strong>abc</strong>").IgnoreCase);

    // General
    Assert.That(result, Does.StartWith("<strong>").IgnoreCase);
    Assert.That(result, Does.EndWith("</strong>").IgnoreCase);
    Assert.That(result, Does.Contain("abc").IgnoreCase);
}
```

```
 [Test]
public void OverlappingBookingsExist_BookingCancelled_ReturnsEmptyString()
{
    // Arrange
    var booking = new Booking { Status = "Cancelled" };

    // Act
    var result = BookingHelper.OverlappingBookingsExist(booking);

    // Assert
    Assert.That(result, Is.Empty);
    //Assert.That(result, Is.EqualTo(string.Empty));
}
```

### Array tests

**[`^ top ^`](#unit-testing-nunit-moq-csharp)** | **[`^ Table of content ^`](#table-of-content)**

```
[Test]
[TestCase(1, new[] { 1 })]
[TestCase(2, new[] { 1 })]
[TestCase(5, new[] { 1, 3, 5 })]
public void GetOddNumbers_LimitIsGraterTheZero_ReturnsOddNumberUpToLimit(int limit, int[] expectedArr)
{
    // Arrange
    // Act
    var result = _math.GetOddNumbers(limit);
    // Assert
    Assert.That(result, Is.Not.Empty);

    Assert.That(result.Length, Is.EqualTo(expectedArr.Length));

    foreach (var n in expectedArr)
    {
        Assert.That(result, Does.Contain(n));
    }

    Assert.That(result, Is.EquivalentTo(expectedArr));

    Assert.That(result, Is.Ordered);
    Assert.That(result, Is.Unique);
}
```

### Return type tests

**[`^ top ^`](#unit-testing-nunit-moq-csharp)** | **[`^ Table of content ^`](#table-of-content)**

```
[Test]
public void GetCustomer_ArgIdIsZero_ReturnNotFound()
{
    //Arrange
    const int id = 0;

    //Act
    var result = _customerController.GetCustomer(id);

    // Assert

    //NotFound
    Assert.That(result, Is.TypeOf<NotFound>());

    //NotFound or one of it's derivatives
    // Assert.That(result, Is.InstanceOf<NotFound>());
}
```

### Return Void tests

**[`^ top ^`](#unit-testing-nunit-moq-csharp)** | **[`^ Table of content ^`](#table-of-content)**

Test changes on ivoked/efected entities/objects states, or events accurance.

```
[Test]
public void Log_WhenCalled_SetTheLastErrorProperty()
{
    //Arrange
    const string error = "errorA";

    //Act
    _errorLogger.Log(error);

    //Assert
    Assert.That(_errorLogger.LastError, Is.EquivalentTo(error));
}
```

### Exeption tests

**[`^ top ^`](#unit-testing-nunit-moq-csharp)** | **[`^ Table of content ^`](#table-of-content)**

```
[Test]
    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    public void Log_InvalidError_ThrowArgumentNullException(string? error)
    {
        //Arrange
        //Act
        //Assert
        //Assert.That(() => _errorLogger.Log(error), Throws.ArgumentNullException);
        Assert.That(() => _errorLogger.Log(error), Throws.Exception.TypeOf<ArgumentNullException>());

    }
```

### Event tests

**[`^ top ^`](#unit-testing-nunit-moq-csharp)** | **[`^ Table of content ^`](#table-of-content)**

```
[Test]
public void DoSomething_RaisesEvent()
{
    // Arrange
    var eventPublisher = new EventPublisher();
    bool eventRaised = false;
    eventPublisher.SomethingHappened += (sender, args) => eventRaised = true;

    // Act
    eventPublisher.DoSomething();

    // Assert
    Assert.IsTrue(eventRaised);
}
```

### Create mocked object

**[`^ top ^`](#unit-testing-nunit-moq-csharp)** | **[`^ Table of content ^`](#table-of-content)**

```
[TestFixture]
public class OrderServiceTests
{
    private Mock<IStorage> _storageMock;
    private IOrderService _service;

    [SetUp]
    public void Setup()
    {
        _storageMock = new Mock<IStorage>();
        _service = new OrderService(_storageMock.Object);
    }
}
```

### Interaction between objects Verify

**[`^ top ^`](#unit-testing-nunit-moq-csharp)** | **[`^ Table of content ^`](#table-of-content)**

```
[Test]
public void PlaceOrder_WhenCalled_PlaceOrder()
{
    // Arrange
    var order = new Order();

    // Act
    _service.PlaceOrder(order);

    // Assert
    _storageMock.Verify(storage=>storage.Store(order));
}
```

### Moked object method value returned

**[`^ top ^`](#unit-testing-nunit-moq-csharp)** | **[`^ Table of content ^`](#table-of-content)**

```
[Test]
public void PlaceOrder_WhenCalled_ReturnTheOrderId()
{
    // Arrange
    var id = 1;
    var order = new Order(id);
    _storageMock
        .Setup(storage => storage.Store(order))
        .Returns(id);

    // Act
    var result = _service.PlaceOrder(order);

    // Assert
    Assert.That(result, Is.EqualTo(id));
}
```

### Moked object method generic args

**[`^ top ^`](#unit-testing-nunit-moq-csharp)** | **[`^ Table of content ^`](#table-of-content)**

```
 [Test]
public void DownloadFile_DownloadFailure_ReturnFalse()
{
    // Arrange
    _fileDownLoaderMock
        .Setup(fileDownLoader =>
            fileDownLoader.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
        .Throws<WebException>();

    // Act
    var result = _installerHalper.DownloadInstaller("", "");

    // Assert
    Assert.That(result, Is.False);
}
```

### Test with helper methods

**[`^ top ^`](#unit-testing-nunit-moq-csharp)** | **[`^ Table of content ^`](#table-of-content)**

```
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

    private DateTime Before(DateTime dateTime, int days = 1)
    {
        return dateTime.AddDays(-days);
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
```

### Comments

**[`^ top ^`](#unit-testing-nunit-moq-csharp)** | **[`^ Table of content ^`](#table-of-content)**

Comments in [comments.pdf](./Docs/comments.pdf)
