using CsvHelper.Configuration.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Expenses.Models
{
    public class Transaction
    {
        [Ignore]
        public Guid Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string IbanFrom { get; set; }
        public string IbanTo { get; set; }
        public string Code { get; set; }
        public string OnOff { get; set; }
        public double Ammount { get; set; }
        public string Kind { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }
    }
}
