using GraphQL;
using GraphQL.Types;

namespace NorthwindApiSampler.Graph
{
    public class NorthwindSchema : Schema
    {
        public NorthwindSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<NorthwindQuery>();
        }

        //public NorthwindSchema(NorthwindQuery query)
        //{
        //    Query = query;
        //}
    }
}
