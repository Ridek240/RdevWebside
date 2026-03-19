using Microsoft.AspNetCore.Identity.UI.Services;

namespace Main.Areas.Identity.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Tutaj scaffold daje miejsce na implementację wysyłki maila
            // Możesz użyć SMTP, SendGrid itp.
            Console.WriteLine($"[EmailSender] To: {email}, Subject: {subject}");
            return Task.CompletedTask;
        }
    }
}
