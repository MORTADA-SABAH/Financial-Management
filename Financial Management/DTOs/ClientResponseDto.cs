namespace FinancialManagement.DTOs
{
    public class ClientResponseDto
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
