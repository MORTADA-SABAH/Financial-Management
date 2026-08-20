using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FinancialManagement.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "اسم الشركة او الزبون مطلوب")]
        public string? Name { get; set; }

        [Required (ErrorMessage ="رقم الهاتف مطلوب")]
        public string? PhoneNumber { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Balance { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<MoneyManagement> Transactions { get; set; } = new List<MoneyManagement >();
    }
}
