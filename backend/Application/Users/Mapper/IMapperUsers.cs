using backend.Application.Users.DTOs;
using backend.Models;

namespace backend.Application.Users.Mapper
{
    public interface IMapperUsers
    {
        public User MapperInsert(SaveUserDTO dto);
    }
}
