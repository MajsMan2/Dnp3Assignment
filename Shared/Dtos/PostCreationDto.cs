namespace Shared.Dtos;

public class PostCreationDto
{
    public int OwnerId { get; }
    public string Title { get; }
    public string NewText { get; }

    public PostCreationDto(int ownerId, string title, string newText)
    {
        OwnerId = ownerId;
        Title = title;
        NewText = newText;
    }
}