using Microsoft.EntityFrameworkCore;
using Protrack.Infrastructure.EFCore.Entities;

namespace Protrack.Infrastructure.EFCore.Context;

public partial class ProtrackPostgresContext : DbContext
{
    public ProtrackPostgresContext(DbContextOptions<ProtrackPostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FileEntity> Files { get; set; }

    public virtual DbSet<Scope> Scopes { get; set; }

    public virtual DbSet<ScopesType> ScopesTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersProfile> UsersProfiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FileEntity>(entity =>
        {
            entity.HasKey(e => e.FileId).HasName("files_pkey");

            entity.ToTable("files");

            entity.Property(e => e.FileId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("file_id");
            entity.Property(e => e.IsTemporal)
                .HasDefaultValue(true)
                .HasColumnName("is_temporal");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Path)
                .HasMaxLength(255)
                .HasColumnName("path");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.UploadedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("uploaded_at");
            entity.Property(e => e.UploadedBy).HasColumnName("uploaded_by");

            entity.HasOne(d => d.UploadedByNavigation).WithMany(p => p.Files)
                .HasForeignKey(d => d.UploadedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("files_uploaded_by_fkey");
        });

        modelBuilder.Entity<Scope>(entity =>
        {
            entity.HasKey(e => e.ScopeId).HasName("scopes_pkey");

            entity.ToTable("scopes");

            entity.HasIndex(e => e.Name, "scopes_name_key").IsUnique();

            entity.Property(e => e.ScopeId).HasColumnName("scope_id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasDefaultValueSql("'without description'::character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.ShowName)
                .HasMaxLength(50)
                .HasColumnName("show_name");
            entity.Property(e => e.TypeId).HasColumnName("type_id");

            entity.HasOne(d => d.Type).WithMany(p => p.Scopes)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("scopes_type_id_fkey");
        });

        modelBuilder.Entity<ScopesType>(entity =>
        {
            entity.HasKey(e => e.ScopeTypeId).HasName("scopes_types_pkey");

            entity.ToTable("scopes_types");

            entity.HasIndex(e => e.Name, "scopes_types_name_key").IsUnique();

            entity.Property(e => e.ScopeTypeId).HasColumnName("scope_type_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.ShowName)
                .HasMaxLength(50)
                .HasColumnName("show_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "users_username_key").IsUnique();

            entity.Property(e => e.UserId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(255)
                .HasColumnName("email_address");
            entity.Property(e => e.LoginAttemps)
                .HasDefaultValue(5)
                .HasColumnName("login_attemps");
            entity.Property(e => e.MfaAuthenticated)
                .HasDefaultValue(false)
                .HasColumnName("mfa_authenticated");
            entity.Property(e => e.MfaEnabled)
                .HasDefaultValue(false)
                .HasColumnName("mfa_enabled");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.Username)
                .HasMaxLength(32)
                .HasColumnName("username");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InverseCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("users_created_by_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.InverseUpdatedByNavigation)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("users_updated_by_fkey");
        });

        modelBuilder.Entity<UsersProfile>(entity =>
        {
            entity.HasKey(e => e.UserProfileId).HasName("users_profiles_pkey");

            entity.ToTable("users_profiles");

            entity.Property(e => e.UserProfileId).HasColumnName("user_profile_id");
            entity.Property(e => e.AvatarId).HasColumnName("avatar_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(54)
                .HasColumnName("display_name");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Avatar).WithMany(p => p.UsersProfiles)
                .HasForeignKey(d => d.AvatarId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("users_profiles_avatar_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
