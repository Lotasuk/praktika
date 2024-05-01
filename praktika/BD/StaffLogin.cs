using System;
using System.Collections.Generic;

namespace praktika.BD;

public partial class StaffLogin
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int IdStaff { get; set; }

    public virtual Staff IdStaffNavigation { get; set; } = null!;
}
