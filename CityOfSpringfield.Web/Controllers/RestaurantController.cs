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
    public class RestaurantController : ControllerBase
    {
        private static readonly string[] Names = new string[] 
        {
            "Freddy's", "Culver's", "Taco Bell", "Finley's Tap House"
        };

        private static readonly string[] Genres = new string[] 
        {
            "American", "Italian", "Mexican"
        };

        private readonly ILogger<RestaurantController> _logger;

        public RestaurantController(ILogger<RestaurantController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Restaurant> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Restaurant
            {
                Name = Names[rng.Next(Names.Length)],
                Genre = Genres[rng.Next(Genres.Length)]
            })
            .ToArray();
        }
    }
}