using Newtonsoft.Json;
using TestNinja.Interfaces.Mocking;
using Video = TestNinja.Types.Mocking.Video;

namespace TestNinja.Services.Mocking;

public class VideoService : IVideoService
{
    public const string ErrorParsingTheVideo = "Error parsing the video.";

    private readonly IFileReader _fileReader;
    private readonly IRepository _repository;

    public VideoService(IFileReader fileReader, IRepository repository)
    {
        _fileReader = fileReader;
        _repository = repository;
    }

    public string ReadVideoTitle(string fileName)
    {
        var str = _fileReader.ReadAllText(fileName);
        var video = JsonConvert.DeserializeObject<Video>(str);
        if (video == null)
            return ErrorParsingTheVideo;
        return video.Title;
    }

    public string GetUnprocessedVideosAsCsv()
    {
        var videoIds = new List<int>();

        var videos = _repository.GetVideos();
        foreach (var v in videos)
            videoIds.Add(v.Id);

        return String.Join(",", videoIds);
    }
}