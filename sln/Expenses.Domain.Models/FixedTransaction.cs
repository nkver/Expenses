using Expenses.Domain.Models.Options;
using System;

namespace Expenses.Domain.Models
{
    public class FixedTransaction
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string CounterParty { get; set; }
        public decimal Amount { get; set; }
        public Interval TransactionInterval { get; set; }
        public DateTime? StartDate { get; set; }

        public DateTime? NextTransactionDate { get; set; }

        public TransactionType TransactionType { get; set; }
        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }

        public FixedTransaction() { }

        public FixedTransaction(string description, string counterParty, decimal amount, Interval collectionInterval, DateTime? startDate, TransactionType transactionType, Category category, Subcategory subcategory)
        {
            Description = description;
            CounterParty = counterParty;
            Amount = amount;
            TransactionInterval = collectionInterval;
            StartDate = startDate;
            NextTransactionDate = startDate;
            TransactionType = transactionType;
            Category = category;
            Subcategory = subcategory;
        }

        public void SetNextTransactionDateTo(DateTime date)
        {
            NextTransactionDate = date;
        }

        public void SetNextTransactionDate()
        {
            if (NextTransactionDate == null)
                return;

            var newDate = (DateTime)NextTransactionDate;

            if (TransactionInterval.Equals(Interval.Daily))
                newDate.AddDays(1);
            if (TransactionInterval.Equals(Interval.Weekly))
                newDate.AddDays(7);
            if (TransactionInterval.Equals(Interval.Monthly))
                newDate.AddMonths(1); 
            if (TransactionInterval.Equals(Interval.Quarterly))
                newDate.AddMonths(3); 
            if (TransactionInterval.Equals(Interval.HalfYearly))
                newDate.AddMonths(6); 
            if (TransactionInterval.Equals(Interval.Yearly))
                newDate.AddYears(1);

            NextTransactionDate = newDate;
        }

        public void SetPreviousTransactionDate()
        {
            if (NextTransactionDate == null)
                return;

            var newDate = (DateTime)NextTransactionDate;

            if (TransactionInterval.Equals(Interval.Daily))
                newDate.AddDays(-1);
            if (TransactionInterval.Equals(Interval.Weekly))
                newDate.AddDays(-7);
            if (TransactionInterval.Equals(Interval.Monthly))
                newDate.AddMonths(-1);
            if (TransactionInterval.Equals(Interval.Quarterly))
                newDate.AddMonths(-3);
            if (TransactionInterval.Equals(Interval.HalfYearly))
                newDate.AddMonths(-6);
            if (TransactionInterval.Equals(Interval.Yearly))
                newDate.AddYears(-1);

            NextTransactionDate = newDate;
        }

    }
}
