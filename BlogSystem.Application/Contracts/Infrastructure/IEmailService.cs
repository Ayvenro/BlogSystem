using BlogSystem.Application.Models.Mail;

namespace BlogSystem.Application.Contracts.Infrastructure
{
	public interface IEmailService
	{
		Task<bool> SendEmailAsync(Email email);
	}
}
