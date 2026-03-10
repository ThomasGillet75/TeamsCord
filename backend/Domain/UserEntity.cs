namespace Domain;

public class UserEntity
{
    public string Username { get; set; }
    public string Email { get; set; }

    public UserEntity(string username, string email)
    {
        Username = username;
        Email = email;
    }
}