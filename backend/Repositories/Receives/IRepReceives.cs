using backend.Models;
using backend.Repositories.Base;

namespace backend.Repositories.Receives
{
    public interface IRepReceives : IRepository<Receive>
    {
        public Receive Save(Receive receive);
        public void Delete(int receiveId, int userId);
        public List<Receive> List(int userId, DateTime date);
    }
}
