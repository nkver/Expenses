using Expenses.Domain.Models;
using Expenses.Domain.Options;
using System;
using System.ComponentModel.DataAnnotations;

namespace Expenses.Models
{
    public class FixedTransactionForm
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public string CounterParty { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public Interval TransactionInterval { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        public TransactionDirection TransactionDirection { get; set; }
        public string CategoryId { get; set; }
        public string SubcategoryId { get; set; }
    }
}
