using Expenses.Domain.Interfaces;
using Expenses.Domain.Models;
using Expenses.Infrastructure.Data;
using Expenses.Infrastructure.Logic;
using Expenses.Infrastructure.Models;
using Expenses.Infrastructure.Models.Csv;
using Expenses.Infrastructure.Models.Extensions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.Infrastructure.Services
{
    public class TransactionDataService : ITransactionDataService
    {
        public void UpdateTransaction(Transaction updatedTransaction)
        {
            var context = new ExpensesContext();
            var transactionDto = updatedTransaction.ToDto();
            transactionDto.Category = transactionDto.Category != null 
                ? context.Categories.FirstOrDefault(x => x.Id == transactionDto.Category.Id)
                : null;

            transactionDto.Subcategory = transactionDto.Subcategory != null 
                ? context.Subcategories.FirstOrDefault(x => x.Id == transactionDto.Subcategory.Id)
                : null;

            context.Transactions.Update(transactionDto);

            context.SaveChanges();

            Console.WriteLine($"Updated transaction: {transactionDto.Id}");
        }

        public async Task AddTransactionsToAccount(Account account, Stream stream)
        {
            var context = new ExpensesContext();

            var reader = new ReadCsvService();
                var csvRecords = reader.ReadCsv(stream);
                var transactions = IngTransactionDto.ToTransactionDto(csvRecords);

            var accountDto = context.Accounts
               .Include(x => x.Transactions).ThenInclude(x => x.Category)
               .Include(x => x.Transactions).ThenInclude(x => x.Subcategory)
               .First(x => Equals(x.Iban, account.Iban));

            var transactionsToAdd = new List<TransactionDto>();
            foreach (var transaction in transactions)
            {
                var queryResult = accountDto.Transactions
                    .FirstOrDefault(x => 
                        x.Date.Equals(transaction.Date) && 
                        x.CounterIban.Equals(transaction.CounterIban) && 
                        x.Amount.Equals(transaction.Amount) && 
                        x.Description.Equals(transaction.Description));
                if (queryResult == null)
                    transactionsToAdd.Add(transaction);
            }
                      
            accountDto.Transactions.AddRange(transactionsToAdd);

            await context.SaveChangesAsync();           
            
        }


    }
}
