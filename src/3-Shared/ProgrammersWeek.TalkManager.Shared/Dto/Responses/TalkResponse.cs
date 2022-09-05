using ProgrammersWeek.TalkManager.Shared.Models;

namespace ProgrammersWeek.TalkManager.Shared.Dto.Responses
{
    public class TalkResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateTimeUtc { get; set; }

        public List<AuthorResponse> Authors { get; set; } = new();

        public string InterestArea { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string SessionType { get; set; }
    }
}
