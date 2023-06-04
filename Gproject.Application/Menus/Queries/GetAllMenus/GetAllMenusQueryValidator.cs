using FluentValidation;
using Gproject.Application.Authentication.Commands.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Application.Menus.Queries.GetAllMenus
{
    public class GetAllMenusQueryValidator : AbstractValidator<GetAllMenusQuery>
    {
        public GetAllMenusQueryValidator()
        {
           
        }
    }
}
