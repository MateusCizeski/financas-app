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
                Id = Guid.NewGuid().ToString(),
                UserId = dto.UserId,
                Description = dto.Description,
                Value = dto.Value,
                Type = dto.Type,
                Date = dto.Date,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt
            };

            return receive;
        }
    }
}
