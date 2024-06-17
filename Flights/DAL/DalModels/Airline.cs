using System;
using System.Collections.Generic;

namespace Flights.Models;

public partial class Airline
{
    public int AirlineId { get; set; }

    public string AirlineName { get; set; } = null!;

    public string ContactInformation { get; set; } = null!;

    public string Website { get; set; } = null!;

    public int WorkerId { get; set; }

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();

    public virtual Workers Worker { get; set; } = null!;
}
