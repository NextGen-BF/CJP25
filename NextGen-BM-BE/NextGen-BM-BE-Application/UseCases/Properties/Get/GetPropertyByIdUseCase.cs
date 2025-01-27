using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Expenses.Get
{

    public sealed class GetPropertiesByIdUseCase(IPropertyRepository _propertyRepositories)
    {
        private readonly IPropertyRepository propertyRepository = _propertyRepositories;
        public async Task<Property> Execute(int propertyId)
        {
            var result = await propertyRepository.GetPropertyByIdAsync(propertyId);
            return result;
        }
    }
}