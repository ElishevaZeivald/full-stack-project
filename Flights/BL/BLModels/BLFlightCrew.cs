using Flights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLModels
{
    public class BLFlightCrew
    {
        public int TeamId { get; set; }

        public int WorkerId { get; set; }

        public int RoleId { get; set; } 

        public int FlightId { get; set; }
    }
}
