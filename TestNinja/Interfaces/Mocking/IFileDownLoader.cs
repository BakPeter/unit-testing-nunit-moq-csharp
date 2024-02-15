namespace TestNinja.Interfaces.Mocking;

public interface IFileDownLoader
{
    void DownloadFile(string address, string setupDestinationFile);
}