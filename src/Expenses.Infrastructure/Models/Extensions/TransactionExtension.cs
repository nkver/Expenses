using Expenses.Domain.Models;
using Expenses.Domain.Options;
using System.Collections.Generic;
using System.Linq;

namespace Expenses.Infrastructure.Models.Extensions
{
    public static class TransactionExtension
    {
        public static TransactionDto ToDto(this Transaction input)
        {
            return new TransactionDto
            {
                Id = input.Id,
                Date = input.Date,
                Description = input.Description,
                MyIban = input.IbanFrom,
                CounterIban = input.IbanTo,
                Direction = (ushort)input.Direction,
                Amount = input.Amount,
                Method = (ushort)input.Method,
                Comments = input.Comments,
                Category = input.Category?.ToDto(),
                Subcategory = input.Subcategory?.ToDto(),
                IsProcessed = input.IsProcessed
            };
        }


        public static List<TransactionDto> ToDto(this IEnumerable<Transaction> input)
        {
            return input.Select(ToDto).ToList();
        }

        public static Transaction ToDomainModel(this TransactionDto input)
        {
            var transactionDirection = (TransactionDirection)input.Direction;
            var transactionMethod = (TransactionMethod)input.Method;

            return new Transaction(input.Id,
                    input.Date,
                    input.Description,
                    input.MyIban,
                    input.CounterIban,
                    transactionDirection,
                    input.Amount,
                    transactionMethod,
                    input.Comments,
                    input.Category?.ToDomainModel(),
                    input.Subcategory?.ToDomainModel(),
                    input.IsProcessed);
        }

        public static List<Transaction> ToDomainModel(this IEnumerable<TransactionDto> input)
        {
            return input.Select(ToDomainModel).ToList();
        }
    }
}

