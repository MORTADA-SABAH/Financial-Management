using FinancialManagement.Models;
using FinancialManagement.Services;
using FinancialManagement.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FinancialManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddClien([FromBody]CreateClientDto dto)
        {
            var result = await _clientService.AddClient(dto);
            return Ok(result);
        }

        [HttpGet("Add")]
        public async Task<IActionResult> GetAllClients()
        {
            var result = await _clientService.GetAllClients();
            return Ok(result);
        }
    }
}
