namespace Application.UseCase.Auth;

public record AuthUseCase(
    GetProfileUseCase Get,
    SignInUseCase SignIn,
    SignUpUseCase SignUp
);