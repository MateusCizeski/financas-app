using financas_app.DTOs;
using financas_app.Models;

namespace financas_app.Services
{
    public interface IServiceReceive
    {
        CreateReceiveDTO CreateReceive(Receive receive);
        List<Receive> ListReceives();
    }
}
