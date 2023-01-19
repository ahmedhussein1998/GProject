using Gproject.Domain.Common.Models;
using Gproject.Domain.DinnerAggregate.ValueObjects;
using Gproject.Domain.HostAggregate.ValueObjects;
using Gproject.Domain.MenuAggregate.Entities;
using Gproject.Domain.MenuAggregate.ValueObjects;
using Gproject.Domain.MenuReviewAggregate.ValueObjects;
using System.Data;
using static System.Collections.Specialized.BitVector32;

namespace Gproject.Domain.MenuAggregate
{
    public sealed class Menu : AggregateRoot<MenuId>
    {

        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinner = new();
        private readonly List<MenuReviewId> _menuReviewIds =new();
        public string Name { get; private set; }
        public string Description { get; private set; }
        public AverageRating? AverageRating { get; private set; }
        public IReadOnlyList<MenuSection> Sections => _sections;
        public HostId HostId { get; private set; }
        public IReadOnlyList<DinnerId> DinnerIds => _dinner;
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds;
        public DateTime CreatededDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }
        public Menu(MenuId menuId, string name, string description,
            HostId hostId, List<MenuSection> sections, DateTime creatededDateTime, DateTime updatedDateTime) : base(menuId)
        {
            Name= name; 
            Description= description;   
            HostId= hostId;
            _sections = sections;
            CreatededDateTime = creatededDateTime;                
            UpdatedDateTime= updatedDateTime;
        }
        public static Menu Create(string name, string description, HostId hostId, List<MenuSection> sections, AverageRating averageRating)
        {
            return new(MenuId.CreateUnique(), name, description, hostId, sections??new(),averageRating.CreateNew(averageRating.value, averageRating.NumRating), DateTime.UtcNow, DateTime.UtcNow);
        }
        #pragma warning disable CS8618
        private Menu()
        {

        }
        #pragma warning restore CS8618
    }
}
