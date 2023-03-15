using System;
using System.Collections.Generic;

namespace ItAgency_bdCRUD.Models;

public partial class Client
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Company { get; set; }

    public virtual ICollection<Project> Projects { get; } = new List<Project>();
}
