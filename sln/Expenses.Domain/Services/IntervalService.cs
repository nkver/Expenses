using Expenses.Domain.Interfaces;
using Expenses.Domain.Options;
using System;

namespace Expenses.Domain.Services
{
    public class IntervalService : IIntervalService
    {
        public DateTime GetNextTransactionDate(DateTime date, Interval interval)
        {

            if (interval.Equals(Interval.Daily))
                return date.AddDays(1);
            if (interval.Equals(Interval.Weekly))
                return date.AddDays(7);
            if (interval.Equals(Interval.Monthly))
                return date.AddMonths(1);
            if (interval.Equals(Interval.Quarterly))
                return date.AddMonths(3);
            if (interval.Equals(Interval.HalfYearly))
                return date.AddMonths(6);
            if (interval.Equals(Interval.Yearly))
                return date.AddYears(1);

            return date;
        }

        public DateTime GetPreviousTransactionDate(DateTime date, Interval interval)
        {

            if (interval.Equals(Interval.Daily))
                return date.AddDays(-1);
            if (interval.Equals(Interval.Weekly))
                return date.AddDays(-7);
            if (interval.Equals(Interval.Monthly))
                return date.AddMonths(-1);
            if (interval.Equals(Interval.Quarterly))
                return date.AddMonths(-3);
            if (interval.Equals(Interval.HalfYearly))
                return date.AddMonths(-6);
            if (interval.Equals(Interval.Yearly))
                return date.AddYears(-1);

            return date;
        }
    }
}
