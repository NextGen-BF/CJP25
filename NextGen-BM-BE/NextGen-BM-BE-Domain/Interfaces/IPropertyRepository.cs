using NextGen_BM_BE_Domain.Entities.PropertyAggregate;

namespace NextGen_BM_BE_Domain.Interfaces{

    public interface IPropertyRepository    
    {
        Task CreateProperty(Property property);
        Task<Property> GetPropertyByID(int propertyID);
        Task<List<Property>> GetAllProperties();
        Task<List<Property>> GetPropertiesByUserID(int userID);
        Task<List<Property>> GetPropertiesByBuildingID(int buildingID);
        Task UpdateProperty(Property property);
        Task DeleteProperty(int propertyID);
    }
}