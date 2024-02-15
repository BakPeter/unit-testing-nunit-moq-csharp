using Moq;
using TestNinja.Interfaces.Mocking;
using TestNinja.Services.Mocking;
using TestNinja.Types.Mocking;

namespace TestNinja.UnitTests.Mocking;

[TestFixture]
public class VideoServiceTests
{
    //     [Test]
    //     public void MethodName_Scenario_ExpectedBehaviour()
    //     {
    //         // Arrange
    //         // Act
    //         // Assert
    //     }

    private Mock<IFileReader> _fileReaderMock;
    private IVideoService _videoService;
    private Mock<IRepository> _repositoryMock;

    [SetUp]
    public void Setup()
    {
        _fileReaderMock = new Mock<IFileReader>();
        _repositoryMock = new Mock<IRepository>();
        _videoService = new VideoService(_fileReaderMock.Object, _repositoryMock.Object);
    }

    [Test]
    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    public void ReadVideoTitle_FileNameIsEmpty_ReturnErrorMessage(string fileName)
    {
        // Arrange
        _fileReaderMock
            .Setup(fr => fr.ReadAllText(fileName))
            .Returns("");

        // Act
        var result = _videoService.ReadVideoTitle(fileName);

        // Assert
        Assert.That(result, Is.EqualTo(VideoService.ErrorParsingTheVideo));
    }

    [Test]
    public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnEmptyString()
    {
        // Arrange
        _repositoryMock
            .Setup(r => r.GetVideos())
            .Returns(new List<Video>());

        // Act
        var result = _videoService.GetUnprocessedVideosAsCsv();

        // Assert
        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void GetUnprocessedVideosAsCsv_SomeVideosAreNotProcessed_ReturnIds()
    {
        // Arrange
        _repositoryMock
            .Setup(r => r.GetVideos())
            .Returns(new List<Video>
            {
                //new Video{Id = 1, IsProcessed = false, Title = "video 1"},
                //new Video{Id = 2, IsProcessed = false, Title = "video 2"},
                //new Video{Id = 3, IsProcessed = false, Title = "video 3"},
                new Video { Id = 1 },
                new Video { Id = 2 },
                new Video { Id = 3 }
            });

        // Act
        var result = _videoService.GetUnprocessedVideosAsCsv();

        // Assert
        Assert.That(result, Is.EqualTo("1,2,3"));
    }
}