using Expenses.Domain.Options;
using System;

namespace Expenses.Domain.Interfaces
{
    public interface IIntervalService
    {
        DateTime GetNextTransactionDate(DateTime date, Interval interval);
        DateTime GetPreviousTransactionDate(DateTime date, Interval interval);
    }
}
