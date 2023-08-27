using BlogSystem.Application.Contracts.Infrastructure;
using BlogSystem.Application.Models.Mail;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BlogSystem.Infrastructure.Mail
{
	public class EmailService : IEmailService
	{

		public EmailSettings EmailSettings { get; }
		public EmailService(IOptions<EmailSettings> emailSettings)
		{
			EmailSettings = emailSettings.Value;
		}
		public async Task<bool> SendEmailAsync(Email email)
		{
			var client = new SendGridClient(EmailSettings.ApiKey);
			var subject = email.Subject;
			var body = email.Body;
			var to = new EmailAddress(email.To);
			var from = new EmailAddress
			{
				Email = EmailSettings.FromAddress,
				Name = EmailSettings.FromName
			};
			var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, body, body);
			var response = await client.SendEmailAsync(sendGridMessage);
			if (response.StatusCode == System.Net.HttpStatusCode.Accepted ||
				response.StatusCode == System.Net.HttpStatusCode.OK)
			{
				return true;
			}
			return false;
		}
	}
}
