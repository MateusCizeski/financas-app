using backend.Models;
using static backend.Models.Receive;

namespace backend.Application.Receives.DTOs
{
    public class SaveReceiveDTO
    {
        //public string Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public EnumType Type { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
