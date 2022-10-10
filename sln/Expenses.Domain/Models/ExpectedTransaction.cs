using Expenses.Domain.Options;
using System;

namespace Expenses.Domain.Models
{
    public class ExpectedTransaction
    {
        public string Description { get; }
        public string Counterparty { get; }
        public decimal Amount { get; }
        public TransactionDirection TransactionDirection { get; }
        public DateTime TransactionDate { get; }

        public ExpectedTransaction(string description, string counterparty, decimal amount, TransactionDirection transactionDirection, DateTime transactionDate)
        {
            Description = description;
            Counterparty = counterparty;
            Amount = amount;
            TransactionDirection = transactionDirection;
            TransactionDate = transactionDate;
        }
    }
}
