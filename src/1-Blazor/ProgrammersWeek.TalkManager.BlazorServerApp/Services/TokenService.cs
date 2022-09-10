namespace ProgrammersWeek.TalkManager.BlazorServerApp.Services
{
    public class TokenService
    {
        public string? AntiForgeryToken { get; set; }

        public string? AccessToken { get; set; }

        public string? RefreshToken { get; set; }

        public DateTimeOffset ExpiresAt { get; set; }
    }
}
