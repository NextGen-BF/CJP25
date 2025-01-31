using NextGen_BM_BE_Domain.ViewModels;
using NextGen_BM_BE_Domain.Entities.BuildingAggregate;

namespace NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces{
public interface IBuildingService{

        Task<Building> GetBuildingByIdAsync(int buildingId);
        Task<List<Building>> GetAllBuildingsAsync();
        Task CreateBuildingAsync(BuildingViewModel building);
        Task UpdateBuildingAsync(BuildingViewModel building);
        Task DeleteBuildingAsync(int buildingId);
}
}