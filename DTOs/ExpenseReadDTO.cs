namespace financas_app.DTOs
{
    public class ExpenseReadDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
    }
}
