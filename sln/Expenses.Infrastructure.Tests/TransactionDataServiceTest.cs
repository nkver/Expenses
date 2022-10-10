using Expenses.Domain.Models;
using Expenses.Infrastructure.Data;
using Expenses.Infrastructure.Models;
using Expenses.Infrastructure.Models.Extensions;
using Expenses.Infrastructure.Services;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace Expenses.Infrastructure.Tests
{

    public abstract class TransactionDataServiceTest 
    {
        private readonly Account _account;
        protected DbContextOptions<ExpensesContext> ContextOptions { get; }

        protected TransactionDataServiceTest(DbContextOptions<ExpensesContext> contextOptions)
        {
            ContextOptions = contextOptions;
            _account = new Account("NL00TEST0000000001", "TestingAccount", 1000m, Domain.Options.AccountType.Checking);

            Seed();
        }


        private void Seed()
        {
            using (var context = new ExpensesContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var accountDto = _account.ToDto();

                context.Accounts.Add(accountDto);

                context.SaveChanges();
            }
        }

        [Fact]
        public async Task AddTransactionsToAccount_AddsAndSavesTransactions()
        {
            using (var context = new ExpensesContext(ContextOptions))
            {
                var service = new TransactionDataService();

                var pathToFile = $"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}{Path.DirectorySeparatorChar}test.csv";

                if (!File.Exists(pathToFile))
                    throw new FileNotFoundException($"File not found at path {pathToFile}");

                FileStream fs = File.Open(pathToFile, FileMode.Open);

                var reader = new StreamReader(fs);
                
                await service.AddTransactionsToAccount(_account, fs);
                


                var accountDto = context.Accounts.First(x => Equals(x.Iban, _account.Iban));

                using (new AssertionScope())
                {
                    accountDto.Transactions.Count.Should().Be(9);
                }



            }
        }

      
    }
}
