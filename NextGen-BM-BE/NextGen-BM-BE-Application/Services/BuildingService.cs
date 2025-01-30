using NextGen_BM_BE_Domain.Entities.BuildingAggregate;
using NextGen_BM_BE_Domain.Interfaces;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;


namespace NextGen_BM_BE_Application.Services;

public class BuildingService: IBuildingService
{
    private readonly IBuildingRepository buildingRepository;
    public BuildingService(IBuildingRepository _buildingRepository)
    {
        buildingRepository = _buildingRepository;
    }

    public async Task CreateBuildingAsync(Building building){
        await buildingRepository.CreateBuildingAsync(building);
    }

    public async Task DeleteBuildingAsync(int buildingId)
    {
        await buildingRepository.DeleteBuildingAsync(buildingId);
    }

    public async Task<List<Building>> GetAllBuildingsAsync(){
        return await buildingRepository.GetAllBuildingsAsync();
    }

    public async Task<Building> GetBuildingByIdAsync(int buildingId)
    {
        return await buildingRepository.GetBuildingByIdAsync(buildingId);
    }

    public async Task UpdateBuildingAsync(Building building)
    {
        await buildingRepository.UpdateBuildingAsync(building);
    }
}