namespace Application.UseCase;

public record AuthUseCase(
    GetProfileUseCase Get,
    SignInUseCase SignIn,
    SignUpUseCase SignUp
);