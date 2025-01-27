using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Expenses.Get
{

    public sealed class GetPropertiesByUserIdUseCase(IPropertyRepository _propertyRepositories)
    {
        private readonly IPropertyRepository propertyRepository = _propertyRepositories;
        public async Task<IList<Property>> Execute(int userId)
        {
            var result = await propertyRepository.GetPropertiesByUserIdAsync(userId);
            return result;
        }
    }
}