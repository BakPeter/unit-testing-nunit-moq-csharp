using TestNinja.Interfaces.Fundamentals;
using TestNinja.Services.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals;

[TestFixture]
public class HtmlFormatterTests
{
    private IHtmlFormatter _htmlFormatter;

    [SetUp]
    public void Setup()
    {
        _htmlFormatter = new HtmlFormatter();
    }

    [Test]
    public void FormatAsBold_WhenCalled_ReturnsTheArgumentStringEnclosedWithStrongElement()
    {
        // Arrange
        // var str = "abc";

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

}