using System.Net.Mail;
using Application.DTOs.Auth.Requests;
using Domain;
using Infrastructure;

namespace Application.UseCase.Auth;

public class SignUpUseCase(IUserEFService userEfService, IPasswordService passwordService)
{
    public const int MinPasswordLength = 8;

    public async Task<(bool IsSuccess, string? Error)> ExecuteAsync(SignUpRequest request)
    {
        (bool IsSuccess, string? Error) validationResult = await ValidateRequestAsync(request);
        if (!validationResult.IsSuccess)
            return (false, validationResult.Error);
        
        string hashedPassword = passwordService.Hash(request.Password);
        UserEntity newUser = new UserEntity(request.Username, request.Email, hashedPassword);
        await userEfService.AddUserAsync(newUser);
        return (true, null);
    }

    private async Task<(bool IsSuccess, string? Error)> ValidateRequestAsync(SignUpRequest request)
    {
        if (request is null) return (false, "Request is invalid.");
        if (string.IsNullOrWhiteSpace(request.Username)) return (false, "username is required.");

        if (string.IsNullOrWhiteSpace(request.Email) || !MailAddress.TryCreate(request.Email, out _))
            return (false, "email is invalid.");

        if (string.IsNullOrWhiteSpace(request.Password) || request.Password.Length < MinPasswordLength)
            return (false, "the password should have at least " + MinPasswordLength + " characters.");

        if (await userEfService.ExistsByEmailAsync(request.Email.Trim()))
            return (false, "this email is already registered.");

        return (true, null);
    }
}