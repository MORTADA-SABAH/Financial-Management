using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using FinancialManagement.DTOs;
using FinancialManagement.Models;
using FinancialManagement.DataBase;
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
            var newTransaction = new MoneyManagement
            {
                Amount = dto.Amount,
                TransactionType = dto.TransactionType,
                Description = dto.Description,
                TransactionDate = DateTime.Now,

                ClientId = dto.ClientId,
                ExpenseCategoryId = dto.ExpenseCategoryId
            };

            _context.MoneyManagements.Add(newTransaction);
            await _context.SaveChangesAsync();
            return "ok";
        }

        public async Task<List<TransactionResponseDto>> GetAllTransactions()
        {
            var transactions = await _context.MoneyManagements
                .Include(t => t.Client)
                .Include(t => t.ExpenseCategory)
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
            return transactions;
        }
    }
}
