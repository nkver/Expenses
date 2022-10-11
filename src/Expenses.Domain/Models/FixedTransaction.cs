using Expenses.Domain.Options;
using System;

namespace Expenses.Domain.Models
{
    public class FixedTransaction
    {
        public Guid Id { get; }
        public string Description { get; }
        public string CounterParty { get; }
        public decimal Amount { get; }
        public Interval TransactionInterval { get; }
        public DateTime StartDate { get; }
        public DateTime? EndDate { get; }

        public TransactionDirection TransactionDirection { get; }
        public Category Category { get; }
        public Subcategory Subcategory { get; }

        public FixedTransaction(Guid id, string description, string counterParty, decimal amount, Interval transactionInterval, DateTime startDate, DateTime? endDate, TransactionDirection transactionType, Category category, Subcategory subcategory)
        {
            Id = id;
            Description = description;
            CounterParty = counterParty;
            Amount = amount;
            TransactionInterval = transactionInterval;
            StartDate = startDate;
            EndDate = endDate;
            TransactionDirection = transactionType;
            Category = category;
            Subcategory = subcategory;
        }

        public FixedTransaction(string description, string counterParty, decimal amount, Interval transactionInterval, DateTime startDate, DateTime? endDate, TransactionDirection transactionType, Category category, Subcategory subcategory)
        {
            Description = description;
            CounterParty = counterParty;
            Amount = amount;
            TransactionInterval = transactionInterval;
            StartDate = startDate;
            EndDate = endDate;
            TransactionDirection = transactionType;
            Category = category;
            Subcategory = subcategory;
        }

    }
}
