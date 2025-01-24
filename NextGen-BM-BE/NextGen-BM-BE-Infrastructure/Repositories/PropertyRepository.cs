using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces;
namespace NextGen_BM_BE_Infrastructure.Repositories{

    public class PropertyRepository : IPropertyRepository
    {
        public async Task CreatePropertyAsync(Property property)
        {
            throw new NotImplementedException();
        }

        public async Task DeletePropertyAsync(int propertyId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Property>> GetAllPropertiesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Property>> GetPropertiesByBuildingIdAsync(int buildingId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Property>> GetPropertiesByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Property> GetPropertyByIdAsync(int propertyId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePropertyAsync(Property property)
        {
            throw new NotImplementedException();
        }
    }

}