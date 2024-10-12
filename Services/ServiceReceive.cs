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

        public CreateReceiveDTO CreateReceive(Receive receive)
        {
            if (!receive.UserId)
            {
                throw new Exception("user id is required.");
            }

            var user = _financeAppContext.User.Where(u => u.Id == receive.UserId).FirstOrDefault();

            if(user == null)
            {
                throw new Exception("User not found.");
            }

            user.Balance += receive.Type == "receita" ? receive.Value : -receive.Value;

            _financeAppContext.User.Update(user);
            _financeAppContext.SaveChanges();

            return new CreateReceiveDTO
            {
                Id = receive.Id,
                Description = receive.Description,
                Value = receive.Value,
                Type = receive.Type,
                Date = receive.Date,
                UserId = receive.UserId
            };
        }

        public List<Receive> ListReceives()
        {
            var receives = _financeAppContext.Receive.ToList();

            return receives;
        }
    }
}
