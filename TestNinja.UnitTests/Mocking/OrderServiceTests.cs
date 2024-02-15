using Moq;
using TestNinja.Services.Mocking;

namespace TestNinja.UnitTests.Mocking;

[TestFixture]
public class OrderServiceTests
{
    //     [Test]
    //     public void MethodName_Scenario_ExpectedBehaviour()
    //     {
    //         // Arrange
    //         // Act
    //         // Assert
    //     }
    private Mock<IStorage> _storageMock;
    private IOrderService _service;

    [SetUp]
    public void Setup()
    {
        _storageMock = new Mock<IStorage>();
        _service = new OrderService(_storageMock.Object);
    }

    [Test]
    public void PlaceOrder_WhenCalled_PlaceOrder()
    {
        // Arrange
        var id = 1;
        var order = new Order(id);

        // Act
        _service.PlaceOrder(order);

        // Assert
        _storageMock.Verify(storage => storage.Store(order));
    }

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
}