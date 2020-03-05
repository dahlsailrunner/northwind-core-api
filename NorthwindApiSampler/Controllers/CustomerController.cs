using Microsoft.AspNetCore.Mvc;
using NorthwindApiSampler.DataModels;
using NorthwindApiSampler.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindApiSampler.Controllers
{
    [Route("rest/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly INorthwindRepository _repo;

        public CustomerController(INorthwindRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<List<Customer>> GetCustomers()
        {
            return await _repo.GetCustomers();
        }
    }
}