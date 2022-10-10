using Expenses.Domain.Models;
using System;
using System.Collections.Generic;

namespace Expenses.Domain.Interfaces
{
    public interface IOverviewService
    {
        public List<ExpectedBalance> GetBalanceOverviewBetween(DateTime startDate, DateTime endDate, decimal currentBalance);
    }
}
