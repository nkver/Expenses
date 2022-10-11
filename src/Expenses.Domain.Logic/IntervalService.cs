using Expenses.Domain.Models.Options;
using System;

namespace Expenses.Domain.Logic
{
    public class IntervalService
    {
        public int NumberOfDaysPer(Interval interval, DateTime referenceDate)
        {
            if (interval.Equals(Interval.Daily))
                return 1;
            if (interval.Equals(Interval.Weekly))
                return 7;
            if (interval.Equals(Interval.Monthly))
                return (referenceDate.AddMonths(1) - referenceDate).Days;
            if (interval.Equals(Interval.Quarterly))
                return (referenceDate.AddMonths(3) - referenceDate).Days;
            if (interval.Equals(Interval.HalfYearly))
                return (referenceDate.AddMonths(6) - referenceDate).Days;
            if (interval.Equals(Interval.Yearly))
                return (referenceDate.AddYears(1) - referenceDate).Days;
            return 0;
        }


    }
}
