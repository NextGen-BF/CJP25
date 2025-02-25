using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Expenses.Get
{

    public sealed class GetPropertyTypesUseCase(IPropertyRepository _propertyRepositories)
    {
        private readonly IPropertyRepository propertyRepository = _propertyRepositories;
        public async Task<IList<Enums>> Execute()
        {
            var result = await propertyRepository.GetPropertyTypesAsync();
            return result;
        }
    }
}