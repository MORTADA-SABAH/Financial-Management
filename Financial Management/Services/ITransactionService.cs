using Financial_Management.DTOs;
using FinancialManagement.DTOs;
using FinancialManagement.Models;

namespace FinancialManagement.Services
{
    public interface ITransactionService
    {
        Task<string> AddTransaction(CreateTransactionDto dto);
        Task<List<TransactionResponseDto>> GetAllTransactions(TransactionFilterDto filter);
    }
}
