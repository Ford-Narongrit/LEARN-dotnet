namespace WebApi.Helpers;

using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // in memory database used for simplicity, change to a real db for production applications
        options.UseSqlServer(Configuration.GetConnectionString("SqlServer"));

    }

    // initial relationship
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>()
            .HasOne(b => b.User)
            .WithMany(a => a.Posts)
            .HasForeignKey(b => b.UserId);
    }

    // Add a DbSet for each entity type that you want to include in your model.
    public DbSet<User> Users => Set<User>();
    public DbSet<Post> Posts => Set<Post>();
}