using CsvHelper.Configuration.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Expenses.Models
{
    public class Transaction
    {
        [Ignore]
        public Guid Id { get; set; }
        [Name("Datum")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Name("Naam / Omschrijving")]
        public string Name { get; set; }
        [Name("Rekening")]
        public string IbanFrom { get; set; }
        [Name("Tegenrekening")]
        public string IbanTo { get; set; }
        [Name("Code")]
        public string Code { get; set; }
        [Name("Af Bij")]
        public string OnOff { get; set; }
        [Name("Bedrag (EUR)")]
        public double Ammount { get; set; }
        [Name("MutatieSoort")]
        public string Kind { get; set; }
        [Name("Mededelingen")]
        public string Description { get; set; }

    }
}
