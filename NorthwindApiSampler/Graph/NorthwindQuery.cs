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
                "customers",
                resolve: ctx => repo.GetCustomers()
            );
        }
    }
}
