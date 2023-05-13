using System;
using System.Collections.Generic;

namespace DataBaseUniv.Models;

public partial class Task
{
    public int Id { get; set; }

    public int CourceId { get; set; }

    public string Name { get; set; } = null!;

    public string TaskContent { get; set; } = null!;

    public virtual Cource Cource { get; set; } = null!;
}
