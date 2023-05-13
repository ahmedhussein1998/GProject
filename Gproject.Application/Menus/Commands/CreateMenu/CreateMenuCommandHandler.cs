using ErrorOr;
using Gproject.Application.Common.Interfaces.Persistance;
using Gproject.Domain.Common.ValueObjects;
using Gproject.Domain.HostAggregate.ValueObjects;
using Gproject.Domain.MenuAggregate;
using Gproject.Domain.MenuAggregate.Entities;
using Gproject.Domain.Resources;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Gproject.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<string>>
    {
        private readonly IMenuRepository _menurepository;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public CreateMenuCommandHandler(IMenuRepository menurepository, IStringLocalizer<SharedResources> stringLocalizer)
        {
            _menurepository = menurepository;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<ErrorOr<string>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            // Create Menu
            try
            {
            var menu = Menu.Create(name: new DescriptionLocalized(request.NameAr, request.NameEn) , description: new DescriptionLocalized(request.DescriptionAr, request.DescriptionEn) ,
                                    sections: request?.Sections?.ConvertAll
                                        (section => MenuSection.Create(new DescriptionLocalized(section.NameAr, section.NameEn), new DescriptionLocalized(section.DescriptionAr, section.DescriptionEn), 
                                           section.Items.ConvertAll
                                             (items => MenuItem.Create( new DescriptionLocalized(items.DescriptionAr, items.DescriptionEn), new DescriptionLocalized(items.DescriptionAr, items.DescriptionEn) )))));

            _menurepository.Add(menu);
            }
            catch (Exception ex)
            {

                throw;
            }
            // Persist  Menu

            // Return Menu
            return _stringLocalizer[SharedResourcesKeys.CreateSuccess].ToString();
        }
    }
}
