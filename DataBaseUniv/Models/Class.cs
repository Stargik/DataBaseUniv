using System;
using System.Collections.Generic;

namespace DataBaseUniv.Models;

public partial class Class
{
    public int Id { get; set; }

    public int TeacherId { get; set; }

    public int CourceId { get; set; }

    public int Classroom { get; set; }

    public virtual Cource Cource { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
