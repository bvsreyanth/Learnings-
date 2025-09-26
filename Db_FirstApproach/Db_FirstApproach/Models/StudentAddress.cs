using System;
using System.Collections.Generic;

namespace Db_FirstApproach.Models;

public partial class StudentAddress
{
    public int StudentId { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public virtual Student Student { get; set; } = null!;
}
