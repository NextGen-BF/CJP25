using NextGen_BM_BE_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGen_BM_BE_Application.UseCases.Buildings.Delete
{
    public class DeleteUserBuildingLinkUseCase(IBuildingRepository buildingRepository)
    {
        private readonly IBuildingRepository _buildingRepository = buildingRepository;

        public async Task Execute(Guid userId, int buildingId)
        {
            await _buildingRepository.DeleteUserBuildingLinkAsync(userId, buildingId);
        }
    }
}
