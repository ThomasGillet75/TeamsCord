using Application.DTOs.Profile;
using Application.Interfaces;
using Domain;
using Infrastructure;

namespace Application.UseCase.Auth;

public class GetProfileUseCase(IUserEFService userEFService)
{
    public async Task<GetUserResponse> Execute(Guid userId)
    {
        UserEntity userEntity = userEFService.GetUserById(userId) ??
                                throw new KeyNotFoundException($"User {userId} does not exist.");
        return new GetUserResponse(userEntity.Username);
    }
}