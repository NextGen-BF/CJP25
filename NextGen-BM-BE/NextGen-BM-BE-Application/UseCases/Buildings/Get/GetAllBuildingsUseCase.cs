using NextGen_BM_BE_Domain.Entities.BuildingAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Buildings.Get
{

public sealed class GetAllBuildingsUseCase(IBuildingRepository _buildingRepository)
    {
    private readonly IBuildingRepository buildingRepository = _buildingRepository;

        public async Task<IList<Building>> Execute(){
        var result = await buildingRepository.GetAllBuildingsAsync();
        return result;
    }
}
}