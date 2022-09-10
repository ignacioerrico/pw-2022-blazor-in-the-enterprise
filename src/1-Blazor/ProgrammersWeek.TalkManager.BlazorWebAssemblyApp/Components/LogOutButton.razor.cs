using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components;
using ProgrammersWeek.TalkManager.BlazorUi.Components;

namespace ProgrammersWeek.TalkManager.BlazorWebAssemblyApp.Components
{
    public partial class LogOutButton : LogOutButtonBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public SignOutSessionStateManager SignOutSessionStateManager { get; set; }

        public async Task LogOut()
        {
            await SignOutSessionStateManager.SetSignOutState();
            NavigationManager.NavigateTo("/authentication/logout");
        }
    }
}
