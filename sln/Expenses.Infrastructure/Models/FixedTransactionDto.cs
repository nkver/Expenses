using System;
using System.ComponentModel.DataAnnotations;

namespace Expenses.Infrastructure.Models
{
    public class FixedTransactionDto
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string CounterParty { get; set; }
        public decimal Amount { get; set; }
        public uint TransactionIntervalId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public uint TransactionDirectionId { get; set; }
        public CategoryDto Category { get; set; }
        public SubcategoryDto Subcategory { get; set; }       

    }
}
