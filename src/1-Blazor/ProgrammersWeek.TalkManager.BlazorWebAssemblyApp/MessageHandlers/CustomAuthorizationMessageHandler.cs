using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace ProgrammersWeek.TalkManager.BlazorWebAssemblyApp.MessageHandlers
{
    public class CustomAuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public CustomAuthorizationMessageHandler(IAccessTokenProvider provider,
            NavigationManager navigation,
            IConfiguration configuration)
            : base(provider, navigation)
        {
            var authorizedUrls = new [] { configuration.GetValue<string>("WebApiUrl") };
            ConfigureHandler(authorizedUrls);
        }
    }
}
