using NextGen_BM_BE_Application.UseCases.Buildings.Create;
using NextGen_BM_BE_Application.UseCases.Buildings.Delete;
using NextGen_BM_BE_Application.UseCases.Buildings.Get;
using NextGen_BM_BE_Application.UseCases.Buildings.Update;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;

namespace NextGen_BM_BE_Application.Services
{
    public class BuildingService : IBuildingService
    {
        public async Task<Building> GetBuildingByIdAsync(int buildingId)
        {
            return await GetBuildingByIdUseCase.Execute(buildingId);
        }

        public async Task<List<Building>> GetAllBuildingsAsync()
        {
            return await GetAllBuildingsUseCase.Execute();
        }

        public async Task CreateBuildingAsync(Building building)
        {
            await CreateBuildingUseCase.Execute(building);
        }

        public async Task UpdateBuildingAsync(Building building)
        {
            await UpdateBuildingUseCase.Execute(building);
        }

        public async Task DeleteBuildingAsync(int buildingId)
        {
            await DeleteBuildingUseCase.Execute(buildingId);
        }
    }
}
