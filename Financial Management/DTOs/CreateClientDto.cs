namespace FinancialManagement.DTOs
{
    public class CreateClientDto
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Address { get; set; }
    }
}
