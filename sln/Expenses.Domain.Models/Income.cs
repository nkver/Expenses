using Expenses.Domain.Models.Options;
using System;

namespace Expenses.Domain.Models
{
    public class Income
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public double Amount { get; set; }
        public Interval PaymentInterval { get; set; }
        public DateTime StartDate { get; set; }
        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }

    }
}