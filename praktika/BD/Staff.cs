using System;
using System.Collections.Generic;

namespace praktika.BD;

public partial class Staff
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Number { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<ServiceMaintenance> ServiceMaintenances { get; set; } = new List<ServiceMaintenance>();

    public virtual ICollection<StaffLogin> StaffLogins { get; set; } = new List<StaffLogin>();
}
