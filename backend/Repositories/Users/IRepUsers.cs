using backend.Models;
using backend.Repositories.Base;

namespace backend.Repositories.Users
{
    public interface IRepUsers : IRepository<User>
    {
        public UserDto Save(User user);
        public UserDto ListUser(int id);
        public void ListBalanceUser(int id, DateTime data);
    }
}
