using Microsoft.EntityFrameworkCore;

namespace EmployersAndTasks.Entities
{
    public class RecruitmentTaskDbContext : DbContext
    {
        private string _connectionString =
            "Server=.\\SQLEXPRESS;Database=RecruitmentTask;Trusted_Connection=True;";
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(x => x.Email)
                .IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
