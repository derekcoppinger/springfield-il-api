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
    public class TransportationController : ControllerBase
    {
        private static readonly string[] Names = new string[] 
        {
            "SMTD"
        };

        private static readonly string[] Types = new string[] 
        {
            "Bus"
        };

        private readonly ILogger<TransportationController> _logger;

        public TransportationController(ILogger<TransportationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Transportation> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Transportation
            {
                Name = Names[rng.Next(Names.Length)],
                Type = Types[rng.Next(Types.Length)]
            })
            .ToArray();
        }
    }
}