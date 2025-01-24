using NextGen_BM_BE_Domain.Entities.BuildingAggregate;
using NextGen_BM_BE_Domain.Interfaces;
namespace NextGen_BM_BE_Infrastructure.Repositories{

    public class BuildingRepository : IBuildingRepository
    {
        public Task CreateBuilding(Building building)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBuilding(int buildingID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Building>> GetAllBuildings()
        {
            throw new NotImplementedException();
        }

        public Task<Building> GetBuildingByID(int buildingID)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBuilding(Building building)
        {
            throw new NotImplementedException();
        }
    }
}
;