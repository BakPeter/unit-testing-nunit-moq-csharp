using TestNinja.Interfaces.Mocking;

namespace TestNinja.Services.Mocking;

public class FileReader : IFileReader
{
    public string ReadAllText(string fileName)
    {
        return File.ReadAllText("video.txt");
    }
}