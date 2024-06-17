using System;
using System.Collections.Generic;

namespace Flights.Models;

public partial class Traveling
{
    public int PassengerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string ContactInfo { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
