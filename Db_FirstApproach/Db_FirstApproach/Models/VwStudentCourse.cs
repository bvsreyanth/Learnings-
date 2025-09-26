using System;
using System.Collections.Generic;

namespace Db_FirstApproach.Models;

public partial class VwStudentCourse
{
    public int StudentId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int CourseId { get; set; }

    public string? CourseName { get; set; }
}
