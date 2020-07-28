using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CityOfSpringfield.Data.Models;

namespace CityOfSpringfield.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinessController : ControllerBase
    {
        private static readonly string[] Names = new string[] 
        {
            "Horace Mann"
        };

        private static readonly string[] Types = new string[] 
        {
            "Insurance"
        };

        private readonly ILogger<BusinessController> _logger;

        public BusinessController(ILogger<BusinessController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Business> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Business
            {
                Name = Names[rng.Next(Names.Length)],
                BusinessType = Types[rng.Next(Types.Length)]
            })
            .ToArray();
        }
    }
}