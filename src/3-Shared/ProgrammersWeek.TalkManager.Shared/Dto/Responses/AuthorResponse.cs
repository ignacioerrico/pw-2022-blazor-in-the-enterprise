namespace ProgrammersWeek.TalkManager.Shared.Dto.Responses;

public class AuthorResponse
{
    public string Name { get; set; } = string.Empty;
    public string? Title { get; set; }
    public string? Bio { get; set; }
    public byte[]? Picture { get; set; }
}