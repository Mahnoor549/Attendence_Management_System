using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class TeacherClass
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int TeacherId { get; set; }

    public virtual ICollection<Attendence> Attendences { get; set; } = new List<Attendence>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual Teacher Teacher { get; set; } = null!;
}
