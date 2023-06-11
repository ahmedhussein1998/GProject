using ErrorOr;
using Gproject.Domain.Common.ValueObjects;
using Gproject.Application.Resources;
using MediatR;
using Microsoft.Extensions.Localization;
using Gproject.Application.Common.Interfaces.Email;

namespace Gproject.Application.Emails.Commands.SendEmail
{
    public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand, ErrorOr<string>>
    {
        private readonly IMailingService _mailService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public SendEmailCommandHandler(IMailingService mailrepository, IStringLocalizer<SharedResources> stringLocalizer)
        {
            _mailService = mailrepository;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<ErrorOr<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            try
            {

            await _mailService.SendEmailAsync(request.ToEmail,request.Subject,request.Body,request?.Attachments);  
            }
            catch (Exception ex)
            {

                return ErrorOr.Error.Failure("Authenticate Failer", ex.Message);

            }

            return _stringLocalizer[SharedResourcesKeys.EmailSendSuccess].ToString();
        }
    }
}
