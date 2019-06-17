namespace SULS.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class SULSContext : DbContext
    {
        public SULSContext()
        {
        }

        public SULSContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Problem> Problems { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}