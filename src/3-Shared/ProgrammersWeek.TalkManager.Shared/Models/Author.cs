namespace ProgrammersWeek.TalkManager.Shared.Models;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Title { get; set; }
    public string? Bio { get; set; }
    public byte[]? Picture { get; set; }

    public List<Talk>? Talks { get; set; }
}