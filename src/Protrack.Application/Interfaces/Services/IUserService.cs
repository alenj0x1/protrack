using Protrack.Application.Dtos.Request;
using Protrack.Application.Dtos.Response;
using Protrack.Application.Dtos.Response.User;

namespace Protrack.Application.Interfaces.Services;

public interface IUserService
{
    public GenericResponse<UserResponse> Create(UserCreateRequest request);
}