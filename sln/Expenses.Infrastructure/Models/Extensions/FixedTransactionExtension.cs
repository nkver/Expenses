using Expenses.Domain.Models;
using Expenses.Domain.Options;
using System.Collections.Generic;
using System.Linq;

namespace Expenses.Infrastructure.Models.Extensions
{
    public static class FixedTransactionExtension
    {
        public static FixedTransactionDto ToDto(this FixedTransaction input)
        {
            return new FixedTransactionDto
            {
                Id = input.Id,
                Description = input.Description,
                CounterParty = input.CounterParty,
                Amount = input.Amount,
                TransactionIntervalId = (uint)input.TransactionInterval,
                StartDate = input.StartDate,
                EndDate = input.EndDate,
                TransactionDirectionId = (uint)input.TransactionDirection,
                Category = input.Category?.ToDto(),
                Subcategory = input.Subcategory?.ToDto()
            };
        }


        public static List<FixedTransactionDto> ToDto(this IEnumerable<FixedTransaction> input)
        {
            return input.Select(ToDto).ToList();
        }

        public static FixedTransaction ToDomainModel(this FixedTransactionDto input)
        {
            return new FixedTransaction(
                input.Id,
                    input.Description,
                    input.CounterParty,
                    input.Amount,
                    (Interval)input.TransactionIntervalId,
                    input.StartDate,
                    input.EndDate,
                    (TransactionDirection)input.TransactionDirectionId,
                    input.Category?.ToDomainModel(),
                    input.Subcategory?.ToDomainModel()
                    );
        }

        public static List<FixedTransaction> ToDomainModel(this IEnumerable<FixedTransactionDto> input)
        {
            return input.Select(ToDomainModel).ToList();
        }
    }
}

