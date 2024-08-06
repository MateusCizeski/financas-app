namespace backend.Application.Receives.DTOs
{
    public class SaveReceiveDTO
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
