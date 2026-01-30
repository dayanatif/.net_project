using Microsoft.EntityFrameworkCore;
using SoftwareSubscriptionApp.Models;

namespace SoftwareSubscriptionApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        
        public DbSet<SoftwareSubscription> SoftwareSubscriptions { get; set; }
        public DbSet<EmailUser> EmailUsers { get; set; }
        public DbSet<DomainDetails> DomainDetails { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Explicit table mappings
            modelBuilder.Entity<SoftwareSubscription>().ToTable("software_subscription");
            modelBuilder.Entity<EmailUser>().ToTable("email_user");
            modelBuilder.Entity<DomainDetails>().ToTable("domain_details");
            modelBuilder.Entity<AppUser>().ToTable("app_user");

            
        }
    }
}
