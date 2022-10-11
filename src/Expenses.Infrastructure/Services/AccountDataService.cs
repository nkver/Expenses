using Expenses.Domain.Interfaces;
using Expenses.Domain.Models;
using Expenses.Infrastructure.Data;
using Expenses.Infrastructure.Models.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Expenses.Infrastructure.Services
{
    public class AccountDataService : IAccountDataService
    {
        private ExpensesContext _context;

        public AccountDataService(ExpensesContext context)
        {
            _context = context;
        }

        public Account CreateNewAccount(Account account)
        {
            _context.Accounts.Add(account.ToDto());
            _context.SaveChanges();

            var accountDto = _context.Accounts.First(x => x.Iban == account.Iban);

            return accountDto.ToDomainModel();
        }

        public Account GetAccountFor(string iban)
        {
            var accountDto = _context.Accounts.First(x => x.Iban == iban);

            return accountDto.ToDomainModel();
        }

        public Account UpdateBalanceFor(Account account, decimal balance)
        {
           var accountDto = _context.Accounts.First(x => x.Iban == account.Iban);
            accountDto.Balance = balance;

            foreach (var transaction in accountDto.Transactions.Where(x => x.IsProcessed == false))
            {
                transaction.IsProcessed = true;
            }

            _context.SaveChanges();

            return accountDto.ToDomainModel();
        }

        public List<Account> GetAllAccounts()
        {
            var accountDtos = _context.Accounts
                .Include(x => x.Transactions).ThenInclude(x => x.Category)
                .Include(x => x.Transactions).ThenInclude(x => x.Subcategory).ToList();

            return accountDtos.ToDomainModel();
        }
    }
}
