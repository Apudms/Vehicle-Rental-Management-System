﻿using System;
using System.Collections.Generic;

namespace WebVRMS.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string NoTelp { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
