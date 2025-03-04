using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Expenses.Get
{

    public sealed class GetPropertyUserLinkUseCase(IPropertyRepository _propertyRepositories)
    {
        private readonly IPropertyRepository propertyRepository = _propertyRepositories;
        public async Task<PropertyUsers> Execute(int propertyId, int userId)
        {
            var result = await propertyRepository.GetPropertyUserLinkAsync(propertyId, userId);
            return result;
        }
    }
}