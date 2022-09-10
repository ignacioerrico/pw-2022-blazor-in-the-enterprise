using Microsoft.AspNetCore.Components;
using ProgrammersWeek.TalkManager.BlazorServerApp.Services;

namespace ProgrammersWeek.TalkManager.BlazorServerApp
{
    public partial class App
    {
        [Parameter]
        public TokenService HttpContextToken { get; set; } = new();

        [Inject]
        public TokenService Token { get; set; } = new();

        protected override Task OnInitializedAsync()
        {
            Token.AntiForgeryToken = HttpContextToken.AntiForgeryToken;
            Token.AccessToken = HttpContextToken.AccessToken;
            Token.RefreshToken = HttpContextToken.RefreshToken;
            Token.ExpiresAt = HttpContextToken.ExpiresAt;

            return base.OnInitializedAsync();
        }
    }
}
