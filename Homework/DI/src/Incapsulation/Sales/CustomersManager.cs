using System;
using System.Collections.Generic;
using System.Linq;

namespace Sales
{
    public class CustomersManager
    {
        private readonly Dictionary<int, Customer> customers = new Dictionary<int, Customer>();

        public void AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            customer.Id = this.customers.Count;

            this.customers.Add(customer.Id, customer);
        }

        public IEnumerable<Customer> FindCustomers(string searchPattern)
            => this.customers.Values
                .Where(c => c.FullName.IndexOf(searchPattern, StringComparison.InvariantCultureIgnoreCase) >= 0)
                .ToArray();
    }
}