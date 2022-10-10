using Expenses.Shared;

namespace Expenses.Domain.Models.Options
{
    public class Interval : TypeSafeEnum
    {
        public static readonly Interval Daily = new Interval(1, "Dag");
        public static readonly Interval Weekly = new Interval(3, "Week");
        public static readonly Interval Monthly = new Interval(4, "Maand");
        public static readonly Interval Quarterly = new Interval(5, "Kwartaal");
        public static readonly Interval HalfYearly = new Interval(6, "Halfjaar");
        public static readonly Interval Yearly = new Interval(7, "Jaar");


        private Interval (int id, string DisplayName) : base(id, DisplayName)
        { }

    }
}
