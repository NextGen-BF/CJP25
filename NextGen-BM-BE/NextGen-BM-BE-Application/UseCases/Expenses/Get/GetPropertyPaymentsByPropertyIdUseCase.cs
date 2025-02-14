using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Expenses.Get
{
    public sealed class GetAllPropertyPaymentsByPropertyIdUseCase(
        IExpensesRepository _expensesRepository
    )
    {
        private readonly IExpensesRepository expensesRepository = _expensesRepository;

        public async Task<IList<PropertyPayments>> Execute(int propertyId)
        {
            var result = await expensesRepository.GetPropertyPaymentsByPropertyIdAsync(propertyId);
            return result;
        }
    }
}
