using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLModels
{
    public class BLAirlines
    {
        public string AirlineName { get; set; }
        public string ContactInformation { get; set; }
        public string Website { get; set; }
        public virtual ICollection<BLFlights> Flights { get; set; } = new List<BLFlights>();

    }
}
