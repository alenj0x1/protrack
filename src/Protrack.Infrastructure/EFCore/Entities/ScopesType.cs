using System;
using System.Collections.Generic;

namespace Protrack.Infrastructure.EFCore.Entities;

public partial class ScopesType
{
    public int ScopeTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string ShowName { get; set; } = null!;

    public virtual ICollection<Scope> Scopes { get; set; } = new List<Scope>();
}
