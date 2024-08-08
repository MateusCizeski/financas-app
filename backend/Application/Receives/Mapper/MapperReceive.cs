using backend.Application.Receives.DTOs;
using backend.Models;

namespace backend.Application.Receives.Mapper
{
    public class MapperReceive : IMapperReceive
    {
        public Receive MapperInsert(SaveReceiveDTO dto)
        {
            Receive receive = new Receive()
            {
                UserId = dto.UserId,
                Description = dto.Description,
                Value = dto.Value,
                Type = dto.Type,
                Date = DateTime.Now.ToUniversalTime(),
                CreatedAt = DateTime.Now.ToUniversalTime(),
                UpdatedAt = DateTime.Now.ToUniversalTime()
            };

            return receive;
        }
    }
}
