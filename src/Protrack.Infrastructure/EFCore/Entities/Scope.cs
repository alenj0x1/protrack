using System;
using System.Collections.Generic;

namespace Protrack.Infrastructure.EFCore.Entities;

public partial class Scope
{
    public int ScopeId { get; set; }

    public int TypeId { get; set; }

    public string Name { get; set; } = null!;

    public string ShowName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ScopesType Type { get; set; } = null!;
}
