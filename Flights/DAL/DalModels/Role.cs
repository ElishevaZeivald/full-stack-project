using System;
using System.Collections.Generic;

namespace Flights.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string MainPilot { get; set; } = null!;

    public string SecondaryPilot { get; set; } = null!;

    public string Attendant { get; set; } = null!;

    public virtual ICollection<FlightCrew> FlightCrews { get; set; } = new List<FlightCrew>();
}
