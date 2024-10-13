using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace financas_app.Models
{
    public class Receive
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("value")]
        public float Value { get; set; }

        [Column("type")]
        public string Type { get; set; }

        [Column("date")]
        public string Date { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}
