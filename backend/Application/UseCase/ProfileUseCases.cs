namespace Application.UseCase;

public record ProfileUseCases(
    GetProfileUseCase Get,
    CreateProfileUseCase Create
);