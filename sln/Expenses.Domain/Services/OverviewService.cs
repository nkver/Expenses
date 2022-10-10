using Expenses.Domain.Interfaces;
using Expenses.Domain.Models;
using Expenses.Domain.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Expenses.Domain.Services
{
    public class OverviewService : IOverviewService
    {
        private readonly IIntervalService _intervalService;
        private readonly IFixedTransactionDataService _transactionDataService;

        public OverviewService(IIntervalService intervalService, IFixedTransactionDataService transactionDataService)
        {
            _intervalService = intervalService;
            _transactionDataService = transactionDataService;
        }


        public List<ExpectedBalance> GetBalanceOverviewBetween(DateTime startDate, DateTime endDate, decimal currentBalance)
        {
            var expectedBalances = new List<ExpectedBalance>();
            var expectedTransactions = GetExpectedTransactionsBetween(startDate, endDate);

            var transactionDates = expectedTransactions.Select(x => x.TransactionDate.Date).Distinct().OrderBy(x => x).ToList();

            foreach (var date in transactionDates)
            {
                var transactionsOnDate = expectedTransactions.Where(x => x.TransactionDate.Date == date.Date);
                foreach (var transaction in transactionsOnDate)
                {
                    if (transaction.TransactionDirection.Equals(TransactionDirection.Deposit))
                        currentBalance += transaction.Amount;
                    if (transaction.TransactionDirection.Equals(TransactionDirection.Withdrawal))
                        currentBalance -= transaction.Amount;
                }

                expectedBalances.Add(new ExpectedBalance(date, currentBalance, transactionsOnDate));
            }

            return expectedBalances;

        }

        private List<ExpectedTransaction> GetExpectedTransactionsBetween(DateTime startDate, DateTime endDate)
        {
            var fixedTransactions = _transactionDataService.GetFixedTransactions();
            var expectedTransactions = new List<ExpectedTransaction>();

            foreach (var transaction in fixedTransactions.Where(x => x.StartDate! > endDate || (x.EndDate == null || x.EndDate! < startDate)))
            {
                var transactionDate = transaction.StartDate;
                while (transactionDate < startDate)
                {
                    transactionDate = _intervalService.GetNextTransactionDate(transactionDate, transaction.TransactionInterval);
                }

                while (transactionDate <= endDate)
                {
                    expectedTransactions.Add(new ExpectedTransaction(transaction.Description, transaction.CounterParty, transaction.Amount, transaction.TransactionDirection, transactionDate));
                    transactionDate = _intervalService.GetNextTransactionDate(transactionDate, transaction.TransactionInterval);
                }
            }

            return expectedTransactions;
        }
    }
}
