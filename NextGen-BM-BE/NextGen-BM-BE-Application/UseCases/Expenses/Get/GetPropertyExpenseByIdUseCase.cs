using NextGen_BM_BE_Domain.Entities.PropertyAggregate;
using NextGen_BM_BE_Domain.Interfaces;

namespace NextGen_BM_BE_Application.UseCases.Expenses.Get
{
    public sealed class GetPropertyExpenseByIdUseCase(IExpensesRepository _expensesRepository)
    {
        private readonly IExpensesRepository expensesRepository = _expensesRepository;

        public async Task<PropertyExpense> Execute(int expenseId)
        {
            var result = await expensesRepository.GetPropertyExpenseByIdAsync(expenseId);
            return result;
        }
    }
}
