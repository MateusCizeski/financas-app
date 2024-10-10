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
            base.OnModelCreating(modelBuilder);
        }
    }
}
