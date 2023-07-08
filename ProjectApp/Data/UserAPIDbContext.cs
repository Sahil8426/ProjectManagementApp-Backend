using Microsoft.EntityFrameworkCore;
using ProjectApp.Models;

namespace ProjectApp.Data
{
    public class UserAPIDbContext : DbContext
    {
        public UserAPIDbContext(DbContextOptions<UserAPIDbContext> options) : base(options)
        {
        }

        public DbSet<CreateUser> AddUsers { get; set; }
    }
}
