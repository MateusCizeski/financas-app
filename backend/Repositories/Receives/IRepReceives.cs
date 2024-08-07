using backend.Models;
using backend.Repositories.Base;

namespace backend.Repositories.Receives
{
    public interface IRepReceives : IRepository<Receive>
    {
        public Receive Save(Receive receive);
        public void Delete(string receiveId, string userId);
        public List<Receive> List(string userId, string date);
    }
}
