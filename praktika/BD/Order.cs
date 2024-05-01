using System;
using System.Collections.Generic;

namespace praktika.BD;

public partial class Order
{
    public int Id { get; set; }

    public DateOnly DateOfSale { get; set; }

    public int IdCar { get; set; }

    public int IdClient { get; set; }

    public int IdStaff { get; set; }

    public bool StatusOfOrder { get; set; }

    public decimal Amount { get; set; }

    public virtual Car IdCarNavigation { get; set; } = null!;

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual Staff IdStaffNavigation { get; set; } = null!;
}
