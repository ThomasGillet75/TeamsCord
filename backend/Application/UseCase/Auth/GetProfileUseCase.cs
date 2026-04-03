using Application.DTOs.Profile;
using Application.Interfaces;
using Domain;
using Infrastructure;

namespace Application.UseCase.Auth;

public class GetProfileUseCase(IUserEFService userEFService)
{
    public async Task<GetUserResponse> Execute(string userId)
    {
        UserEntity userEntity = userEFService.GetUserById(Guid.Parse(userId));
        return new GetUserResponse(userEntity.Username);
    }
}