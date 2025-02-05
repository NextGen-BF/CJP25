using NextGen_BM_BE_Domain.Entities.PropertyAggregate;

namespace NextGen_BM_BE_Domain.Interfaces
{
    public interface IPropertyRepository
    {
        Task CreatePropertyAsync(Property property);
        Task<Property> GetPropertyByIdAsync(int propertyId);
        Task<List<Property>> GetAllPropertiesAsync();
        Task<List<Property>> GetPropertiesByUserIdAsync(int userId);
        Task<List<Property>> GetPropertiesByBuildingIdAsync(int buildingId);
        Task UpdatePropertyAsync(Property property);
        Task DeletePropertyAsync(int propertyId);
    }
}
