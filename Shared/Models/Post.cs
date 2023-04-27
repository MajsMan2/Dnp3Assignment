using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Shared.Models;

public class Post
{
    
    [Key]
    public int Id { get; set; }
    
    public User Owner { get; private set; }
    public string Title { get; private set; }
    
    public string NewText { get; private set; }

    public int Karma { get; private set; }
    
    public Post(User owner, string title, string newText, int karma)
    {
        Owner = owner;
        Title = title;
        NewText = newText;
        Karma = karma;
    }

    private Post()
    {
    }
}