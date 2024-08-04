using backend.Data;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ReceivesContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(ReceivesContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
    }
}
