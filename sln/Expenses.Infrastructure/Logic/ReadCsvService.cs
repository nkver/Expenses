using TinyCsvParser;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using Expenses.Domain.Models;
using Expenses.Infrastructure.Mapping;

namespace Expenses.Infrastructure.Logic
{
    public class ReadCsvService
    {
        public async Task<List<Transaction>> DoReadCsv(Stream stream)
        {
            var options = new CsvParserOptions(true, ',');
            var csvMapper = new CsvTransactionMapping();
            var csvReader = new CsvParser<Transaction>(options, csvMapper);

            var records = await Task.FromResult(csvReader.ReadFromStream(stream, Encoding.UTF8));

            var result = records.Select(x => x.Result).ToList();

            return result;
        }
    }
}
