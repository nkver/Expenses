using Microsoft.EntityFrameworkCore;
using Expenses.Infrastructure.Models;

namespace Expenses.Infrastructure.Data
{
    public class ExpensesContext : DbContext
    {

        public ExpensesContext()
        {
        }
        public ExpensesContext(DbContextOptions<ExpensesContext> options)
            : base(options)
        {
        }

        public DbSet<AccountDto> Accounts { get; set; }
        public DbSet<TransactionDto> Transactions { get; set; }
        public DbSet<CategoryDto> Categories { get; set; }
        public DbSet<SubcategoryDto> Subcategories { get; set; }
        public DbSet<FixedTransactionDto> FixedTransactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=..\\Expenses.Infrastructure\\Data\\HouseHoldExpenses.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryDto>()
                .HasData(new CategoryDto() { Id = 1, Name = "Overig" } );

            modelBuilder.Entity<SubcategoryDto>()
                .HasData(new SubcategoryDto() { Id = 1, Name = "Overig", CategoryId = 1 });

       
        }
    }
}
