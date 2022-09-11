using Microsoft.AspNetCore.Identity.UI.Services;

namespace IdentityServer.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // **WARNING** The email won't be sent.  This is only for demo purposes.  :-)
            return Task.CompletedTask;
        }
    }
}
