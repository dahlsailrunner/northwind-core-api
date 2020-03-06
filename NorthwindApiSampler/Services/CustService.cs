using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using NorthwindApiSampler.Interfaces;
using NortwindApiSampler.Services;

namespace NorthwindApiSampler.Services
{
    public class CustService : NortwindApiSampler.Services.CustomerService.CustomerServiceBase
    {
        private readonly INorthwindRepository _repo;

        public CustService(INorthwindRepository repo)
        {
            _repo = repo;
        }

        public override async Task<CustomerResponse> GetAllCustomers(Empty request, ServerCallContext context)
        {
            var response = new CustomerResponse();
            var customers = await _repo.GetCustomers();
            response.Customers.AddRange(customers.Select(c=>
                new CustomerMessage
                {
                    CustomerId = c.CustomerId,
                    CompanyName = c.CompanyName,
                    ContactName = c.ContactName
                }));
            return response;
        }
    }
}
