namespace Shared.Dtos;

public class UserCreationDto
{
    public string UserName { get;}
    
    public string Password { get; }
    
    public string Email { get; }
    
    public int Karma { get; }

    public UserCreationDto(string userName, string password, string email, int karma)
    {
        UserName = userName;
        Password = password;
        Email = email;
        Karma = karma;
    }
}