using FinancialManagement.DTOs;

namespace FinancialManagement.Services
{
    public interface IExpenseCategoryService
    {
        Task<string> AddCategoryAsync(CreateExpenseCategoryDto dto);
        Task<List<ExpenseCategoryResponseDto>> GetAllCategoriesAsync();
    }
}
