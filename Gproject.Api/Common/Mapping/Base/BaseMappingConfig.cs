using Gproject.Application.Authentication.Commands.Register;
using Gproject.Application.Authentication.Common;
using Gproject.Application.Authentication.Queries.Login;
using Gproject.Application.Menus.Commands.CreateMenu;
using Gproject.contracts.Authentication;
using Gproject.contracts.Menus;
using Gproject.Domain.MenuAggregate;
using Mapster;
using MenuSection = Gproject.Domain.MenuAggregate.Entities.MenuSection;
using MenuItem = Gproject.Domain.MenuAggregate.Entities.MenuItem;

namespace Gproject.Api.Common.Mapping
{
    public class BaseMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateMenuRequest, CreateMenuCommand>();
                
            config.NewConfig<Menu, MenuResponse>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name.DescriptionLoc)
                .Map(dest => dest.Description, src => src.Description.DescriptionLoc);

            config.NewConfig<MenuSection, MenuSectionResponse>()
                .Map(dest => dest.Id, src => src.Id);
            config.NewConfig<MenuItem, MenuItemResponse>()
               .Map(dest => dest.Id, src => src.Id);
        }
    }
}
