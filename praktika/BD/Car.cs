using System;
using System.Collections.Generic;

namespace praktika.BD;

public partial class Car
{
    public int Id { get; set; }

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Color { get; set; } = null!;

    public DateOnly YearOfRelease { get; set; }

    public decimal Cost { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
