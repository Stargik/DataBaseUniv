using System;
using System.Collections.Generic;

namespace DataBaseUniv.Models;

public partial class Level
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Cource> Cources { get; set; } = new List<Cource>();
}
