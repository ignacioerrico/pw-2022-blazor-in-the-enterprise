using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using MudBlazor.Services;
using ProgrammersWeek.TalkManager.BlazorServerApp.Components;
using ProgrammersWeek.TalkManager.BlazorServerApp.Services;
using ProgrammersWeek.TalkManager.BlazorUi.Components;
using ProgrammersWeek.TalkManager.BlazorUi.Interfaces;
using ProgrammersWeek.TalkManager.BlazorUi.Services;
using ProgrammersWeek.TalkManager.Shared.Authorization;
using ProgrammersWeek.TalkManager.Shared.Identity;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddMudServices();

builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<RefreshTokenService>();
builder.Services.AddScoped<ITalkClientService, TalkClientService>();

builder.Services.AddSingleton<LogOutButtonBase, LogOutButton>();

var webApiUrl = builder.Configuration.GetValue<string>("Urls:WebApi");
builder.Services.AddHttpClient<ICallEndpoint, CallEndpoint>(service =>
    service.BaseAddress = new Uri(webApiUrl));

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme,
        options =>
        {
            options.Authority = builder.Configuration.GetValue<string>("Urls:Authority");
            options.ClientId = "talkmanagerblazorserver";
            options.ClientSecret = "secret";
            options.ResponseType = "code";
            options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.Scope.Add("openid");
            options.Scope.Add("profile");
            options.Scope.Add("email");
            options.Scope.Add("talkmanagerapi");
            options.Scope.Add("offline_access"); // Get refresh token from Identity Server
            options.GetClaimsFromUserInfoEndpoint = true;
            options.SaveTokens = true;
            options.Scope.Add("roles");
            options.ClaimActions.MapJsonKey("role", "role", "role");
            options.TokenValidationParameters.RoleClaimType = "role";
        });

builder.Services.AddAuthorizationCore(options =>
    options.AddPolicy(CustomPolicy.Admin, policy => policy.RequireClaim("role", Roles.Admin)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
