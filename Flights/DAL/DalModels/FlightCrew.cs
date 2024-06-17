using System;
using System.Collections.Generic;

namespace Flights.Models;

public partial class FlightCrew
{
    public int TeamId { get; set; }

    public int WorkerId { get; set; }

    public int RoleId { get; set; }

    public int FlightId { get; set; }

    public virtual Flight Flight { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
