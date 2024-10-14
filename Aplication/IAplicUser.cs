using financas_app.DTOs;
using financas_app.Models;
using financas_app.Services;

namespace financas_app.Aplication
{
    public interface IAplicUser
    {
        ReturnUserDTO CreateUser(CreateUserDTO dto);
        string AuthUser(AuthLoginDTO dto);
        ListDetailUserDTO ListDetailUser(int id);
        List<DashboardItem> ListUserBalance(ListUserBalanceDTO dto);
    }
}
