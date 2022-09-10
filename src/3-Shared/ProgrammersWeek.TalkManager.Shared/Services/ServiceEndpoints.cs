namespace ProgrammersWeek.TalkManager.Shared.Services
{
    public static class ServiceEndpoints
    {
        public static string GetAll = "api/talk";
        public static string GetById(int id) => $"api/talk/{id}";
    }
}
