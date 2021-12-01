using Microsoft.EntityFrameworkCore;
using Expenses.Domain.Models;
using System.Runtime.InteropServices.ComTypes;
using Expenses.Domain.Models.Options;

namespace Expenses.Infrastructure.Data
{
    public class ExpensesContext : DbContext
    {
        public ExpensesContext()
        { }
        public ExpensesContext(DbContextOptions<ExpensesContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<FixedExpense> FixedExpenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Interval> Intervals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(new Category() { Id = 1, Name = "Overig" });

            modelBuilder.Entity<Subcategory>()
                .HasData(new Subcategory() { CategoryId = 1, Id = 1, Name = "Overig" });

            modelBuilder.Entity<Interval>()
                .HasData(new Subcategory() { CategoryId = 1, Id = 1, Name = "Overig" });

        }
    }
}
