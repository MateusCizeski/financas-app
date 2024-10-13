using financas_app.Data;
using financas_app.DTOs;
using financas_app.Models;

namespace financas_app.Services
{
    public class DashboardItem
    {
        public string Tag { get; set; }
        public float Saldo { get; set; }
    }

    public class ServiceUser : IServUser
    {
        private readonly FinanceAppContext _financeAppContext;

        public ServiceUser(FinanceAppContext financeAppContext)
        {
            _financeAppContext = financeAppContext;
        }

        public ReturnUserDTO CreateUser(CreateUserDTO dto)
        {
            if(dto.Email == null)
            {
                throw new Exception("Email incorrect");
            }

            var userAlreadyExists = _financeAppContext.User.Where(u => u.Email == dto.Email).FirstOrDefault();

            if (userAlreadyExists != null) 
            {
                throw new Exception("User already exists");
            }

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                Balance = dto.Balance
            };

            _financeAppContext.User.Add(user);
            _financeAppContext.SaveChanges();

            return new ReturnUserDTO
            {
                Name = user.Name,
                Email = user.Email,
                Balance = user.Balance
            };
        }

        public ListDetailUserDTO ListDetailUser(int id)
        {
           var user = _financeAppContext.User.Where(u => u.Id == id).FirstOrDefault();

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return new ListDetailUserDTO
            {
                Id  = user.Id,
                Name = user.Name,
                Email = user.Email,
                Balance = user.Balance,
            };
        }

        public List<DashboardItem> ListUserBalance(ListUserBalanceDTO dto)
        {
            if (dto.UserId == null)
            {
                throw new Exception("Invalid user");
            }

            var dashboard = new List<DashboardItem>();
            var user = _financeAppContext.User.Where(u => u.Id == dto.UserId).FirstOrDefault();

            if (user == null)
            {
                throw new Exception("User not found");
            }

            dashboard.Add(new DashboardItem
            {
                Tag = "Saldo",
                Saldo = user.Balance
            });

            var revenues = _financeAppContext.Receive.Where(r => r.UserId == user.Id && 
                                                                 r.Date == dto.Date && 
                                                                 r.Type == "receita").ToList();

            var expenses = _financeAppContext.Receive.Where(r => r.UserId == user.Id &&
                                                                 r.Date == dto.Date &&
                                                                 r.Type == "despesa").ToList();

            var totalRevenue = revenues.Sum(r => r.Value);
            var totalExpense = expenses.Sum(r => r.Value);

            dashboard.Add(new DashboardItem
            {
                Tag = "Receita",
                Saldo = totalRevenue
            });

            dashboard.Add(new DashboardItem
            {
                Tag = "Despesa",
                Saldo = totalExpense
            });

            return dashboard;
        }
    }
}
