using System;
using System.Collections.Generic;

namespace Flights.Models;

public partial class Flight
{
    public int FlightId { get; set; }

    public int AirlineId { get; set; }

    public string DepartureAirport { get; set; } = null!;

    public string ArrivalAirport { get; set; } = null!;

    public DateTime DepartureTime { get; set; }

    public DateTime ArrivalTime { get; set; }

    public TimeSpan FlightDuration { get; set; }

    public virtual Airline Airline { get; set; } = null!;

    public virtual ICollection<FlightCrew> FlightCrews { get; set; } = new List<FlightCrew>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
