using System;
using System.Collections.Generic;

namespace WpfApp1;

public partial class PhoneBrand
{
    public int PhoneBrandId { get; set; }

    public string PhoneBrandName { get; set; } = null!;

    public virtual ICollection<Phone> Phones { get; set; } = new List<Phone>();
}
