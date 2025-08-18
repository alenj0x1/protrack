using System;
using System.Collections.Generic;

namespace Protrack.Infrastructure.EFCore.Entities;

public partial class User
{
    public Guid UserId { get; set; }

    public string Username { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool MfaAuthenticated { get; set; }

    public bool MfaEnabled { get; set; }

    public int LoginAttemps { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid? UpdatedBy { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<FileEntity> Files { get; set; } = new List<FileEntity>();

    public virtual ICollection<User> InverseCreatedByNavigation { get; set; } = new List<User>();

    public virtual ICollection<User> InverseUpdatedByNavigation { get; set; } = new List<User>();

    public virtual User? UpdatedByNavigation { get; set; }
}
