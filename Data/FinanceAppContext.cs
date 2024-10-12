using financas_app.Models;
using Microsoft.EntityFrameworkCore;

namespace financas_app.Data
{
    public class FinanceAppContext : DbContext
    {
        public FinanceAppContext(DbContextOptions<FinanceAppContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Receive> Receive { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("users")
                .HasKey(u => u.Id);

            modelBuilder.Entity<Receive>()
                .ToTable("receives")
                .HasKey(r => r.Id);

            modelBuilder.Entity<Receive>()
                .HasOne(r => r.User)
                .WithMany(u => u.Receives)
                .HasForeignKey(r => r.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
