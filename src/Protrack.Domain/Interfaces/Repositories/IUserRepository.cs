using Protrack.Domain.Entities;

namespace Protrack.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    public User Create(User user);
    public bool IfExistsWithEmailAddress(string emailAddress);
    public bool IfExistsWithUsername(string username);
    public List<User> Get(int skip, int take, string? username, string? emailAddress);
    public User? Get(Guid id);
    public User? Get(string username);
    public User Update(User user);
    public User Delete(User user);
}