using TestNinja.Interfaces.Mocking;
using TestNinja.Types.Mocking;

namespace TestNinja.Services.Mocking;

public class Repository : IRepository
{
    public IEnumerable<Video> GetVideos()
    {
        using var context = new VideoContext();
        var videos =
            (from video in context.Videos
                where !video.IsProcessed
                select video).ToList();
        return videos;
    }
}