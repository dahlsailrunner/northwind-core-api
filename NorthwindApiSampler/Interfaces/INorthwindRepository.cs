using NorthwindApiSampler.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindApiSampler.Interfaces
{
    public interface INorthwindRepository
    {
        Task<Customer> GetCustomer(string customerId);
        Task<List<Customer>> GetCustomers();       
    }
}
