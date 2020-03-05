using NorthwindApiSampler.DataModels;

namespace NorthwindApiSampler.Repositories.PgHelpers
{
    public static class CustomerSchema
    {
        public static string Table { get; } = "customers";

        public static class Columns
        {
            public static string Id { get; } = nameof(Customer.CustomerId).ToSnakeCase();
            public static string CompanyName { get; } = nameof(Customer.CompanyName).ToSnakeCase();
            public static string ContactName { get; } = nameof(Customer.ContactName).ToSnakeCase();
            public static string ContactTitle { get; } = nameof(Customer.ContactTitle).ToSnakeCase();
            public static string Address { get; } = nameof(Customer.Address).ToSnakeCase();
            public static string City { get; } = nameof(Customer.City).ToSnakeCase();
            public static string Region { get; } = nameof(Customer.Region).ToSnakeCase();
            public static string PostalCode { get; } = nameof(Customer.PostalCode).ToSnakeCase();
            public static string Country { get; } = nameof(Customer.Country).ToSnakeCase();
            public static string Phone { get; } = nameof(Customer.Phone).ToSnakeCase();
            public static string Fax { get; } = nameof(Customer.Fax).ToSnakeCase();

        }
    }
}
