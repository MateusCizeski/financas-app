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

        public void DeleteReceive(DeleteReceiveDTO dto)
        {
            var receive = _financeAppContext.Receive.Where(r => r.Id == dto.ReceiveId).FirstOrDefault();
            var user = _financeAppContext.User.Where(u => u.Id == dto.UserId).FirstOrDefault();
            var valueUpdated = receive.Type == "despesa" ? user.Balance += receive.Value : user.Balance -= receive.Value;

            _financeAppContext.Receive.Remove(receive);
            _financeAppContext.User.Update(user);
            _financeAppContext.SaveChanges();
        }

        public List<Receive> ListReceives()
        {
            var receives = _financeAppContext.Receive.ToList();

            return receives;
        }
    }
}
