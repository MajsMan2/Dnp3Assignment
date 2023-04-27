namespace Shared.Dtos;

public class PostCreationDto
{
    public int OwnerId { get; }
    public string Title { get; }
    public string NewText { get; }
    public int Karma { get; }
    public Vote Votetype{ get; }

    public PostCreationDto(int ownerId, string title, string newText)
    {
        OwnerId = ownerId;
        Title = title;
        NewText = newText;
        Karma = 0;
    }
}

public enum Vote
{
    Upvote=1,
    DownVote=-1
}