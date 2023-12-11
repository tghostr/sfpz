using System;
using System.Collections.Generic;

namespace WpfApp1;

public partial class Seller
{
    public int SellerId { get; set; }

    public string SellerFirstName { get; set; } = null!;

    public string SellerLastName { get; set; } = null!;

    public string? SellerMiddleName { get; set; }

    public string SellerLogin { get; set; } = null!;

    public string SellerPassword { get; set; } = null!;

    public virtual ICollection<SellHiistory> SellHiistories { get; set; } = new List<SellHiistory>();
}
