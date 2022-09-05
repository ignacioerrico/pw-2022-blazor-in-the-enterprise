namespace ProgrammersWeek.TalkManager.Shared.Models;

public class Talk
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DateTimeUtc { get; set; }

    public List<Author>? Authors { get; set; }

    public int InterestAreaId { get; set; }
    public InterestArea? InterestArea { get; set; }

    public int RegionId { get; set; }
    public Region? Region { get; set; }

    public SessionType SessionType { get; set; } = SessionType.Online;
}