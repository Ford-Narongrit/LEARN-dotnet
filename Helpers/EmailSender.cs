using System.Text;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace WebApi.Helpers;

public interface IEmailSender
{
    Task SendEmailAsync(string email, string subject, string message);
}

public class EmailSender : IEmailSender
{
    private readonly UserCredential _credential;
    private readonly GmailService _gmailService;
    private readonly string? _userEmail;

    public EmailSender(IConfiguration configuration)
    {
        var token = new TokenResponse { RefreshToken = configuration["GoogleOAuth:RefreshToken"] };
        ClientSecrets secrets = new ClientSecrets()
        {
            ClientId = configuration["GoogleOAuth:ClientId"],
            ClientSecret = configuration["GoogleOAuth:ClientSecret"]
        };
        _credential = new UserCredential(new GoogleAuthorizationCodeFlow(
                    new GoogleAuthorizationCodeFlow.Initializer
                    {
                        ClientSecrets = secrets
                    }
                ), "user", token);
        _userEmail = configuration["GoogleOAuth:UserEmail"];

        _gmailService = new GmailService(new BaseClientService.Initializer
        {
            HttpClientInitializer = _credential,
            ApplicationName = configuration["GoogleOAuth:ApplicationName"]
        });
    }
    public async Task SendEmailAsync(string toEmail, string subject, string messageBody)
    {
        var mailMessage = new MimeMessage();
        mailMessage.From.Add(MailboxAddress.Parse(_userEmail));
        mailMessage.ReplyTo.Add(MailboxAddress.Parse(toEmail));
        mailMessage.To.Add(MailboxAddress.Parse(toEmail));
        mailMessage.Subject = subject;
        mailMessage.Body = new TextPart("plain")
        {
            Text = messageBody
        };

        var rawMessage = Convert.ToBase64String(Encoding.UTF8.GetBytes(mailMessage.ToString()));
        var gmailMessage = new Message { Raw = rawMessage };
        await _gmailService.Users.Messages.Send(gmailMessage, "me").ExecuteAsync();
    }
}

