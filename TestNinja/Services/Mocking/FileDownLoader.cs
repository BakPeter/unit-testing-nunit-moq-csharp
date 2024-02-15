using System.Net;
using TestNinja.Interfaces.Mocking;

namespace TestNinja.Services.Mocking;

public class FileDownLoader : IFileDownLoader
{
    public void DownloadFile(string address, string setupDestinationFile)
    {
        var client = new WebClient();
        client.DownloadFile(address, setupDestinationFile);
    }
}