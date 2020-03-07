using GraphQL.Client.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Client.Serializer.Newtonsoft;

namespace NorthwindGraphQLClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var options = new GraphQLHttpClientOptions
            {
                UseWebSocketForQueriesAndMutations = false,
                EndPoint = new System.Uri("https://localhost:5001/graphql"),
                JsonSerializer = new NewtonsoftJsonSerializer()
            };
            var client = new GraphQLHttpClient(options);            
            var request = new GraphQLHttpRequest
            {
                Query = @"
                query northwindQuery {
                      customers {
                        customerId, 
                        companyName,
                        contactName
                      }
                }"
            };

            var response = await client.SendQueryAsync<CustomerResponse>(request);
            var x = response.Data.Customers.FirstOrDefault();
        }
    }
}
