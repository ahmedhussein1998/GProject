using ErrorOr;
using Gproject.Application.Common.Interfaces.Persistance;
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
            var menu = Menu.Create(name: request.Name, description: request.Description, hostId: HostId.Create(request.HostId),
                                    sections: request.Sections.ConvertAll
                                        (section => MenuSection.Create(section.Name, section.Description, 
                                            section.Items.ConvertAll
                                                (items => MenuItem.Create(items.Name, items.Description))))
                                        );
            // Persist Menu
            _menurepository.Add(menu);
            // Return Menu
            return menu;
        }
    }
}
