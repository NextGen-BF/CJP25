using Microsoft.Net.Http.Headers;

namespace NextGen_BM_BE_Domain.ViewModels{
    public class UserBuildingsViewModel{
        public int UserBuildingsId {get; set;}
        public int BuildingId { get; set; }
        public int UserId { get; set; }
        public int? RoleId { get; set; }
        public bool Approved { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}