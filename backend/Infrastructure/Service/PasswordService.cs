using Application.Interfaces;
using BCrypt.Net;

namespace Infrastructure;

public class PasswordService : IPasswordService
{
    
    public const int MinPasswordLength = 8;
    public const int MaxPasswordLength = 128;
    public string Hash(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password is required.", nameof(password));
        if (password.Length > MaxPasswordLength)
            throw new ArgumentException("Password cannot be longer than " + MaxPasswordLength + " characters.", nameof(password));
        if(password.Length < MinPasswordLength)
            throw new ArgumentException("Password must be at least " + MinPasswordLength + " characters long.", nameof(password));

        return BCrypt.Net.BCrypt.EnhancedHashPassword(password, hashType: HashType.SHA384); 
    }

    public bool Verify(string password, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password is required.", nameof(password));

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("Password hash is required.", nameof(passwordHash));

        return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash, hashType: HashType.SHA384);
    }
}