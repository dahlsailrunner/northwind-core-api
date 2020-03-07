using System.Collections.Generic;

namespace NorthwindGraphQLClient
{
    public class CustomerResponse
    {
        public List<ClientCustomer> Customers { get; set; }
    }
    public class ClientCustomer
    {
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
    }
}