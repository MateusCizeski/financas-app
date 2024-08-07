using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("receives", Schema = "financas")]
    public class Receive
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public EnumType Type { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
    public enum EnumType
    {
       [Description("Revenue")]
       Revenue = 1,

       [Description("Expense")]
       Expense = 2
    }
}
