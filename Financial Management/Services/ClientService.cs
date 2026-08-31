using FinancialManagement.DataBase;
using FinancialManagement.DTOs;
using Microsoft.EntityFrameworkCore;

namespace FinancialManagement.Services
{
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext _context;

        public ClientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddClient(CreateClientDto dto)
        {
            var newClient = new FinancialManagement.Models.Client
            {
                Name = dto.Name,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address,
                CreatedAt = DateTime.Now
            };
            _context.Clients.Add(newClient);
            await _context.SaveChangesAsync();
            return newClient.Name;
        }

        public async Task<List<ClientResponseDto>> GetAllClients()
        {
            var clients = await _context.Clients
                .Select(c => new ClientResponseDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    PhoneNumber = c.PhoneNumber,
                    Date = c.CreatedAt
                })
                .ToListAsync();

            return clients;
        }
    }
}
