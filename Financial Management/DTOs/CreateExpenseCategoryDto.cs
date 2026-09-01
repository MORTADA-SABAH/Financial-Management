using System.ComponentModel.DataAnnotations;

namespace FinancialManagement.DTOs
{
    public class CreateExpenseCategoryDto
    {
        [Required(ErrorMessage = "اسم التصنيف مطلوب")]
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
