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
        }
    }
}
