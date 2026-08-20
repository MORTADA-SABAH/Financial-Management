using Financial_Management.Enum;
using Financial_Management.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialManagement.Models
{
    public class MoneyManagement
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="المبلغ مطلوب")]
        [Column(TypeName = "decimal(18,4)")]
        public Decimal Amount { get; set; }

        public TransactionType TransactionType { get; set; }
        public string? Description { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        public int? ClientId { get; set; }
        [ForeignKey ("ClientId")]
        public Client? Client { get; set; }

        public int? ExpenseCategoryId { get; set; }
        [ForeignKey ("ExpenseCategoryId")]
        public ExpenseCategory? ExpenseCategory { get; set; }
    }
}
