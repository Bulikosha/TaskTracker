using Microsoft.EntityFrameworkCore;

namespace TaskTrackerAPI.DataContext;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
        Database.EnsureCreated();
    }
}