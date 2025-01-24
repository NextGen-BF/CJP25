using Ardalis.Specification;
namespace NextGen_BM_BE_Domain.Entities.BuildingAggregate.Specifications{

    public class BuildingWithAddress: Specification<Building>{

        public BuildingWithAddress(int buildingID)
        {
            Query.Where(building => building.BuildingId == buildingID)
            .Include(building => building.BuildingAddress)
            .Include(building => building.BuildingExpenses);
        }
    }
};

