using Dapper;
using NorthwindApiSampler.DataModels;
using NorthwindApiSampler.Interfaces;
using NorthwindApiSampler.Repositories.PgHelpers;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindApiSampler.Repositories
{
    public class NorthwindRepository : INorthwindRepository
    {
        private readonly IDbConnection _db;

        public NorthwindRepository(IDbConnection db)
        {
            _db = db;
        }
        public Task<Customer> GetCustomer(string customerId)
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

            return Task.FromResult(_db.QueryAsync<Customer>(sql, new { customerId }).Result.SingleOrDefault());
        }

        public Task<List<Customer>> GetCustomers()
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

            return Task.FromResult(_db.QueryAsync<Customer>(sql).Result.ToList());
        }
    }
}
