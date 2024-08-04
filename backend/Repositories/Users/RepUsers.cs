using backend.Data;
using backend.Models;
using backend.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.Users
{
    public class RepUsers : Repository<User>, IRepUsers
    {
        public RepUsers(ReceivesContext context) : base(context)
        {
        }
    }
}
