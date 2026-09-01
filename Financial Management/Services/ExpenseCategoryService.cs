using FinancialManagement.DataBase;
using FinancialManagement.DTOs;
using FinancialManagement.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FinancialManagement.Services
{
    public class ExpenseCategoryService : IExpenseCategoryService
    {
        private readonly ApplicationDbContext _context;
        public ExpenseCategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddCategoryAsync(CreateExpenseCategoryDto dto)
        {
            var category = new ExpenseCategory
            {
                Name = dto.Name,
                Description = dto.Description
            };

            _context.ExpenseCategories.Add(category);
            await _context.SaveChangesAsync();
            return "Done";
        }
        public async Task<List<ExpenseCategoryResponseDto>> GetAllCategoriesAsync()
        {
            return await _context.ExpenseCategories
                .Select(c => new ExpenseCategoryResponseDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                })
                .ToListAsync();
        }
    }
}
