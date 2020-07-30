using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CityOfSpringfield.Data.Models;
using CityOfSpringfield.Data.Context;
using Microsoft.Data.Sqlite;

namespace CityOfSpringfield.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StreetController : ControllerBase
    {
        private static readonly string[] Streets = new[]
        {
            "Wabash", "Veterans", "Dirksen"
        };

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
        
        // Refactor this so the DB conntection detail is not here
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            // Documentation
            // https://docs.microsoft.com/en-us/dotnet/standard/data/sqlite/?tabs=netcore-cli

            // Street street = new Street();
            var street = "";
            using (var connection = new SqliteConnection("Data Source=../springfield-il.db"))
            {
                // var connection = SqliteConnection("Data Source=springfield-il.db");
                connection.Open();
                
                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT Name
                    FROM Street
                    WHERE id = $id
                ";
                command.Parameters.AddWithValue("$id", id);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        street = reader.GetString(0);
                    }
                    
                }
            }

            if (street == null)
            {
                return NotFound();
            }

            return Ok(street);

            
        }
    }
}
