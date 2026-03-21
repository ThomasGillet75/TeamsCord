namespace Domain;

public class UserEntity
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public UserEntity(Guid id, string username, string email, string password)
    {
        Id = id;
        Username = username;
        Email = email;
        Password = password;
    }    
    public UserEntity(string username, string email, string password)
    {
        Username = username;
        Email = email;
        Password = password;
    }
}