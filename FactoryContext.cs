using Microsoft.EntityFrameworkCore;
using RSCProgerss.Model;

namespace RSCProgerss
{
    public class FactoryContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Order> Orders { get; set; }

        private readonly string _connString = "server = localhost;user id = root; password = root; database=factory";
        public FactoryContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(_connString, new MySqlServerVersion(new Version(8, 0, 25)));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>()
                .HasIndex(w => w.Login)
                .IsUnique();

            modelBuilder.Entity<Master>()
                .HasIndex(m => m.Login)
                .IsUnique();
        }
        public override int SaveChanges()
        {
            var newWorkers = ChangeTracker.Entries<Worker>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
                .Select(e => e.Entity.Login)
                .ToList();

            var newMasters = ChangeTracker.Entries<Master>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
                .Select(e => e.Entity.Login)
                .ToList();

            var allLogins = Workers.Select(w => w.Login).Concat(Masters.Select(m => m.Login)).ToList();

            if (newWorkers.Intersect(allLogins).Any() || newMasters.Intersect(allLogins).Any())
            {
                throw new Exception("Login must be unique across both Workers and Masters.");
            }

            return base.SaveChanges();
        }
    }
}
