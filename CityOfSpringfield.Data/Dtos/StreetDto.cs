using System;
using System.Collections.Generic;
using System.Text;

namespace CityOfSpringfield.Data.Dtos
{
    class StreetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Direction { get; set; }
        public bool IsOneWay { get; set; }
    }
}
