﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WebVRMS.Models;

public partial class Invoice
{
    public string InvoiceId { get; set; }

    public decimal Amount { get; set; }

    public DateTime InvoiceDate { get; set; }

    public string Riid { get; set; }

    public virtual Payment Payment { get; set; }

    public virtual Rental Ri { get; set; }
}