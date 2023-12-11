using System;
using System.Collections.Generic;

namespace WpfApp1;

public partial class Phone
{
    public int PhoneId { get; set; }

    public string PhoneModel { get; set; } = null!;

    public int PhoneBrandId { get; set; }

    public decimal PhonePrice { get; set; }

    public virtual PhoneBrand PhoneBrand { get; set; } = null!;

    public virtual ICollection<SellHiistory> SellHiistories { get; set; } = new List<SellHiistory>();
}
