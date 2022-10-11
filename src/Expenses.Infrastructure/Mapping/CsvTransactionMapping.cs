using Expenses.Infrastructure.Models.Csv;
using TinyCsvParser.Mapping;
using TinyCsvParser.TypeConverter;

namespace Expenses.Infrastructure.Mapping
{
    public class IngCsvTransactionMapping : CsvMapping<IngTransactionDto>
    {
        public IngCsvTransactionMapping() : base()
        {
            MapProperty(0, x => x.Date, new DateTimeConverter("yyyyMMdd"));
            MapProperty(1, x => x.Description);
            MapProperty(2, x => x.MyIban);
            MapProperty(3, x => x.CounterIban);
            MapProperty(4, x => x.MethodCode);
            MapProperty(5, x => x.OnOff);
            MapProperty(6, x => x.Amount);
            MapProperty(7, x => x.MethodDescription);
            MapProperty(8, x => x.Comments);
            MapProperty(9, x => x.Balance);
        }
    }
}
