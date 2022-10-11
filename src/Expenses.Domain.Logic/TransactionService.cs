using Expenses.Domain.Models;

namespace Expenses.Domain.Logic
{
    internal class TransactionService
    {
        public void MatchTransactionToFixedExpense(Transaction transaction, FixedExpense fixedExpense)
        {
            transaction.SetFixedFinance(fixedExpense);
        }
    }
}
