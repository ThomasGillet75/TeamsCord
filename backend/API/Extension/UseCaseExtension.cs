using Application.UseCase;

namespace API.Extension;

public static class UseCaseExtension
{
    public static IServiceCollection AddUseCase(this IServiceCollection services)
    {
        services.AddScoped<AuthUseCase>();
        services.AddScoped<SignUpUseCase>();
        services.AddScoped<SignInUseCase>();
        services.AddScoped<GetProfileUseCase>();
        return services;
    }
}