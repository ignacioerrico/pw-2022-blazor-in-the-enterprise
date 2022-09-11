using Duende.IdentityServer;
using Duende.IdentityServer.AspNetIdentity;
using Duende.IdentityServer.Services;
using IdentityServer.Areas.Identity.Data;
using IdentityServer.Data;
using IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using ProgrammersWeek.TalkManager.Shared.Authorization;
using ProgrammersWeek.TalkManager.Shared.Identity;
using Serilog;

namespace IdentityServer;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();

        builder.Services.AddSingleton<IEmailSender, EmailSender>();

        var connectionString = builder.Configuration.GetConnectionString("IdentityServerDbContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityServerDbContextConnection' not found.");

        builder.Services.AddDbContext<IdentityServerDbContext>(options =>
            options.UseSqlServer(connectionString));

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // **IMPORTANT**
                // This is only for demo purposes!
                // In a production environment you want to remove this!
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<IdentityServerDbContext>()
            .AddDefaultTokenProviders(); // This is about tokens to reset passwords, for example, not about tokens like access tokens

        var isBuilder = builder.Services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                // see https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/
                options.EmitStaticAudienceClaim = true;
            })
            .AddAspNetIdentity<ApplicationUser>();

        // in-memory, code config
        isBuilder.AddInMemoryIdentityResources(Config.IdentityResources);
        isBuilder.AddInMemoryApiScopes(Config.ApiScopes);
        isBuilder.AddInMemoryClients(Config.Clients);


        // if you want to use server-side sessions: https://blog.duendesoftware.com/posts/20220406_session_management/
        // then enable it
        //isBuilder.AddServerSideSessions();
        //
        // and put some authorization on the admin/management pages
        //builder.Services.AddAuthorization(options =>
        //       options.AddPolicy("admin",
        //           policy => policy.RequireClaim("sub", "1"))
        //   );
        //builder.Services.Configure<RazorPagesOptions>(options =>
        //    options.Conventions.AuthorizeFolder("/ServerSideSessions", "admin"));


        builder.Services.AddAuthentication()
            .AddGoogle(options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                // register your IdentityServer with Google at https://console.developers.google.com
                // enable the Google+ API
                // set the redirect URI to https://localhost:5001/signin-google
                options.ClientId = "copy client ID from Google here";
                options.ClientSecret = "copy client secret from Google here";
            });

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseStaticFiles();
        app.UseRouting();
        app.UseIdentityServer();
        app.UseAuthorization();

        app.MapRazorPages()
            .RequireAuthorization();

        return app;
    }

    public static async Task CreateRolesAndAdminAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        foreach (var roleName in Roles.AllRoles)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (roleExist) continue;
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }

        const string adminName = "admin@email.com";

        var poweruser = new ApplicationUser
        {
            UserName = adminName,
            Email = adminName,
        };

        // **IMPORTANT**
        // This should be at least in User Secrets - for demo purposes, you know :-)
        string userPWD = "admin";

        var dbPowerUser = await userManager.FindByEmailAsync(adminName);

        if (dbPowerUser is null)
        {
            var createPowerUser = await userManager.CreateAsync(poweruser, userPWD);
            if (createPowerUser.Succeeded)
            {
                await userManager.AddToRoleAsync(poweruser, Roles.Admin);
            }
        }
    }
}