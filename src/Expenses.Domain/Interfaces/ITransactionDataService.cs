using Expenses.Domain.Models;
using System.IO;
using System.Threading.Tasks;

namespace Expenses.Domain.Interfaces
{
    public interface ITransactionDataService
    {
        void UpdateTransaction(Transaction updatedTransaction);

        Task AddTransactionsToAccount(Account account, Stream stream);


    }
}
