using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Buildings.Get
{
    public class GetUserBuildingLinkUseCase(IBuildingRepository buildingRepository)
    {
        private readonly IBuildingRepository _buildingRepository = buildingRepository;

        public async Task<UserBuildings> Execute(int userId, int buildingId)
        {
            return await _buildingRepository.GetUserBuildingsLink(userId, buildingId);
        }
    }
}
