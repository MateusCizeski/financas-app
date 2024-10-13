using financas_app.DTOs;
using financas_app.Models;

namespace financas_app.Services
{
    public interface IServiceReceive
    {
        Receive CreateReceive(CreateReceiveDTO dto);
        void DeleteReceive(DeleteReceiveDTO dto);
        List<Receive> ListReceives();
    }
}
