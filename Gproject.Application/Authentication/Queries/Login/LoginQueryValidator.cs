using FluentValidation;
using Gproject.Application.Authentication.Commands.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Application.Authentication.Queries.Login
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            //RuleFor(x => x.Email).EmailAddress().NotEmpty();
            RuleFor(x => x.Email).NotEmpty();//allow to login by user name or email
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
