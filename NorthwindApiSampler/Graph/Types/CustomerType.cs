using GraphQL.Types;
using NorthwindApiSampler.DataModels;

namespace NorthwindApiSampler.Graph.Types
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Field(t => t.CustomerId, type:typeof(IdGraphType));
            Field(t => t.CompanyName);
            Field(t => t.ContactName);
            Field(t => t.Address);
            Field(t => t.City);
            Field(t => t.Region);
            Field(t => t.PostalCode);
            Field(t => t.Country);
            Field(t => t.Phone);
            Field(t => t.Fax);
        }
    }
}
