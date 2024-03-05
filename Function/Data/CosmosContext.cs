using Function.Entities;
using Microsoft.EntityFrameworkCore;

namespace Function.Data
{
    public class CosmosContext : DbContext
    {
        private readonly string _connectionUri;
        private readonly string _connectionKey;
        private readonly string _databaseName;
        public CosmosContext(string connectionUri, string connectionKey, string databaseName)
        {
            _connectionKey = connectionKey;
            _databaseName = databaseName;
            _connectionUri = connectionUri;
        }

        public DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(_connectionUri, _connectionKey, _databaseName);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
            .Property(f => f.id)
            .ValueGeneratedOnAdd()
            .HasConversion(
                v => Guid.NewGuid().
                ToString(), v => 0);
            modelBuilder.Entity<Project>().OwnsMany(a => a.Tasks, task =>
            {
                task.Property<int>("id").ValueGeneratedOnAdd().HasConversion(v => Guid.NewGuid().ToString(), v => 0);
                task.HasKey("id");
            });
        }

       
    }
}
