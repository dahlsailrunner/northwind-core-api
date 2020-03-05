using Dapper;
using NorthwindApiSampler.DataModels;
using NorthwindApiSampler.Interfaces;
using NorthwindApiSampler.Repositories.PgHelpers;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NorthwindApiSampler.Repositories
{
    public class NorthwindRepository : INorthwindRepository
    {
        private readonly IDbConnection _db;

        public NorthwindRepository(IDbConnection db)
        {
            _db = db;
        }
        public Customer GetCustomer(string customerId)
        {
            var sql = $@"
                SELECT {CustomerSchema.Columns.Id},
                       {CustomerSchema.Columns.CompanyName},
                       {CustomerSchema.Columns.ContactName},
                       {CustomerSchema.Columns.ContactTitle},
                       {CustomerSchema.Columns.Address},
                       {CustomerSchema.Columns.City},
                       {CustomerSchema.Columns.Region},
                       {CustomerSchema.Columns.PostalCode},
                       {CustomerSchema.Columns.Country},
                       {CustomerSchema.Columns.Phone},
                       {CustomerSchema.Columns.Fax}
                 FROM {CustomerSchema.Table}
                 WHERE {CustomerSchema.Columns.Id} = @customerId";

            return _db.Query<Customer>(sql, new { customerId }).SingleOrDefault();
        }

        public List<Customer> GetCustomers()
        {
            var sql = $@"
                SELECT 
                       {CustomerSchema.Columns.Id},
                       {CustomerSchema.Columns.CompanyName},
                       {CustomerSchema.Columns.ContactName},
                       {CustomerSchema.Columns.ContactTitle},
                       {CustomerSchema.Columns.Address},
                       {CustomerSchema.Columns.City},
                       {CustomerSchema.Columns.Region},
                       {CustomerSchema.Columns.PostalCode},
                       {CustomerSchema.Columns.Country},
                       {CustomerSchema.Columns.Phone},
                       {CustomerSchema.Columns.Fax}
                 FROM {CustomerSchema.Table} 
                 LIMIT 1000";

            return _db.Query<Customer>(sql).ToList();
        }
    }
}
