namespace Shared.Dtos;

public class PostBasicDto
{
    public int Id { get; }
    public string UserName { get; set; }
    public string Title { get; set; }
    public string NewText { get; set; }

    public PostBasicDto(int id, string userName, string title, string newText)
    {
        Id = id;
        UserName = userName;
        Title = title;
        NewText = newText;
    }
}