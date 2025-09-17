using System;
using System.Collections.Generic;

namespace Protrack.Infrastructure.EFCore.Entities;

public partial class AppFile
{
    public Guid AppFileId { get; set; }

    public string Name { get; set; } = null!;

    public string RelativePath { get; set; } = null!;

    public bool IsTemporal { get; set; }

    public long Size { get; set; }

    public DateTime UploadedAt { get; set; }

    public Guid? UploadedBy { get; set; }

    public virtual User? UploadedByNavigation { get; set; }

    public virtual ICollection<UsersProfile> UsersProfiles { get; set; } = new List<UsersProfile>();
}
