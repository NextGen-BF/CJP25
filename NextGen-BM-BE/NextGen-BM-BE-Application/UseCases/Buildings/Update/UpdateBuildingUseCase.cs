using NextGen_BM_BE_Domain.Interfaces;
using NextGen_BM_BE_Domain.Entities.BuildingAggregate;

namespace NextGen_BM_BE_Application.UseCases.Buildings.Update
{

public sealed class UpdateBuildingUseCase(IBuildingRepository _buildingRepository)
    {
    private readonly IBuildingRepository buildingRepository = _buildingRepository;

        public async Task Execute(Building building){
        await buildingRepository.UpdateBuildingAsync(building);
    }
}
}