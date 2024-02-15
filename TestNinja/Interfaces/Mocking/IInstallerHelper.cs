namespace TestNinja.Interfaces.Mocking;

public interface IInstallerHelper
{
    bool DownloadInstaller(string customerName, string installerName);
}