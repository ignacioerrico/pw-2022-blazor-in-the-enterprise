using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using ProgrammersWeek.TalkManager.BlazorUi;
using ProgrammersWeek.TalkManager.BlazorUi.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var webApiUrl = builder.Configuration.GetValue<string>("WebApiUrl");
builder.Services.AddHttpClient<ITalkClientService, TalkClientService>(service =>
    service.BaseAddress = new Uri(webApiUrl));

builder.Services.AddMudServices();

await builder.Build().RunAsync();
