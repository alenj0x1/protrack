using System;
using System.Collections.Generic;

namespace Protrack.Infrastructure.EFCore.Entities;

public partial class UsersProfile
{
    public int UserProfileId { get; set; }

    public string? DisplayName { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public Guid? AvatarId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual FileEntity? Avatar { get; set; }
}
