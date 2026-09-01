using Financial_Management.DTOs;
using FinancialManagement.DTOs;
using FinancialManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancialManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddTransaction([FromBody] CreateTransactionDto dto)
        {
            var result = await _transactionService.AddTransaction(dto);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllTransactions([FromQuery] TransactionFilterDto filter)
        {
            var result = await _transactionService.GetAllTransactions(filter);
            return Ok(result);
        }
    }
}
