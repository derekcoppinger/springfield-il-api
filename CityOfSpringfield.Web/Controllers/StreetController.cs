using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CityOfSpringfield.Data.Models;

namespace CityOfSpringfield.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StreetController : ControllerBase
    {
        private static readonly string[] Directions = new[]
        {
            "N", "S", "E", "W", "NE", "NW", "SE", "SW"
        };

        private readonly ILogger<StreetController> _logger;

        public StreetController(ILogger<StreetController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Street> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Street
            {
                Name = "New Street!",
                Direction = Directions[rng.Next(Directions.Length)]
            })
            .ToArray();
        }
    }
}
