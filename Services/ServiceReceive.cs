using financas_app.Data;
using financas_app.DTOs;
using financas_app.Models;

namespace financas_app.Services
{
    public class ServiceReceive : IServiceReceive
    {
        private readonly FinanceAppContext _financeAppContext;

        public ServiceReceive(FinanceAppContext financeAppContext)
        {
            _financeAppContext = financeAppContext;
        }

        public Receive CreateReceive(CreateReceiveDTO dto)
        {
            if (dto.UserId == null)
            {
                throw new Exception("user id is required.");
            }

            var user = _financeAppContext.User.Where(u => u.Id == dto.UserId).FirstOrDefault();

            if(user == null)
            {
                throw new Exception("User not found.");
            }

            user.Balance += dto.Type == "receita" ? dto.Value : -dto.Value;

            _financeAppContext.User.Update(user);
            

            var receive = new Receive
            {
                Description = dto.Description,
                Value = dto.Value,
                Type = dto.Type,
                Date = dto.Date,
                UserId = dto.UserId
            };

            _financeAppContext.Receive.Add(receive);
            _financeAppContext.SaveChanges();

            return receive;
        }

        public void DeleteReceive(int id)
        {
            var receive = _financeAppContext.Receive.Where(r => r.Id == id).FirstOrDefault();

            if(receive == null)
            {
                throw new Exception("Expense or Income does not exist.");
            }

            var user = _financeAppContext.User.Where(u => u.Id == receive.UserId).FirstOrDefault();
            var valueUpdated = receive.Type == "despesa" ? user.Balance += receive.Value : user.Balance -= receive.Value;

            _financeAppContext.Receive.Remove(receive);
            _financeAppContext.User.Update(user);
            _financeAppContext.SaveChanges();
        }

        public List<Receive> ListReceives(ListReceiveDTO dto)
        {
            var receives = _financeAppContext.Receive.Where(r => r.Date == dto.Date && r.UserId == dto.UserId).ToList();

            return receives;
        }
    }
}
