using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.contracts.Menus
{
    public record CreateMenuRequest(
        string NameAr,
        string NameEn,
        string? DescriptionAR  ,
        string DescriptionEn,
        List<MenuSection>? Sections);

    public record MenuSection(
        string NameAr, 
        string NameEn, 
        string DescriptionAr,
        string DescriptionEn,
        List<MenuItem> Items);

    public record MenuItem(
        string NameAr,
        string NameEn,
        string DescriptionAr,
        string DescriptionEn
        );
}
