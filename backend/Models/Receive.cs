using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("receives", Schema = "financas")]
    public class Receive
    {
        [Key]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
