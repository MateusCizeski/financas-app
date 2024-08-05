using backend.Models;
using backend.Repositories.Base;

namespace backend.Repositories.Users
{
    public interface IRepUsers : IRepository<User>
    {
        public UserDto Save(User user);
        public UserDto ListUser(string id);
        public void ListBalanceUser(string id, DateTime data);
    }
}
