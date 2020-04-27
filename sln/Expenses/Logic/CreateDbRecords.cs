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
            var category = new Category(categoryName);
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetCategories()
        {
            return  await _context.Categories.OrderBy(x => x.Value).ToListAsync();
        }
        
        public async Task DeleteCategory(int id)
        {
            var cat = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(cat);
            await _context.SaveChangesAsync();
        }

    }
}
