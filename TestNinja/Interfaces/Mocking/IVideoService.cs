namespace TestNinja.Interfaces.Mocking;

public interface IVideoService
{
    string ReadVideoTitle(string fileName);
    string GetUnprocessedVideosAsCsv();
}