using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using UserMinimal.API.Interfaces;
using UserMinimal.API.Mapper;
using UserMinimal.API.Models;
using UserMinimal.API.Requests;
using UserMinimal.API.Responses;

namespace UserMinimal.API.Endpoints;

[HttpPut("users/{id:guid}"), AllowAnonymous]
public class UpdateUserEndpoint : Endpoint<UpdateUserRequest, UserResponse>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserEndpoint(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public override async Task HandleAsync(UpdateUserRequest req, CancellationToken ct)
    {
        User existingUser = await _userRepository.GetByIdAsync(req.Id);

        if (existingUser is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        User userEntity = req.ToUser();
        await _userRepository.UpdateAsync(userEntity);

        UserResponse customerResponse = userEntity.ToUserResponse();
        await SendOkAsync(customerResponse, ct);
    }
}
