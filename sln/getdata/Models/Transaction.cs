using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getdata.Models
{
    public class Transaction
    {
        //[Name("Datum")]
        //public DateTime Date { get; set; }
        [Name("Naam / Omschrijving")]
        public string Description { get; set; }
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
        public string Message { get; set; }
    }
}
