using financas_app.DTOs;
using financas_app.Models;

namespace financas_app.Services
{
    public interface IServUser
    {
        ReturnUserDTO CreateUser(CreateUserDTO dto);
        ReturnAuthLoginDTO AuthUser(AuthLoginDTO dto);
        ListDetailUserDTO ListDetailUser(int id);
        List<DashboardItem> ListUserBalance(ListUserBalanceDTO dto);
    }
}
