using Microsoft.EntityFrameworkCore;
using TestNinja.Types.Mocking;

namespace TestNinja.Services.Mocking;

public class VideoContext : DbContext
{
    public DbSet<Video> Videos { get; set; }
}