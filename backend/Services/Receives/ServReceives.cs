using backend.Models;
using backend.Repositories.Receives;

namespace backend.Services.Receives
{
    public class ServReceives : IServReceives
    {
        private readonly IRepReceives _repReceives;

        public ServReceives(IRepReceives repReceives) 
        {
            _repReceives = repReceives;
        }

        public List<Receive> List(string userId, DateTime date)
        {
            var receives = _repReceives.List(userId, date);

            return receives;
        }

        public Receive Save(Receive receive)
        {
            return _repReceives.Save(receive);
        }
    }
}
