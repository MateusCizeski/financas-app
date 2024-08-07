using backend.Application.Users.DTOs;
using backend.Application.Users.Mapper;
using backend.Models;
using backend.Repositories.Users;
using backend.Services.Users;

namespace backend.Application.Users
{
    public class AplicUsers : IAplicUsers
    {
        private readonly IServUsers _servUsers;
        private readonly IMapperUsers _mapperUsers;

        public AplicUsers(IServUsers servUsers, IMapperUsers mapperUsers)
        {
            _servUsers = servUsers;
            _mapperUsers = mapperUsers;
        }

        public UserDto ListUser(int id)
        {
            return _servUsers.ListUser(id);
        }

        public UserDto Save(SaveUserDTO dto)
        {
            var user = _mapperUsers.MapperInsert(dto);

            return _servUsers.Save(user);
        }
    }
}
