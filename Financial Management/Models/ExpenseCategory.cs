using FinancialManagement.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_Management.Models
{
    public class ExpenseCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }

        public ICollection<MoneyManagement> Transactions { get; set; } = new List<MoneyManagement>();
        
    }
}
