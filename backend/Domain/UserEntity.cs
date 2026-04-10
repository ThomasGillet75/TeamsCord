namespace Domain;

public class UserEntity
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public UserEntity(Guid id, string username, string email, string password): this(username, email, password)
    {
        Id = id;
    }    
    public UserEntity(string username, string email, string password)
    {
        Username = username.Trim();
        Email = email.Trim().ToLowerInvariant();
        Password = password;
    }
}