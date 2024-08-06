using backend.Application.Receives.DTOs;
using backend.Models;

namespace backend.Application.Receives.Mapper
{
    public interface IMapperReceive
    {
        public Receive MapperInsert(SaveReceiveDTO dto);
    }
}
