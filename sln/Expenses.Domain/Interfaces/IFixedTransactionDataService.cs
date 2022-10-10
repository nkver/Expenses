using Expenses.Domain.Models;
using System;
using System.Collections.Generic;

namespace Expenses.Domain.Interfaces
{
    public interface IFixedTransactionDataService
    {
        void UpdateTransaction(Transaction updatedTransaction);
        void AddFixedTransaction(string description, string counterParty, decimal amount, ushort transactionIntervalId,
            DateTime startDate, DateTime? endDate, ushort transactionDirectionId, uint? categoryId, uint? subcategoryId);

        List<FixedTransaction> GetFixedTransactions();

        void UpdateFixedTransaction(FixedTransaction fixedTransaction);

        void DeleteFixedTransaction(Guid id);


    }
}
