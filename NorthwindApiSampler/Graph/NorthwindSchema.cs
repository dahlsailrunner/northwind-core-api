using GraphQL.Types;

namespace NorthwindApiSampler.Graph
{
    public class NorthwindSchema : Schema
    {        
        public NorthwindSchema(NorthwindQuery query)
        {
            Query = query;
        }
    }
}
