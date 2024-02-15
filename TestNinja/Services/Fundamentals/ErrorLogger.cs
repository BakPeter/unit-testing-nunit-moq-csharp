using TestNinja.Interfaces.Fundamentals;

namespace TestNinja.Services.Fundamentals;

public class ErrorLogger : IErrorLogger
{
    public event EventHandler<Guid>? ErrorLogged;
    public string LastError { get; set; }

    public void Log(string error)
    {
        if (error is null || error.Length == 0 || error.Equals(" ")) throw new ArgumentNullException();
        LastError = error;
        ErrorLogged?.Invoke(this, Guid.NewGuid());
    }
}