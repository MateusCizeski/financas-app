using backend.Models;
using static backend.Models.Receive;

namespace backend.Application.Receives.DTOs
{
    public class SaveReceiveDTO
    {
        public int UserId { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public EnumType Type { get; set; }
    }
}
