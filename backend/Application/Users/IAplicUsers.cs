using backend.Application.Users.DTOs;
using backend.Models;
using backend.Repositories.Users;

namespace backend.Application.Users
{
    public interface IAplicUsers
    {
        public UserDto Save(SaveUserDTO dto);
        public UserDto ListUser(string id);
    }
}
