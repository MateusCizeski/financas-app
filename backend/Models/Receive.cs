namespace backend.Models
{
    public class Receive
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
