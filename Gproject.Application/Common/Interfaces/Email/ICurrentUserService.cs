using Microsoft.AspNetCore.Http;

namespace Gproject.Application.Common.Interfaces.Email
{
    public interface IMailingService
{
    Task SendEmailAsync(string mailTo, string subject, string body, IList<IFormFile> attachments = null);
}

}

