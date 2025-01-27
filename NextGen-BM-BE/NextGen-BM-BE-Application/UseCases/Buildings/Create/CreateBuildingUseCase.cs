using NextGen_BM_BE_Domain.Interfaces;
using NextGen_BM_BE_Domain.Entities.BuildingAggregate;

namespace NextGen_BM_BE_Application.UseCases.Buildings.Create
{

public sealed class CreateBuildingUseCase(IBuildingRepository _buildingRepository)
    {
    private readonly IBuildingRepository buildingRepository = _buildingRepository;

        public async Task Execute(Building building){
        await buildingRepository.CreateBuildingAsync(building);
    }
}
}