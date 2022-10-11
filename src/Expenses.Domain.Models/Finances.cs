using System.Collections.Generic;

namespace Expenses.Domain.Models
{
    public class Finances
    {
        public decimal Balance { get; set; }
        public List<FixedTransaction> FixedTransaction { get; set; }
    }
}
