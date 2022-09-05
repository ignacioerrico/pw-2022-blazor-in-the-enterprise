namespace ProgrammersWeek.TalkManager.Shared.Models;

public class InterestArea
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<Talk>? Talks { get; set; }
}