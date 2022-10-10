using Expenses.Domain.Models;
using Expenses.Domain.Models.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Expenses.Domain.Logic
{
    public class FinancesService
    {
        public decimal GetBalance(Finances finances)
        {
            return finances.Balance;
        }

        public decimal GetBalanceForDate(Finances finances, DateTime currentDate, DateTime referenceDate)
        {
            var balance = finances.Balance;
            if (referenceDate.Date < currentDate.Date)
                return balance;

            var transactionsInTimeSpan = GetExpectedTransactionsBetween(finances, currentDate, referenceDate);

            foreach (var expense in transactionsInTimeSpan.Where(x => x.TransactionType == TransactionType.Expense))
            {
                balance -= expense.Amount;
            }

            foreach (var income in transactionsInTimeSpan.Where(x => x.TransactionType == TransactionType.Income))
            {
                balance += income.Amount;
            }

            return balance;
        }

        private List<FixedTransaction> GetExpectedTransactionsBetween(Finances finances, DateTime startDate, DateTime endDate)
        {   
            
            var expectedTransactions = new List<FixedTransaction>();

            foreach (var transaction in finances.FixedTransaction)
            {
                var currentTransactionDate = transaction.NextTransactionDate;

                while (transaction.NextTransactionDate <= endDate && transaction.NextTransactionDate > transaction.StartDate)
                {
                    expectedTransactions.Add(transaction);
                    transaction.SetNextTransactionDate();
                }
                transaction.NextTransactionDate = currentTransactionDate;
                transaction.SetPreviousTransactionDate();

                while (transaction.NextTransactionDate >= startDate && transaction.NextTransactionDate > transaction.StartDate)
                {
                    expectedTransactions.Add(transaction);
                    transaction.SetPreviousTransactionDate();
                }
                transaction.NextTransactionDate = currentTransactionDate;
            }

            return expectedTransactions.OrderBy(x => x.Id).ThenBy(x => x.NextTransactionDate).ToList();
        }

    }
}
