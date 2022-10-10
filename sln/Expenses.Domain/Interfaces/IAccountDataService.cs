using Expenses.Domain.Models;
using System.Collections.Generic;

namespace Expenses.Domain.Interfaces
{
    public interface IAccountDataService
    {
        Account CreateNewAccount(Account account);
        Account GetAccountFor(string iban);

        List<Account> GetAllAccounts();

        Account UpdateBalanceFor(Account account, decimal balance);

    }
}
