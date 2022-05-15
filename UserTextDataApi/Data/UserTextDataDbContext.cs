using System.Net.Mime;
using Microsoft.EntityFrameworkCore;

namespace UserTextDataApi.Data;

public class UserTextDataDbContext : DbContext
{
    public UserTextDataDbContext(DbContextOptions<UserTextDataDbContext> options) : base(options)
    {
    }

    public DbSet<UserTextDataWrapper> UserData { get; set; }
    public DbSet<Wrapper> Texts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserTextDataWrapper>()
            .HasMany(c => c.Texts);

        modelBuilder.Entity<UserTextDataWrapper>().HasData( new UserTextDataWrapper { Id = 88421114} );
        modelBuilder.Entity<Wrapper>().HasData(new { Id = 88421114, textValue = "Hello1"});
        modelBuilder.Entity<Wrapper>().HasData(new { Id = 88421114, textValue = "Hello2"});
        
    }
}