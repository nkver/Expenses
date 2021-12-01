using Expenses.Domain.Models;
using Expenses.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.Infrastructure.Logic
{
    public class ExpensesData
    {
        private readonly ExpensesContext _context;
        public ExpensesData(ExpensesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetTransactions()
        {
            return await _context.Transactions.OrderBy(x => x.Date).ToListAsync();
        }

        public async Task UpdateTransaction(Transaction transaction)
        {
            _context.Transactions.Update(transaction);

            await _context.SaveChangesAsync();

            Console.WriteLine($"Updated transaction: {transaction.Id}");
        }

        public async Task AddTransactions(Stream stream)
        {
            {
                var reader = new ReadCsvService();
                var records = await reader.DoReadCsv(stream);
                var recordCount = records.Count();            

                Console.WriteLine("Inserting {0} transactions in DataBase", records.Count());

                using (var progress = new ProgressBar())
                {
                    double currentCount = 0;
                    foreach (var record in records)
                    {
                        progress.Report(currentCount / recordCount);
                        currentCount += 1;
                        await _context.Transactions.AddAsync(record);
                        _context.SaveChanges();
                    }
                }

                Log.Debug("Done writing records");
            }
        }

        public async Task AddCategory(string categoryName)
        {
            var category = new Category() { Name = categoryName };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return _context.Categories
                .OrderBy(x => x.Name)
                .Include(cat => cat.Subcategories)
                .ToList();
        }
        
        public async Task DeleteCategory(int id)
        {
            var currentCategory = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(currentCategory);
            await _context.SaveChangesAsync();

            Log.Debug($"Deleted category: {currentCategory.Name}");
        }

        public async Task AddSubCategory(Subcategory subCategory)
        {
            await _context.Subcategories.AddAsync(subCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Subcategory>> GetSubCategoriesFor(int categoryId)
        {
            return await _context.Subcategories.Where(x => x.CategoryId.Equals(categoryId))
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task DeleteSubCategory(int id)
        {
            var currentCategory = await _context.Subcategories.FindAsync(id);
            _context.Subcategories.Remove(currentCategory);
            await _context.SaveChangesAsync();

            Log.Debug($"Deleted subcategory: {currentCategory.Name}");
        }

        public async Task AddFixedExpense(FixedExpense fixedExpense)
        {
            await _context.FixedExpenses.AddAsync(fixedExpense);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FixedExpense>> GetFixedExpenses()
        {
            return await _context.FixedExpenses.ToListAsync();
        }

        public async Task UpdateFixedExpense(FixedExpense fixedExpense)
        {
            _context.FixedExpenses.Update(fixedExpense);

            await _context.SaveChangesAsync();

            Log.Debug($"Updated fixed expense: {fixedExpense.Description}");
        }

        public async Task DeleteFixedExpense(Guid id)
        {
            var currentExpense = await _context.FixedExpenses.FirstOrDefaultAsync(x => x.Id == id);
            _context.FixedExpenses.Remove(currentExpense);
            await _context.SaveChangesAsync();

            Log.Debug($"Deleted fixed expense: {currentExpense.Description}");
        }

        public async Task AddIncome(Income income)
        {
            await _context.Incomes.AddAsync(income);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Income>> GetIncomes()
        {
            return await _context.Incomes.ToListAsync();
        }

        public async Task UpdateIncome(Income income)
        {
            _context.Incomes.Update(income);

            await _context.SaveChangesAsync();

            Log.Debug($"Updated income: {income.Description}");
        }

        public async Task DeleteIncome(int id)
        {
            var currentIncome = await _context.Incomes.FindAsync(id);
            _context.Incomes.Remove(currentIncome);
            await _context.SaveChangesAsync();

            Log.Debug($"Deleted income: {currentIncome.Description}");
        }


    }
}
