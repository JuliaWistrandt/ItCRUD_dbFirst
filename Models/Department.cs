using System;
using System.Collections.Generic;

namespace ItAgency_bdCRUD.Models;

public partial class Department
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
