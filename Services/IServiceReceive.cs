using financas_app.DTOs;
using financas_app.Models;

namespace financas_app.Services
{
    public interface IServiceReceive
    {
        Receive CreateReceive(CreateReceiveDTO dto);
        void DeleteReceive(int id);
        List<Receive> ListReceives(ListReceiveDTO dto);
    }
}
