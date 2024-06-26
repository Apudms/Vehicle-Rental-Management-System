using System;
using System.Collections.Generic;

namespace WebVRMS.Models;

public partial class Invoice
{
    public string InvoiceId { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime InvoiceDate { get; set; }

    public string? Riid { get; set; }

    public virtual Payment? Payment { get; set; }

    public virtual Rental? Ri { get; set; }
}
