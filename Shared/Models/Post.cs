using System.ComponentModel.DataAnnotations;
namespace Shared.Models;

public class Post
{
    
    [Key]
    public int Id { get; set; }
    public User Owner { get; private set; }
    public string Title { get; private set; }
    public string NewText { get; private set; }
    public bool IsCompleted { get; set; }

    
    public Post(User owner, string title, string newText)
    {
        Owner = owner;
        Title = title;
        NewText = newText;
    }

    private Post()
    {
    }
    
}