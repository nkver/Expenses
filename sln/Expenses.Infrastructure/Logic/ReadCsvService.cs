using TinyCsvParser;
using System.Text;
using Expenses.Infrastructure.Mapping;
using Expenses.Infrastructure.Models.Csv;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Expenses.Infrastructure.Logic
{
    public class ReadCsvService
    {
        public List<IngTransactionDto> ReadCsv(Stream stream)
        {
            var options = new CsvParserOptions(true, ';');
            var csvMapper = new IngCsvTransactionMapping();
            var csvParser = new CsvParser<IngTransactionDto>(options, csvMapper);

            var records = csvParser.ReadFromStream(stream, Encoding.ASCII).ToList();

            var result = records.Select(x => x.Result).ToList();

            return result;
        }
    }
}
