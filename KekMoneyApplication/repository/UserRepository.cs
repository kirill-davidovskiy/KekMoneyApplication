using Microsoft.EntityFrameworkCore;
using KekMoneyApplication.entities;

namespace KekMoneyApplication.repository;

public class UserRepository : DbContext
{

    public UserRepository(DbContextOptions<UserRepository> configuration) : base(configuration)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    
    
    public void AddUser(string username, string password)
    {
        Database.ExecuteSqlRaw($"exec AddUser '{username}', '{password}'");
    }

    public void Authorization(string username, string password)
    {
        Database.ExecuteSqlRaw($"exec Authorize '{username}', '{password}'");
    }
}