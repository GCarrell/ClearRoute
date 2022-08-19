using CsvHelper;
using CsvHelper.Configuration;
using Stage1.Models;
using System.Globalization;

namespace Stage1.Handler
{
    public class CsvHandler
    {
        private CsvConfiguration config;
        public CsvHandler()
        {
            config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };
        }

        public HashSet<Customer> RetrieveAllCustomers(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                return csv.GetRecords<Customer>().ToHashSet();
            }
        }

        public void WriteCustomersToTextFile(HashSet<Customer> customers, string fileName)
        {
            using var writer = new StreamWriter(fileName);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<CustomerMap>();
            csv.WriteHeader<Customer>();
            csv.NextRecord();

            foreach (var customer in customers)
            {
                csv.WriteRecord(customer);
                csv.NextRecord();
            }
        }
    }
}
