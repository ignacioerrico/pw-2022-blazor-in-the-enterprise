using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using ProgrammersWeek.TalkManager.BlazorUi.Components;
using ProgrammersWeek.TalkManager.BlazorUi.Interfaces;
using ProgrammersWeek.TalkManager.BlazorWebAssemblyApp;
using ProgrammersWeek.TalkManager.BlazorWebAssemblyApp.Components;
using ProgrammersWeek.TalkManager.BlazorWebAssemblyApp.MessageHandlers;
using ProgrammersWeek.TalkManager.BlazorWebAssemblyApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<LogOutButtonBase, LogOutButton>();

builder.Services.AddTransient<CustomAuthorizationMessageHandler>();

var webApiUrl = builder.Configuration.GetValue<string>("WebApiUrl");
builder.Services.AddHttpClient<ITalkClientService, TalkClientService>(service =>
    service.BaseAddress = new Uri(webApiUrl))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

builder.Services.AddMudServices();

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Local", options.ProviderOptions);
});

await builder.Build().RunAsync();
