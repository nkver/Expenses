using Expenses.Domain.Models;
using TinyCsvParser.Mapping;
using TinyCsvParser.TypeConverter;

namespace Expenses.Infrastructure.Mapping
{
    public class CsvTransactionMapping : CsvMapping<Transaction>
    {
        public CsvTransactionMapping() : base ()
        {
            MapProperty(0, x => x.Date, new DateTimeConverter("yyyyMMdd"));
            MapProperty(1, x => x.Name);
            MapProperty(2, x => x.IbanFrom);
            MapProperty(3, x => x.IbanTo);
            MapProperty(4, x => x.Code);
            MapProperty(5, x => x.OnOff);
            MapProperty(6, x => x.Amount);
            MapProperty(7, x => x.Kind);
            MapProperty(8, x => x.Description);
        }
    }
}
