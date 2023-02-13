

namespace Gproject.contracts.Menus
{
    public record MenuResponse(
        string Id,
        string Name,
        string Description,
        float? averageRating,
        List<MenuSectionResponse> Sections,
        string HostId,
        List<string> dinnerIds,
        List<string> MenuReviewIds,
        DateTime createdDateTime,
        DateTime updatedDateTime
        );

    public record MenuSectionResponse(
        string Id,
        string Name,
        string Description,
        List<MenuItemResponse> Items
        );

    public record MenuItemResponse(
        string Id,
        string Name,
        string Description);
}
