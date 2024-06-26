using System;
using System.Collections.Generic;

namespace WebVRMS.Models;

public partial class Payment
{
    public string PaymentId { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? Ipid { get; set; }

    public virtual Invoice? Ip { get; set; }
}
