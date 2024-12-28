using Microsoft.EntityFrameworkCore;
namespace Train_Tickets.Models
{
    public class ProjectContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-02PMLSH;Database=Train Tickets;Trusted_Connection=True; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Train> Trains { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Basic configuration using data annotations is typically enough,
            // but you can still add configurations here if necessary.

            modelBuilder.Entity<Trip>()
                .HasOne(t => t.StartStation)
                .WithMany(s => s.StartTrips)
                .HasForeignKey(t => t.StartStationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Trip>()
                .HasOne(t => t.EndStation)
                .WithMany(s => s.EndTrips)
                .HasForeignKey(t => t.EndStationId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }


    }
}
