using Stage1.Handler;
using Stage1.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        CsvHandler csvHandler = new CsvHandler();
        HashSet<Customer> customers = csvHandler.RetrieveAllCustomers(Directory.GetCurrentDirectory() + "/latest-customers.txt");
        customers.RemoveWhere(customer => customer.Age < 40 || customer.Age > 59);
        csvHandler.WriteCustomersToTextFile(customers, "latest-customers-filtered.txt");
    }
}