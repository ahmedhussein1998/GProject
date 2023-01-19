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
    public class MenuMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateMenuRequest request, string HostId), CreateMenuCommand>()
                .Map(dest => dest.HostId, src => src.HostId)
                .Map(dest => dest, src => src.request);
            config.NewConfig<Menu, MenuResponse>()
                .Map(dest => dest.Id , src => src.Id.Value)
                .Map(dest => dest.averageRating , src => src.AverageRating)
                .Map(dest => dest.HostId, src => src.HostId)
                .Map(dest=> dest.dinnerIds , src =>src.DinnerIds.Select(dinnerId => dinnerId.Value))
                .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(menuRevireId => menuRevireId.Value));

            config.NewConfig<MenuSection, MenuSectionResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);
            config.NewConfig<MenuItem, MenuItemResponse>()
               .Map(dest => dest.Id, src => src.Id.Value);
        }
    }
}
