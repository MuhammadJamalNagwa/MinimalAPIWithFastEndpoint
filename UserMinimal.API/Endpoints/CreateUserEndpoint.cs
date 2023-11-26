using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using UserMinimal.API.Interfaces;
using UserMinimal.API.Mapper;
using UserMinimal.API.Models;
using UserMinimal.API.Requests;
using UserMinimal.API.Responses;

namespace UserMinimal.API.Endpoints;

[HttpPost("users"), AllowAnonymous]
public class CreateUserEndpoint : Endpoint<CreateUserRequest, UserResponse>
{
    private readonly IUserRepository _userRepository;

    public CreateUserEndpoint(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public override async Task HandleAsync(CreateUserRequest req, CancellationToken ct)
    {
        User userEntity = req.ToUser();

        await _userRepository.AddAsync(userEntity);

        var userResponse = userEntity.ToUserResponse();
        await SendCreatedAtAsync<GetUserEndpoint>(
            new { Id = userEntity.Id.Value }, userResponse, generateAbsoluteUrl: true, cancellation: ct);
    }
}
