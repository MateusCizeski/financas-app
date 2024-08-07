using backend.Application.Receives.DTOs;
using backend.Models;

namespace backend.Application.Receives
{
    public interface IAplicReceives
    {
        public Receive Save(SaveReceiveDTO dto);
        public List<Receive> List(int userId, DateTime date);
    }
}
