using ErrorOr;
using Gproject.Domain.MenuAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Application.Menus.Commands.CreateMenu
{
    public record CreateMenuCommand(
       string NameAr,
       string NameEn,
       string DescriptionAr,
       string DescriptionEn,
       Guid HostId,
       List<MenuSectionCommand> Sections):IRequest<ErrorOr<Menu>>;

    public record MenuSectionCommand(
        string NameAr,
        string NameEn,
        string DescriptionAr,
        string DescriptionEn,
        List<MenuItemCommand> Items);

    public record MenuItemCommand(
        string NameAr,
        string NameEn,
        string DescriptionAr,
        string DescriptionEn
        );
}
