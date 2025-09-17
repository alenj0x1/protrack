using Protrack.Domain.Entities;
using Protrack.Domain.Interfaces.Repositories;
using Protrack.Infrastructure.EFCore.Context;

namespace Protrack.Infrastructure.EFCore.Repositories;

public class UserRepository(ProtrackPostgresContext context) : IUserRepository
{
    private readonly ProtrackPostgresContext _context = context;
    
    public User Create(User user)
    {
        throw new NotImplementedException();
    }

    public bool IfExistsWithEmailAddress(string emailAddress)
    {
        throw new NotImplementedException();
    }

    public bool IfExistsWithUsername(string username)
    {
        throw new NotImplementedException();
    }

    public List<User> Get(int skip, int take, string? username, string? emailAddress)
    {
        throw new NotImplementedException();
    }

    public User? Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public User? Get(string username)
    {
        throw new NotImplementedException();
    }

    public User Update(User user)
    {
        throw new NotImplementedException();
    }

    public User Delete(User user)
    {
        throw new NotImplementedException();
    }

    public Entities.User Map(User user)
    {
        return new Entities.User
        {
            UserId = user.UserId,
            Username = user.Username,
            EmailAddress = user.EmailAddress,
            Password = user.Password,
            MfaAuthenticated = user.MfaAuthenticated,
            MfaEnabled = user.MfaEnabled,
            LoginAttemps = user.LoginAttempts,
            CreatedAt = user.CreatedAt,
            CreatedBy = user.CreatedBy,
            UpdatedAt = user.UpdatedAt,
            UpdatedBy = user.UpdatedBy,
            DeletedAt = user.DeletedAt,
            DeletedBy = user.DeletedBy
        };
    }
}