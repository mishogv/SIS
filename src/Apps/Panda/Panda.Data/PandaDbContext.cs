namespace Panda.Data
{
    using Domain;

    using Microsoft.EntityFrameworkCore;

    public class PandaDbContext : DbContext
    {
        public PandaDbContext()
        {
        }

        public PandaDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(DbSettings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receipt>()
                        .HasOne(x => x.Recipient)
                        .WithMany(x => x.Receipts)
                        .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}