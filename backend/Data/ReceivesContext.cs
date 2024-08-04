using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class ReceivesContext : DbContext
    {
        public ReceivesContext(DbContextOptions<ReceivesContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Receive> Receives { get; set; }
    }
}
