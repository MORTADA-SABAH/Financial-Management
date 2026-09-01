namespace Financial_Management.DTOs
{
    public class TransactionFilterDto
    {
        public int? ClientId { get; set; }
        public int ?ExpenseCategoryId { get; set; }
        public int? TransactionType { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
