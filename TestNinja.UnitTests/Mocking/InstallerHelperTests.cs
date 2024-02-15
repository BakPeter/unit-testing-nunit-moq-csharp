using System.Net;
using Moq;
using TestNinja.Interfaces.Mocking;
using TestNinja.Services.Mocking;

namespace TestNinja.UnitTests.Mocking;

[TestFixture]
public class InstallerHelperTests
{
    private Mock<IFileDownLoader> _fileDownLoaderMock;
    //private Mock<string> _setupDestinationMock;
    private IInstallerHelper _installerHalper;

    [SetUp]
    public void Setup()
    {
        _fileDownLoaderMock = new Mock<IFileDownLoader>();
        //_setupDestinationMock = new Mock<string>();
        _installerHalper = new InstallerHelper("_setupDestinationMock.Object", _fileDownLoaderMock.Object);
    }

    [Test]
    public void DownloadFile_DownloadSuccess_ReturnTrue()
    {
        // Arrange
        _fileDownLoaderMock.Setup(fd =>
            fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()));

        // Act
        var result = _installerHalper.DownloadInstaller("", "");

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void DownloadFile_DownloadFailure_ReturnFalse()
    {
        // Arrange
        _fileDownLoaderMock
            .Setup(fileDownLoader =>
                fileDownLoader.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
            .Throws<WebException>();

        // Act
        var result = _installerHalper.DownloadInstaller("", "");

        // Assert
        Assert.That(result, Is.False);
    }
}