using Gproject.Domain.Common.Models;
using Gproject.Domain.Dinner.ValueObjects;
using Gproject.Domain.Host.ValueObjects;
using Gproject.Domain.Menu.Entities;
using Gproject.Domain.Menu.ValueObjects;
using Gproject.Domain.MenuReview.ValueObjects;
using System.Data;

namespace Gproject.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {

        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinner = new();
        private readonly List<MenuReviewId> _menuReviewIds =new();
        public string Name { get; }
        public string Description { get; }
        public float AverageRating { get; }
        public IReadOnlyList<MenuSection> Sections => _sections;
        public HostId HostId { get; }
        public IReadOnlyList<DinnerId> DinnerIds => _dinner;
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds;
        public DateTime CreatededDateTime { get; }
        public DateTime UpdatedDateTime { get; }
        public Menu(MenuId menuId, string name, string description, float averageRating,
            HostId hostId, DateTime creatededDateTime, DateTime updatedDateTime) : base(menuId)
        {
            Name= name; 
            Description= description;   
            AverageRating= averageRating;
            HostId= hostId;
            CreatededDateTime= creatededDateTime;                
            UpdatedDateTime= updatedDateTime;
        }
        public static Menu Create(string name, string description, float averageRating)
        {
            return new(MenuId.CreateUnique(), name, description, averageRating);
        }
    }
}
