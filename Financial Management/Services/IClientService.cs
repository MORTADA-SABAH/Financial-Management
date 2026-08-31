using FinancialManagement.DTOs;
using FinancialManagement.Models;

namespace FinancialManagement.Services
{
    public interface IClientService
    {
        Task<string> AddClient(CreateClientDto dto);
        Task<List<ClientResponseDto>> GetAllClients();
    }
}
