using System.Net;
using TestNinja.Interfaces.Mocking;

namespace TestNinja.Services.Mocking;

public class InstallerHelper : IInstallerHelper
{
    private readonly string _setupDestinationFile;
    private readonly IFileDownLoader _fileDownLoader;
    public InstallerHelper(string setupDestinationFile, IFileDownLoader fileDownLoader)
    {
        _setupDestinationFile = setupDestinationFile;
        _fileDownLoader = fileDownLoader;
    }

    public bool  DownloadInstaller(string customerName, string installerName)
    {
        try
        {
            var address = string.Format("http://example.com/{0}/{1}",
                customerName,
                installerName);
            _fileDownLoader.DownloadFile(address, _setupDestinationFile);
            return true;
        }
        catch (WebException)
        {
            return false;
        }
    }
}