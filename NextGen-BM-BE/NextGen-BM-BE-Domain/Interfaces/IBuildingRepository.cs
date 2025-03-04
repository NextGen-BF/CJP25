using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.BuildingAggregate;

namespace NextGen_BM_BE_Domain.Interfaces
{
    public interface IBuildingRepository
    {
        Task<Building> GetBuildingByIdAsync(int buildingId);
        Task<List<Building>> GetAllBuildingsAsync(int? page, int? pageSize);
        Task<List<Building>> GetBuildingsByUserIdAsync(int userId, int? page, int? pageSize);
        Task<Building> CreateBuildingAsync(Building building);
        Task UpdateBuildingAsync(Building building);
        Task DeleteBuildingAsync(int buildingId);
        Task DeleteUserBuildingLinkAsync(int userId, int buildingId);
        Task<UserBuildings> GetUserBuildingsLink(int userId, int buildingId);
    }
}
