using TestNinja.Interfaces.Fundamentals;

namespace TestNinja.Services.Fundamentals;

public class HtmlFormatter : IHtmlFormatter
{
    public string FormatAsBold(string str)
    {
        return $"<strong>{str}</strong>";
    }
}