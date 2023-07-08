using Microsoft.EntityFrameworkCore;
using ProjectApp.Models;

namespace ProjectApp.Data
{
    public class AddTaskAPIDbContext : DbContext
    {
        public AddTaskAPIDbContext(DbContextOptions<AddTaskAPIDbContext> options) : base(options)
        {
        }

        public DbSet<AddTask> AddTasks { get; set; }
    }
}
