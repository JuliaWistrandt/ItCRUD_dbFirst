using System;
using System.Collections.Generic;

namespace ItAgency_bdCRUD.Models;

public partial class ItAgency
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Location { get; set; }
}
