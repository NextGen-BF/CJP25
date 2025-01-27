using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Buildings.Get
{

public sealed class GetBuildingByIdUseCase(IBuildingRepository _buildingRepository)
    {
    private readonly IBuildingRepository buildingRepository = _buildingRepository;

        public async Task Execute(int buildingId){
        await buildingRepository.GetBuildingByIdAsync(buildingId);
    }
}
}