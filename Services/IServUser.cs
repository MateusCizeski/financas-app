using financas_app.DTOs;

namespace financas_app.Services
{
    public interface IServUser
    {
        ReturnUserDTO CreateUser(CreateUserDTO dto);
        ListDetailUserDTO ListDetailUser(int id);
        List<DashboardItem> ListUserBalance(ListUserBalanceDTO dto);
    }
}
