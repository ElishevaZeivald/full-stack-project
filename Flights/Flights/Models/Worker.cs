using System;
using System.Collections.Generic;

namespace Flights.Models;

public partial class Worker
{
    public int WorkerId { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string ContactInfo { get; set; } = null!;

    public DateTime DateOfEmployment { get; set; }

    public virtual ICollection<Airline> Airlines { get; set; } = new List<Airline>();
}
