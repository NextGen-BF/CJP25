using NextGen_BM_BE_Domain.Entities.BuildingAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Buildings.Get
{

public sealed class GetBuildingByIdUseCase(IBuildingRepository _buildingRepository)
    {
    private readonly IBuildingRepository buildingRepository = _buildingRepository;

        public async Task<Building> Execute(int buildingId){
        var result = await buildingRepository.GetBuildingByIdAsync(buildingId);
        return result;
    }
}
}