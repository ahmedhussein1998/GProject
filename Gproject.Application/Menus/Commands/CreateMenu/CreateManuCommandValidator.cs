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
            RuleFor(x => x.NameAr).NotEmpty().WithMessage("Arabic Name is required.")
                                 .MaximumLength(50)
                                .OverridePropertyName("Manu Name")
                                .Matches("^[\\u0621-\\u064A0-9 ]+$") ;

            ;
            RuleFor(x => x.NameEn).NotEmpty()
                         .MaximumLength(50)
                        .Matches("^[0-9A-Za-z ]+$");


            RuleFor(x => x.DescriptionEn).NotEmpty();
        }
    }
}
