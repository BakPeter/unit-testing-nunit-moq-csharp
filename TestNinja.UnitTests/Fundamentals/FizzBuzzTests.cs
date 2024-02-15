namespace TestNinja.UnitTests.Fundamentals;

[TestFixture]
public class FizzBuzzTests
{

    private IFizzBuzz _fizzBuzz;

    [SetUp]
    public void Setup()
    {
        _fizzBuzz = new FizzBuzz();
    }

    // method: GetOutput(int number)
    // number divisible by 3 return Fizz
    // number divisible by 5 return Buzz
    // number divisible by 3 and 5 return FizzBuzz
    // else
    //      number not divisible by 5 or 3 return number as string

    [Test]
    public void GetOutput_NumberDivisibleBy3_ReturnFizz()
    {
        // Arrange
        var number = 3;
        
        // Act
        var result = _fizzBuzz.GetOutput(number); 

        // Assert
        Assert.That(result, Is.EqualTo("Fizz"));
    }

    [Test]
    public void GetOutput_NumberDivisibleBy5_ReturnFuzz()
    {
        // Arrange
        var number = 5;

        // Act
        var result = _fizzBuzz.GetOutput(number);

        // Assert
        Assert.That(result, Is.EqualTo("Fuzz"));
    }

    [Test]
    public void GetOutput_NumberDivisibleBy3And5_ReturnFizzFuzz()
    {
        // Arrange
        var number = 15;

        // Act
        var result = _fizzBuzz.GetOutput(number);

        // Assert
        Assert.That(result, Is.EqualTo("FizzFuzz"));
    }

    [Test]
    public void GetOutput_NumberNotDivisibleBy3Or5_ReturnNumberAsString()
    {
        // Arrange
        var number = 7;

        // Act
        var result = _fizzBuzz.GetOutput(number);

        // Assert
        Assert.That(result, Is.EqualTo("7"));
    }
}

public class FizzBuzz : IFizzBuzz
{
    public string GetOutput(int number)
    {
        if (number % 3 == 0 && number % 5 == 0) return "FizzFuzz";
        if (number % 3 == 0) return "Fizz";
        if (number % 5 == 0) return "Fuzz";
        return number.ToString();
    }
}

public interface IFizzBuzz
{
    string GetOutput(int number);
}