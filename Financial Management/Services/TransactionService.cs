using Financial_Management.DTOs;
using FinancialManagement.DataBase;
using FinancialManagement.DTOs;
using FinancialManagement.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinancialManagement.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ApplicationDbContext _context;

        public TransactionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddTransaction(CreateTransactionDto dto)
        {
           if(dto.ClientId.HasValue && dto.ClientId.Value > 0)
            {
                var client = await _context.Clients.FindAsync(dto.ClientId.Value);
                if(client == null)
                {
                    return "الزبون المحدد غير موجود";
                }
                if((int)dto.TransactionType == 1)
                {
                    client.Balance -= dto.Amount;
                }
                else if((int)dto.TransactionType == 2)
                {
                    client.Balance += dto.Amount;
                }
            }
            var newTransaction = new MoneyManagement
            {
                Amount = dto.Amount,
                TransactionType = dto.TransactionType,
                Description = dto.Description,
                TransactionDate = DateTime.Now,
                ClientId = (dto.ClientId.HasValue && dto.ClientId.Value > 0) ? dto.ClientId : null,
                ExpenseCategoryId = (dto.ExpenseCategoryId.HasValue && dto.ExpenseCategoryId.Value > 0) ? dto.ExpenseCategoryId : null
            };
            _context.MoneyManagements.Add(newTransaction);
            await _context.SaveChangesAsync();
            return "تمت إضافة المعاملة وتحديث رصيد الزبون بنجاح";
        }

        public async Task<List<TransactionResponseDto>> GetAllTransactions(TransactionFilterDto filter)
        {
            var query = _context.MoneyManagements.AsQueryable();

            if (filter.ClientId.HasValue)
                query = query.Where(t => t.ClientId == filter.ClientId.Value);

            if (filter.ExpenseCategoryId.HasValue)
                query = query.Where(t => t.ExpenseCategoryId == filter.ExpenseCategoryId.Value);

            if (filter.TransactionType.HasValue)
                query = query.Where(t => (int)t.TransactionType == filter.TransactionType.Value);

            if (filter.FromDate.HasValue)
                query = query.Where(t => t.TransactionDate >= filter.FromDate.Value);

            if (filter.ToDate.HasValue)
                query = query.Where(t => t.TransactionDate <= filter.ToDate.Value);

            return await query
                .Select(t => new TransactionResponseDto
                {
                    Id = t.Id,
                    Amount = t.Amount,
                    TransactionType = t.TransactionType,
                    Description = t.Description,
                    TransactionDate = t.TransactionDate,
                    CategoryName = t.ExpenseCategory != null ? t.ExpenseCategory.Name : "",
                    ClientName = t.Client != null ? t.Client.Name : ""
                })
                .ToListAsync();
        }
    }
}
