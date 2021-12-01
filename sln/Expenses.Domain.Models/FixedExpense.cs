using Expenses.Domain.Models.Options;
using System;

namespace Expenses.Domain.Models
{
    public class FixedExpense
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Creditor { get; set; }
        public double Amount { get; set; }
        public Interval CollectionInterval { get; set; }
        public DateTime? StartDate { get; set; }
        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }

        public FixedExpense() { }

        public FixedExpense(string description, string creditor, double amount, Interval collectionInterval, DateTime? startDate, Category category, Subcategory subcategory)
        {
            Description = description;
            Creditor = creditor;
            Amount = amount;
            CollectionInterval = collectionInterval;
            StartDate = startDate;
            Category = category;
            Subcategory = subcategory;
        }

    }
}
