using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class ReceivesContext : DbContext
    {
        public ReceivesContext(DbContextOptions<ReceivesContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Receive> Receives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach(var property in entityType.GetProperties())
                {
                    var currentName = property.Name;
                    var newName = ToSnakeCase(currentName);
                    property.SetColumnName(newName);
                }
            }
        }
        private string ToSnakeCase(string input)
        {
            if (string.IsNullOrEmpty(input)) { return input; }
            var startUnderscores = System.Text.RegularExpressions.Regex.Match(input, @"^_+");
            return startUnderscores + System.Text.RegularExpressions.Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }
    }
}
