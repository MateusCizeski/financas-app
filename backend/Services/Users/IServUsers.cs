using backend.Models;
using backend.Repositories.Users;

namespace backend.Services.Users
{
    public interface IServUsers
    {
        public UserDto Save(User user);
        public UserDto ListUser(string id);
    }
}
