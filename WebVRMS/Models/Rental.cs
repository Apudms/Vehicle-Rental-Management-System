﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WebVRMS.Models;

public partial class Rental
{
    public string RentalId { get; set; }

    public DateTime RentalDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public string Status { get; set; }

    public int UserId { get; set; }

    public string VehicleId { get; set; }

    public virtual Invoice Invoice { get; set; }

    public virtual Vehicle Vehicle { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}