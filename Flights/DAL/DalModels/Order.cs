using System;
using System.Collections.Generic;

namespace Flights.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int PassengerId { get; set; }

    public int FlightId { get; set; }

    public string SeatNumber { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public virtual Flight Flight { get; set; } = null!;

    public virtual Traveling Passenger { get; set; } = null!;
}
