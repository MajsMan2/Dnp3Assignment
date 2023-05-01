using System.ComponentModel.DataAnnotations;

namespace Shared.Models;
public class User
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    
    public int Karma { get; set; }
    
    [Key]
    public int Id { get; set; }
}