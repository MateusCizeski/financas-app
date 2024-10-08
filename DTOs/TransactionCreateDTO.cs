using System.ComponentModel.DataAnnotations;

namespace financas_app.DTOs
{
    public enum TransactionTypeDTO
    {
        Income = 1,
        Expense = 2
    }

    public class TransactionCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser positivo.")]
        public decimal Amount { get; set; }

        [Required]
        [RegularExpression(@"^\d{1,2}/\d{1,2}/\d{4}$", ErrorMessage = "A data deve estar no formato d/m/Y.")]
        public string Date { get; set; }

        [Required]
        [EnumDataType(typeof(TransactionTypeDTO))]
        public TransactionTypeDTO TransactionType { get; set; }

        // Opcional: Categoria
        public int? CategoryId { get; set; }
    }
}
