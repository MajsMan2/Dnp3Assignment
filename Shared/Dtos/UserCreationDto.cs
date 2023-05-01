namespace Shared.Dtos;

public class UserCreationDto
{
    public string UserName { get;}
    
    public string Password { get; }
    
    public string Email { get; }
    
    public int Karma { get; }
    
    public int Id { get; }

    public UserCreationDto(string userName, string password, string email, int karma, int id)
    {
        UserName = userName;
        Password = password;
        Email = email;
        Karma = 0;
        Id = id;
    }
}