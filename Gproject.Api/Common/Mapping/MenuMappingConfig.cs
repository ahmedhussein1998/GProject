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
            //config.NewConfig<(CreateMenuRequest request, string HostId), CreateMenuCommand>()
            //    .Map(dest => dest.HostId, src => src.HostId)
            //    .Map(dest => dest, src => src.request);
            config.NewConfig<Menu, MenuResponse>()
                .Map(dest => dest.Name, src => src.Name.Description)
                .Map(dest => dest.Description, src => src.Description.Description);
                //.Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(menuRevireId => menuRevireId.Value));
                //.Map(dest => dest.HostId, src => src.HostId)
                //.Map(dest => dest.dinnerIds, src => src.DinnerIds.Select(dinnerId => dinnerId.Value))

            config.NewConfig<MenuSection, MenuSectionResponse>()
                 .Map(dest => dest.Name, src => src.Name.Description)
                 .Map(dest => dest.Description, src => src.Description.Description);
            config.NewConfig<MenuItem, MenuItemResponse>()
                .Map(dest => dest.Name, src => src.Name.Description)
                .Map(dest => dest.Description, src => src.Description.Description);
        }
    }
}
