using financas_app.DTOs;
using financas_app.Models;
using financas_app.Services;

namespace financas_app.Aplication
{
    public class AplicUser : IAplicUser
    {
        private readonly IServUser _servUser;

        public AplicUser(IServUser servUser)
        {
            _servUser = servUser;
        }

        public ReturnUserDTO CreateUser(CreateUserDTO dto)
        {
            var user = _servUser.CreateUser(dto);

            return user;
        }

        public ListDetailUserDTO ListDetailUser(int id)
        {
            var user = _servUser.ListDetailUser(id);

            return user;
        }

        public List<DashboardItem> ListUserBalance(ListUserBalanceDTO dto)
        {
            var items = _servUser.ListUserBalance(dto);
            
            return items;
        }
    }
}
