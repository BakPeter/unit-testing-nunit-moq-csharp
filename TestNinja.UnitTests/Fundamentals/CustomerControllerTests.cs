using TestNinja.Services.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals;

[TestFixture]
public class CustomerControllerTests
{
    private CustomerController _customerController;

    [SetUp]
    public void Setup()
    {
        _customerController = new CustomerController();
    }

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

    [Test]
    public void GetCustomer_ArgIdIsNotZero_OK()
    {
        //Arrange
        const int id = 1;

        //Act
        var result = _customerController.GetCustomer(id);

        // Assert

        //Ok
        Assert.That(result, Is.TypeOf<Ok>());

        //NotFound or one of it's derivatives
        Assert.That(result, Is.InstanceOf<Ok>());
    }
}