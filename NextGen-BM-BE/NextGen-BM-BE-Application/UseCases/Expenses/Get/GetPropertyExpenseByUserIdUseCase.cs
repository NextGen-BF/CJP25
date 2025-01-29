using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Expenses.Get
{
    public sealed class GetAllPropertyExpenseByUserIdUseCase(
        IExpensesRepository _expensesRepository
    )
    {
        private readonly IExpensesRepository expensesRepository = _expensesRepository;

        public async Task<IList<PropertyExpense>> Execute(int userId)
        {
            var result = await expensesRepository.GetPropertyExpenseByUserIdAsync(userId);
            return result;
        }
    }
}
