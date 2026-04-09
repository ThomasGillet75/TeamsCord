using System.Net.Mail;
using Application.DTOs.Auth.Requests;
using Domain;
using Infrastructure;

namespace Application.UseCase.Auth;

public class SignUpUseCase(
    IUserEFService userEFService,
    IPasswordHasher passwordHasher)

{
    public const int MinPasswordLength = 8;
    public async Task<(bool IsSuccess, string? Error)> ExecuteAsync(
        SignUpRequest request,
        CancellationToken cancellationToken = default)
    {
        
        
        (bool IsSuccess , string? Error) validationResult = await ValidateRequestAsync(request, cancellationToken);
        if (!validationResult.IsSuccess)
            return (false, validationResult.Error);

        string hashedPassword = passwordHasher.Hash(request.Password);

        UserEntity user = new UserEntity(
            request.Username.Trim(),
            request.Email.Trim().ToLowerInvariant(),
            hashedPassword);

        await userEFService.AddUserAsync(user, cancellationToken);

        return (true, null);
    }
    
    private async Task<(bool IsSuccess, string? Error)> ValidateRequestAsync(
        SignUpRequest request, 
        CancellationToken cancellationToken)
    {
        if (request is null) return (false, "Request is invalid.");
        if (string.IsNullOrWhiteSpace(request.Username)) return (false, "username is required.");
    
        if (string.IsNullOrWhiteSpace(request.Email) || !MailAddress.TryCreate(request.Email, out _))
            return (false, "email is invalid.");

        // Note: I fixed the > sign to < sign below
        if (string.IsNullOrWhiteSpace(request.Password) || request.Password.Length < MinPasswordLength)
            return (false, "the password should have at least " + MinPasswordLength + " characters.");

        if (await userEFService.ExistsByEmailAsync(request.Email.Trim(), cancellationToken))
            return (false, "this email is already registered.");

        return (true, null);
    }
}