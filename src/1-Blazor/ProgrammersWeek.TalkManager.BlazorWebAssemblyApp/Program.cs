using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using ProgrammersWeek.TalkManager.BlazorServerApp.Services;
using ProgrammersWeek.TalkManager.BlazorUi.Components;
using ProgrammersWeek.TalkManager.BlazorUi.Interfaces;
using ProgrammersWeek.TalkManager.BlazorUi.Services;
using ProgrammersWeek.TalkManager.BlazorWebAssemblyApp;
using ProgrammersWeek.TalkManager.BlazorWebAssemblyApp.Components;
using ProgrammersWeek.TalkManager.BlazorWebAssemblyApp.MessageHandlers;
using ProgrammersWeek.TalkManager.Shared.Authorization;
using ProgrammersWeek.TalkManager.Shared.Identity;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<LogOutButtonBase, LogOutButton>();

builder.Services.AddTransient<CustomAuthorizationMessageHandler>();
builder.Services.AddScoped<ITalkClientService, TalkClientService>();

var webApiUrl = builder.Configuration.GetValue<string>("WebApiUrl");
builder.Services.AddHttpClient<ICallEndpoint, CallEndpoint>(service =>
    service.BaseAddress = new Uri(webApiUrl))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

builder.Services.AddMudServices();

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Local", options.ProviderOptions);
});

builder.Services.AddAuthorizationCore(options =>
    options.AddPolicy(CustomPolicy.Admin, policy => policy.RequireClaim("role", Roles.Admin)));

await builder.Build().RunAsync();
