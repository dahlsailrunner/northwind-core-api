using NorthwindApiSampler.DataModels;
using System.Collections.Generic;

namespace NorthwindApiSampler.Interfaces
{
    public interface INorthwindRepository
    {
        Customer GetCustomer(string customerId);
        List<Customer> GetCustomers();       
    }
}
