using NextGen_BM_BE_Application.UseCases.Expenses.Get;
using NextGen_BM_BE_Application.UseCases.Properties.Create;
using NextGen_BM_BE_Application.UseCases.Propertys.Delete;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces;
using NextGen_BM_BE_Domain.Services;

namespace NextGen_BM_BE_Application.Services{

    public class PropertyService:IPropertyService
    {
        readonly IPropertyRepository _propertyRepository;
        readonly GetPropertiesByIdUseCase _getPropertiesByIdUseCase;
        public PropertyService(IPropertyRepository propertyRepository, GetPropertiesByIdUseCase getPropertiesByIdUseCase)
        {
            _propertyRepository=propertyRepository;
            _getPropertiesByIdUseCase=getPropertiesByIdUseCase;
        }

        public async Task CreatePropertyAsync(Property property)
        {
            var createPropertyUseCase = new CreatePropertyUseCase(_propertyRepository);
            await createPropertyUseCase.Execute(property);
        }
        public async Task DeletePropertyAsync(int propertyId)
        {
            var deletePropertyUseCase = new DeletePropertyUseCase(_propertyRepository);
            await deletePropertyUseCase.Execute(propertyId);
        }

        public async Task<IList<Property>> GetAllPropertiesAsync()
        {
            var getAllPropertiesUseCase = new GetAllPropertiesUseCase(_propertyRepository);
            return await getAllPropertiesUseCase.Execute();
        }

        public async Task UpdatePropertyAsync(Property property)
        {
            var updatePropertyUseCase = new UpdatePropertyUseCase(_propertyRepository);
            await updatePropertyUseCase.Execute(property);
        }
        public async Task<Property> GetPropertyByIdAsync(int propertyId)
        {
            return await _getPropertiesByIdUseCase.Execute(propertyId);
        }

        public Task<IList<Property>> GetPropertyByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Property>> GetPropertyByBuildingIdAsync(int buildingId)
        {
            throw new NotImplementedException();
        }
    }
}