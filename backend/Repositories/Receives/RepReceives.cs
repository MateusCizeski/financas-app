using backend.Data;
using backend.Models;
using backend.Repositories.Base;

namespace backend.Repositories.Receives
{
    public class RepReceives : Repository<Receive>, IRepReceives
    {
        public RepReceives(ReceivesContext context) : base(context)
        {
        }
    }
}
