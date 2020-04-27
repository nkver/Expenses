using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using getdata.Models;

namespace getdata.Logic
{
    public class ReadCsv
    {
        public async Task<List<Transaction>> DoReadCsv()
        {
            var reader = new StreamReader("Data\\test.csv");
            var csvReader = new CsvReader(reader);
            var records = csvReader.GetRecords<Transaction>().ToList();

            foreach ( var record in records )
            {
                Console.WriteLine(record.Message);
            }

            return await Task.FromResult(records);
        }
    }
}
