using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Gproject.Application.Emails.Commands.SendEmail
{
    public record SendEmailCommand(
     string ToEmail,
    string Subject,
    string Body,
    IList<IFormFile>? Attachments
        ) : IRequest<ErrorOr<string>>;



}
