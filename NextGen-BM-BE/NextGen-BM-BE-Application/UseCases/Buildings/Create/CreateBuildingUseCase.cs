using NextGen_BM_BE_Domain.Entities.BuildingAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Buildings.Create
{
    public sealed class CreateBuildingUseCase(IBuildingRepository _buildingRepository)
    {
        private readonly IBuildingRepository buildingRepository = _buildingRepository;

        public async Task Execute(Building building)
        {
            await buildingRepository.CreateBuildingAsync(building);
        }
    }
}
