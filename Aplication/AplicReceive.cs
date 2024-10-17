using financas_app.DTOs;
using financas_app.Models;
using financas_app.Services;

namespace financas_app.Aplication
{
    public class AplicReceive : IAplicReceive
    {
        private readonly IServiceReceive _serviceReceive;

        public AplicReceive(IServiceReceive serviceReceive)
        {
            _serviceReceive = serviceReceive;
        }

        public Receive CreateReceive(CreateReceiveDTO dto)
        {
            var receive = _serviceReceive.CreateReceive(dto);

            return receive;
        }

        public void DeleteReceive(int id)
        {
            _serviceReceive.DeleteReceive(id);
        }

        public List<Receive> ListReceives(ListReceiveDTO dto)
        {
           var receives = _serviceReceive.ListReceives(dto);

            return receives;
        }
    }
}
