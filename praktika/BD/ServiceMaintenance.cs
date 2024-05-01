using System;
using System.Collections.Generic;

namespace praktika.BD;

public partial class ServiceMaintenance
{
    public int Id { get; set; }

    public DateOnly DateOfService { get; set; }

    public string TypeOfWork { get; set; } = null!;

    public int IdClient { get; set; }

    public int IdStaff { get; set; }

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual Staff IdStaffNavigation { get; set; } = null!;
}
