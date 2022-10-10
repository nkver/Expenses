using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Expenses.Infrastructure.Models
{
    public class AccountDto
    {
        [Key]
        public string Iban { get; set; }
        public string DisplayName { get; set; }

        public decimal Balance { get; set; }

        public List<TransactionDto> Transactions { get; set; }

        public ushort Type { get; set;  }

    }
}
