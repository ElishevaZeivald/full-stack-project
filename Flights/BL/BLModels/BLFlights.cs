using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLModels
{
    public class BLFlights
    {
        public int FlightNumber { get; set; }
        public int AirlineId { get; set; }
        public string source { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime LandingTime{ get; set; }
        public TimeSpan FlightDuration { get; set; }
    }
}
