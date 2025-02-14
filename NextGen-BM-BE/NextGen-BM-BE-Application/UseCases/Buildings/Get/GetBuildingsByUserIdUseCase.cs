using NextGen_BM_BE_Domain.Entities.BuildingAggregate;
using NextGen_BM_BE_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGen_BM_BE_Application.UseCases.Buildings.Get
{
    public sealed class GetBuildingsByUserIdUseCase(IBuildingRepository buildingRepository)
    {
        private readonly IBuildingRepository _buildingRepository = buildingRepository;
    
        public async Task<IList<Building>> Execute(Guid userId)
        {
            var result = await _buildingRepository.GetBuildingsByUserIdAsync(userId);
            return result;
        }
    }
}
