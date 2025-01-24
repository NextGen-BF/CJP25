using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces;
namespace NextGen_BM_BE_Infrastructure.Repositories{

    public class PropertyRepository : IPropertyRepository
    {
        public Task CreateProperty(Property property)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProperty(int propertyID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Property>> GetAllProperties()
        {
            throw new NotImplementedException();
        }

        public Task<List<Property>> GetPropertiesByBuildingID(int buildingID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Property>> GetPropertiesByUserID(int userID)
        {
            throw new NotImplementedException();
        }

        public Task<Property> GetPropertyByID(int propertyID)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProperty(Property property)
        {
            throw new NotImplementedException();
        }
    }

}