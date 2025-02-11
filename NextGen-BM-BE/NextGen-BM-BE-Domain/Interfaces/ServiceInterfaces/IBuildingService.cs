using NextGen_BM_BE_Domain.Entities.BuildingAggregate;
using NextGen_BM_BE_Domain.ViewModels;

namespace NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces
{
    public interface IBuildingService
    {
        Task<BuildingViewModel> GetBuildingByIdAsync(int buildingId);
        Task<IList<BuildingViewModel>> GetAllBuildingsAsync();
        Task<IList<BuildingViewModel>> GetBuildingsByUserIdAsync(Guid userId);
        Task CreateBuildingAsync(BuildingViewModel building);
        Task UpdateBuildingAsync(BuildingViewModel building);
        Task DeleteBuildingAsync(int buildingId);
    }
}
