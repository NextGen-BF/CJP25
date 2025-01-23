using NextGen_BM_BE_Domain.Entities.BuildingAggregate;

namespace NextGen_BM_BE_Domain.Interfaces{

    public interface IBuildingRepository{
        Task<Building> GetBuildingByID(int buildingID);
        Task<List<Building>> GetAllBuildings();
        Task CreateBuilding(Building building);
        Task UpdateBuilding(Building building);
        Task DeleteBuilding(int buildingID);
    }
}