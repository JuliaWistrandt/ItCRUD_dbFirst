using System;
using System.Collections.Generic;

namespace ItAgency_bdCRUD.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int Position { get; set; }

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Position PositionNavigation { get; set; } = null!;
}
