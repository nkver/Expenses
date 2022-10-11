using Expenses.Domain.Options;
using System.Collections.Generic;

namespace Expenses.Domain.Models
{
    public class Account
    {
        public string Iban { get; }
        public string DisplayName { get; }

        public decimal Balance { get; }

        public List<Transaction> Transactions { get; }

        public AccountType Type { get; }


        public Account(string iban, string displayName, decimal balance, List<Transaction> transactions, AccountType type)
        {
            Iban = iban;
            DisplayName = displayName;
            Transactions = transactions;
            Balance = balance;
            Type = type;
        }

        public Account(string iban, string displayName, decimal balance, AccountType type) : this(iban, displayName, balance, new List<Transaction>(), type)
        {

        }
    }
}
