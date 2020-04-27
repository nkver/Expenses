using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Expenses.Models;

namespace Expenses.Data
{
    public class ExpensesContext : IdentityDbContext
    {
        public ExpensesContext()
        { }
        public ExpensesContext(DbContextOptions<ExpensesContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}
