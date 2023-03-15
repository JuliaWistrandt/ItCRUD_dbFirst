using System;
using System.Collections.Generic;

namespace ItAgency_bdCRUD.Models;

public partial class Position
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal? Salary { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
