using backend.Application.Receives.DTOs;
using backend.Models;

namespace backend.Application.Receives
{
    public interface IAplicReceives
    {
        public Receive Save(SaveReceiveDTO dto);
        public List<Receive> List(string userId, string date);
    }
}
