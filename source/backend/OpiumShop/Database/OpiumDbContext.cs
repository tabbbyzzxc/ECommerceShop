using Domain;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Database
{
    public class OpiumDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public OpiumDbContext(IConfiguration configuration)
        {
            var dbExists = Database.EnsureCreated();
            _configuration = configuration;

        }

        public OpiumDbContext(DbContextOptions options)
            : base(options)
        {
            var dbExists = Database.EnsureCreated();
            
        }

        public DbSet<User> User { get; set; }

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString: _configuration.GetConnectionString("local"));
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }

}