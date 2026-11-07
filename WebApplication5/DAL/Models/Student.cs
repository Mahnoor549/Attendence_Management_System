using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public long Cnic { get; set; }

    public int ClassId { get; set; }

    public virtual ICollection<Attendence> Attendences { get; set; } = new List<Attendence>();

    public virtual TeacherClass Class { get; set; } = null!;
}
