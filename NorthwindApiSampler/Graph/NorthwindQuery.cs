using GraphQL.Types;
using NorthwindApiSampler.Graph.Types;
using NorthwindApiSampler.Interfaces;

namespace NorthwindApiSampler.Graph
{
    public class NorthwindQuery : ObjectGraphType
    {
        public NorthwindQuery(INorthwindRepository repo)
        {
            Field<ListGraphType<CustomerType>>(
                name: "customers",
                description: "Customers that have made orders in the past at some point.",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "customerId" }),
                resolve: _ => repo.GetCustomers()
            );
        }
    }
}
