using Microsoft.EntityFrameworkCore;
using Function.Entities;
using DataTask = Function.Entities.Task;

namespace Function.Data
{
    public class SqlDbContext : DbContext
    {
        
        public SqlDbContext(string connectionString) : base(GetOptions(connectionString))
        {

        }
        private static DbContextOptions<SqlDbContext> GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<SqlDbContext>(), connectionString).Options;
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<DataTask> Tasks { get; set; }
    }
}
