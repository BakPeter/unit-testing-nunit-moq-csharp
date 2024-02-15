using TestNinja.Types.Mocking;

namespace TestNinja.Interfaces.Mocking;

public interface IRepository
{
    IEnumerable<Video> GetVideos();
}