using System;
using System.Collections.Generic;

namespace WebVRMS.Models;

public partial class Rental
{
    public string RentalId { get; set; } = null!;

    public DateTime RentalDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public string Status { get; set; } = null!;

    public int UserId { get; set; }

    public string VehicleId { get; set; } = null!;

    public virtual Invoice? Invoice { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual Vehicle Vehicle { get; set; } = null!;
}
