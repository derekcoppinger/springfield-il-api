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
    public class EventController : ControllerBase
    {
        private static readonly string[] Names = new string[] 
        {
            "LOG Festival"
        };

        private static readonly string[] Types = new string[] 
        {
            "Concert"
        };

        private static readonly DateTime[] Dates = new DateTime[] 
        {
            DateTime.Today
        };

        private readonly ILogger<EventController> _logger;

        public EventController(ILogger<EventController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Event
            {
                Name = Names[rng.Next(Names.Length)],
                Type = Types[rng.Next(Types.Length)],
                DateOfEvent = Dates[rng.Next(Dates.Length)]
            })
            .ToArray();
        }
    }
}