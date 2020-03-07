using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using System;
using System.Linq;
using static NortwindApiSampler.Services.CustomerService;

namespace NorthwindGrpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new CustomerServiceClient(channel);

            var response = client.GetAllCustomers(new Empty());
            var firstCustomer = response.Customers.FirstOrDefault();
        }
    }
}
