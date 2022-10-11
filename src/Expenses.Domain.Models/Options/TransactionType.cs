using Expenses.Shared;

namespace Expenses.Domain.Models.Options
{
    public class TransactionType : TypeSafeEnum
    {
        public static readonly TransactionType Income = new TransactionType(1, "Inkomen");
        public static readonly TransactionType Expense = new TransactionType(2, "Uitgave");

        private TransactionType(int id, string DisplayName) : base(id, DisplayName) { }
    }
}
