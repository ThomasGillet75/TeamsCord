using Application.UseCase.Auth;
using Application.UseCase.Server;

namespace API.Extension;

public static class UseCaseExtension
{
    public static IServiceCollection AddUseCase(this IServiceCollection services)
    {
        services.AddScoped<AuthUseCase>();
        services.AddScoped<SignUpUseCase>();
        services.AddScoped<SignInUseCase>();
        services.AddScoped<GetProfileUseCase>();

        services.AddScoped<ServerUseCase>();
        services.AddScoped<GetServersUseCase>();
        return services;
    }
}