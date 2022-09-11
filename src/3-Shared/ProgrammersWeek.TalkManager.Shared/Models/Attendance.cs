namespace ProgrammersWeek.TalkManager.Shared.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public string ParticipantId { get; set; }
        
        public int TalkId { get; set; }
        public Talk Talk { get; set; }
    }
}
