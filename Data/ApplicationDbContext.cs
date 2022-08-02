using Microsoft.EntityFrameworkCore;
using StudentEmployeeMVC.Models;

namespace StudentEmployeeMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskToDo> TasksToDo { get; set; }
    }
}
