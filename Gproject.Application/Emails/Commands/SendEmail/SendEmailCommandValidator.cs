using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Application.Emails.Commands.SendEmail
{
    public class CreateManuCommandValidator :AbstractValidator<SendEmailCommand>
    {
        public CreateManuCommandValidator()
        {
            RuleFor(x => x.ToEmail).EmailAddress().NotEmpty();
            
            RuleFor(x => x.Body).NotEmpty();


            RuleFor(x => x.Subject).NotEmpty();
        }
    }
}
