using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Application.Authentication.Commands.ManagePermissions
{
    public class ManagePermissionsCommandValidator : AbstractValidator<ManagePermissionsCommand>
    {
        public ManagePermissionsCommandValidator()
        {

        }
    }
}
