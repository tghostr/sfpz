using System;
using System.Collections.Generic;

namespace WpfApp1;

public partial class Client
{
    public int ClientId { get; set; }

    public string ClientFirstName { get; set; } = null!;

    public string ClientLastName { get; set; } = null!;

    public string? CliientMiddleName { get; set; }

    public long ClientPhone { get; set; }

    public virtual ICollection<SellHiistory> SellHiistories { get; set; } = new List<SellHiistory>();
}
