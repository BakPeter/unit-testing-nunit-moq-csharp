using TestNinja.Services.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals;

[TestFixture]
public class DemeritPointsCalculatorTests
{
    private DemeritPointsCalculator _demeritPointsCalculator;

    [SetUp]
    public void Setup()
    {
        _demeritPointsCalculator = new DemeritPointsCalculator();
    }

    // Calculate demerit points
    // 0<= speed <= 300 => throw ArgumentException
    // 0 < speed < 65 => return 0
    // speed > 65 => 1 for every 5 point over limit

    [Test]
    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(301)]
    public void CalculateDemeritPoints_InvalidSpeed_ThrowArgumentOutOfRangeException(int speed)
    {
        // Arrange
        // Act

        // Assert
        Assert.That(() => _demeritPointsCalculator.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    [TestCase(1)]
    [TestCase(40)]
    [TestCase(65)]
    public void CalculateDemeritPoints_ValidUnderLimitSpeed_ReturnZero(int speed)
    {
        // Arrange
        
        // Act
        var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);

        // Assert
        Assert.That(result, Is.Zero);
    }

    [Test]
    [TestCase(66, 0)]
    [TestCase(67, 0)]
    [TestCase(65, 0)]
    [TestCase(75, 2)]
    [TestCase(80, 3)]
    public void CalculateDemeritPoints_ValidUnderLimitSpeed_ReturnZero(int speed, int expectedResult)
    {
        // Arrange

        // Act
        var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

}