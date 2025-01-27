using NextGen_BM_BE_Domain.Entities.BuildingAggregate;
using NextGen_BM_BE_Domain.Interfaces;
namespace NextGen_BM_BE_Infrastructure.Repositories{

    public class BuildingRepository : IBuildingRepository
    {
        public async Task CreateBuildingAsync(Building building)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteBuildingAsync(int buildingId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Building>> GetAllBuildingsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Building> GetBuildingByIdAsync(int buildingId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateBuildingAsync(Building building)
        {
            throw new NotImplementedException();
        }
    }
}
;