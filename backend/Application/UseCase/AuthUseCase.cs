namespace Application.UseCase;

public record AuthUseCase(
    GetProfileUseCase Get,
    CreateProfileUseCase SignUp
);