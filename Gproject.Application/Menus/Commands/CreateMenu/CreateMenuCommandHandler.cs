using ErrorOr;
using Gproject.Application.Common.Interfaces.Persistance;
using Gproject.Domain.Common.ValueObjects;
using Gproject.Domain.HostAggregate.ValueObjects;
using Gproject.Domain.MenuAggregate;
using Gproject.Domain.MenuAggregate.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
    {
        private readonly IMenuRepository _menurepository;

        public CreateMenuCommandHandler(IMenuRepository menurepository)
        {
            _menurepository = menurepository;
        }

        public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            // Create Menu
            var menu = Menu.Create(name: new DescriptionLocalized(request.NameAr, request.NameEn) , description: new DescriptionLocalized(request.DescriptionAr, request.DescriptionEn) , hostId: HostId.Create(request.HostId),
                                    sections: request.Sections.ConvertAll
                                        (section => MenuSection.Create(new DescriptionLocalized(section.NameAr, section.NameEn), new DescriptionLocalized(section.DescriptionAr, section.DescriptionEn), 
                                           section.Items.ConvertAll
                                             (items => MenuItem.Create( new DescriptionLocalized(items.DescriptionAr, items.DescriptionEn), new DescriptionLocalized(items.DescriptionAr, items.DescriptionEn) )))));
            // Persist  Menu
            _menurepository.Add(menu);
            // Return Menu
            return menu;
        }
    }
}
