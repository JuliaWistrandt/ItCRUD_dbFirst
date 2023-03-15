using System;
using System.Collections.Generic;

namespace ItAgency_bdCRUD.Models;

public partial class Tool
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? DailyCosts { get; set; }

    public int ProjectId { get; set; }

    public virtual Project Project { get; set; } = null!;
}
