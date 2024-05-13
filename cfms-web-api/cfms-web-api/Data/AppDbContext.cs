using System.Configuration;
using cfms_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace cfms_web_api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Hide connection strings from public view
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseCosmos(configuration.GetConnectionString("CosmosDBConnection"), "cfms-db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuring User table
            modelBuilder.Entity<User>().ToContainer("Customer").HasPartitionKey(u => u.Id);

            //Configuring Feedback table
            modelBuilder.Entity<Feedback>().ToContainer("Feedback").HasPartitionKey(f => f.Id);
        }
    }
}

