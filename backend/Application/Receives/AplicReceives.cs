using backend.Application.Receives.DTOs;
using backend.Application.Receives.Mapper;
using backend.Models;
using backend.Services.Receives;

namespace backend.Application.Receives
{
    public class AplicReceives : IAplicReceives
    {
        private readonly IServReceives _servReceives;
        private readonly IMapperReceive _mapperReceive;

        public AplicReceives(IServReceives servReceives, IMapperReceive mapperReceive)
        {
            _servReceives = servReceives;
            _mapperReceive = mapperReceive;
        }

        public List<Receive> List(string userId, string date)
        {
            var receives = _servReceives.List(userId, date);

            return receives;
        }

        public Receive Save(SaveReceiveDTO dto)
        {
            var receive = _mapperReceive.MapperInsert(dto);

            return _servReceives.Save(receive);
        }
    }
}
