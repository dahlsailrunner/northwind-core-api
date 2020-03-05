using Microsoft.AspNetCore.Mvc;
using NorthwindApiSampler.DataModels;
using NorthwindApiSampler.Interfaces;
using System.Collections.Generic;

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
        public List<Customer> GetCustomers()
        {
            return _repo.GetCustomers();
        }
    }
}