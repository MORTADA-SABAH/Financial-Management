using Financial_Management.Enum;
using Financial_Management.Models;
using System.ComponentModel.DataAnnotations;

namespace FinancialManagement.DTOs
{
    public class CreateTransactionDto
    {
        [Required (ErrorMessage ="حط المبلغ ")]
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public string? Description { get; set; }
        public int? ClientId { get; set; }
        public int? ExpenseCategoryId { get; set; }
    }
}
