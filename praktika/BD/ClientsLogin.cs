using System;
using System.Collections.Generic;

namespace praktika.BD;

public partial class ClientsLogin
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int IdClients { get; set; }

    public virtual Client IdClientsNavigation { get; set; } = null!;
}
