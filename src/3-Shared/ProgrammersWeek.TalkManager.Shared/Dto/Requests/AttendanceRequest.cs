namespace ProgrammersWeek.TalkManager.Shared.Dto.Requests
{
    public class AttendanceRequest
    {
        public string ParticipantId { get; set; } = string.Empty;
        public int TalkId { get; set; }
    }
}
