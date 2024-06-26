using System;
using System.Collections.Generic;

namespace WebVRMS.Models;

public partial class Vehicle
{
    public string VehicleId { get; set; } = null!;

    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string? Year { get; set; }

    public decimal RentalPrice { get; set; }

    public bool AvailabilityStatus { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
