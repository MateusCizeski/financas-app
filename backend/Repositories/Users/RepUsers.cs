using backend.Data;
using backend.Models;
using backend.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.Users
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class RepUsers : Repository<User>, IRepUsers
    {
        public RepUsers(ReceivesContext context) : base(context)
        {
        }

        public UserDto Save(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            var userDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Balance = user.Balance,
                created_at = user.created_at,
                updated_at = user.updated_at
            };


            return userDto;
        }

        public UserDto ListUser(string id)
        {
            var user = _context.Users.Where(u => u.Id == id).Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Balance = u.Balance,
                created_at = u.created_at,
                updated_at = u.updated_at
            }).FirstOrDefault();

            return user;
        }

        public void ListBalanceUser(string id, DateTime data)
        {

        }
    }
}
