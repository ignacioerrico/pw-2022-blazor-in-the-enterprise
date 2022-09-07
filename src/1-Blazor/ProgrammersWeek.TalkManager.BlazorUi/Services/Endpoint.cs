namespace ProgrammersWeek.TalkManager.BlazorUi.Services
{
    internal static class Endpoint
    {
        public static string GetAll = "api/talk";
        public static string GetById(int id) => $"api/talk/{id}";
    }
}
