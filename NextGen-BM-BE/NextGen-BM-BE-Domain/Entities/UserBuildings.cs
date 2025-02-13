using NextGen_BM_BE_Domain.Entities.BuildingAggregate;

namespace NextGen_BM_BE_Domain.Entities
{
    public class UserBuildings
    {
        public int UserBuildingsId { get; set; }
        public int UserId { get; set; }
        public int BuildingId { get; set; }
        public bool Approved { get; set; }
        public int RoleId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public DateOnly? DeletedDate { get; set; }
        public Building? Building { get; set; }
        public required User User { get; set; }
        public Role? Role { get; set; }
    }
};
