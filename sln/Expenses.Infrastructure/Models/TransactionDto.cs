using System;
using System.ComponentModel.DataAnnotations;

namespace Expenses.Infrastructure.Models
{
    public class TransactionDto
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string MyIban { get; set; }
        public string CounterIban { get; set; }
        public ushort Direction { get; set; }
        public decimal Amount { get; set; }
        public ushort Method { get; set; }
        public string Comments { get; set; }
        public CategoryDto Category { get; set; }
        public SubcategoryDto Subcategory { get; set; }
        public bool IsProcessed { get; set; }    
       
    }
}
