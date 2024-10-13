namespace financas_app.DTOs
{
    public class CreateReceiveDTO
    {
        public string Description { get; set; }
        public float Value { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public int UserId { get; set; }
    }
}
