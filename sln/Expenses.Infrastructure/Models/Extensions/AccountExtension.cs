using Expenses.Domain.Models;
using Expenses.Domain.Options;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Expenses.Infrastructure.Models.Extensions
{
    public static class AccountExtension
    {
        public static AccountDto ToDto(this Account account)
        {
            var transactions = account.Transactions.ToDto();
            return new AccountDto
            {
                Iban = account.Iban,
                DisplayName = account.DisplayName,
                Balance = account.Balance,
                Transactions = transactions.ToList(),
                Type = (ushort)account.Type
            };
        }

        public static List<AccountDto> ToDto(this IEnumerable<Account> accounts)
        {
            return accounts.Select(ToDto).ToList();
        }

        public static Account ToDomainModel(this AccountDto accountDto)
        {
            var accountType = accountDto.Type == 1
                ? AccountType.Checking
                : accountDto.Type == 2
                ? AccountType.Saving
                : throw new InvalidDataException($"Error mapping AccountDto to domain model. Unknown AccountType: {accountDto.Type}");

            return new Account(accountDto.Iban, accountDto.DisplayName, accountDto.Balance, accountDto.Transactions.ToDomainModel(), accountType);
        }

        public static List<Account> ToDomainModel(this IEnumerable<AccountDto> accountDtos)
        {
            return accountDtos.Select(ToDomainModel).ToList();
        }
    }
}
