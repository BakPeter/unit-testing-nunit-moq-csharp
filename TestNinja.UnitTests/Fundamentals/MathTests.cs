using TestNinja.Interfaces.Fundamentals;
using Math = TestNinja.Services.Fundamentals.Math;

namespace TestNinja.UnitTests.Fundamentals;

[TestFixture]
public class MathTests
{
    private IMath _math;

    [SetUp]
    public void Setup()
    {
        _math = new Math();
    }

    [Test]
    [Ignore("My reason for ignoring the test")]
    public void Add_WhenCalled_ReturnsSumOfInputArgs()
    {
        // Arrange
        var arg1 = 1;
        var arg2 = 2;
        var expectedResult = 3;

        // Act
        var actualResult = _math.Add(arg1, arg2);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    [TestCase(2, 1, 2)]
    [TestCase(1, 2, 2)]
    [TestCase(1, 1, 1)]
    public void Max_WhenCalled_ReturnsTheGraterArgument(int arg1, int arg2, int expectedResult)
    {
        // Arrange

        // Act
        var result = _math.Max(arg1, arg2);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

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
}