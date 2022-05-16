using System.Net.Mime;
using Microsoft.EntityFrameworkCore;

namespace UserTextDataApi.Data;

public class UserDataDbContext : DbContext
{
    public UserDataDbContext(DbContextOptions<UserDataDbContext> options) : base(options)
    { }

    public DbSet<UserData> UserData { get; set; }
    public DbSet<UserText> Texts { get; set; }

}