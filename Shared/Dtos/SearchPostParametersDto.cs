namespace Shared.Dtos;

public class SearchPostParametersDto
{
    public string? UserName { get;}
    public int? UserId { get;}
    public bool? CompletedStatus { get;}
    public string? TitleContains { get;}
    public string? TextContains { get; }

    public SearchPostParametersDto(string? userName, int? userId, bool? completedStatus, string? titleContains, string? textContains)
    {
        UserName = userName;
        UserId = userId;
        CompletedStatus = completedStatus;
        TitleContains = titleContains;
        TextContains = textContains;
    }
}