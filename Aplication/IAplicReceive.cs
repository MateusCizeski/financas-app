using financas_app.DTOs;
using financas_app.Models;

namespace financas_app.Aplication
{
    public interface IAplicReceive
    {
        List<Receive> ListReceives(ListReceiveDTO dto);
        Receive CreateReceive(CreateReceiveDTO dto);
        void DeleteReceive(int id);
    }
}
