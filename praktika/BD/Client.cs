using System;
using System.Collections.Generic;

namespace praktika.BD;

public partial class Client
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Number { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<ClientsLogin> ClientsLogins { get; set; } = new List<ClientsLogin>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ServiceMaintenance> ServiceMaintenances { get; set; } = new List<ServiceMaintenance>();
}
