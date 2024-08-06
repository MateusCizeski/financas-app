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

        public void Delete(string receiveId, string userId)
        {
            throw new NotImplementedException();
        }

        public List<Receive> List(string userId, DateTime date)
        {
            var receives = _context.Receives.Where(r => r.Date == date && r.UserId == userId).ToList();

            return receives;
        }

        public Receive Save(Receive receive)
        {
            _context.Receives.Add(receive);
            _context.SaveChanges();

            return receive;
        }
    }
}
