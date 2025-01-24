using NextGen_BM_BE_Domain.Entities.BuildingAggregate;

namespace NextGen_BM_BE_Domain.Interfaces{

    public interface IBuildingRepository{
        Task<Building> GetBuildingByIdAsync(int buildingId);
        Task<List<Building>> GetAllBuildingsAsync();
        Task CreateBuildingAsync(Building building);
        Task UpdateBuildingAsync(Building building);
        Task DeleteBuildingAsync(int buildingId);
    }
}