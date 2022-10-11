using Expenses.Domain.Options;
using System;

namespace Expenses.Domain.Models
{
    public class Transaction
    {
        public Guid Id { get; }

        public DateTime Date { get; }
        public string Description { get; }
        public string IbanFrom { get; }
        public string IbanTo { get; }
        public TransactionDirection Direction { get; }
        public decimal Amount { get; }
        public TransactionMethod Method { get; }
        public string Comments { get; }
        public Category Category { get; private set; }
        public Subcategory Subcategory { get; private set; }
        public bool IsProcessed { get; }

        public Transaction(Guid id, DateTime date, string description, string ibanFrom, string ibanTo, TransactionDirection direction, 
            decimal amount, TransactionMethod method, string comments, Category category, Subcategory subcategory, bool isProcessed)
        {
            Id = id;
            Date = date;
            Description = description;
            IbanFrom = ibanFrom;
            IbanTo = ibanTo;
            Direction = direction;
            Amount = amount;
            Method = method;
            Comments = comments;
            Category = category;
            Subcategory = subcategory;
            IsProcessed = isProcessed;
        }

        public void SetCategory(Category category)
        {
            Category = category;
        }

        public void SetSubCategory(Subcategory category)
        {
            Subcategory = category;
        }

    }
}
