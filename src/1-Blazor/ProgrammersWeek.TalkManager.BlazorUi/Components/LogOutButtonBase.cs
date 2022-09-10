using Microsoft.AspNetCore.Components;

namespace ProgrammersWeek.TalkManager.BlazorUi.Components
{
    /// <summary>
    /// The way to log out differs between Blazor Server and Blazor WebAssembly, so each
    /// model must implement its own LogOutButton component.
    /// </summary>
    public abstract class LogOutButtonBase : ComponentBase
    {
    }
}
