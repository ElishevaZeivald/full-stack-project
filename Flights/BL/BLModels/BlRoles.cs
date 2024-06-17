using Flights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLModels
{
    public class BlRoles
    {
        public string MainPilot { get; set; } = null!;
        public string SecondaryPilot { get; set; } = null!;
        public string Attendant { get; set; } = null!;

    }
}
