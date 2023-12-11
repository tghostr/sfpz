using System;
using System.Collections.Generic;

namespace WpfApp1;

public partial class SellHiistory
{
    public int SellHiistoryId { get; set; }

    public int SellHiistoryProductId { get; set; }

    public int SellHiistorySellerId { get; set; }

    public int SellHiistoryClientId { get; set; }

    public DateTime SellHiistoryDateTime { get; set; }

    public virtual Client SellHiistoryClient { get; set; } = null!;

    public virtual Phone SellHiistoryProduct { get; set; } = null!;

    public virtual Seller SellHiistorySeller { get; set; } = null!;
}
