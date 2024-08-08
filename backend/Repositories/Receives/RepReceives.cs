using backend.Data;
using backend.Models;
using backend.Repositories.Base;

namespace backend.Repositories.Receives
{
    public class RepReceives : Repository<Receive>, IRepReceives
    {
        public RepReceives(ReceivesContext context) : base(context) { }

        public void Delete(int receiveId, int userId)
        {
            throw new NotImplementedException();
        }

        public List<Receive> List(int userId, DateTime date)
        {
            var receives = _context.Receives.Where(r => r.Date == date && r.UserId == userId).ToList();

            return receives;
        }

        public Receive Save(Receive receive)
        {
            if(receive == null)
            {
                throw new Exception("Invalid receive.");
            }

            if(receive.UserId == null)
            {
                throw new Exception("Invalid user.");
            }

            var user = _context.Users.Where(u => u.Id == receive.UserId).FirstOrDefault();

            if(receive.Type == EnumType.Revenue)
            {
                user.Balance = user.Balance + receive.Value;
            }else
            {
                user.Balance = user.Balance - receive.Value;
            }

            _context.Receives.Add(receive);
            _context.Users.Update(user);
            _context.SaveChanges();

            return receive;
        }
    }
}
