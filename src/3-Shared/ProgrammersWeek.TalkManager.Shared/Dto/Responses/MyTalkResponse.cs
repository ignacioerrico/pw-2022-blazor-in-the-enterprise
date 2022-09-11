namespace ProgrammersWeek.TalkManager.Shared.Dto.Responses
{
    public class MyTalkResponse
    {
        public string Title { get; set; }
        public DateTime DateTimeUtc { get; set; }
        public List<string> Authors { get; set; }
        public string InterestArea { get; set; }
        public string Region { get; set; }
    }
}
