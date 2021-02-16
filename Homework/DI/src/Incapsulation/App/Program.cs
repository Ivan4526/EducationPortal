using System;
using System.Linq;
using Sales;

namespace App
{
    internal class Program
    {
        private static void Main()
        {
            var customer = new Customer
            {
                FirstName = "John",
                LastName = "Smith"
            };

            var manager = new CustomersManager();

            manager.AddCustomer(customer);

            var found = manager.FindCustomers("s").ToArray();

            Array.ForEach(found, Console.WriteLine);
        }
    }
}
