using Expenses.Domain.Interfaces;
using Expenses.Domain.Models;
using Expenses.Domain.Options;
using System.Collections.Generic;
using System.Linq;

namespace Expenses.Domain.Services
{
    public class AccountService
    {
        private readonly IAccountDataService _accountDataService;

        public AccountService (IAccountDataService accountDataService)
        {
            _accountDataService = accountDataService;
        }

        public List<Account> GetAllAccounts()
        {
            var accounts = _accountDataService.GetAllAccounts();

            foreach (var account in accounts)
            {
                UpdateBalance(account);
            }

            return accounts;
        }

        public Account UpdateBalance(Account account)
        {
            var balance = account.Balance;

            var withdrawalsToBeProcessed = account.Transactions.Where(x => !x.IsProcessed && Equals(x.Direction, TransactionDirection.Withdrawal));
            var depositsToBeProcessed = account.Transactions.Where(x => !x.IsProcessed && Equals(x.Direction, TransactionDirection.Deposit));

            foreach (var transaction in withdrawalsToBeProcessed)
            {
                balance -= transaction.Amount;
            }

            foreach (var transaction in depositsToBeProcessed)
            {
                balance -= transaction.Amount;
            }

            return _accountDataService.UpdateBalanceFor(account, balance);
        }

        public Account CreateNewAccount(string iban, string displayName, decimal balance, AccountType type)
        {
            return _accountDataService.CreateNewAccount(new Account(iban, displayName, balance, type));
        }



    }
}
