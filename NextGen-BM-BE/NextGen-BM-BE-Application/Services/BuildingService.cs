using NextGen_BM_BE_Application.UseCases.Buildings.Create;
using NextGen_BM_BE_Application.UseCases.Buildings.Delete;
using NextGen_BM_BE_Application.UseCases.Buildings.Get;
using NextGen_BM_BE_Application.UseCases.Buildings.Update;
using NextGen_BM_BE_Domain.Entities.BuildingAggregate;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;

namespace NextGen_BM_BE_Application.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly GetBuildingByIdUseCase _getBuildingByIdUseCase;
        private readonly GetAllBuildingsUseCase _getAllBuildingsUseCase;
        private readonly CreateBuildingUseCase _createBuildingUseCase;

        private readonly UpdateBuildingUseCase _updateBuildingUseCase;
        private readonly DeleteBuildingUseCase _deleteBuildingUseCase;

        public BuildingService(
            GetBuildingByIdUseCase getBuildingByIdUseCase,
            GetAllBuildingsUseCase getAllBuildingsUseCase,
            CreateBuildingUseCase createBuildingUseCase,
            UpdateBuildingUseCase updateBuildingUseCase,
            DeleteBuildingUseCase deleteBuildingUseCase
        )
        {
            _getBuildingByIdUseCase = getBuildingByIdUseCase;
            _getAllBuildingsUseCase = getAllBuildingsUseCase;
            _createBuildingUseCase = createBuildingUseCase;
            _updateBuildingUseCase = updateBuildingUseCase;
            _deleteBuildingUseCase = deleteBuildingUseCase;
        }

        public async Task<Building> GetBuildingByIdAsync(int buildingId)
        {
            return await _getBuildingByIdUseCase.Execute(buildingId);
        }

        public async Task<List<Building>> GetAllBuildingsAsync()
        {
            return (List<Building>)await _getAllBuildingsUseCase.Execute();
        }

        public async Task CreateBuildingAsync(Building building)
        {
            await _createBuildingUseCase.Execute(building);
        }

        public async Task UpdateBuildingAsync(Building building)
        {
            await _updateBuildingUseCase.Execute(building);
        }

        public async Task DeleteBuildingAsync(int buildingId)
        {
            await _deleteBuildingUseCase.Execute(buildingId);
        }
    }
}
