using FinancialManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialManagement.DataBase
{
    public class ApplicationDbContext : DbContext
    {  // هذا السطر هوه حلقة الوصل بين الكود والداتابيس 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        public DbSet<Client> Clients { get; set; }
        public DbSet<MoneyManagement> MoneyManagements { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
    }
}
