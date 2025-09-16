using Protrack.Application.Dtos.Request;
using Protrack.Application.Dtos.Response;
using Protrack.Application.Dtos.Response.User;
using Protrack.Application.Interfaces.Services;
using Protrack.Domain.Entities;
using Protrack.Shared.Constants;

namespace Protrack.Application.Services;

public class UserService : IUserService
{
    public GenericResponse<UserResponse> Create(UserCreateRequest request)
    {
        try
        {
            var userCreate = new User.Builder()
                .WithUsername(request.Username)
                .WithEmailAddress(request.EmailAddress)
                .WithPassword("")
                .Build();

            return new GenericResponse<UserResponse>.Builder(new UserResponse
                {
                })
                .WithMessage(ResponseConstants.UserCreatedCorrectly)
                .WithStatusCode(StatusCodeConstants.Created)
                .Build();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}