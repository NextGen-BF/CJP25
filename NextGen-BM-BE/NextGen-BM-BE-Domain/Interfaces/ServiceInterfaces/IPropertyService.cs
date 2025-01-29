using NextGen_BM_BE_Domain.Entities.PropertyAggregate;

namespace NextGen_BM_BE_Domain.Services{
    public interface IPropertyService
    {
        Task<IList<Property>> GetAllPropertiesAsync(); 
        Task CreatePropertyAsync(Property property); 
        Task DeletePropertyAsync(int propertyId); 
        Task UpdatePropertyAsync(Property property);
        Task<Property> GetPropertyByIdAsync(int propertyId);
        Task<IList<Property>> GetPropertyByUserIdAsync(int userId);
        Task<IList<Property>> GetPropertyByBuildingIdAsync(int buildingId);
    }
}