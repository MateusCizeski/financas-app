namespace financas_app.Models
{
    public class Receive
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } 
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
