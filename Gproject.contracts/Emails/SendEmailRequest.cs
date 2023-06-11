using Microsoft.AspNetCore.Http;

namespace Gproject.contracts.Menus
{
    public record SendEmailRequest(
     string ToEmail,
     string Subject,
     string Body,
    IList<IFormFile>? Attachments
);
}
