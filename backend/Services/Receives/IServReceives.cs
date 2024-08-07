using backend.Models;

namespace backend.Services.Receives
{
    public interface IServReceives
    {
        public Receive Save(Receive receive);
        public List<Receive> List(int userId, DateTime date);
    }
}
