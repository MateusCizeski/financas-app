using backend.Models;
using backend.Repositories.Users;

namespace backend.Services.Users
{
    public class ServUsers : IServUsers
    {
        private readonly IRepUsers _repUsers;

        public ServUsers(IRepUsers repUsers) 
        {
            _repUsers = repUsers;
        }

        public UserDto ListUser(string id)
        {
            var user = _repUsers.ListUser(id);

            return user;
        }

        public UserDto Save(User user)
        {
            return _repUsers.Save(user);
        }
    }
}
