using Expenses.Domain.Interfaces;
using Expenses.Domain.Models;
using Expenses.Infrastructure.Data;
using Expenses.Infrastructure.Models;
using Expenses.Infrastructure.Models.Extensions;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Expenses.Infrastructure.Services
{
    public class FixedTransactionDataService : IFixedTransactionDataService
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

        public void AddFixedTransaction(string description, string counterParty, decimal amount, ushort transactionIntervalId, 
            DateTime startDate, DateTime? endDate, ushort transactionDirectionId, uint? categoryId, uint? subcategoryId)
        {
            var context = new ExpensesContext(); 

            var fixedTransactionDto = new FixedTransactionDto
            {
                Description = description,
                CounterParty = counterParty,
                Amount = amount,
                TransactionIntervalId = transactionIntervalId,
                StartDate = startDate,
                EndDate = endDate,
                TransactionDirectionId = transactionDirectionId,
            };

            fixedTransactionDto.Category = categoryId != null
                ? context.Categories.FirstOrDefault(x => x.Id == categoryId)
                : null;

            fixedTransactionDto.Subcategory = subcategoryId != null
                ? context.Subcategories.FirstOrDefault(x => x.Id == subcategoryId)
                : null;

            context.FixedTransactions.Add(fixedTransactionDto);

            context.SaveChanges();        
            
        }

        public List<FixedTransaction> GetFixedTransactions()
        {
            var context = new ExpensesContext();
            var queryResult = context.FixedTransactions;
            return queryResult.ToDomainModel();
        }

        public void UpdateFixedTransaction(FixedTransaction fixedTransaction)
        {
            var context = new ExpensesContext();

            context.FixedTransactions.Update(fixedTransaction.ToDto());

            context.SaveChanges();

            Log.Debug($"Updated fixed expense: {fixedTransaction.Description}");
        }

        public void DeleteFixedTransaction(Guid id)
        {
            var context = new ExpensesContext();
            var queryResult = context.FixedTransactions.FirstOrDefault(x => x.Id == id);
            context.FixedTransactions.Remove(queryResult);
            context.SaveChanges();

            Log.Debug($"Deleted fixed transaction: {queryResult.Description}");
        }

    }
}
