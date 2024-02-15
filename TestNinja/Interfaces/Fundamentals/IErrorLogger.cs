namespace TestNinja.Interfaces.Fundamentals;

public interface IErrorLogger
{
    public event EventHandler<Guid> ErrorLogged;

    public string LastError { get; set; }
    void Log(string error);
}