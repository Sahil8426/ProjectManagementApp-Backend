using Microsoft.EntityFrameworkCore;
using ProjectApp.Models;

namespace ProjectApp.Data
{
    public class ProjectsAPIDbcontext : DbContext
    {
        public ProjectsAPIDbcontext(DbContextOptions<ProjectsAPIDbcontext> options) : base(options)
        {
        }

        public DbSet<CreateProject> Createprojects {get;set;}
    }
}
