using System;
using System.Collections.Generic;

namespace Expenses.Domain.Models
{
    public class ExpectedBalance
    {
        public DateTime Date { get; }
        public decimal Balance { get; }
        public IEnumerable<ExpectedTransaction> ExpectedTransactions { get; }

        public ExpectedBalance(DateTime date, decimal balance, IEnumerable<ExpectedTransaction> expectedTransactions)
        {
            Date = date;
            Balance = balance;
            ExpectedTransactions = expectedTransactions;
        }
    }
}
