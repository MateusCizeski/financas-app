using backend.Application.Users.DTOs;
using backend.Models;

namespace backend.Application.Users.Mapper
{
    public class MapperUsers : IMapperUsers
    {
        public User MapperInsert(SaveUserDTO dto)
        {
            User user = new User()
            {
                //Id = Guid.NewGuid().ToString(),
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                Balance = dto.Balance,
                CreatedAt = DateTime.Now.ToUniversalTime(),
                UpdatedAt = DateTime.Now.ToUniversalTime()
            };

            return user;
        }
    }
}
