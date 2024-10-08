namespace financas_app.DTOs
{
    public class TransactionReadDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
        public string TransactionType { get; set; }

        // Opcional: Categoria
        public string Category { get; set; }
    }
}
