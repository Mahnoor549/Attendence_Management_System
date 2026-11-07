using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public long Cnic { get; set; }

    public decimal Salary { get; set; }

    public decimal Tax { get; set; }

    public int? Password { get; set; }

    public virtual ICollection<TeacherClass> TeacherClasses { get; set; } = new List<TeacherClass>();
}
