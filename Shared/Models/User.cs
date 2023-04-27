using System.ComponentModel.DataAnnotations;

namespace Shared.Models;
public class User
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Domain { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public int SecurityLevel { get; set; }
    
    [Key]
    public int Id { get; set; }
}