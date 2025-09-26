using System;
using System.Collections.Generic;

namespace Db_FirstApproach.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? StandardId { get; set; }

    public virtual Standard? Standard { get; set; }

    public virtual StudentAddress? StudentAddress { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
