using Moq;
using TestNinja.Interfaces.Mocking;
using TestNinja.Services.Mocking;

namespace TestNinja.UnitTests.Mocking;

[TestFixture]
public class EmployeeControllerTests
{
    private Mock<IEmployeeStorage> _employeeStorageMock;
    private EmployeeController _employeeController;

    [SetUp]
    public void Setup()
    {

        _employeeStorageMock = new Mock<IEmployeeStorage>();
        _employeeController = new EmployeeController(_employeeStorageMock.Object);
    }

    [Test]
    public void DeleteEmployee_WhenCalled_DeleteEmployeeFromDb()
    {
        // Arrange
        var id = 1;
        _employeeStorageMock.Setup(ec => ec.DeleteEmployee(id));

        // Act
        _employeeController.DeleteEmployee(id);

        // Assert
        _employeeStorageMock.Verify(es => es.DeleteEmployee(id));
    }

    [Test]
    public void DeleteEmployee_WhenCalled_ReturnsRedirectResult()
    {
        // Arrange
        _employeeStorageMock.Setup(ec => ec.DeleteEmployee(It.IsAny<int>()));

        // Act
        var result = _employeeController.DeleteEmployee(1);

        // Assert
        Assert.That(result, Is.TypeOf<RedirectResult>());
    }
}