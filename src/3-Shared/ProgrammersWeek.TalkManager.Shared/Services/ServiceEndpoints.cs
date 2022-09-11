namespace ProgrammersWeek.TalkManager.Shared.Services
{
    public static class ServiceEndpoints
    {
        public static string GetAll = "api/talk";
        public static string GetById(int id) => $"api/talk/{id}";

        public static string AttendanceRequest = "api/attendance";
        public static string GetTalkIdsForAsync(string participantId) => $"api/attendance/talk-ids/{participantId}";
    }
}
