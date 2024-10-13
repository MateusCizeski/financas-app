﻿using financas_app.DTOs;
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

        public void DeleteReceive(DeleteReceiveDTO dto)
        {
            _serviceReceive.DeleteReceive(dto);
        }

        public List<Receive> ListReceives()
        {
           var receives = _serviceReceive.ListReceives();

            return receives;
        }
    }
}
