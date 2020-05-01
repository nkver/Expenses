using Expenses.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.Logic
{
    public class CreateDbRecords
    {
        private readonly Expenses.Data.ExpensesContext _context;
        public CreateDbRecords(Expenses.Data.ExpensesContext context)
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
                var records = await reader.DoReadTinyCsv(stream);
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

                Console.WriteLine("Done writing records");
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
            return  await _context.Categories.OrderBy(x => x.Name).ToListAsync();
        }
        
        public async Task DeleteCategory(int id)
        {
            var cat = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(cat);
            await _context.SaveChangesAsync();
        }

        public async Task AddSubCategory(Subcategory subCategory)
        {
            await _context.Subcategories.AddAsync(subCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Subcategory>> GetSubCategoriesFor(int categoryId)
        {
            return await _context.Subcategories.Where(x => x.CategoryId.Equals(categoryId)).OrderBy(x => x.Name).ToListAsync();
        }

        public async Task DeleteSubCategory(int id)
        {
            var cat = await _context.Subcategories.FindAsync(id);
            _context.Subcategories.Remove(cat);
            await _context.SaveChangesAsync();
        }

        private bool TransactionExists(Guid id)
        {
            return _context.Transactions.Any(e => e.Id == id);
        }

    }
}
