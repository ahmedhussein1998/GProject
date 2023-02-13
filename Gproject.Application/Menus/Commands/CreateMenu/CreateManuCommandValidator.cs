using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Application.Menus.Commands.CreateMenu
{
    public class CreateManuCommandValidator :AbstractValidator<CreateMenuCommand>
    {
        public CreateManuCommandValidator()
        {
            RuleFor(x => x.NameAr).NotEmpty();
            RuleFor(x => x.NameEn).NotEmpty();
            RuleFor(x => x.DescriptionAr).NotEmpty();
            RuleFor(x => x.DescriptionEn).NotEmpty();
            RuleFor(x => x.Sections).NotEmpty();
        }
    }
}
