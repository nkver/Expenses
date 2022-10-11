using Expenses.Infrastructure.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Data.Common;

namespace Expenses.Infrastructure.Tests
{
    public class SqliteInMemoryTransactionDataServiceTest : TransactionDataServiceTest, IDisposable
    {
        private readonly DbConnection _connection;
        public SqliteInMemoryTransactionDataServiceTest() : base(new DbContextOptionsBuilder<ExpensesContext>()
            .UseSqlite(CreateInMemoryDatabase())
            .Options)
        {
            _connection = RelationalOptionsExtension.Extract(ContextOptions).Connection;
        }

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }

        public void Dispose() => _connection.Dispose();
    }
}
