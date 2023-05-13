using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBaseUniv.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
