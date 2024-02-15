using TestNinja.Interfaces.Fundamentals;
using TestNinja.Services.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals;

[TestFixture]
public class ErrorLoggerTests
{
    private IErrorLogger _errorLogger;

    [SetUp]
    public void Setup()
    {
        _errorLogger = new ErrorLogger();
    }

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

    [Test]
    public void Log_ValidError_RaiseErrorLoggedEvent()
    {
        //Arrange
        const string error = "error"; 
        var id = Guid.Empty;
        _errorLogger.ErrorLogged += (sender, args) => { id = args;};
        
        //Act
        _errorLogger.Log(error);

        //Assert
        Assert.That(id, Is.Not.EqualTo(Guid.Empty));
    }
}