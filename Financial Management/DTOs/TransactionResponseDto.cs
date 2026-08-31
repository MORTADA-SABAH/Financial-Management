using FinancialManagement.Enum;

namespace FinancialManagement.DTOs
{
    public class TransactionResponseDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public string? Description { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? CategoryName { get; set; }
        public string? ClientName { get; set; }
    }
}
