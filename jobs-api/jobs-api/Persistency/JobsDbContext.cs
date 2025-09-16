using jobs_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace jobs_api.Persistency
{
    public class JobsDbContext : DbContext
    {
        public JobsDbContext(DbContextOptions<JobsDbContext> options) : base(options)
        { }

        // DB Sets
        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // If you want to configure the Job entity, use modelBuilder.Entity<Job>()
            // For example, to configure the table name:
            builder.Entity<Job>(o => 
            {
                o.HasKey(j => j.Id);
            });
        }

    }
}
