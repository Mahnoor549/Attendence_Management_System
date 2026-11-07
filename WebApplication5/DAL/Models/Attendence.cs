using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Attendence
{
    public int Id { get; set; }

    public int StdId { get; set; }

    public int ClassId { get; set; }

    public string Status { get; set; } = null!;

    public DateOnly Date { get; set; }

    public string Name { get; set; } = null!;

    public virtual TeacherClass Class { get; set; } = null!;

    public virtual Student Std { get; set; } = null!;
}
