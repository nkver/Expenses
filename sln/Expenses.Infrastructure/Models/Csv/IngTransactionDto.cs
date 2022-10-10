using Expenses.Domain.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Expenses.Infrastructure.Models.Csv
{
    public class IngTransactionDto
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string MyIban { get; set; }
        public string CounterIban { get; set; }
        public string MethodCode { get; set; }
        public string OnOff { get; set; }
        public decimal Amount { get; set; }
        public string MethodDescription { get; set; }
        public string Comments { get; set; }
        public decimal Balance { get; set; }

        public static TransactionDto ToTransactionDto(IngTransactionDto input)
        {
            return new TransactionDto
            {
                Date = input.Date,
                Description = input.Description,
                MyIban = input.MyIban,
                CounterIban = input.CounterIban,
                Direction = MapDirection(input.OnOff),
                Amount = input.Amount,
                Method = MapMethod(input.MethodCode),
                Comments = input.Comments,
                IsProcessed = false,
            };
        }
        public static List<TransactionDto> ToTransactionDto(IEnumerable<IngTransactionDto> input)
        {
            return input.Select(ToTransactionDto).ToList();
        }


        private static ushort MapMethod(string code)
        {
            return
                Equals(code, "GT")
                ? (ushort)TransactionMethod.OnlineBanking
                    : Equals(code, "BA")
                 ? (ushort)TransactionMethod.PayTerminal
                    : Equals(code, "DV")
                 ? (ushort)TransactionMethod.Others
                    : Equals(code, "GM")
                 ? (ushort)TransactionMethod.ATM
                    : Equals(code, "OV")
                 ? (ushort)TransactionMethod.Transfer
                    : Equals(code, "IC")
                 ? (ushort)TransactionMethod.Collection
                    : Equals(code, "VZ")
                 ? (ushort)TransactionMethod.CollectivePayment
                    : Equals(code, "ID")
                 ? (ushort)TransactionMethod.CollectivePayment
                    : throw new InvalidDataException($"Unknown transaction method code: {code}");
        }

        private static ushort MapDirection(string code)
        {
            return Equals(code, "Bij")
                ? (ushort)TransactionDirection.Deposit
                : Equals(code, "Af")
                ? (ushort)TransactionDirection.Withdrawal
                : throw new InvalidDataException($"Unknown transaction direction code: {code}");
        }
    }
}
